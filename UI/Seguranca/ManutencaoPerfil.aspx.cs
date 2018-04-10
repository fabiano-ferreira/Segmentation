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

namespace UI.Seguranca
{
    public partial class ManutencaoPerfil1 : System.Web.UI.Page
    {
        Perfil dadosPerfil = new Perfil();
        List<Perfil> perfilLista = new List<Perfil>();
        PerfilBLL oPerfil = new PerfilBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencheGrvManutencaoPerfil();
            }
        }

        public void PreencheGrvManutencaoPerfil()
        {
            perfilLista = oPerfil.Listar();
            grvManutencaoPerfil.DataSource = perfilLista;
            grvManutencaoPerfil.DataBind();
        }

        public void lkbSalvar_Click(object sender, EventArgs e)
        {
            dadosPerfil.Nome = txtNome.Text;
            dadosPerfil.Usuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];

            if (string.IsNullOrEmpty(txtIdPerfil.Text))
            {
                oPerfil.Novo(dadosPerfil);
            }
            else
            {
                dadosPerfil.IDPerfil = Convert.ToInt32(txtIdPerfil.Text);
                oPerfil.Editar(dadosPerfil);
            }
            
            PreencheGrvManutencaoPerfil();
            txtNome.Text = string.Empty;
            txtIdPerfil.Text = string.Empty;
        }

        public void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        public void btnExcluir_Click(object sender, EventArgs e)
        {
            ImageButton btnExcluir = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnExcluir.NamingContainer;
            dadosPerfil.IDPerfil = Convert.ToInt32(grvManutencaoPerfil.DataKeys[grid.RowIndex].Value);

            oPerfil.Remover(dadosPerfil);
            PreencheGrvManutencaoPerfil();
        }
         
        public void btnEditar_Click(object sender, EventArgs e)
        {
            ImageButton btnEditar = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnEditar.NamingContainer;
            txtIdPerfil.Text = grvManutencaoPerfil.DataKeys[grid.RowIndex].Values[0].ToString();
            txtNome.Text = grvManutencaoPerfil.DataKeys[grid.RowIndex].Values[1].ToString();
        }
    }
}
