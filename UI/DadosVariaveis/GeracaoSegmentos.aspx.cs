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

namespace UI.DadosVariaveis
{
    public partial class GeracaoSegmentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var bizCampanha = new BLL.CampanhaBLL();
                ddlCampanha.DataSource = bizCampanha.Listar();
                ddlCampanha.DataValueField = "IdCampanha";
                ddlCampanha.DataTextField = "Nome";
                ddlCampanha.DataBind();
                ddlCampanha.Items.Insert(0, "");
                ddlCampanha.SelectedIndex = 0;

                PreencheGrid();
            }
        }

        public void PreencheGrid()
        {
            if (!string.IsNullOrEmpty(ddlModelo.SelectedValue))
            {
                var segmento = new VO.Segmento();
                var bizSegmento = new BLL.SegmentoBLL();

                segmento.IDSegmento = null;
                segmento.Modelo = new VO.Modelo()
                {
                    IDModelo = Convert.ToInt32(ddlModelo.SelectedValue)
                };
                
                segmento = bizSegmento.Listar(segmento);

                grvGeracaoSegmentos.DataSource = segmento.SegmentoLista;
                grvGeracaoSegmentos.DataBind();
            }
        }

        protected void ddlCampanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCampanha.SelectedValue))
            {
                var modelo = new VO.Modelo();
                var modeloList = new List<VO.Modelo>();
                var bizModelo = new BLL.ModeloBLL();

                modelo.Campanha = new VO.Campanha()
                {
                    IDCampanha = Convert.ToInt32(ddlCampanha.SelectedValue)
                };

                modeloList = bizModelo.CampanhaListar(modelo);
                ddlModelo.DataSource = modeloList;
                ddlModelo.DataTextField = "Nome";
                ddlModelo.DataValueField = "IdModelo";
                ddlModelo.DataBind();
                ddlModelo.Items.Insert(0, "");
                ddlModelo.SelectedIndex = 0;
            }
            else
            {
                ddlModelo.SelectedIndex = 0;
                grvGeracaoSegmentos.DataSource = null;
                grvGeracaoSegmentos.DataBind();
            }
        }

        protected void ddlModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlModelo.SelectedValue))
            {
                PreencheGrid();
            }
            else
            {
                grvGeracaoSegmentos.DataSource = null;
                grvGeracaoSegmentos.DataBind();
            }
        }

        protected void lkbGerarSegmentos_Click(object sender, EventArgs e)
        {
            var modelo = new VO.Modelo();
            var bizSegmento = new BLL.SegmentoBLL();

            modelo.IDModelo = Convert.ToInt32(ddlModelo.SelectedValue);
            modelo.Usuario = ((VO.Usuario)HttpContext.Current.Session["UsuarioLogado"]);
            
            try
            {
                bizSegmento.GerarCodigoSegmento(modelo);
            }
            catch (BLL.Exceptions.RegraLogicaInvalida ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "alert('"+ ex.Message +"');", true);
            }
            
            PreencheGrid();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }
    }
}