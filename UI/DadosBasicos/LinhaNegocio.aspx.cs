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
    public partial class LinhaNegocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Inicializar();
            }
        }

        private void Inicializar()
        {
            List<VO.LinhaNegocio> dadosLinhaNegocioLista = new List<VO.LinhaNegocio>();
            LinhaNegocioBLL oLinhaNegocio = new LinhaNegocioBLL();

            dadosLinhaNegocioLista = oLinhaNegocio.Listar();
            grvManutencaoPerfil.DataSource = dadosLinhaNegocioLista;
            grvManutencaoPerfil.DataBind();
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            VO.LinhaNegocio dadosLinhaNegocio = new VO.LinhaNegocio();
            LinhaNegocioBLL oLinhaNegocio = new LinhaNegocioBLL();
            dadosLinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            dadosLinhaNegocio.Usuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                dadosLinhaNegocio.Nome = txtNome.Text;
                dadosLinhaNegocio.RazaoSocial = txtRazaoSocial.Text;
                dadosLinhaNegocio.CNPJ = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "");

                oLinhaNegocio.Novo(dadosLinhaNegocio);
            }
            else
            {
                dadosLinhaNegocio.IDLinhaNegocio = Convert.ToInt32(txtCodigo.Text);
                dadosLinhaNegocio.Nome = txtNome.Text;
                dadosLinhaNegocio.RazaoSocial = txtRazaoSocial.Text;
                dadosLinhaNegocio.CNPJ = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "");

                oLinhaNegocio.Editar(dadosLinhaNegocio);
            }

            txtCNPJ.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtRazaoSocial.Text = string.Empty;

            Inicializar();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton btnEdit = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnEdit.NamingContainer;
            txtCodigo.Text = grvManutencaoPerfil.DataKeys[grid.RowIndex].Values[0].ToString();
            txtNome.Text = grvManutencaoPerfil.DataKeys[grid.RowIndex].Values[1].ToString();
            txtRazaoSocial.Text = grvManutencaoPerfil.DataKeys[grid.RowIndex].Values[2].ToString();
            txtCNPJ.Text = grvManutencaoPerfil.DataKeys[grid.RowIndex].Values[3].ToString();
        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            VO.LinhaNegocio dadosLinhaNegocio = new VO.LinhaNegocio();
            LinhaNegocioBLL oLinhaNegocio = new LinhaNegocioBLL();

            ImageButton btnExcluir = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnExcluir.NamingContainer;
            dadosLinhaNegocio.IDLinhaNegocio = Convert.ToInt32(grvManutencaoPerfil.DataKeys[grid.RowIndex].Value);
            
            try
            {
                oLinhaNegocio.Remover(dadosLinhaNegocio);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:alert('Impossível excluir esta Linha de Negocio, \\nja existe relação para ela no sistema de Segmentação.');", true);
            }
            Inicializar();
        }
    }
}
