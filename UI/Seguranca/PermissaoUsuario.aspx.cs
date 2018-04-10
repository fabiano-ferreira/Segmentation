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
using VO;
using BLL;
using System.Collections.Generic;

namespace UI.Seguranca
{
    public partial class PermissaoUsuario1 : System.Web.UI.Page
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
            List<Usuario> dadosUsuarioLista = new List<Usuario>();
            LinhaNegocioBLL oLinhaNegocio = new LinhaNegocioBLL();
            VO.LinhaNegocio dadosLinhaNegocio = new LinhaNegocio();

            dadosLinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

            dadosUsuarioLista = oLinhaNegocio.ListarUsuario(dadosLinhaNegocio);

            ddlNomeUsuario.DataSource = dadosUsuarioLista;

            ddlNomeUsuario.DataTextField = "Nome";

            ddlNomeUsuario.DataValueField = "IdUsuario";
            ddlNomeUsuario.DataBind();

            ddlNomeUsuario.Items.Insert(0, "");
            ddlNomeUsuario.SelectedIndex = 0;
        }




        protected void btnAdicionarTodos_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < ltbAssociarPermissoes.Items.Count; i++)
            {
                ltbAssociarPermissoesAdd.Items.Add(ltbAssociarPermissoes.Items[i]);
            }
            ltbAssociarPermissoes.Items.Clear();
        }

        protected void Adicionar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(ltbAssociarPermissoes.SelectedValue))
            {
                ltbAssociarPermissoesAdd.Items.Add(ltbAssociarPermissoes.SelectedItem);
                ltbAssociarPermissoes.Items.Remove(ltbAssociarPermissoes.SelectedItem);
            }
        }

        protected void Remover_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(ltbAssociarPermissoesAdd.SelectedValue))
            {
                ltbAssociarPermissoes.Items.Add(ltbAssociarPermissoesAdd.SelectedItem);
                ltbAssociarPermissoesAdd.Items.Remove(ltbAssociarPermissoesAdd.SelectedItem);
            }
        }

        protected void btnRemoverTodos_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < ltbAssociarPermissoesAdd.Items.Count; i++)
            {
                ltbAssociarPermissoes.Items.Add(ltbAssociarPermissoesAdd.Items[i]);
            }
            ltbAssociarPermissoesAdd.Items.Clear();
        }
        



        protected void btnAdicionarTodos1_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < ltbAssociarPerfil.Items.Count; i++)
            {
                ltbAssociarPerfilAdd.Items.Add(ltbAssociarPerfil.Items[i]);
            }
            ltbAssociarPerfil.Items.Clear();
        }

        protected void btnAdicionarTodos2_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(ltbAssociarPerfil.SelectedValue))
            {
                ltbAssociarPerfilAdd.Items.Add(ltbAssociarPerfil.SelectedItem);
                ltbAssociarPerfil.Items.Remove(ltbAssociarPerfil.SelectedItem);
            }
        }

        protected void btnRemoverTodos3_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(ltbAssociarPerfilAdd.SelectedValue))
            {
                ltbAssociarPerfil.Items.Add(ltbAssociarPerfilAdd.SelectedItem);
                ltbAssociarPerfilAdd.Items.Remove(ltbAssociarPerfilAdd.SelectedItem);
            }
        }

        protected void btnRemoverTodos4_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < ltbAssociarPerfilAdd.Items.Count; i++)
            {
                ltbAssociarPerfil.Items.Add(ltbAssociarPerfilAdd.Items[i]);
            }
            ltbAssociarPerfilAdd.Items.Clear();
        }



        protected void ddlNomeUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNomeUsuario.SelectedIndex != 0)
            {
                PermissaoSistemaBLL oPermissaoSistema = new PermissaoSistemaBLL();
                PermissaoSistema dadosPermissaoSistema = new PermissaoSistema();
                PerfilBLL oPerfil = new PerfilBLL();
                Perfil dadosPerfil = new Perfil();
                dadosPermissaoSistema.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(ddlNomeUsuario.SelectedValue) };
                dadosPerfil.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(ddlNomeUsuario.SelectedValue) };

                ltbAssociarPermissoes.DataSource = oPermissaoSistema.ListarSemRelacaoUsuario(dadosPermissaoSistema);
                ltbAssociarPermissoes.DataTextField = "Nome";
                ltbAssociarPermissoes.DataValueField = "IDPermissao";
                ltbAssociarPermissoes.DataBind();

                ltbAssociarPermissoesAdd.DataSource = oPermissaoSistema.ListarUsuario(dadosPermissaoSistema);
                ltbAssociarPermissoesAdd.DataTextField = "Nome";
                ltbAssociarPermissoesAdd.DataValueField = "IDPermissao";
                ltbAssociarPermissoesAdd.DataBind();

                ltbAssociarPerfil.DataSource = oPerfil.ListarSemRelacaoUsuario(dadosPerfil);
                ltbAssociarPerfil.DataTextField = "Nome";
                ltbAssociarPerfil.DataValueField = "IdPerfil";
                ltbAssociarPerfil.DataBind();

                ltbAssociarPerfilAdd.DataSource = oPerfil.ListarUsuario(dadosPerfil);
                ltbAssociarPerfilAdd.DataTextField = "Nome";
                ltbAssociarPerfilAdd.DataValueField = "IdPerfil";
                ltbAssociarPerfilAdd.DataBind();
            }
            else
            {
                ltbAssociarPerfil.Items.Clear();
                ltbAssociarPerfilAdd.Items.Clear();
                ltbAssociarPermissoes.Items.Clear();
                ltbAssociarPermissoesAdd.Items.Clear();
            }
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            PermissaoSistemaBLL oPermissaoSistema = new PermissaoSistemaBLL();
            PermissaoSistema dadosPermissaoSistema = new PermissaoSistema();
            PerfilBLL oPerfil = new PerfilBLL();
            Perfil dadosPerfil = new Perfil();

            dadosPermissaoSistema.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(ddlNomeUsuario.SelectedValue) };
            dadosPerfil.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(ddlNomeUsuario.SelectedValue) };
            oPerfil.RemoverUsuario(dadosPerfil);
            oPermissaoSistema.RemoverUsuario(dadosPermissaoSistema);


            for (int i = 0; i < ltbAssociarPermissoesAdd.Items.Count; i++)
            {
                dadosPermissaoSistema.IDPermissao = Convert.ToInt32(ltbAssociarPermissoesAdd.Items[i].Value);

                oPermissaoSistema.NovoUsuario(dadosPermissaoSistema);
            }

            for (int i = 0; i < ltbAssociarPerfilAdd.Items.Count; i++)
            {
                dadosPerfil.IDPerfil = Convert.ToInt32(ltbAssociarPerfilAdd.Items[i].Value);

                oPerfil.NovoUsuario(dadosPerfil);
            }
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }
    }
}
