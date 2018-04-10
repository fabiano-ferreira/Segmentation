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
    public partial class CriterioVariavel : System.Web.UI.Page
    {
        VO.Campanha dadosCampanha = new VO.Campanha();
        List<VO.Campanha> campanhaLista = new List<VO.Campanha>();
        BLL.CampanhaBLL oCampanha = new BLL.CampanhaBLL();
        VO.Modelo dadosModelo = new VO.Modelo();
        List<VO.Modelo> modeloLista = new List<VO.Modelo>();
        BLL.ModeloBLL oModelo = new BLL.ModeloBLL();
        VO.Variavel dadosVariavel = new VO.Variavel();
        List<VO.Variavel> variavelLista = new List<VO.Variavel>();
        BLL.VariavelBLL oVariavel = new BLL.VariavelBLL();
        VO.Criterio dadosCriterio = new VO.Criterio();
        List<VO.Criterio> criterioLista = new List<VO.Criterio>();
        BLL.CriterioBLL oCriterio = new BLL.CriterioBLL();
        VO.TipoCriterioVariavel dadosTipoCriterioVariavel = new VO.TipoCriterioVariavel();
        List<VO.TipoCriterioVariavel> tipoCriterioVariavelLista = new List<VO.TipoCriterioVariavel>();
        BLL.TipoCritetrioVariavelBLL oTipoCriterioVariavel = new BLL.TipoCritetrioVariavelBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                campanhaLista = oCampanha.Listar();
                ddlCampanha.DataSource = campanhaLista;
                ddlCampanha.DataTextField = "Nome";
                ddlCampanha.DataValueField = "IDCampanha";
                ddlCampanha.DataBind();
                ddlCampanha.Items.Insert(0, "");
                ddlCampanha.SelectedIndex = 0;

                tipoCriterioVariavelLista = oTipoCriterioVariavel.Listar();
                ddlTipoCriterioVariavel.DataSource = tipoCriterioVariavelLista;
                ddlTipoCriterioVariavel.DataTextField = "Descricao";
                ddlTipoCriterioVariavel.DataValueField = "IDTipoCriterioVariavel";
                ddlTipoCriterioVariavel.DataBind();
                ddlTipoCriterioVariavel.Items.Insert(0, "");
                ddlTipoCriterioVariavel.SelectedIndex = 0;
            }
        }

        public void lkbSalvar_Click(object sender, EventArgs e)
        {
            dadosCriterio.Variavel = new VO.Variavel() { IDVariavel = Convert.ToInt32(ddlVariavel.SelectedValue) };
            oCriterio.RemoverVariavel(dadosCriterio);

            for (int i = 0; i < lbxValorAdd.Items.Count; i++)
            {
                dadosCriterio.IDCriterio = Convert.ToInt32(lbxValorAdd.Items[i].Value);
                string[] linhaSeparada = lbxValorAdd.Items[i].Text.Split('/');
                if (linhaSeparada[1].Trim() != "")
                    dadosCriterio.Valor = Convert.ToInt32(linhaSeparada[1]);
                if (linhaSeparada[2] != " ")
                    dadosCriterio.Valor2 = Convert.ToInt32(linhaSeparada[2]);
                else
                    dadosCriterio.Valor2 = null;

                string[] criterioSeparado = linhaSeparada[0].Split('-');

                for (int k = 0; k < ddlTipoCriterioVariavel.Items.Count; k++)
                {
                    if (ddlTipoCriterioVariavel.Items[k].Text == criterioSeparado[1].Trim())
                    {
                        if (!string.IsNullOrEmpty(ddlTipoCriterioVariavel.SelectedValue))
                        {
                            dadosCriterio.TipoCriterioVariavel = new TipoCriterioVariavel()
                            {
                                IDTipoCriterioVariavel = Convert.ToInt32(ddlTipoCriterioVariavel.Items[k].Value)
                            };
                        }
                        else
                            dadosCriterio.TipoCriterioVariavel = new TipoCriterioVariavel();
                    }
                }

                oCriterio.NovoVariavel(dadosCriterio);
            }
            
        }

        public void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void Adicionar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxVariavelAdd.SelectedValue.ToString()))
            {
                lbxVariavelAdd.SelectedItem.Text += string.Concat(" - " , ddlTipoCriterioVariavel.SelectedItem.Text,
                    " / ", txtValor.Text, " / ", txtValor2.Text);
                lbxValorAdd.Items.Add(lbxVariavelAdd.SelectedItem);
                lbxVariavelAdd.Items.Remove(lbxVariavelAdd.SelectedItem);
                txtValor.Text = string.Empty;
                txtValor2.Text = string.Empty;
                txtValor2.Enabled = false;
                ddlTipoCriterioVariavel.SelectedIndex = 0;
            }
        }

        protected void Remover_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxValorAdd.SelectedValue.ToString()))
            {
                string[] linhaSeparada = lbxValorAdd.SelectedItem.Text.Split('-');
                lbxValorAdd.SelectedItem.Text = linhaSeparada[0];
                lbxVariavelAdd.Items.Add(lbxValorAdd.SelectedItem);
                lbxValorAdd.Items.Remove(lbxValorAdd.SelectedItem);
            }
        }

        protected void ddlCampanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(ddlCampanha.SelectedValue.ToString()))
            {
                dadosModelo.Campanha = new VO.Campanha()
                {
                    IDCampanha = Convert.ToInt32(ddlCampanha.SelectedValue)
                };
                modeloLista = oModelo.RelacaoVariavelListar(dadosModelo);
                ddlModelo.DataSource = modeloLista;
                ddlModelo.DataTextField = "Nome";
                ddlModelo.DataValueField = "IDModelo";
                ddlModelo.DataBind();
                ddlModelo.Items.Insert(0, "");
                ddlModelo.SelectedIndex = 0;
            }
            else
            {
                ddlCampanha.SelectedIndex = 0;
                if (!string.IsNullOrEmpty(ddlModelo.Text))
                    ddlModelo.SelectedIndex = 0;
                if (!string.IsNullOrEmpty(ddlVariavel.Text))
                    ddlVariavel.SelectedIndex = 0;
                ddlVariavel.Items.Clear();
                ddlModelo.Items.Clear();
                lbxValorAdd.Items.Clear();
                lbxVariavelAdd.Items.Clear();
            }
        }

        protected void ddlModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(ddlModelo.SelectedValue.ToString()))
            {
                dadosVariavel.Modelo = new Modelo()
                {
                    IDModelo = Convert.ToInt32(ddlModelo.SelectedValue)
                };
                variavelLista = oVariavel.ListarRelacaoModelo(dadosVariavel);
                ddlVariavel.DataSource = variavelLista;
                ddlVariavel.DataTextField = "Descricao";
                ddlVariavel.DataValueField = "IDVariavel";
                ddlVariavel.DataBind();
                ddlVariavel.Items.Insert(0, "");
                ddlVariavel.SelectedIndex = 0;
            }
            else
            {
                if (!string.IsNullOrEmpty(ddlVariavel.Text))
                    ddlVariavel.SelectedIndex = 0;
                ddlVariavel.Items.Clear();
                lbxValorAdd.Items.Clear();
                lbxVariavelAdd.Items.Clear();
            }
        }

        protected void ddlVariavel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlVariavel.SelectedValue.ToString()))
            {
                dadosCriterio.Variavel = new Variavel() { IDVariavel = Convert.ToInt32(ddlVariavel.SelectedValue) };
                dadosCriterio.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

                lbxValorAdd.DataSource = oCriterio.RelacaoVariavelListar(dadosCriterio);
                lbxValorAdd.DataValueField = "IDCriterio";
                lbxValorAdd.DataTextField = "Nome";
                lbxValorAdd.DataBind();

                lbxVariavelAdd.DataSource = oCriterio.RelacaoSemVariavelListar(dadosCriterio);
                lbxVariavelAdd.DataValueField = "IDCriterio";
                lbxVariavelAdd.DataTextField = "Nome";
                lbxVariavelAdd.DataBind();
            }
            else
            {
                lbxValorAdd.Items.Clear();
                lbxVariavelAdd.Items.Clear();
            }
        }

        protected void ddlTipoCriterioVariavel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoCriterioVariavel.SelectedItem.Text == "ENTRE")
            {
                txtValor2.Enabled = true;
            }
            else
            {
                txtValor2.Enabled = false;
                txtValor2.Text = string.Empty;
            }
        }
    }
}
