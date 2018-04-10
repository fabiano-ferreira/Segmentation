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
    public partial class CriterioAtratividade : System.Web.UI.Page
    {
        VO.Criterio dadosCriterio = new VO.Criterio();
        List<VO.Criterio> criterioLista = new List<VO.Criterio>();
        BLL.CriterioBLL oCriterio = new BLL.CriterioBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dadosCriterio.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

                criterioLista = oCriterio.ListarRelacaoLinhaNegocio(dadosCriterio);
                ddlCriterio.DataSource = criterioLista;
                ddlCriterio.DataTextField = "Nome";
                ddlCriterio.DataValueField = "IDCriterio";
                ddlCriterio.DataBind();
                ddlCriterio.Items.Insert(0, "");
                ddlCriterio.SelectedIndex = 0;

                criterioLista = oCriterio.ListarAderencia(dadosCriterio);
                lbxCoordXInicialQ2.DataSource = criterioLista;
                lbxCoordXInicialQ2.DataTextField = "Nome";
                lbxCoordXInicialQ2.DataBind();

            }
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            dadosCriterio.CriterioAderencia = new CriterioAderencia() { IDCriterioAderencia = null };
            oCriterio.RemoverAderencia(dadosCriterio);

            for (int i = 0; i < lbxCoordXInicialQ2.Items.Count; i++)
            {
                string[] linhaSeparada = lbxCoordXInicialQ2.Items[i].Text.Split('/');

                for (int k = 0; k < ddlCriterio.Items.Count; k++)
                {
                    if (ddlCriterio.Items[k].Text == linhaSeparada[0].ToString().Trim())
                    {
                        dadosCriterio.IDCriterio = Convert.ToInt32(ddlCriterio.Items[k].Value);
                        dadosCriterio.Valor = Convert.ToInt32(linhaSeparada[1]);
                        oCriterio.NovoAderencia(dadosCriterio);
                    }
                }
            }
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void btnAdicionarItem_Click(object sender, ImageClickEventArgs e)
        {
            string scrpt = string.Empty; 
            for (int i = 0; i < lbxCoordXInicialQ2.Items.Count; i++)
            {
                string[] linhaSeparada = lbxCoordXInicialQ2.Items[i].Text.Split('/');

                if (ddlCriterio.SelectedItem.Text == linhaSeparada[0].ToString().Trim())
                {
                    scrpt = "Já existe um Critério Selecionado com o mesmo nome.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), scrpt, true);
                    return;
                }
            }

            lbxCoordXInicialQ2.Items.Add(ddlCriterio.SelectedItem.ToString() + " / " + txtCoordXInicial.Text);
            txtCoordXInicial.Text = string.Empty;
            ddlCriterio.SelectedIndex = 0;

        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxCoordXInicialQ2.SelectedItem.Text))
            {
                lbxCoordXInicialQ2.Items.Remove(lbxCoordXInicialQ2.SelectedItem);
            }
        }
    }
}
