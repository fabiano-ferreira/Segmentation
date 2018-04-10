using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using BLL;
using VO;
using System.IO;

namespace UI.DadosBasicos
{
    public partial class ModeloManterModelo : System.Web.UI.Page
    {
        List<VO.Campanha> campanhaLista = new List<VO.Campanha>();
        VO.Campanha dadosCampanha = new VO.Campanha();
        BLL.CampanhaBLL oCampanha = new BLL.CampanhaBLL();
        List<VO.TipoSegmento> tipoSegmentoLista = new List<VO.TipoSegmento>();
        VO.TipoSegmento dadosTipoSegmento = new VO.TipoSegmento();
        BLL.TipoSegmentoBLL oTipoSegmento = new BLL.TipoSegmentoBLL();
        List<VO.Modelo> modeloLista = new List<VO.Modelo>();
        VO.Modelo dadosModelo = new VO.Modelo();
        BLL.ModeloBLL oModelo = new BLL.ModeloBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dadosCampanha.IDCampanha = null;
                dadosCampanha.Usuario = new Usuario()
                {
                    IDUsuario = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).IDUsuario
                };
                campanhaLista = oCampanha.ListarRelacaoUsuario(dadosCampanha);
                ddlCampanha.DataSource = campanhaLista;
                ddlCampanha.DataValueField = "IDCampanha";
                ddlCampanha.DataTextField = "Nome";
                ddlCampanha.DataBind();
                ddlCampanha.Items.Insert(0, "");
                ddlCampanha.SelectedIndex = 0;

                dadosTipoSegmento.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
                tipoSegmentoLista = oTipoSegmento.ListarLinhaNegocio(dadosTipoSegmento);
                ddlTipoSegmento.DataSource = tipoSegmentoLista;
                ddlTipoSegmento.DataValueField = "IDTipoSegmento";
                ddlTipoSegmento.DataTextField = "Nome";
                ddlTipoSegmento.DataBind();
                ddlTipoSegmento.Items.Insert(0, "");
                ddlTipoSegmento.SelectedIndex = 0;

            }
        }

        public void PreencheGrvManterModelo()
        {
            if (!string.IsNullOrEmpty(ddlCampanha.SelectedValue))
            {
                dadosModelo.Campanha = new VO.Campanha()
                {
                    IDCampanha = Convert.ToInt32(ddlCampanha.SelectedValue)
                };
                modeloLista = oModelo.CampanhaListar(dadosModelo);

                List<object> objLista = new List<object>();
                foreach (Modelo list in modeloLista)
                {
                    var obj = new
                    {
                        CodigoModelo = list.IDModelo.ToString(),
                        TipoSegmento = list.TipoSegmento.Nome,
                        Nome = list.Nome,
                        CodigoTipoSegmento = list.TipoSegmento.IDTipoSegmento,
                    };
                    objLista.Add(obj);
                }

                grvManterModelo.DataSource = objLista;
                grvManterModelo.DataBind();
            }
            else
            {
                grvManterModelo.DataSource = null;
                grvManterModelo.DataBind();
            }
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            dadosModelo.Nome = txtNome.Text;
            dadosModelo.Usuario = (VO.Usuario)HttpContext.Current.Session["UsuarioLogado"];
            dadosModelo.TipoSegmento = new TipoSegmento()
            {
                IDTipoSegmento = Convert.ToInt32(ddlTipoSegmento.SelectedValue)
            };

            if (string.IsNullOrEmpty(txtCodigModelo.Text))
            {
                oModelo.Novo(dadosModelo);

                dadosCampanha.IDCampanha = Convert.ToInt32(ddlCampanha.SelectedValue);
                dadosCampanha.Modelo = new Modelo()
                {
                    IDModelo = dadosModelo.IDModelo
                };
                oCampanha.NovoModelo(dadosCampanha);
            }
            else
            {
                dadosModelo.IDModelo = Convert.ToInt32(txtCodigModelo.Text);
                oModelo.Editar(dadosModelo);
                txtCodigModelo.Text = string.Empty;
            }
            

            ddlTipoSegmento.SelectedIndex = 0;
            txtNome.Text = string.Empty;
            PreencheGrvManterModelo();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        public void btnExcluir_Click(object sender, EventArgs e)
        {
            ImageButton btnExcluir = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnExcluir.NamingContainer;
            dadosCampanha.Modelo = new Modelo() 
            {
                IDModelo = Convert.ToInt32(grvManterModelo.DataKeys[grid.RowIndex].Value)
            };
            dadosCampanha.IDCampanha = Convert.ToInt32(ddlCampanha.SelectedValue);
            oCampanha.ModeloRemover(dadosCampanha);

            dadosModelo.IDModelo = Convert.ToInt32(grvManterModelo.DataKeys[grid.RowIndex].Value);
            oModelo.Remover(dadosModelo);

            PreencheGrvManterModelo();
        }

        protected void ddlCampanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencheGrvManterModelo();
        }

        public void btnEditar_Click(object sender, EventArgs e)
        {
            ImageButton btnEditar = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnEditar.NamingContainer;

            txtCodigModelo.Text = grvManterModelo.DataKeys[grid.RowIndex].Values[0].ToString();
            ddlTipoSegmento.SelectedValue = grvManterModelo.DataKeys[grid.RowIndex].Values[1].ToString();
            txtNome.Text = grvManterModelo.DataKeys[grid.RowIndex].Values[2].ToString();
        }
    }
}