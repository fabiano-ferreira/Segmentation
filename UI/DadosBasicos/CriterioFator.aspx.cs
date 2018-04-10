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

namespace UI.DadosBasicos
{
    public partial class CriterioFator1 : System.Web.UI.Page
    {
        VO.Fator dadosFator = new VO.Fator();
        List<VO.Fator> fatorLista = new List<VO.Fator>();
        BLL.FatorBLL oFator = new BLL.FatorBLL();
        VO.Criterio dadosCriterio = new VO.Criterio();
        List<VO.Criterio> criterioLista = new List<VO.Criterio>();
        BLL.CriterioBLL oCriterio = new BLL.CriterioBLL();
        VO.Modelo dadosModelo = new VO.Modelo();
        List<VO.Modelo> modeloLista = new List<VO.Modelo>();
        BLL.ModeloBLL oModelo = new BLL.ModeloBLL();
        VO.Variavel dadosVariavel = new VO.Variavel();
        List<VO.Variavel> variavelLista = new List<VO.Variavel>();
        BLL.VariavelBLL oVariavel = new BLL.VariavelBLL();
        VO.Campanha dadosCampanha = new VO.Campanha();
        List<VO.Campanha> campanhaLista = new List<VO.Campanha>();
        BLL.CampanhaBLL oCampanha = new BLL.CampanhaBLL();


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
            }
        }

        protected void ddlFator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFator.SelectedIndex != 0)
            {
                dadosCriterio.Fator = new Fator()
                {
                    IDFator = Convert.ToInt32(ddlFator.SelectedValue)
                };
                dadosCriterio.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

                criterioLista = oCriterio.ListarRelacaoFator(dadosCriterio);
                lbxValorAdd.DataSource = criterioLista;
                lbxValorAdd.DataTextField = "Nome";
                lbxValorAdd.DataValueField = "IDCriterio";
                lbxValorAdd.DataBind();

                criterioLista = oCriterio.ListarSemRelacaoFator(dadosCriterio);
                lbxFatorAdd.DataSource = criterioLista;
                lbxFatorAdd.DataTextField = "Nome";
                lbxFatorAdd.DataValueField = "IDCriterio";
                lbxFatorAdd.DataBind();

            }
            else
            {
                lbxFatorAdd.Items.Clear();
                lbxValorAdd.Items.Clear();
            }
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            dadosCriterio.Fator = new Fator()
            {
                IDFator = Convert.ToInt32(ddlFator.SelectedValue)
            };
            oCriterio.RemoverFator(dadosCriterio);

            for (int i = 0; i < lbxValorAdd.Items.Count; i++)
            {
                dadosCriterio.IDCriterio = Convert.ToInt32(lbxValorAdd.Items[i].Value);
                string[] linhaSeparada = lbxValorAdd.Items[i].Text.Split('/');
                dadosCriterio.Valor = Convert.ToInt32(linhaSeparada[1].Trim());

                oCriterio.NovoFator(dadosCriterio);
            }
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void Adicionar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxFatorAdd.SelectedValue.ToString()))
            {
                lbxFatorAdd.SelectedItem.Text += string.Concat(" / ", txtValor.Text);
                lbxValorAdd.Items.Add(lbxFatorAdd.SelectedItem);
                lbxFatorAdd.Items.Remove(lbxFatorAdd.SelectedItem);
                txtValor.Text = string.Empty;
            }
        }

        protected void Remover_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxValorAdd.SelectedValue.ToString()))
            {
                string[] linhaSeparada = lbxValorAdd.SelectedItem.Text.Split('/');
                lbxValorAdd.SelectedItem.Text = linhaSeparada[0];
                lbxFatorAdd.Items.Add(lbxValorAdd.SelectedItem);
                lbxValorAdd.Items.Remove(lbxValorAdd.SelectedItem);
            }
        }

        protected void ddlCampanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCampanha.SelectedValue.ToString()))
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
                if (!string.IsNullOrEmpty(ddlFator.Text))
                    ddlFator.SelectedIndex = 0;
                ddlModelo.Items.Clear();
                ddlFator.Items.Clear();
                lbxValorAdd.Items.Clear();
                lbxFatorAdd.Items.Clear();
            }
        }

        protected void ddlModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlModelo.SelectedValue.ToString()))
            {
                dadosFator.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
                dadosFator.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
                dadosFator.TipoFator = new TipoFator();
                dadosFator.IDFator = null;

                fatorLista = oFator.ListarModeloFator(dadosFator);
                ddlFator.DataSource = fatorLista;
                ddlFator.DataTextField = "Nome";
                ddlFator.DataValueField = "IdFator";
                ddlFator.DataBind();
                ddlFator.Items.Insert(0, "");
                ddlFator.SelectedIndex = 0;
            }
            else
            {
                lbxValorAdd.Items.Clear();
                lbxFatorAdd.Items.Clear();
                if (!string.IsNullOrEmpty(ddlFator.Text))
                    ddlFator.SelectedIndex = 0;
                ddlFator.Items.Clear();

            }
        }


    }
}