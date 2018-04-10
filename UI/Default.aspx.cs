using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;
using BLL;

namespace UI
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            string strScript = "";
            Usuario dadosUsuario = new Usuario();
            UsuarioBLL oUsuario = new UsuarioBLL();
            dadosUsuario.NomeUsuario = txtUsuario.Text;
            dadosUsuario.Senha = oUsuario.getMd5Hash(txtSenha.Text);

            dadosUsuario = oUsuario.Validar(dadosUsuario);

            if (string.IsNullOrEmpty(dadosUsuario.IDUsuario.ToString()))
            {
                strScript = "javascript:alert('Usuário ou senha inválido');";
            }
            else if (dadosUsuario.TipoStatusUsuario.IdTipoStatusUsuario == 2)
            {
                strScript = "javascript:alert('Usuário Inativo');";
            }
            else if (dadosUsuario.MudarSenha == true)
            {
                mdlCadastro.Show();
                HttpContext.Current.Session["UsuarioLogado"] = dadosUsuario;
            }
            else
            {
                HttpContext.Current.Session["UsuarioLogado"] = dadosUsuario;
                strScript = "start();";
            }

            ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), strScript, true);
        }


        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            Usuario dadosUsuario = new Usuario();
            UsuarioBLL oUsuario = new UsuarioBLL();
            dadosUsuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
            dadosUsuario.TipoStatusUsuario = new TipoStatusUsuario();
            dadosUsuario.Senha =  oUsuario.getMd5Hash(txtConfirmarSenha.Text);
            dadosUsuario.MudarSenha = false;

            oUsuario.Editar(dadosUsuario);
            txtNovaSenha.Text = string.Empty;
            txtConfirmarSenha.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtSenha.Text = string.Empty;

            ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "start();", true);
        }

        protected void lkbCalcelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtSenha.Text = string.Empty;
            mdlCadastro.Hide();
        }
    }
}
