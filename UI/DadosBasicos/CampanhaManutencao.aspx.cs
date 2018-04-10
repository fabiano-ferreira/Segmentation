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


namespace UI.DadosBasicos
{
    public partial class Campanha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Inicializar();
            }
        }

        public void Inicializar()
        {
            List<VO.Campanha> dadosCampanhaLista = new List<VO.Campanha>();
            CampanhaBLL oCampanha = new CampanhaBLL();

            //Retorna Lista de Campanhas
            dadosCampanhaLista = oCampanha.Listar();

            //Popula o DataSource
            grvCampanha.DataSource = dadosCampanhaLista;
            grvCampanha.DataBind();
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            CampanhaBLL oCampanha = new CampanhaBLL();
            VO.Campanha dadosCampanha = new VO.Campanha();

            dadosCampanha.Nome = txtNome.Text;
            //absorve os dados do usuario logado
            dadosCampanha.Usuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                //Insere nova campanha
                oCampanha.Novo(dadosCampanha);
            }
            else
            {
                dadosCampanha.IDCampanha = Convert.ToInt32(txtCodigo.Text);
                oCampanha.Editar(dadosCampanha);
            }

            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
            //Atualiza o GridView
            Inicializar();
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            VO.Campanha dadosCampanha = new VO.Campanha();
            CampanhaBLL oCampanha = new CampanhaBLL();

            ImageButton btnEdit = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnEdit.NamingContainer;
            txtCodigo.Text = grvCampanha.DataKeys[grid.RowIndex].Values[0].ToString();
            txtNome.Text = grvCampanha.DataKeys[grid.RowIndex].Values[1].ToString();
        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            VO.Campanha dadosCampanha = new VO.Campanha();
            CampanhaBLL oCampanha = new CampanhaBLL();

            ImageButton btnExcluir = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnExcluir.NamingContainer;
            dadosCampanha.IDCampanha = Convert.ToInt32(grvCampanha.DataKeys[grid.RowIndex].Value);


            try
            {
                oCampanha.Remover(dadosCampanha);

                Inicializar();
            }
            catch (Exception)
            {
                //Esta Campanha já está relacionada a algum dado no Sistema de Segmentação, favor verifique.
                throw;
            }            
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }
    }
}