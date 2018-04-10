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
using VO;
using BLL;
using System.Drawing;

namespace UI.DadoVariavel
{
    public partial class FatorManutencao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Fator> Fatores = new List<Fator>();
                HttpContext.Current.Session["ListaFator"] = Fatores;
                lkbNovoFator.Enabled = false;
                Inicializar();
            }
        }

        public void LimpaCampos()
        {
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtComentario.Text = string.Empty;
            txtPeso.Text = string.Empty;
            txtFatorPai.Text = string.Empty;
            txtIdFator.Text = string.Empty;
            txtCodigoFator.Text = string.Empty;
            txtIdFatorPai.Text = string.Empty;
        }

        public void Inicializar()
        {
            VO.Campanha dadosCampanha = new VO.Campanha();
            BLL.CampanhaBLL oCampanha = new BLL.CampanhaBLL();
            VO.TipoFator dadosTipoFator = new TipoFator();
            BLL.TipoFatorBLL oTipoFator = new TipoFatorBLL();

            dadosCampanha.IDCampanha = null;
            dadosCampanha.Usuario = new Usuario()
            {
                IDUsuario = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).IDUsuario
            };
            
            ddlCampanha.DataSource = oCampanha.ListarRelacaoUsuario(dadosCampanha);
            ddlCampanha.DataValueField = "IDCampanha";
            ddlCampanha.DataTextField = "Nome";
            ddlCampanha.DataBind();
            ddlCampanha.Items.Insert(0, "");
            ddlCampanha.SelectedIndex = 0;

            ddlTipoFator.DataSource = oTipoFator.Listar();
            ddlTipoFator.DataTextField = "Nome";
            ddlTipoFator.DataValueField = "IdTipoFator";
            ddlTipoFator.DataBind();
            ddlTipoFator.Items.Insert(0, "");
            ddlTipoFator.SelectedIndex = 0;
        }

        public void PreencheModelo()
        {
            List<VO.Modelo> modeloLista = new List<VO.Modelo>();
            VO.Modelo dadosModelo = new VO.Modelo();
            BLL.ModeloBLL oModelo = new BLL.ModeloBLL();

            if (!string.IsNullOrEmpty(ddlCampanha.SelectedValue))
            {
                dadosModelo.Campanha = new VO.Campanha()
                {
                    IDCampanha = Convert.ToInt32(ddlCampanha.SelectedValue)
                };
                modeloLista = oModelo.CampanhaListar(dadosModelo);

                List<object> objLista = new List<object>();
                foreach (Modelo list in modeloLista)
                {
                    var obj = new
                    {
                        CodigoModelo = list.IDModelo.ToString(),
                        TipoSegmento = list.TipoSegmento.Nome,
                        Nome = list.Nome,
                        CodigoTipoSegmento = list.TipoSegmento.IDTipoSegmento,
                    };
                    objLista.Add(obj);
                }

                ddlModelo.DataSource = objLista;
                ddlModelo.DataTextField = "Nome";
                ddlModelo.DataValueField = "CodigoModelo";
                ddlModelo.DataBind();
                ddlModelo.Items.Insert(0, "");
                ddlModelo.SelectedIndex = 0;
            }
            else
            {
                ddlModelo.Items.Clear();
            }
        }

        protected void lkbNovoFator_Click(object sender, EventArgs e)
        {
            Fator dadosFator = new Fator();
            FatorBLL oFator = new FatorBLL();
            List<Fator> dadosFatorLista = new List<Fator>();

            dadosFator.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
            dadosFator.TipoFator = new TipoFator() { IDTipoFator = Convert.ToInt32(ddlTipoFator.SelectedValue) };
            dadosFator.Usuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
            dadosFator.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

            if (string.IsNullOrEmpty(txtIdFator.Text))
            {
                dadosFator.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
                dadosFator.TipoFator = new TipoFator() { IDTipoFator = Convert.ToInt32(ddlTipoFator.SelectedValue) };
                dadosFator.Usuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
                dadosFator.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
                dadosFatorLista = ((List<Fator>)HttpContext.Current.Session["ListaFator"]);

                if (string.IsNullOrEmpty(txtCodigoFator.Text))
                {
                    dadosFator.Codigo = oFator.GeraCodigoRaiz(dadosFator, dadosFatorLista);
                }
                else
                {
                    dadosFator.Codigo = txtCodigoFator.Text;
                }

                if (!string.IsNullOrEmpty(txtIdFatorPai.Text))
                {
                    dadosFator.IdPai = Convert.ToInt32(txtIdFatorPai.Text);
                }
                dadosFator.Nome = txtNome.Text;
                dadosFator.Descricao = txtDescricao.Text;
                dadosFator.Comentario = txtComentario.Text;
                dadosFator.Peso = Convert.ToInt32(txtPeso.Text);
                dadosFator.Status = 1;

                ((List<Fator>)HttpContext.Current.Session["ListaFator"]).Add(dadosFator);
            }
            else
            {
                dadosFatorLista = (List<Fator>)HttpContext.Current.Session["ListaFator"];

                for (int i = 0; i < dadosFatorLista.Count; i++)
                {
                    if (dadosFatorLista[i].IDFator == Convert.ToInt32(txtIdFator.Text))
                    {
                        dadosFatorLista[i].Nome = txtNome.Text;
                        dadosFatorLista[i].Descricao = txtDescricao.Text;
                        dadosFatorLista[i].Comentario = txtComentario.Text;
                        dadosFatorLista[i].Peso = Convert.ToInt32(txtPeso.Text);
                        dadosFatorLista[i].Status = 2;
                    }
                }
            }

            //PopulaTreeView();
            Swap(trvFator.Nodes[0], dadosFator);
            LimpaCampos();
        }

        public void PopulaTreeView()
        {
            List<Fator> dadosFatorLista = new List<Fator>();
            LinhaNegocio dadosLinhaNegocio = new LinhaNegocio();

            dadosLinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            dadosFatorLista = ((List<Fator>)HttpContext.Current.Session["ListaFator"]);

            trvFator.Nodes.Clear();

            trvFator.Nodes.Add(new TreeNode("Fatores", "0"));

            
            for (int i = 0; i < dadosFatorLista.Count; i++)
            {
                if (dadosFatorLista[i].IdPai == 0)
                {
                    TreeNode tvFator = new TreeNode();
                    tvFator.Text = string.Concat(dadosFatorLista[i].Codigo, " - ", dadosFatorLista[i].Nome);
                    tvFator.Value = dadosFatorLista[i].IDFator.ToString();
                    trvFator.Nodes[0].ChildNodes.Add(tvFator);
                    //trvFator.Nodes[0].Expanded = true;
                }
            }
            for (int i = 0; i < dadosFatorLista.Count; i++)
            {
                if (dadosFatorLista[i].IdPai != 0)
                {
                    Swap(trvFator.Nodes[0], dadosFatorLista[i]);
                }
            }
        }

        protected void Swap(TreeNode node, Fator valor)
        {
            if (valor.IdPai == 0)
            {
                node.ChildNodes.Add((new TreeNode(valor.Codigo + " - " + valor.Nome, valor.IDFator.ToString())));
            }
            else
            {
                if (node.ChildNodes.Count > 0)
                {
                    foreach (TreeNode child in node.ChildNodes)
                    {
                        if (child.Value == valor.IdPai.ToString())
                        {
                            child.ChildNodes.Add(new TreeNode(valor.Codigo + " - " + valor.Nome, valor.IDFator.ToString()));
                            return;
                        }
                        else
                        {
                            Swap(child, valor);
                        }
                    }
                }
                else
                {
                    if (node.Value == valor.IdPai.ToString())
                    {
                        node.ChildNodes.Add(new TreeNode(valor.Codigo + " - " +  valor.Nome, valor.IDFator.ToString()));
                        return;
                    }
                    return;
                }
            }
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoFator.Text))
            {
                LimpaCampos();
            }
            else
            {
                Response.Redirect("../Index.aspx");
            }
        }
        
        protected void lkbPesquisar1_Click(object sender, EventArgs e)
        {
            Fator dadosFator = new Fator();
            List<Fator> dadosFatorLista = new List<Fator>();
            FatorBLL oFator = new FatorBLL();

            dadosFator.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
            dadosFator.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            dadosFator.TipoFator = new TipoFator() { IDTipoFator = Convert.ToInt32(ddlTipoFator.SelectedValue) };
            if (!string.IsNullOrEmpty(txtCodigoFiltro.Text))
            {
                dadosFator.Codigo = txtCodigoFiltro.Text;
            }
            else
            {
                dadosFator.Codigo = null;
            }
            if (!string.IsNullOrEmpty(txtNomeFiltro.Text))
            {
                dadosFator.Nome = txtNomeFiltro.Text;
            }
            else
            {
                dadosFator.Nome = "%";
            }
            dadosFatorLista = oFator.ListarFiltroFator(dadosFator);
            grvFator.DataSource = dadosFatorLista;
            grvFator.DataBind();
            uppFator.Update();
        }

        protected void btnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            mdlFator.Show();
        }

        protected void lkbCancelarModal_Click(object sender, EventArgs e)
        {
            mdlFator.Hide();
        }

        protected void btnModalProd_Click(object sender, EventArgs e)
        {
            mdlProdutos.Show();
        }

        protected void ddlCampanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencheModelo();
        }

        protected void btnListarFatores_Click(object sender, EventArgs e)
        {
            FatorBLL oFator = new FatorBLL();
            Fator dadosFator = new Fator();
            dadosFator.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
            dadosFator.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            dadosFator.TipoFator = new TipoFator() { IDTipoFator = Convert.ToInt32(ddlTipoFator.SelectedValue) };
            HttpContext.Current.Session["ListaFator"] = oFator.ListarModeloFator(dadosFator);
            PopulaTreeView();
            LimpaCampos();
            lkbNovoFator.Enabled = true;
        }

        protected void lkbSalvarFator_Click(object sender, EventArgs e)
        {
            FatorBLL oFator = new FatorBLL();
            Fator dadosFator = new Fator();
            List<Fator> dadosFatorLista = new List<Fator>();
            
            dadosFatorLista = (List<Fator>)HttpContext.Current.Session["ListaFator"];
            try
            {
                oFator.Persistir(dadosFatorLista);
                dadosFator.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
                dadosFator.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
                dadosFator.TipoFator = new TipoFator() { IDTipoFator = Convert.ToInt32(ddlTipoFator.SelectedValue) };
                HttpContext.Current.Session["ListaFator"] = oFator.ListarModeloFator(dadosFator);
                PopulaTreeView();
                LimpaCampos();
            }
            catch (BLL.Exceptions.PesoInvalido ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "alert('" + ex.Message + "');", true);
            }
            catch (Exception)
            {

            }
        }

        protected void trvFator_SelectedNodeChanged(object sender, EventArgs e)
        {
            List<Fator> dadosFator = new List<Fator>();
            FatorBLL oFator = new FatorBLL();

            dadosFator = (List<Fator>)HttpContext.Current.Session["ListaFator"];

            for (int i = 0; i < dadosFator.Count; i++)
            {
                if (!string.IsNullOrEmpty(trvFator.SelectedNode.Value))
                {                
                    if (dadosFator[i].IDFator == Convert.ToInt32(trvFator.SelectedNode.Value))
                    {
                        txtIdFator.Text = dadosFator[i].IDFator.ToString();
                        txtNome.Text = dadosFator[i].Nome;
                        txtDescricao.Text = dadosFator[i].Descricao;
                        txtComentario.Text = dadosFator[i].Comentario;
                        txtCodigoFator.Text = dadosFator[i].Codigo;
                        txtPeso.Text = dadosFator[i].Peso.ToString();
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "alert('Salve o Fator " + dadosFator[i].Nome + ", para que possa ser editado');", true);
                }
            }
        }

        protected void rdbFator_CheckedChanged(Object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            GridViewRow gvRow = (GridViewRow)radioButton.NamingContainer;
            List<Fator> dadosFatorLista = new List<Fator>();
            Fator dadosFator = new Fator();
            FatorBLL oFator = new FatorBLL();
            txtIdFatorPai.Text = grvFator.DataKeys[gvRow.RowIndex].Values[0].ToString();
            txtFatorPai.Text = grvFator.DataKeys[gvRow.RowIndex].Values[2].ToString();

            dadosFatorLista = ((List<Fator>)HttpContext.Current.Session["ListaFator"]);
            dadosFator = oFator.GeraCodigo(dadosFatorLista, txtIdFatorPai.Text);
            txtCodigoFator.Text = dadosFator.Codigo;
            for (int i = 0; i < dadosFatorLista.Count; i++)
            {
                if (dadosFatorLista[i].IDFator == dadosFator.IdPai)
                {
                    dadosFatorLista[i].FatorFilho.Add(dadosFator);
                }
            }

            grvFator.DataSource = null;
            grvFator.DataBind();
            mdlFator.Hide();
            uppFatorPai.Update();
        }

        protected void lkbModalProduto_Click(object sender, EventArgs e)
        {
            mdlProdutos.Show();
        }

        protected void lkbRemover_Click(object sender, EventArgs e)
        {
            FatorBLL oFator = new FatorBLL();
            Fator dadosFator = new Fator();

            try
            {
                dadosFator.IDFator = Convert.ToInt32(txtIdFator.Text);
                dadosFator.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
                oFator.Remover(dadosFator);
                dadosFator.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
                dadosFator.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
                dadosFator.TipoFator = new TipoFator() { IDTipoFator = Convert.ToInt32(ddlTipoFator.SelectedValue) };
                HttpContext.Current.Session["ListaFator"] = oFator.ListarModeloFator(dadosFator);
                PopulaTreeView();
                LimpaCampos();

            }
            catch (System.Data.SqlClient.SqlException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:alert('Impossível excluir este Fator, \\nja existe relação para ele no sistema de Segmentação.');", true);
            }

        }

    }
}