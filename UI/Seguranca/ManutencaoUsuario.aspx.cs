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
    public partial class ManutencaoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Inicializar();
            }
        }

        protected void Inicializar()
        {
            Usuario dadosUsuario = new Usuario();
            dadosUsuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];

	        

            //carrega dropdownlist com status de usuário
            ddlStatus.DataSource = new TipoStatusUsuarioBLL().Listar();
            ddlStatus.DataBind();
            //carrega gridview com todos usuario criadas
            grvManutencaoUsuarios.DataSource = new LinhaNegocioBLL().ListarUsuario(dadosUsuario.LinhaNegocio);
            grvManutencaoUsuarios.DataBind();
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario();
            usuario.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

            usuario.DataCriacao = DateTime.Now;
            usuario.DataModificacao = DateTime.Now;
            usuario.Email = txtEmail.Text;
            usuario.MudarSenha = ckbAlterarSenha.Checked;
            usuario.Nome = txtNome.Text;
            usuario.NomeUsuario = txtLogin.Text;
            usuario.Senha = new UsuarioBLL().getMd5Hash(txtSenha.Text);
            usuario.TipoStatusUsuario = new TipoStatusUsuario() { IdTipoStatusUsuario = Convert.ToInt32(ddlStatus.SelectedValue) };
            usuario.LogUsuario = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).NomeUsuario;

            if (String.IsNullOrEmpty(lblId.Text))
            {
                new UsuarioBLL().Novo(usuario);
                usuario.LinhaNegocio.Usuario = usuario;
                new LinhaNegocioBLL().NovoUsuario(usuario.LinhaNegocio);
            }
            else
            {
                usuario.IDUsuario = Convert.ToInt32(lblId.Text);
                new UsuarioBLL().Editar(usuario);
            }

            this.Inicializar();
            this.LimparCampos();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            var button = sender as ImageButton;
            var row = button.NamingContainer as GridViewRow;

            var id = grvManutencaoUsuarios.DataKeys[row.RowIndex].Value;

            var usuario = new UsuarioBLL().Listar(new Usuario() { IDUsuario = Convert.ToInt32(id) });

            txtEmail.Text = usuario.Email;
            txtLogin.Text = usuario.NomeUsuario;
            txtNome.Text = usuario.Nome;
            ddlStatus.SelectedValue = usuario.TipoStatusUsuario.IdTipoStatusUsuario.ToString();
            ckbAlterarSenha.Checked = usuario.MudarSenha;
            lblId.Text = usuario.IDUsuario.ToString();
        }

        protected void LimparCampos()
        {
            txtConfirmarSenha.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtLogin.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtSenha.Text = String.Empty;
            lblId.Text = String.Empty;
            ckbAlterarSenha.Checked = false;
            
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                this.LimparCampos();
            }
            else
            {
                Response.Redirect("../Index.aspx");
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            var button = sender as ImageButton;
            var row = button.NamingContainer as GridViewRow;
            LinhaNegocio dadosLinhaNegocio = new LinhaNegocio();

            var id = grvManutencaoUsuarios.DataKeys[row.RowIndex].Value;

            var bizUsuario = new UsuarioBLL();

            var usuario = bizUsuario.Listar(new Usuario() { IDUsuario = Convert.ToInt32(id) });
            dadosLinhaNegocio.Usuario = usuario;
            
            try
            {
                usuario.LinhaNegocio = new LinhaNegocio();
                bizUsuario.Remover(usuario);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:alert('Impossível excluir este usuário, \\nja existe relação para ele no sistema de Segmentação,  \\npara Inabilitar seu acesso, \\nmude seu status para Inativo');", true);
            }
                       
            this.Inicializar();
        }
    }
}