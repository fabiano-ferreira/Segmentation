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

namespace UI.DadosBasicos
{
    public partial class CriterioManutencao : System.Web.UI.Page
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
            var dadosCriterio = new Criterio();
            dadosCriterio.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            grvCriterio.DataSource = new CriterioBLL().ListarRelacaoLinhaNegocio(dadosCriterio);
            grvCriterio.DataBind();
        }

        protected void LimparCampos()
        {
            txtNome.Text = String.Empty;
            txtId.Text = String.Empty;
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            var criterio = new Criterio();
            criterio.Nome = txtNome.Text;
            criterio.Usuario = (Usuario)Session["UsuarioLogado"];
            criterio.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

            if (String.IsNullOrEmpty(txtId.Text))
            {
                new CriterioBLL().Novo(criterio);
            }
            else
            {
                criterio.IDCriterio = Convert.ToInt32(txtId.Text);
                new CriterioBLL().Editar(criterio);
            }

            this.LimparCampos();
            this.Inicializar();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
            Response.Redirect("../Index.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnEditar = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnEditar.NamingContainer;
            txtId.Text = grvCriterio.DataKeys[grid.RowIndex].Values[0].ToString();
            txtNome.Text = grvCriterio.DataKeys[grid.RowIndex].Values[1].ToString();
            
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            var button = sender as ImageButton;
            var row = button.NamingContainer as GridViewRow;

            var id = grvCriterio.DataKeys[row.RowIndex].Value;

            new CriterioBLL().Remover(new Criterio() { IDCriterio = Convert.ToInt32(id) });

            this.Inicializar();
        }


    }
}