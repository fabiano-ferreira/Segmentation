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
    public partial class ClasseVariavel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Inicializar();
            }
        }

        public void Inicializar()
        {
            List<VO.ClasseVariavel> dadosClasseVariavelLista = new List<VO.ClasseVariavel>();
            ClasseVariavelBLL oClasseVariavel = new ClasseVariavelBLL();

            dadosClasseVariavelLista = oClasseVariavel.Listar();

            grvClasseVariavel.DataSource = dadosClasseVariavelLista;

            grvClasseVariavel.DataBind();
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            VO.ClasseVariavel dadosClasseVariavel = new VO.ClasseVariavel();
            ClasseVariavelBLL oClasseVariavel = new ClasseVariavelBLL();
            LinhaNegocioBLL oLinhaNegocio = new LinhaNegocioBLL();
            VO.LinhaNegocio dadosLinhaNegocio = new VO.LinhaNegocio();

            dadosLinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            dadosClasseVariavel.Usuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
            dadosClasseVariavel.Nome = txtNome.Text;
            dadosClasseVariavel.Descricao = txtDescricao.Text;
            dadosClasseVariavel.Codigo = txtCodigo.Text;
            
            if (string.IsNullOrEmpty(txtIdClasseVariavel.Text))
            {
                string resultado;
                resultado = oClasseVariavel.Validar(dadosClasseVariavel);

                if (string.IsNullOrEmpty(resultado))
                {
                    oClasseVariavel.Novo(dadosClasseVariavel);
                    dadosLinhaNegocio.ClasseVariavel = dadosClasseVariavel;
                    oLinhaNegocio.NovoClasseVariavel(dadosLinhaNegocio);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:alert('Código de Classe Variável ja Cadastrado.');", true);
                }
            }
            else
            {
                dadosClasseVariavel.IDClasseVariavel = Convert.ToInt32(txtIdClasseVariavel.Text);
                oClasseVariavel.Editar(dadosClasseVariavel);
            }

            txtIdClasseVariavel.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtCodigo.Text = string.Empty;

            Inicializar();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnEdit = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnEdit.NamingContainer;
            txtIdClasseVariavel.Text = grvClasseVariavel.DataKeys[grid.RowIndex].Values[0].ToString();
            txtNome.Text = grvClasseVariavel.DataKeys[grid.RowIndex].Values[1].ToString();
            txtDescricao.Text = grvClasseVariavel.DataKeys[grid.RowIndex].Values[2].ToString();
            txtCodigo.Text = grvClasseVariavel.DataKeys[grid.RowIndex].Values[3].ToString();
        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            VO.LinhaNegocio dadosLinhaNegocio = new VO.LinhaNegocio();
            LinhaNegocioBLL oLinhaNegocio = new LinhaNegocioBLL();

            ImageButton btnExcluir = sender as ImageButton;
            GridViewRow grid = (GridViewRow)btnExcluir.NamingContainer;
            dadosLinhaNegocio = ((Usuario)HttpContext.Current.Session["UsuarioLogado"]).LinhaNegocio;
            dadosLinhaNegocio.ClasseVariavel = new VO.ClasseVariavel() { IDClasseVariavel = Convert.ToInt32(grvClasseVariavel.DataKeys[grid.RowIndex].Value) };

            try
            {
                oLinhaNegocio.RemoverClasseVariavel(dadosLinhaNegocio);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:alert('Impossível excluir esta Classe de Variavel, \\nja existe relação para ela no sistema de Segmentação.');", true);
            }

            Inicializar();
        }
    }
}