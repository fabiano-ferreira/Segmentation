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
    public partial class AssociarCampanha1 : System.Web.UI.Page
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
            CampanhaBLL oCampanha = new CampanhaBLL();
            List<VO.Campanha> dadosCampanhaLista = new List<VO.Campanha>();

            dadosCampanhaLista = oCampanha.Listar();

            ddlCampanha.DataSource = dadosCampanhaLista;
            ddlCampanha.DataValueField = "IDCampanha";
            ddlCampanha.DataTextField = "Nome";
            ddlCampanha.DataBind();
            ddlCampanha.Items.Insert(0,"");
            ddlCampanha.SelectedIndex = 0;
        }

        protected void ddlCampanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            VO.Campanha dadosCampanha = new VO.Campanha();
            List<Usuario> dadosUsuarioLista = new List<Usuario>();
            CampanhaBLL oCampanha = new CampanhaBLL();

            if (ddlCampanha.SelectedIndex != 0)
            {
                dadosCampanha.IDCampanha = Convert.ToInt32(ddlCampanha.SelectedValue);

                dadosUsuarioLista = oCampanha.ListarUsuarioSemRelacao(dadosCampanha);

                ltbUsuarioLista.DataSource = dadosUsuarioLista;
                ltbUsuarioLista.DataValueField = "IdUsuario";
                ltbUsuarioLista.DataTextField = "Nome";
                ltbUsuarioLista.DataBind();

                dadosUsuarioLista = oCampanha.ListarUsuario(dadosCampanha);

                ltbUsuarioADD.DataSource = dadosUsuarioLista;
                ltbUsuarioADD.DataValueField = "IdUsuario";
                ltbUsuarioADD.DataTextField = "Nome";
                ltbUsuarioADD.DataBind();
            }
            else
            {
                ltbUsuarioADD.Items.Clear();
                ltbUsuarioLista.Items.Clear();
            }
        }

        protected void btnAdicionarTodos_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < ltbUsuarioLista.Items.Count; i++)
            {
                ltbUsuarioADD.Items.Add(ltbUsuarioLista.Items[i]);
            }
            ltbUsuarioLista.Items.Clear();
        }

        protected void btnRemoverTodos_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < ltbUsuarioADD.Items.Count; i++)
            {
                ltbUsuarioLista.Items.Add(ltbUsuarioADD.Items[i]);
            }
            ltbUsuarioADD.Items.Clear();
        }

        protected void Adicionar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(ltbUsuarioLista.SelectedValue.ToString()))
            {
                ltbUsuarioADD.Items.Add(ltbUsuarioLista.SelectedItem);
                ltbUsuarioLista.Items.Remove(ltbUsuarioLista.SelectedItem);
            }
        }

        protected void Remover_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(ltbUsuarioADD.SelectedValue.ToString()))
            {
                ltbUsuarioLista.Items.Add(ltbUsuarioADD.SelectedItem);
                ltbUsuarioADD.Items.Remove(ltbUsuarioADD.SelectedItem);
            }
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            VO.Campanha dadosCampanha = new VO.Campanha();
            CampanhaBLL oCampanha = new CampanhaBLL();

            dadosCampanha.Usuario = new Usuario();
            dadosCampanha.IDCampanha = Convert.ToInt32(ddlCampanha.SelectedValue);
            oCampanha.RemoverUsuario(dadosCampanha);

            for (int i = 0; i < ltbUsuarioADD.Items.Count; i++)
            {
                dadosCampanha.Usuario = new Usuario() { IDUsuario = Convert.ToInt32(ltbUsuarioADD.Items[i].Value) };
            
                oCampanha.NovoUsuario(dadosCampanha);	
            }
            
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }
    }
}
