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

namespace UI.DadoVariavel
{
    public partial class VersaoFatorPosicionamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var bizCampanha = new BLL.CampanhaBLL();
                ddlCampanha.DataSource = bizCampanha.Listar();
                ddlCampanha.DataValueField = "IdCampanha";
                ddlCampanha.DataTextField = "Nome";
                ddlCampanha.DataBind();
                ddlCampanha.Items.Insert(0, "");
                ddlCampanha.SelectedIndex = 0;
            }
        }

        public void PreencheGrid()
        {
            var versaoProdutoFator = new VO.VersaoProdutoFator();
            var bizVersaoProdutoFator = new BLL.VersaoProdutoFatorBLL();

            versaoProdutoFator.Modelo = new VO.Modelo()
            {
                IDModelo = Convert.ToInt32(ddlModelo.SelectedValue)
            };
            versaoProdutoFator.IdVersaoProdutoFator = null;
            versaoProdutoFator = bizVersaoProdutoFator.Listar(versaoProdutoFator);

            List<object> objLista = new List<object>();
            foreach (VO.VersaoProdutoFator list in versaoProdutoFator.VersaoProdutoFatorLista)
            {
                var obj = new
                {
                    Descricao = list.Descricao.ToString(),
                    IdModelo = list.Modelo.IDModelo,
                    IdVersaoProdutoFator = list.IdVersaoProdutoFator
                };
                objLista.Add(obj);
            }

            grvCampanha.DataSource = objLista;
            grvCampanha.DataBind();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void lkbPesquisarFator_Click(object sender, EventArgs e)
        {
            var fator = new VO.Fator();
            var fatorList = new List<VO.Fator>();
            var bizFator = new BLL.FatorBLL();
            var produtoNivel = new VO.ProdutoNivel();
            var produtoNivelList = new List<VO.ProdutoNivel>();
            var bizProdutoNivel = new BLL.ProdutoNivelBLL();

            fator.TipoFator = new VO.TipoFator()
            {
                IDTipoFator = 2
            };
            fator.Modelo = new VO.Modelo()
            {
                IDModelo = Convert.ToInt32(ddlModelo.SelectedValue)
            };
            fatorList = bizFator.ListarFatorModeloFator(fator);
            lbxFatores.DataSource = fatorList;
            lbxFatores.DataValueField = "IdFator";
            lbxFatores.DataTextField = "Descricao";
            lbxFatores.DataBind();

            txtDescricao2.Text = txtDescricao.Text;

            produtoNivel.LinhaNegocio = ((VO.Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            produtoNivelList = bizProdutoNivel.ListarRelacaoLinhaNegocio(produtoNivel);
            trvVersao.Nodes.Clear();
            for (int i = 0; i < produtoNivelList.Count; i++)
            {
                trvVersao.Nodes.Add(new TreeNode
                {
                    Value = produtoNivelList[i].IDProdutoNivel.ToString(),
                    Text = produtoNivelList[i].NomePai + " (C)"
                });

            }
                
            mdlFatorPosicionamento.Show();
        }

        protected void lkbFecharFator_Click(object sender, EventArgs e)
        {

            txtDescricao2.Text = string.Empty;
            txtNivelTreeView.Text = string.Empty;
            lbxFatoresSelecionados.Items.Clear();
            lbxProdutosSelecionados.Items.Clear();
            mdlFatorPosicionamento.Hide();
        }
        protected void ddlCampanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCampanha.SelectedValue))
            {
                var modelo = new VO.Modelo();
                var modeloList = new List<VO.Modelo>();
                var bizModelo = new BLL.ModeloBLL();

                modelo.Campanha = new VO.Campanha()
                {
                    IDCampanha = Convert.ToInt32(ddlCampanha.SelectedValue)
                };

                modeloList = bizModelo.CampanhaListar(modelo);

                List<object> objLista = new List<object>();
                foreach (VO.Modelo list in modeloList)
                {
                    var obj = new
                    {
                        IDModelo = list.IDModelo,
                        Nome = list.Nome,
                    };
                    objLista.Add(obj);
                }

                ddlModelo.DataSource = objLista;
                ddlModelo.DataValueField = "IDModelo";
                ddlModelo.DataTextField = "Nome";
                ddlModelo.DataBind();
                ddlModelo.Items.Insert(0, "");
                ddlModelo.SelectedIndex = 0;
            }
            else
            {
                ddlModelo.SelectedIndex = 0;
                grvCampanha.DataSource = null;
                grvCampanha.DataBind();
                txtDescricao.Text = string.Empty;
                txtIdVersao.Text = string.Empty;
                lkbPesquisarFator.Enabled = false;
            }
        }

        protected void btnAdicionarTodos_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < lbxFatores.Items.Count; i++)
            {
                lbxFatoresSelecionados.Items.Add(lbxFatores.Items[i]);
            }
            lbxFatores.Items.Clear();

        }

        protected void btnRemoverTodos_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < lbxFatoresSelecionados.Items.Count; i++)
            {
                lbxFatores.Items.Add(lbxFatoresSelecionados.Items[i]);
            }
            lbxFatoresSelecionados.Items.Clear();

        }

        protected void Adicionar_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxFatores.SelectedValue.ToString()))
            {
                lbxFatoresSelecionados.Items.Add(lbxFatores.SelectedItem);
                lbxFatores.Items.Remove(lbxFatores.SelectedItem);
            }
        }

        protected void Remover_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxFatoresSelecionados.SelectedValue.ToString()))
            {
                lbxFatores.Items.Add(lbxFatoresSelecionados.SelectedItem);
                lbxFatoresSelecionados.Items.Remove(lbxFatoresSelecionados.SelectedItem);
            }
        }

        protected void ddlModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlModelo.SelectedValue))
            {
                PreencheGrid();
            }
            else
            {
                grvCampanha.DataSource = null;
                grvCampanha.DataBind();
                txtDescricao.Text = string.Empty;
                txtIdVersao.Text = string.Empty;
            }

        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            var versaoProdutoFator = new VO.VersaoProdutoFator();
            var bizVersaoProdutoFator = new BLL.VersaoProdutoFatorBLL();
            var usuario = new VO.Usuario();

            usuario = (VO.Usuario)HttpContext.Current.Session["UsuarioLogado"];
            versaoProdutoFator.Usuario = new VO.Usuario()
            {
                IDUsuario = usuario.IDUsuario
            };
            versaoProdutoFator.Descricao = txtDescricao.Text;
            versaoProdutoFator.Modelo = new VO.Modelo()
            {
                IDModelo = Convert.ToInt32(ddlModelo.SelectedValue)
            };

            if (string.IsNullOrEmpty(txtIdVersao.Text))
            {
                bizVersaoProdutoFator.Novo(versaoProdutoFator);
                txtDescricao.Text = string.Empty;
                lkbPesquisarFator.Enabled = false;
            }
            else
            {
                versaoProdutoFator.IdVersaoProdutoFator = Convert.ToInt32(txtIdVersao.Text);
                bizVersaoProdutoFator.Editar(versaoProdutoFator);
                txtDescricao.Text = string.Empty;
                txtIdVersao.Text = string.Empty;
                lkbPesquisarFator.Enabled = false;
            }
            PreencheGrid();
        }

        protected void btnEditarGrid_Click(object sender, EventArgs e)
        {
            ImageButton btnRemover = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnRemover.NamingContainer;

            ddlModelo.SelectedValue = grvCampanha.DataKeys[grid.RowIndex].Values[0].ToString();
            txtIdVersao.Text = grvCampanha.DataKeys[grid.RowIndex].Values[1].ToString();
            txtDescricao.Text = grvCampanha.DataKeys[grid.RowIndex].Values[2].ToString();
            lkbPesquisarFator.Enabled = true;

        }

        protected void btnExcluirGrid_Click(object sender, EventArgs e)
        {
            var versaoProdutoFator = new VO.VersaoProdutoFator();
            var bizVersaoProdutoFator = new BLL.VersaoProdutoFatorBLL();

            ImageButton btnExcluir = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnExcluir.NamingContainer;

            versaoProdutoFator.IdVersaoProdutoFator = Convert.ToInt16(grvCampanha.DataKeys[grid.RowIndex].Values[1].ToString());
            try
            {
                bizVersaoProdutoFator.Remover(versaoProdutoFator);
                PreencheGrid();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:alert('Existe relacionamentos pendentes para essa Versão');", true);
            }
            lkbPesquisarFator.Enabled = false;
        }

        protected void trvVersao_SelectedNodeChanged(object sender, EventArgs e)
        {
            var produtoNivel = new VO.ProdutoNivel();
            var bizProdutoNivel = new BLL.ProdutoNivelBLL();
            
            if (trvVersao.SelectedNode.ChildNodes.Count == 0)
            {
                if (trvVersao.SelectedNode.Text.EndsWith("(C)"))
                {
                    produtoNivel.IDProdutoNivel = Convert.ToInt32(trvVersao.SelectedValue);
                    produtoNivel = bizProdutoNivel.ListarRelacaoProdutoNivel(produtoNivel);

                    foreach (VO.RelacaoProdutoNivel list in produtoNivel.RelacaoProdutoNivelLista)
                    {
                        trvVersao.SelectedNode.ChildNodes.Add(new TreeNode
                        {
                            Value = list.IdFilho.ToString(),
                            Text = list.Nome.ToString() + " (C)"
                        });
                    }

                    produtoNivel.IDProdutoNivel = Convert.ToInt32(trvVersao.SelectedValue);
                    produtoNivel = bizProdutoNivel.ListarRelacaoProdutoNivelProduto(produtoNivel);

                    foreach (VO.RelacaoProdutoNivelProduto list in produtoNivel.RelacaoProdutoNivelProdutoLista)
                    {
                        trvVersao.SelectedNode.ChildNodes.Add(new TreeNode
                        {
                            Value = list.IDProduto.ToString(),
                            Text = list.Nome.ToString() + " (P)"
                        });
                    }
                    trvVersao.SelectedNode.Expanded = true;
                }
            }
            txtTreeView.Text = trvVersao.SelectedNode.Value.ToString() + " - " + trvVersao.SelectedNode.Text.ToString();
        }

        protected void btnAdicionar2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTreeView.Text))
            {
                for (int i = 0; i < lbxProdutosSelecionados.Items.Count; i++)
                {
                    if (lbxProdutosSelecionados.Items[i].Text == txtTreeView.Text)
                    {
                        return;
                    }
                }

                if (lbxProdutosSelecionados.Items.Count == 0)
                {
                    string[] linhaSeparada = trvVersao.SelectedNode.ValuePath.Split('/');
                    txtNivelTreeView.Text = linhaSeparada.Length.ToString();
                    lbxProdutosSelecionados.Items.Add(txtTreeView.Text);
                }
                else 
                {
                    string[] linhaSeparada = trvVersao.SelectedNode.ValuePath.Split('/');
                    if (Convert.ToInt32(linhaSeparada.Length) >= Convert.ToInt32(txtNivelTreeView.Text))
                    {
                        lbxProdutosSelecionados.Items.Add(txtTreeView.Text);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:alert('Categoria ou produto a ser adicionado, só pode ser do mesmo nível à ocorrência da lista');", true);
                    }
                }
            }
        }

        protected void btnRemover2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbxProdutosSelecionados.SelectedValue.ToString()))
            {
                lbxProdutosSelecionados.Items.Remove(lbxProdutosSelecionados.SelectedItem);
            }

        }
    }
}