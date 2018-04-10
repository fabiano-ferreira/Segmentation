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

namespace UI.DadosBasicos
{
    public partial class ProdutosAtratividade : System.Web.UI.Page
    {
        List<VO.Campanha> campanhaLista = new List<VO.Campanha>();
        BLL.CampanhaBLL oCampanha = new BLL.CampanhaBLL();
        VO.Modelo dadosModelo = new VO.Modelo();
        List<VO.Modelo> modeloLista = new List<VO.Modelo>();
        BLL.ModeloBLL oModelo = new BLL.ModeloBLL();
        List<VO.VersaoProdutoFator> versaoProdutoFatorLista = new List<VO.VersaoProdutoFator>();
        VO.VersaoProdutoFator dadosVersaoProdutoFator = new VO.VersaoProdutoFator();
        BLL.VersaoProdutoFatorBLL oVersaoProdutoFator = new VersaoProdutoFatorBLL();
        VO.VersaoProdutoFatorSegmento dadosVersaoProdutoFatorSegmento = new VO.VersaoProdutoFatorSegmento();
        BLL.VersaoProdutoFatorSegmentoBLL oVersaoProdutoFatorSegmento = new VersaoProdutoFatorSegmentoBLL();
        List<VO.VersaoProdutoFatorProdutoNivel> versaoProdutoFatorProdutoNivelLista = new List<VO.VersaoProdutoFatorProdutoNivel>();
        VO.VersaoProdutoFatorProdutoNivel dadosVersaoProdutoFatorProdutoNivel = new VO.VersaoProdutoFatorProdutoNivel();
        BLL.VersaoProdutoFatorProdutoNivelBLL oVersaoProdutoFatorProdutoNivel = new VersaoProdutoFatorProdutoNivelBLL();
        VO.ProdutoNivel dadosProdutoNivel = new VO.ProdutoNivel();
        BLL.ProdutoNivelBLL oProdutoNivel = new ProdutoNivelBLL();
        VO.Criterio dadosCriterio = new VO.Criterio();
        BLL.CriterioBLL oCriterio = new CriterioBLL();
        VO.Produto dadosProduto = new VO.Produto();
        BLL.ProdutoBLL oProduto = new ProdutoBLL();


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
                
