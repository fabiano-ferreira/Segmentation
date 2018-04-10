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

namespace UI.DadosBasicos
{
    public partial class ModeloAssociarUsuario : System.Web.UI.Page
    {
        VO.Modelo dadosModelo = new VO.Modelo();
        List<VO.Modelo> modeloLista = new List<VO.Modelo>();
        BLL.ModeloBLL oModelo = new BLL.ModeloBLL();
        List<VO.Usuario> dadosUsuario = new List<VO.Usuario>();
        BLL.UsuarioBLL oUsuario = new BLL.UsuarioBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                modeloLista = oModelo.Listar();
                ddlModelos.DataSource = modeloLista;
                ddlModelos.DataValueField = "IDModelo";
                ddlModelos.DataTextField = "Nome";
                ddlModelos.DataBind();
                ddlModelos.Items.Insert(0, "");
                ddlModelos.SelectedIndex = 0;
            }

        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void ddlModelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModelos.SelectedIndex != 0)
            {
                dadosModelo.IDModelo = Convert.ToInt32(ddlModelos.SelectedValue);
                dadosUsuario = oModelo.ListarUsuario(dadosModelo);

                lbxPermissoesAdd.DataSource = dadosUsuario;
                lbxPermissoesAdd.DataTextField = "Nome";
                lbxPermissoesAdd.DataValueField = "IDUsuario";
                lbxPermissoesAdd.DataBind();

                dadosUsuario = oModelo.UsuarioSemRelacaoUsuarioListar(dadosModelo);

                lbxUsuariosAdd.DataSource = dadosUsuario;
                lbxUsuariosAdd.DataTextField = "Nome";
                lbxUsuariosAdd.DataValueField = "IDUsuario";
                lbxUsuariosAdd.DataBind();
            }
            else
            {
                lbxUsuariosAdd.Items.Clear();
                lbxPermissoesAdd.Items.Clear();
            }
        }

        protected void btnAdicionarTodos_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < lbxUsuariosAdd.Items.Count; i++)
            {
                lbxPermissoesAdd.Items.Add(lbxUsuariosAdd.Items[i]);
            }
            lbxUsuariosAdd.Items.Clear();
        }

        protected void btnRemoverTodos_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < lbxPermissoesAdd.Items.Count; i++)
            {
                lbxUsuariosAdd.Items.Add(lbxPermissoesAdd.Items[i]);
            }
            lbxPermissoesAdd.Items.Clear();

        }

        protected void Adicionar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxUsuariosAdd.SelectedValue.ToString()))
            {
                lbxPermissoesAdd.Items.Add(lbxUsuariosAdd.SelectedItem);
                lbxUsuariosAdd.Items.Remove(lbxUsuariosAdd.SelectedItem);
            }
        }

        protected void Remover_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxPermissoesAdd.SelectedValue.ToString()))
            {
                lbxUsuariosAdd.Items.Add(lbxPermissoesAdd.SelectedItem);
                lbxPermissoesAdd.Items.Remove(lbxPermissoesAdd.SelectedItem);
            }
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {

            dadosModelo.IDModelo = Convert.ToInt32(ddlModelos.SelectedValue);
            dadosModelo.Usuario = new Usuario();
            oModelo.RemoverUsuario(dadosModelo);

            for (int i = 0; i < lbxPermissoesAdd.Items.Count; i++)
            {
                dadosModelo.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(lbxPermissoesAdd.Items[i].Value) };

                oModelo.NovoUsuario(dadosModelo);
            }

        }

    }
}
