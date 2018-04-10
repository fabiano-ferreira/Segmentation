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
    public partial class ProdutosManutencaoCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarRaiz();   
            }
        }

        protected void CarregarRaiz()
        {
            var categoriasPai = new ProdutoNivelBLL().ListarPais();

            //limpa os possiveis nós já existentes no treeview
            trvCategoria.Nodes[0].ChildNodes.Clear();

            categoriasPai.ForEach(nivel =>
                {
                    //Cria um nó com as informações da categoria
                    var node = new TreeNode();
                    node.Text = nivel.Nome;
                    node.Value = nivel.IDProdutoNivel.ToString();

                    //adciona o nó criado na estrutura do treeview

                    trvCategoria.Nodes[0].ChildNodes.Add(node);
                });
        }
        protected void btnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            grvNivelProduto.DataSource = new ProdutoNivelBLL().ListarNivel();
            grvNivelProduto.DataBind();
            uppGrid.Update();
            mdlCadastro.Show();
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            var produtoNivel = new ProdutoNivel();

            produtoNivel.Nome = txtNome.Text;
            produtoNivel.Usuario = (Usuario)Session["UsuarioLogado"];

            var bizProdutoNivel = new ProdutoNivelBLL();
            
            bizProdutoNivel.Novo(produtoNivel);

            if (!String.IsNullOrEmpty(lblIdCategoria.Text))
            {
                var relacao = new ProdutoNivel();

                relacao.IDProdutoNivel = Convert.ToInt32(lblIdCategoria.Text);
                relacao.IDFilho = produtoNivel.IDProdutoNivel.Value;

                bizProdutoNivel.NovoRelacaoProdutoNivel(relacao);
            }
            CarregarRaiz();
        }

        protected void trvCategoria_SelectedNodeChanged(object sender, EventArgs e)
        {
            var nodeSelecionado = trvCategoria.SelectedNode;

            //verifica se não é a raiz e nem os nós 'pais'
            if (nodeSelecionado.Value != String.Empty && nodeSelecionado.Parent != null)
            {
                nodeSelecionado.ChildNodes.Clear();

                var categoriasFilho = new ProdutoNivelBLL().ListarFilhos(Convert.ToInt32(nodeSelecionado.Value));

                categoriasFilho.ForEach(nivel =>
                    {
                        var node = new TreeNode();
                        node.Value = nivel.IDProdutoNivel.ToString();
                        node.Text = nivel.Nome;

                        nodeSelecionado.ChildNodes.Add(node);
                    });
            }

            txtNome.Text = trvCategoria.SelectedNode.Text;
            uppDadosPai.Update();
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            grvNivelProduto.DataSource = new ProdutoNivelBLL().ListarNivel(txtNome1.Text);
            grvNivelProduto.DataBind();

            uppGrid.Update();
            mdlCadastro.Show();
        }

        protected void chkSeleciona_CheckedChanged(object sender, EventArgs e)
        {
            var check = sender as CheckBox;
            var row = check.NamingContainer as GridViewRow;

            var id = Convert.ToInt32(grvNivelProduto.DataKeys[row.RowIndex].Value.ToString());

            var nivel = new ProdutoNivelBLL().ListarNivel(id);

            lblIdCategoria.Text = nivel.IDProdutoNivel.ToString();
            txtNivelProduto.Text = nivel.Nome;

            uppDadosPai.Update();
            mdlCadastro.Hide();

        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            txtNivelProduto.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtNome1.Text = String.Empty;
            lblId.Text = String.Empty;
            lblIdCategoria.Text = String.Empty;
        }

        protected void lkbExcluir_Click(object sender, EventArgs e)
        {
            var dadosProdutoNivel = new ProdutoNivel();
            var oProdutoNivel = new ProdutoNivelBLL();
            var dadosLinhaNegocio = new VO.LinhaNegocio();
            var oLinhaNegocio = new LinhaNegocioBLL();

            dadosProdutoNivel.IDProdutoNivel = Convert.ToInt32(trvCategoria.SelectedNode.Value);
            dadosProdutoNivel.RelacaoProdutoNivelProduto = new RelacaoProdutoNivelProduto()
            { 
                IDProduto = null
            };
            dadosProdutoNivel.RelacaoProdutoNivel = new RelacaoProdutoNivel() 
            {
                IdRelacaoProdutoNivel = null
            };

            dadosLinhaNegocio.IDLinhaNegocio = null;
            dadosLinhaNegocio.ProdutoNivel = new ProdutoNivel()
            {
                IDProdutoNivel = Convert.ToInt32(trvCategoria.SelectedNode.Value)
            };

            oProdutoNivel.RemoverRelacaoProdutoNivelProduto(dadosProdutoNivel);
            oProdutoNivel.RemoverRelacaoProdutoNivel(dadosProdutoNivel);
            oLinhaNegocio.RemoverProdutoNivel(dadosLinhaNegocio);
            oProdutoNivel.Remover(dadosProdutoNivel);
            CarregarRaiz();
        }
    }
}