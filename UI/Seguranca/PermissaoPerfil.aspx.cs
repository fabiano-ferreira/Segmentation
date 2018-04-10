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
using BLL;
using VO;
using System.Collections.Generic;

namespace UI.Seguranca
{
    public partial class PermissaoPerfil : System.Web.UI.Page
    {
        Perfil dadosPerfil = new Perfil();
        List<Perfil> perfilLista = new List<Perfil>();
        PerfilBLL oPerfil = new PerfilBLL();
        List<PermissaoSistema> permissaoSistemaLista = new List<PermissaoSistema>();
        PermissaoSistema dadosPermissaoSistema = new PermissaoSistema();
        PermissaoSistemaBLL oPermissaoSistema = new PermissaoSistemaBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                perfilLista = oPerfil.Listar();
                ddlUsuario.DataSource = perfilLista;
                ddlUsuario.DataTextField = "Nome";
                ddlUsuario.DataValueField = "IDPerfil";
                ddlUsuario.DataBind();
                ddlUsuario.Items.Insert(0, "");
                ddlUsuario.SelectedIndex = 0;
            }
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsuario.SelectedIndex != 0)
            {
                dadosPermissaoSistema.Perfil = new Perfil()
                {
                    IDPerfil = Convert.ToInt32(ddlUsuario.SelectedValue)
                };

                permissaoSistemaLista = oPermissaoSistema.ListarSemRelacaoPerfil(dadosPermissaoSistema);
                lbxAssociarPermissoesAdd.DataSource = permissaoSistemaLista;
                lbxAssociarPermissoesAdd.DataTextField = "Nome";
                lbxAssociarPermissoesAdd.DataValueField = "IDPermissao";
                lbxAssociarPermissoesAdd.DataBind();

                permissaoSistemaLista = oPermissaoSistema.ListarPerfil(dadosPermissaoSistema);
                lbxPermissoesAdd.DataSource = permissaoSistemaLista;
                lbxPermissoesAdd.DataTextField = "Nome";
                lbxPermissoesAdd.DataValueField = "IDPermissao";
                lbxPermissoesAdd.DataBind();

            }
            else
            {
                lbxAssociarPermissoesAdd.Items.Clear();
                lbxPermissoesAdd.Items.Clear();
            }
        }

        protected void btnAdicionarTodos_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < lbxAssociarPermissoesAdd.Items.Count; i++)
            {
                lbxPermissoesAdd.Items.Add(lbxAssociarPermissoesAdd.Items[i]);
            }
            lbxAssociarPermissoesAdd.Items.Clear();
            
        }

        protected void btnRemoverTodos_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < lbxPermissoesAdd.Items.Count; i++)
            {
                lbxAssociarPermissoesAdd.Items.Add(lbxPermissoesAdd.Items[i]);
            }
            lbxPermissoesAdd.Items.Clear();
            
        }

        protected void Adicionar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxAssociarPermissoesAdd.SelectedValue.ToString()))
            {
                lbxPermissoesAdd.Items.Add(lbxAssociarPermissoesAdd.SelectedItem);
                lbxAssociarPermissoesAdd.Items.Remove(lbxAssociarPermissoesAdd.SelectedItem);
            }
        }

        protected void Remover_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxPermissoesAdd.SelectedValue.ToString()))
            {
                lbxAssociarPermissoesAdd.Items.Add(lbxPermissoesAdd.SelectedItem);
                lbxPermissoesAdd.Items.Remove(lbxPermissoesAdd.SelectedItem);
            }
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            dadosPerfil.IDPerfil = Convert.ToInt32(ddlUsuario.SelectedValue);
            dadosPerfil.PermissaoSistema = new PermissaoSistema();
            oPerfil.RemoverPermissaoSistema(dadosPerfil);

            for (int i = 0; i < lbxPermissoesAdd.Items.Count; i++)
            {
                dadosPerfil.PermissaoSistema = new PermissaoSistema()
                {
                    IDPermissao = Convert.ToInt32(lbxPermissoesAdd.Items[i].Value)
                };

                oPerfil.NovoPermissaoSistema(dadosPerfil);
            }

        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        

        
    }
}