                dadosCriterio.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
                ddlAderencia.DataSource = oCriterio.ListarRelacaoLinhaNegocio(dadosCriterio);
                ddlAderencia.DataTextField = "Nome";
                ddlAderencia.DataValueField = "IDIdCriterioAderencia";
                ddlAderencia.DataBind();
                ddlAderencia.Items.Insert(0, "");
                ddlAderencia.SelectedIndex = 0;

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
                if (!string.IsNullOrEmpty(ddlModelo.Text))
                    ddlModelo.SelectedIndex = 0;
                if (!string.IsNullOrEmpty(ddlVersao.Text))
                    ddlVersao.SelectedIndex = 0;
                ddlAderencia.SelectedIndex = 0;
                ddlModelo.Items.Clear();
                ddlVersao.Items.Clear();
                grvProdutosAtratividade.DataSource = null;
                grvProdutosAtratividade.DataBind();
                trvAderencia.Nodes.Clear();
                txtCatProduto.Text = string.Empty;
                txtAderenciaCalculada.Text = string.Empty;
                lkAderenciaProduto.Enabled = false;
                lkbAderenciaProdutoFilhos.Enabled = false;
            }
        }

        protected void ddlModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlModelo.SelectedValue.ToString()))
            {
                dadosVersaoProdutoFator.Modelo = new Modelo()
                {
                    IDModelo = Convert.ToInt32(ddlModelo.SelectedValue)
                };
                versaoProdutoFatorLista = oVersaoProdutoFator.ListarRelacaoModelo(dadosVersaoProdutoFator);
                ddlVersao.DataSource = versaoProdutoFatorLista;
                ddlVersao.DataTextField = "Descricao";
                ddlVersao.DataValueField = "IdVersaoProdutoFator";
                ddlVersao.DataBind();
                ddlVersao.Items.Insert(0, "");
                ddlVersao.SelectedIndex = 0;
            }
            else
            {
                if (!string.IsNullOrEmpty(ddlVersao.Text))
                    ddlVersao.SelectedIndex = 0;
                ddlAderencia.SelectedIndex = 0;
                ddlVersao.Items.Clear();
                grvProdutosAtratividade.DataSource = null;
                grvProdutosAtratividade.DataBind();
                trvAderencia.Nodes.Clear();
                txtCatProduto.Text = string.Empty;
                txtAderenciaCalculada.Text = string.Empty;
                lkAderenciaProduto.Enabled = false;
                lkbAderenciaProdutoFilhos.Enabled = false;
            }
        }

        protected void ddlVersao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlVersao.SelectedValue.ToString()))
            {
                dadosVersaoProdutoFatorSegmento.IdVersaoProdutoFator = Convert.ToInt32(ddlVersao.SelectedValue);
                grvProdutosAtratividade.DataSource = oVersaoProdutoFatorSegmento.ListarRelacaoSegmento(dadosVersaoProdutoFatorSegmento);
                grvProdutosAtratividade.DataBind();
            }
            else
            {
                trvAderencia.Nodes.Clear();
                ddlAderencia.SelectedIndex = 0;
                grvProdutosAtratividade.DataSource = null;
                grvProdutosAtratividade.DataBind();
                txtCatProduto.Text = string.Empty;
                txtAderenciaCalculada.Text = string.Empty;
                lkAderenciaProduto.Enabled = false;
                lkbAderenciaProdutoFilhos.Enabled = false;
            }
        }

        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            ImageButton btnSelecionar = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnSelecionar.NamingContainer;
            dadosVersaoProdutoFatorProdutoNivel.VersaoProdutoFator = new VersaoProdutoFator()
            {
                IdVersaoProdutoFator = Convert.ToInt32(grvProdutosAtratividade.DataKeys[grid.RowIndex].Values[0].ToString())
            };
            TextBox1.Text = grvProdutosAtratividade.DataKeys[grid.RowIndex].Values[1].ToString();
            versaoProdutoFatorProdutoNivelLista = oVersaoProdutoFatorProdutoNivel.ListarProduto(dadosVersaoProdutoFatorProdutoNivel);

            trvAderencia.Nodes.Clear();

            for (int i = 0; i < versaoProdutoFatorProdutoNivelLista.Count; i++)
            {
                trvAderencia.Nodes.Add(new TreeNode     
                {
                    Value = versaoProdutoFatorProdutoNivelLista[i].ProdutoNivel.IDProdutoNivel.ToString(),
                    Text = versaoProdutoFatorProdutoNivelLista[i].ProdutoNivel.Nome + " (C)"
                });

            }
        }

        protected void trvAderencia_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (trvAderencia.SelectedNode.ChildNodes.Count == 0)
            {
                if (trvAderencia.SelectedNode.Text.EndsWith("(C)"))
                {
                    dadosProdutoNivel.IDProdutoNivel = Convert.ToInt32(trvAderencia.SelectedValue);
                    dadosProdutoNivel = oProdutoNivel.ListarRelacaoProdutoNivel(dadosProdutoNivel);

                    foreach (RelacaoProdutoNivel list in dadosProdutoNivel.RelacaoProdutoNivelLista)
                    {
                        trvAderencia.SelectedNode.ChildNodes.Add(new TreeNode
                        {
                            Value = list.IdFilho.ToString(),
                            Text = list.Nome.ToString() + " (C)"
                        });
                    }

                    dadosProdutoNivel.IDProdutoNivel = Convert.ToInt32(trvAderencia.SelectedValue);
                    dadosProdutoNivel = oProdutoNivel.ListarRelacaoProdutoNivelProduto(dadosProdutoNivel);

                    foreach (RelacaoProdutoNivelProduto list in dadosProdutoNivel.RelacaoProdutoNivelProdutoLista)
                    {
                        trvAderencia.SelectedNode.ChildNodes.Add(new TreeNode
                        {
                            Value = list.IDProduto.ToString(),
                            Text = list.Nome.ToString() + " (P)"
                        });
                    }
                    trvAderencia.SelectedNode.Expanded = true;
                }
            }
            txtCatProduto.Text = trvAderencia.SelectedNode.Value.ToString() + " - " + trvAderencia.SelectedNode.Text.ToString();
            
            if (trvAderencia.SelectedNode.Text.EndsWith("(P)"))
            {
                lkAderenciaProduto.Enabled = true;
                lkbAderenciaProdutoFilhos.Enabled = false;
                txtAderenciaCalculada.Text = string.Empty;

                dadosProduto.IdProduto = Convert.ToInt32(trvAderencia.SelectedValue);
                dadosProduto.Segmento = new Segmento()
                {
                    IDSegmento = Convert.ToInt32(TextBox1.Text)
                };
                dadosProduto.VersaoProdutoFator = new VersaoProdutoFator()
                {
                    IdVersaoProdutoFator = Convert.ToInt32(ddlVersao.SelectedValue)
                };

                dadosProduto = oProduto.ListarCriterioAderenciaSegmento(dadosProduto);

                if (dadosProduto.CriterioAderencia != null)
                {
                    ddlAderencia.SelectedValue = dadosProduto.CriterioAderencia.IDCriterioAderencia.ToString();
                }
                else
                {
                    ddlAderencia.SelectedIndex = 0;
                }
            }
            else
            {
                lkAderenciaProduto.Enabled = false;
                lkbAderenciaProdutoFilhos.Enabled = true;
                ddlAderencia.SelectedIndex = 0;

                dadosProdutoNivel.Produto = new Produto()
                {
                    IdProduto = Convert.ToInt32(trvAderencia.SelectedValue)
                };
                dadosProdutoNivel.VersaoProdutoFator = new VersaoProdutoFator()
                {
                    IdVersaoProdutoFator = Convert.ToInt32(ddlVersao.SelectedValue)
                };
                dadosProdutoNivel.Segmento = new Segmento()
                {
                    IDSegmento = Convert.ToInt32(TextBox1.Text)
                };

                dadosProdutoNivel = oProdutoNivel.ListarCriterioAderenciaSegmento(dadosProdutoNivel);
                txtAderenciaCalculada.Text = dadosProdutoNivel.Nome;
            }
        }

        protected void lkAderenciaProduto_Click(object sender, EventArgs e)
        {
            dadosProduto.IdProduto = Convert.ToInt32(trvAderencia.SelectedValue);
            dadosProduto.CriterioAderencia = new CriterioAderencia()
            {
                    IDCriterioAderencia = Convert.ToInt32(ddlAderencia.SelectedValue)

            };
            dadosProduto.Segmento = new Segmento()
            {
                IDSegmento = Convert.ToInt32(TextBox1.Text)
            };
            dadosProduto.VersaoProdutoFator = new VersaoProdutoFator()
            {
                IdVersaoProdutoFator = Convert.ToInt32(ddlVersao.SelectedValue)
            };

            oProduto.RemoverCriterioAderenciaSegmento(dadosProduto);
            oProduto.NovoCriterioAderenciaSegmento(dadosProduto);
        }

        protected void lkbAderenciaProdutoFilhos_Click(object sender, EventArgs e)
        {
            dadosProduto.CriterioAderencia = new CriterioAderencia()
            {
                IDCriterioAderencia = Convert.ToInt32(ddlAderencia.SelectedValue)
            };
            dadosProduto.Segmento = new Segmento()
            {
                IDSegmento = Convert.ToInt32(TextBox1.Text)
            };
            dadosProduto.VersaoProdutoFator = new VersaoProdutoFator()
            {
                IdVersaoProdutoFator = Convert.ToInt32(ddlVersao.SelectedValue)
            };

            for (int i = 0; i < trvAderencia.SelectedNode.ChildNodes.Count; i++)
            {
                if (trvAderencia.SelectedNode.ChildNodes[i].Text.EndsWith("(P)"))
                {
                    dadosProduto.IdProduto = Convert.ToInt32(trvAderencia.SelectedNode.ChildNodes[i].Value);
                    oProduto.RemoverCriterioAderenciaSegmento(dadosProduto);
                    oProduto.NovoCriterioAderenciaSegmento(dadosProduto);
                }
            }
        }

        protected void lkbCalcularAderencia_Click(object sender, EventArgs e)
        {
            if (trvAderencia.SelectedNode.Text.EndsWith("(C)"))
            {
                double soma = 0;
                double filhos = 0;
                double conta = 0;
                double resultado = 0;

                for (int i = 0; i < trvAderencia.SelectedNode.ChildNodes.Count; i++)
                {
                    dadosProduto.Segmento = new Segmento()
                    {
                        IDSegmento = Convert.ToInt32(TextBox1.Text)
                    };
                    dadosProduto.VersaoProdutoFator = new VersaoProdutoFator()
                    {
                        IdVersaoProdutoFator = Convert.ToInt32(ddlVersao.SelectedValue)
                    };

                    if (trvAderencia.SelectedNode.ChildNodes[i].Text.EndsWith("(P)"))
                    {
                        dadosProduto.IdProduto = Convert.ToInt32(trvAderencia.SelectedNode.ChildNodes[i].Value);
                        dadosProduto = oProduto.ListarCriterioAderencia(dadosProduto);
                        soma += dadosProduto.valor;
                        filhos++;
                    }
                }
                
                conta = soma / filhos;
                resultado = Math.Round(conta, 0);

                dadosCriterio.LinhaNegocio = new VO.LinhaNegocio();
                dadosCriterio.Valor = Convert.ToInt32(resultado);
                dadosCriterio = oCriterio.ListarAderenciaValor(dadosCriterio);

                dadosProdutoNivel.Produto = new Produto()
                {
                    IdProduto = Convert.ToInt32(trvAderencia.SelectedValue)
                };
                dadosProdutoNivel.CriterioAderencia = new CriterioAderencia()
                {
                    IDCriterioAderencia = dadosCriterio.IDIdCriterioAderencia
                };
                dadosProdutoNivel.Segmento = new Segmento()
                {
                    IDSegmento = Convert.ToInt32(TextBox1.Text)
                };
                dadosProdutoNivel.IDCriterioAderenciaCalculado = Convert.ToInt32(resultado);
                dadosProdutoNivel.VersaoProdutoFator = new VersaoProdutoFator()
                {
                    IdVersaoProdutoFator = Convert.ToInt32(ddlVersao.SelectedValue)
                };
                oProdutoNivel.RemoverCriterioAderenciaSegmento(dadosProdutoNivel);
                oProdutoNivel.NovoCriterioAderenciaSegmento(dadosProdutoNivel);
                txtAderenciaCalculada.Text = dadosCriterio.Nome;
            }
        }
    }
}