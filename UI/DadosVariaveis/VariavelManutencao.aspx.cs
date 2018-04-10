using System;
using System.Collections;
using System.Collections.Generic;
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

namespace UI.DadosVariaveis
{
    public partial class VariavelManutencao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlTipoSaida.Enabled = true;
            ddlTipoDado.Enabled = true;

            if (!IsPostBack)
            {
                List<Variavel> dadosVariavel = new List<Variavel>();
                HttpContext.Current.Session["ListaVariavel"] = dadosVariavel;
                Inicializar();
                txtOrdem.Text = "0";
            }
        }

        public void Inicializar()
        {
            VO.Campanha dadosCampanha = new VO.Campanha();
            BLL.CampanhaBLL oCampanha = new BLL.CampanhaBLL();
            TipoSaidaBLL oTipoSaida = new TipoSaidaBLL();
            TipoDadoVariavelBLL oTipoDadosVariavel = new TipoDadoVariavelBLL();
            TipoVariavelBLL oTipoVariavel = new TipoVariavelBLL();
            ClasseVariavelBLL oClasseVariavel = new ClasseVariavelBLL();

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

            ddlTipoSaida.DataSource = oTipoSaida.ListarTodos();
            ddlTipoSaida.DataTextField = "Nome";
            ddlTipoSaida.DataValueField = "IDTipoSaida";
            ddlTipoSaida.DataBind();
            ddlTipoSaida.Items.Insert(0, "");
            ddlTipoSaida.SelectedIndex = 0;

            ddlTipoDado.DataSource = oTipoDadosVariavel.ListarTodos();
            ddlTipoDado.DataTextField = "Nome";
            ddlTipoDado.DataValueField = "IDTipoDadoVariavel";
            ddlTipoDado.DataBind();
            ddlTipoDado.Items.Insert(0, "");
            ddlTipoDado.SelectedIndex = 0;

            ddlTipoVariavel.DataSource = oTipoVariavel.ListarTodos();
            ddlTipoVariavel.DataTextField = "Nome";
            ddlTipoVariavel.DataValueField = "IDTipoVariavel";
            ddlTipoVariavel.DataBind();
            ddlTipoVariavel.Items.Insert(0, "");
            ddlTipoVariavel.SelectedIndex = 0;

            ddlClasseVariavel.DataSource = oClasseVariavel.Listar();
            ddlClasseVariavel.DataTextField = "Nome";
            ddlClasseVariavel.DataValueField = "IDClasseVariavel";
            ddlClasseVariavel.DataBind();
            ddlClasseVariavel.Items.Insert(0, "");
            ddlClasseVariavel.SelectedIndex = 0;
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

        public void LimpaCampos()
        {
            ddlClasseVariavel.SelectedIndex = 0;
            ddlTipoVariavel.SelectedIndex = 0;
            ddlTipoSaida.SelectedIndex = 0;
            ddlTipoDado.SelectedIndex = 0;
            txtDescricao.Text = string.Empty;
            txtDescricao2.Text = string.Empty;
            txtMetodoCientifico.Text = string.Empty;
            txtMetodoPratico.Text = string.Empty;
            txtPerguntaPesquisa.Text = string.Empty;
            txtInteligenciaSistemica.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtColunaImportacao.Text = string.Empty;
            txtVariavelPai.Text = string.Empty;
            txtIdVariavelPai.Text = string.Empty;
            txtIdVariavel.Text = string.Empty;
        }

        protected void Swap(TreeNode node, Variavel valor)
        {
            if (valor.IdPai == 0)
            {
                node.ChildNodes.Add((new TreeNode(valor.Codigo + " - " + valor.Descricao, valor.IDVariavel.ToString())));
            }
            else
            {
                if (node.ChildNodes.Count > 0)
                {
                    foreach (TreeNode child in node.ChildNodes)
                    {
                        if (child.Value == valor.IdPai.ToString())
                        {
                            child.ChildNodes.Add(new TreeNode(valor.Codigo + " - " + valor.Descricao, valor.IDVariavel.ToString()));
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
                        node.ChildNodes.Add(new TreeNode(valor.Codigo + " - " + valor.Descricao, valor.IDVariavel.ToString()));
                        return;
                    }
                    return;
                }
            }
        }

        protected void ddlCampanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencheModelo();
        }

        protected void lkbPesquisarRegras_Click(object sender, EventArgs e)
        {
            CriterioBLL bizCriterio = new CriterioBLL();
            Criterio criterio = new Criterio();
            VariavelBLL oVariavel = new VariavelBLL();
            Variavel dadosVariavel = new Variavel();
            TipoOperadorCalculoBLL oTipoOperador = new TipoOperadorCalculoBLL();

            dadosVariavel.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
            dadosVariavel.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;


            dadosVariavel.IDVariavel = Convert.ToInt32(txtIdVariavel.Text);

            ltbVariaveis.DataSource = oVariavel.ListarRelacao(dadosVariavel);
            ltbVariaveis.DataTextField = "Descricao";
            ltbVariaveis.DataValueField = "IdFilho";
            ltbVariaveis.DataBind();

            criterio.Variavel = new Variavel() { IDVariavel = Convert.ToInt32(txtIdVariavel.Text) };
            criterio.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

            ddlResultadoRegra.DataSource = bizCriterio.RelacaoVariavelListar(criterio);
            ddlResultadoRegra.DataValueField = "IDCriterio";
            ddlResultadoRegra.DataTextField = "Nome";
            ddlResultadoRegra.DataBind();
            ddlResultadoRegra.Items.Insert(0,"");
            ddlResultadoRegra.SelectedIndex = 0;

            mdlRegras.Show();
        }

        protected void lkbPesquisarCalculo_Click(object sender, EventArgs e)
        {
            VariavelBLL oVariavel = new VariavelBLL();
            Variavel dadosVariavel = new Variavel();
            TipoOperadorCalculoBLL oTipoOperador = new TipoOperadorCalculoBLL();

            dadosVariavel.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
            dadosVariavel.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            dadosVariavel.IDVariavel = Convert.ToInt32(txtIdVariavel.Text);
            ddlVariavelSelecionada.DataSource = oVariavel.ListarRelacao(dadosVariavel);
            ddlVariavelSelecionada.DataTextField = "Descricao";
            ddlVariavelSelecionada.DataValueField = "IdFilho";
            ddlVariavelSelecionada.DataBind();
            ddlVariavelSelecionada.Items.Insert(0, "");
            ddlVariavelSelecionada.SelectedIndex = 0;

            ddlOperador.DataSource = oTipoOperador.Listar();
            ddlOperador.DataValueField = "IDTipoOperadorCalculo";
            ddlOperador.DataTextField = "Simbolo";
            ddlOperador.DataBind();
            ddlOperador.Items.Insert(0, "");
            ddlOperador.SelectedIndex = 0;

            
            txtCodigoVariavel.Text = txtCodigo.Text;
            txtNomeVariavel.Text = txtDescricao.Text;
            
            mdlCalculo.Show();
        }

        protected void lkbListaVariavel_Click(object sender, EventArgs e)
        {
            Variavel dadosVariavel = new Variavel();
            VariavelBLL oVariavel = new VariavelBLL();
            List<Variavel> dadosVariavelLista = new List<Variavel>();
            dadosVariavel.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
            dadosVariavel.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

            dadosVariavelLista = oVariavel.ListarLinhaNegocioModelo(dadosVariavel);
            trvVariavel.Nodes[0].ChildNodes.Clear();

            for (int i = 0; i < dadosVariavelLista.Count; i++)
            {
                Swap(trvVariavel.Nodes[0], dadosVariavelLista[i]);
                //TreeNode tnVariavel = new TreeNode();
                //tnVariavel.Value = dadosVariavelLista[i].IDVariavel.ToString();
                //tnVariavel.Text = string.Concat(dadosVariavelLista[i].Codigo, " - ", dadosVariavelLista[i].Descricao);
                //trvVariavel.Nodes[0].ChildNodes.Add(tnVariavel);
            }
            HttpContext.Current.Session["ListaVariavel"] = dadosVariavelLista;
            LimpaCampos();
        }

        protected void btnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            mdlVariavel.Show();
        }

        protected void lkbCancelarModal_Click1(object sender, EventArgs e)
        {
            mdlVariavel.Hide();
            grvVariavel.DataSource = null;
            grvVariavel.DataBind();
            txtNomeFiltro.Text = string.Empty;
            txtCodigoFiltro.Text = string.Empty;
        }

        protected void lkbPesquisar1_Click(object sender, EventArgs e)
        {
            Variavel dadosVariavel = new Variavel();
            VariavelBLL oVariavel = new VariavelBLL();

            dadosVariavel.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
            dadosVariavel.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            if (!string.IsNullOrEmpty(txtCodigoFiltro.Text))
            {
                dadosVariavel.Codigo = txtCodigoFiltro.Text;
            }
            if (!string.IsNullOrEmpty(txtNomeFiltro.Text))
            {
                dadosVariavel.Descricao = txtNomeFiltro.Text;
            }

            grvVariavel.DataSource = oVariavel.ListarModelo(dadosVariavel);
            grvVariavel.DataBind();
            uppVariavel.Update();
        }

        protected void rdbVariavel_CheckedChanged(Object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            GridViewRow gvRow = (GridViewRow)radioButton.NamingContainer;
            List<Variavel> dadosVariavelLista = new List<Variavel>();
            Variavel dadosVariavel = new Variavel();
            VariavelBLL oVariavel = new VariavelBLL();
            txtIdVariavelPai.Text = grvVariavel.DataKeys[gvRow.RowIndex].Values[0].ToString();
            txtVariavelPai.Text = grvVariavel.DataKeys[gvRow.RowIndex].Values[1].ToString();

            dadosVariavelLista = ((List<Variavel>)HttpContext.Current.Session["ListaVariavel"]);
            dadosVariavel = oVariavel.GeraCodigo(dadosVariavelLista, txtIdVariavelPai.Text);
            txtCodigo.Text = dadosVariavel.Codigo;

            HttpContext.Current.Session["ListaVariavelFilho"] = dadosVariavel;
                     
            grvVariavel.DataSource = null;
            grvVariavel.DataBind();
            mdlVariavel.Hide();
            uppVariavel.Update();
            uppCodigo.Update();
        }

        protected void lkbNovaVariavel_Click(object sender, EventArgs e)
        {
            List<Variavel> dadosVariavelLista = new List<Variavel>();
            Variavel dadosVariavel = new Variavel();
            VariavelBLL oVariavel = new VariavelBLL();

            if (HttpContext.Current.Session["ListaVariavelFilho"] == null)
            {
                HttpContext.Current.Session["ListaVariavelFilho"] = new Variavel();
            }

            dadosVariavelLista = (List<Variavel>)HttpContext.Current.Session["ListaVariavel"];
            
            dadosVariavel.Usuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
            dadosVariavel.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
            dadosVariavel.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            dadosVariavel.TipoDadoVariavel = new TipoDadoVariavel() { IDTipoDadoVariavel = Convert.ToInt32(ddlTipoDado.SelectedValue) };
            dadosVariavel.TipoSaida = new TipoSaida() { IDTipoSaida = Convert.ToInt32(ddlTipoSaida.SelectedValue) };
            dadosVariavel.TipoVariavel = new TipoVariavel() { IDTipoVariavel = Convert.ToInt32(ddlTipoVariavel.SelectedValue) };
            dadosVariavel.ClasseVariavel = new ClasseVariavel() { IDClasseVariavel = Convert.ToInt32(ddlClasseVariavel.SelectedValue) };

            if (ddlTipoDado.SelectedValue == "1")
            {
                dadosVariavel.ColunaImportacao = Convert.ToInt32(txtColunaImportacao.Text);
            }

            if (!string.IsNullOrEmpty(txtIdVariavelPai.Text))
            {
                dadosVariavel.IdPai = Convert.ToInt32(txtIdVariavelPai.Text);
            }

            dadosVariavel.Descricao = txtDescricao.Text;
            dadosVariavel.Comentario = txtDescricao2.Text;
            dadosVariavel.MetodoCientificoObtencao = txtMetodoCientifico.Text;
            dadosVariavel.MetodoPraticoObtencao = txtMetodoPratico.Text;
            dadosVariavel.PerguntaSistema = txtPerguntaPesquisa.Text;
            dadosVariavel.InteligenciaSistemicaModelo = txtPerguntaPesquisa.Text;
            
            try
            {
                if (ddlTipoSaida.SelectedValue == "3" && string.IsNullOrEmpty(txtIdVariavel.Text))
                {
                    dadosVariavel.Codigo = oVariavel.GeraCodigoOutput(dadosVariavelLista, dadosVariavel);
                }
                else
                {
                    oVariavel.ValidaTipoSaida(dadosVariavelLista, dadosVariavel);
                    dadosVariavel.Codigo = txtCodigo.Text;
                }
                if (!string.IsNullOrEmpty(txtIdVariavel.Text))
                {
                    dadosVariavel.IDVariavel = Convert.ToInt32(txtIdVariavel.Text);
                    dadosVariavel.Status = 2;

                    for (int i = 0; i < dadosVariavelLista.Count; i++)
                    {
                        if (dadosVariavelLista[i].IDVariavel == dadosVariavel.IDVariavel)
                        {
                            dadosVariavelLista[i] = dadosVariavel;
                        }
                    }
                }
                else
                {
                    dadosVariavel.Status = 1;
                    dadosVariavelLista.Add(dadosVariavel);
                    Swap(trvVariavel.Nodes[0], dadosVariavel);



                    dadosVariavel = (Variavel)HttpContext.Current.Session["ListaVariavelFilho"];
                    for (int i = 0; i < dadosVariavelLista.Count; i++)
                    {
                        if (dadosVariavelLista[i].IDVariavel == dadosVariavel.IdPai)
                        {
                            dadosVariavelLista[i].VariavelFilho.Add(dadosVariavel);
                        }
                    }
                }
                trvVariavel.Nodes[0].ChildNodes.Clear();
                for (int i = 0; i < dadosVariavelLista.Count; i++)
                {
                    Swap(trvVariavel.Nodes[0], dadosVariavelLista[i]);
                    //TreeNode tnVariavel = new TreeNode();
                    //tnVariavel.Value = dadosVariavelLista[i].IDVariavel.ToString();
                    //tnVariavel.Text = string.Concat(dadosVariavelLista[i].Codigo, " - ", dadosVariavelLista[i].Descricao);
                    //trvVariavel.Nodes[0].ChildNodes.Add(tnVariavel);
                }
                LimpaCampos();
            }
            catch(BLL.Exceptions.VariavelInvalida ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "alert('" + ex.Message + "');", true);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void ddlTipoSaida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoSaida.SelectedValue != "3")
            {
                rfvVarPai.Enabled = true;
                btnPesquisar.Enabled = true;
            }
            else
            {
                btnPesquisar.Enabled = false;
                rfvVarPai.Enabled = false;
            }
        }

        protected void ddlTipoDado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoDado.SelectedValue == "1")
            {
                rfvImportacao.Enabled = true;
                txtColunaImportacao.Enabled = true;
                lkbPesquisarCalculo.Enabled = false;
                lkbPesquisarRegras.Enabled = false;
            }
            else if (ddlTipoDado.SelectedValue == "2")
            {
                lkbPesquisarRegras.Enabled = true;
                rfvImportacao.Enabled = false;
                txtColunaImportacao.Enabled = false;
                lkbPesquisarCalculo.Enabled = false;
            }
            else
            {
                lkbPesquisarCalculo.Enabled = true;
                rfvImportacao.Enabled = false;
                txtColunaImportacao.Enabled = false;
                lkbPesquisarRegras.Enabled = false;
            }
        }

        protected void AdicionarItem_Click(object sender, EventArgs e)
        {
            VariavelCalculoVariavel dadosCalculoVariavel = new VariavelCalculoVariavel ();
            if (HttpContext.Current.Session["CalculoVariavel"] == null)
            {
                HttpContext.Current.Session["CalculoVariavel"] = new List<VariavelCalculoVariavel>();
            }

            int ordem = 0;
            ordem = Convert.ToInt32(txtOrdem.Text);
            ordem++;
            txtOrdem.Text = ordem.ToString();

            ddlVariavelSelecionada.Items[ddlVariavelSelecionada.SelectedIndex].Value = ddlVariavelSelecionada.SelectedValue.Replace("/u", "");

            if (ddlOperador.SelectedIndex != 0)
            {
                ((List<VariavelCalculoVariavel>)HttpContext.Current.Session["CalculoVariavel"]).Add(new VariavelCalculoVariavel()
                {
                    Variavel = new Variavel() { IDVariavel = Convert.ToInt32(ddlVariavelSelecionada.SelectedValue) },
                    TipoOperadorCalculo = new TipoOperadorCalculo() { IDTipoOperadorCalculo = Convert.ToInt32(ddlOperador.SelectedValue) },
                    OrdemOperacao = ordem,
                    AbreParentese = ckbAbrePar.Checked,
                    FechaParentese = ckbFechaPar.Checked
                });
            }
            else
            {
                dadosCalculoVariavel.Variavel = new Variavel() { IDVariavel = Convert.ToInt32(ddlVariavelSelecionada.SelectedValue) };
                if (!string.IsNullOrEmpty(ddlOperador.SelectedValue))
                {
                    dadosCalculoVariavel.TipoOperadorCalculo = new TipoOperadorCalculo() { IDTipoOperadorCalculo = Convert.ToInt32(ddlOperador.SelectedValue) };
                }
                else
                {
                    dadosCalculoVariavel.TipoOperadorCalculo = new TipoOperadorCalculo();
                }
                dadosCalculoVariavel.OrdemOperacao = ordem;
                dadosCalculoVariavel.AbreParentese = ckbAbrePar.Checked;
                dadosCalculoVariavel.FechaParentese = ckbFechaPar.Checked;
                ((List<VariavelCalculoVariavel>)HttpContext.Current.Session["CalculoVariavel"]).Add(dadosCalculoVariavel);
            }
            if (ckbAbrePar.Checked == true)
            {
                txtCalculoFinal.Text += "(";
            }

            txtCalculoFinal.Text += string.Concat(ddlOperador.SelectedItem.Text, ddlVariavelSelecionada.SelectedItem.Text);

            if (ckbFechaPar.Checked == true)
            {
                txtCalculoFinal.Text += ")";
            }

            ddlVariavelSelecionada.Items[ddlVariavelSelecionada.SelectedIndex].Value += "/u";

            ckbAbrePar.Checked = false;
            ckbFechaPar.Checked = false;
            ddlOperador.SelectedIndex = 0;
            ddlVariavelSelecionada.SelectedIndex = 0;
            uppCalculo.Update();
        }

        protected void btnRemoverItem_Click(object sender, EventArgs e)
        {
            Session.Remove("CalculoVariavel");
            txtCalculoFinal.Text = string.Empty;
            uppCalculo.Update();
        }

        protected void lkbFecharCalculo_Click(object sender, EventArgs e)
        {
            Session.Remove("CalculoVariavel");
            txtCalculoFinal.Text = string.Empty;
            mdlCalculo.Hide();
        }

        protected void ddlOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCalculoFinal.Text) && ddlOperador.SelectedIndex != 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Primeira variável não pode possuir operadores.');", true);
                ddlOperador.SelectedIndex = 0;
            }
        }

        protected void lkbFecharRegras_Click(object sender, EventArgs e)
        {
            mdlRegras.Hide();
        }

        protected void lkbSalvarVariavel_Click(object sender, EventArgs e)
        {
            List<Variavel> dadosVariavelLista = new List<Variavel>();
            VariavelBLL oVariavel = new VariavelBLL();
            Variavel dadosVariavel = new Variavel();
            dadosVariavel.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
            dadosVariavel.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

            dadosVariavelLista = (List<Variavel>)HttpContext.Current.Session["ListaVariavel"];

            try
            {
                oVariavel.Persistir(dadosVariavelLista);
                dadosVariavelLista = oVariavel.ListarLinhaNegocioModelo(dadosVariavel);
                trvVariavel.Nodes[0].ChildNodes.Clear();
                for (int i = 0; i < dadosVariavelLista.Count; i++)
                {
                    Swap(trvVariavel.Nodes[0], dadosVariavelLista[i]);
                    //TreeNode tnVariavel = new TreeNode();
                    //tnVariavel.Value = dadosVariavelLista[i].IDVariavel.ToString();
                    //tnVariavel.Text = string.Concat(dadosVariavelLista[i].Codigo, " - ", dadosVariavelLista[i].Descricao);
                    //trvVariavel.Nodes[0].ChildNodes.Add(tnVariavel);
                }
                HttpContext.Current.Session["ListaVariavel"] = dadosVariavelLista;
                LimpaCampos();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void ddlModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Variavel dadosVariavel = new Variavel();
            VariavelBLL oVariavel = new VariavelBLL();
            List<Variavel> dadosVariavelLista = new List<Variavel>();
            dadosVariavel.Modelo = new Modelo() { IDModelo = Convert.ToInt32(ddlModelo.SelectedValue) };
            dadosVariavel.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

            dadosVariavelLista = oVariavel.ListarLinhaNegocioModelo(dadosVariavel);
            trvVariavel.Nodes[0].ChildNodes.Clear();

            for (int i = 0; i < dadosVariavelLista.Count; i++)
            {
                Swap(trvVariavel.Nodes[0], dadosVariavelLista[i]);
            }
            HttpContext.Current.Session["ListaVariavel"] = dadosVariavelLista;      
        }

        protected void trvVariavel_SelectedNodeChanged(object sender, EventArgs e)
        {
            List<Variavel> dadosVariavelLista = new List<Variavel>();
            
            dadosVariavelLista = (List<Variavel>)HttpContext.Current.Session["ListaVariavel"];

            LimpaCampos();

            for (int i = 0; i < dadosVariavelLista.Count; i++)
            {
                if (dadosVariavelLista[i].IDVariavel.ToString() == trvVariavel.SelectedNode.Value)
                {
                    ddlClasseVariavel.SelectedValue = dadosVariavelLista[i].ClasseVariavel.IDClasseVariavel.ToString();
                    ddlTipoVariavel.SelectedValue = dadosVariavelLista[i].TipoVariavel.IDTipoVariavel.ToString();
                    ddlTipoSaida.SelectedValue = dadosVariavelLista[i].TipoSaida.IDTipoSaida.ToString();
                    ddlTipoDado.SelectedValue = dadosVariavelLista[i].TipoDadoVariavel.IDTipoDadoVariavel.ToString();
                    txtDescricao.Text = dadosVariavelLista[i].Descricao;
                    txtDescricao2.Text = dadosVariavelLista[i].Comentario;
                    txtMetodoCientifico.Text = dadosVariavelLista[i].MetodoCientificoObtencao;
                    txtMetodoPratico.Text = dadosVariavelLista[i].MetodoPraticoObtencao;
                    txtPerguntaPesquisa.Text = dadosVariavelLista[i].PerguntaSistema;
                    txtInteligenciaSistemica.Text = dadosVariavelLista[i].InteligenciaSistemicaModelo;
                    txtCodigo.Text = dadosVariavelLista[i].Codigo;
                    txtColunaImportacao.Text = dadosVariavelLista[i].ColunaImportacao.ToString();
                    txtIdVariavel.Text = dadosVariavelLista[i].IDVariavel.ToString();
                    if (dadosVariavelLista[i].IdPai != 0)
                    {
                        txtIdVariavelPai.Text = dadosVariavelLista[i].IdPai.ToString();
                        for (int j = 0; j < dadosVariavelLista.Count; j++)
                        {
                            if (dadosVariavelLista[j].IDVariavel == dadosVariavelLista[i].IdPai)
                            {
                                txtVariavelPai.Text = dadosVariavelLista[j].Descricao;
                            }
                        }
                    }
                    if (ddlTipoDado.SelectedValue == "1")
                    {
                        txtColunaImportacao.Enabled = true;
                        lkbPesquisarRegras.Enabled = false;
                        lkbPesquisarCalculo.Enabled = false;
                    }
                    else if (ddlTipoDado.SelectedValue == "2")
                    {
                        lkbPesquisarRegras.Enabled = true;
                        lkbPesquisarCalculo.Enabled = false;
                        txtColunaImportacao.Enabled = false;
                    }
                    else if (ddlTipoDado.SelectedValue == "3")
                    {
                        lkbPesquisarCalculo.Enabled = true;
                        lkbPesquisarRegras.Enabled = false;
                        txtColunaImportacao.Enabled = false;
                    }
                }
            }
            ddlTipoSaida.Enabled = false;
            ddlTipoDado.Enabled = false;
        }

        protected void lkbSalvarCalculo_Click(object sender, EventArgs e)
        {
            CalculoVariavel dadosCalculoVariavel = new CalculoVariavel();
            List<VariavelCalculoVariavel> dadosVariavelCalculoVariavel = new List<VariavelCalculoVariavel>();
            CalculoVariavelBLL oCalculoVariavel = new CalculoVariavelBLL();
            VariavelCalculoVariavelBLL oVariavelCalculoVariavel = new VariavelCalculoVariavelBLL();

            for (int i = 0; i < ddlVariavelSelecionada.Items.Count; i++)
            {
                if (!ddlVariavelSelecionada.Items[i].Value.EndsWith("/u") && ddlVariavelSelecionada.Items[i].Value != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Todas as Variáveis abaixo de " + txtDescricao.Text + "\\n devem ser utilizadas no calculo');", true);
                    return;
                }
            }
            dadosCalculoVariavel.Usuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
            dadosCalculoVariavel.Variavel = new Variavel() { IDVariavel = Convert.ToInt32(txtIdVariavel.Text) };

            oCalculoVariavel.Novo(dadosCalculoVariavel);

            dadosVariavelCalculoVariavel = (List<VariavelCalculoVariavel>)HttpContext.Current.Session["CalculoVariavel"];

            for (int i = 0; i < dadosVariavelCalculoVariavel.Count; i++)
            {
                dadosVariavelCalculoVariavel[i].CalculoVariavel = dadosCalculoVariavel;
                oVariavelCalculoVariavel.Novo(dadosVariavelCalculoVariavel[i]);
            }

            Session.Remove("CalculoVariavel");
            mdlCalculo.Hide();
            txtOrdem.Text = string.Empty;
            LimpaCampos();
        }

        protected void rbtnValor_CheckedChanged(object sender, EventArgs e)
        {
            txtValor.Enabled = true;
            ddlCriterio.Enabled = false;
            if (ddlCriterio.Items.Count > 0)
            {
                ddlCriterio.SelectedIndex = 0;
            }
        }

        protected void rbtnCriterio_CheckedChanged(object sender, EventArgs e)
        {
            ddlCriterio.Enabled = true;
            txtValor.Enabled = false;
            txtValor.Text = string.Empty;
        }

        protected void ltbVariaveis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Criterio criterio = new Criterio();
            CriterioBLL bizCriterio = new CriterioBLL();

            criterio.Variavel = new Variavel() { IDVariavel = Convert.ToInt32(ltbVariaveis.SelectedValue) };
            criterio.LinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;

            ddlCriterio.DataSource = bizCriterio.RelacaoVariavelListar(criterio);
            ddlCriterio.DataValueField = "IDCriterio";
            ddlCriterio.DataTextField = "Nome";
            ddlCriterio.DataBind();
            ddlCriterio.Items.Insert(0, "");

            uppRegraLogica.Update();
        }

        protected void ResultadoRegra_CheckedChanged(object sender, EventArgs e)
        {
            btnPesquisarMapeamento.Enabled = false;
            ddlResultadoRegra.Enabled = true;
        }

        protected void ResultadoMapeamento_CheckedChanged(object sender, EventArgs e)
        {
            btnPesquisarMapeamento.Enabled = true;
            ddlResultadoRegra.Enabled = false;
            if (ddlResultadoRegra.Items.Count > 0)
            {
                ddlResultadoRegra.SelectedIndex = 0;
            }
        }

        protected void txtValor_TextChanged(object sender, EventArgs e)
        {
            
        }


    }
}
