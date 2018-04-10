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
using VO;
using BLL;

namespace UI.DadosBasicos
{
    public partial class TipoSegmentoMercado : System.Web.UI.Page
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
            TipoSegmento dadosTipoSegmento = new TipoSegmento();
            TipoSegmentoBLL oTipoSegmento = new TipoSegmentoBLL();

            dadosTipoSegmento.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

            grvTipoSegmento.DataSource = oTipoSegmento.ListarLinhaNegocio(dadosTipoSegmento);
            grvTipoSegmento.DataBind();

        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            TipoSegmento dadosTipoSegmento = new TipoSegmento();
            TipoSegmentoBLL oTipoSegmento = new TipoSegmentoBLL();
            
            dadosTipoSegmento.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            dadosTipoSegmento.Nome = txtNome.Text;
            dadosTipoSegmento.Usuario = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]);

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                oTipoSegmento.Novo(dadosTipoSegmento);
            }
            else
            {
                dadosTipoSegmento.IDTipoSegmento = Convert.ToInt32(txtCodigo.Text);
                oTipoSegmento.Editar(dadosTipoSegmento);
            }

            Inicializar();
            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
        }

        protected void Edit_Click(object sender, ImageClickEventArgs e)
        {
            var button = sender as ImageButton;
            var row = button.NamingContainer as GridViewRow;

            txtNome.Text = grvTipoSegmento.DataKeys[row.RowIndex].Values[1].ToString();
            txtCodigo.Text = grvTipoSegmento.DataKeys[row.RowIndex].Values[0].ToString();
        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            var button = sender as ImageButton;
            var row = button.NamingContainer as GridViewRow;
            TipoSegmento dadosTipoSegmento = new TipoSegmento();
            TipoSegmentoBLL oTipoSegmento = new TipoSegmentoBLL();

            dadosTipoSegmento.IDTipoSegmento = Convert.ToInt32(grvTipoSegmento.DataKeys[row.RowIndex].Value);

            try
            {
                oTipoSegmento.Remover(dadosTipoSegmento);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:alert('Impossível excluir este Tipo de Segmento, \\nja existe relação para ele no sistema de Segmentação.');", true);
            }

            this.Inicializar();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }
    }
}
