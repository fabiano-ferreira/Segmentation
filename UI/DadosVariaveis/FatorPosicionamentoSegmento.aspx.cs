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

namespace UI.DadosVariaveis
{
    public partial class FatorPosicionamentoSegmento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencheGrid();
            }
        }

        public void PreencheGrid()
        {
            List<KeyValuePair<string, string>> lista = new List<KeyValuePair<string, string>>();
            lista.Add(new KeyValuePair<string, string>("", ""));
            lista.Add(new KeyValuePair<string, string>("", ""));
            lista.Add(new KeyValuePair<string, string>("", ""));
            lista.Add(new KeyValuePair<string, string>("", ""));
            lista.Add(new KeyValuePair<string, string>("", ""));
            lista.Add(new KeyValuePair<string, string>("", ""));
            lista.Add(new KeyValuePair<string, string>("", ""));
            lista.Add(new KeyValuePair<string, string>("", ""));
            lista.Add(new KeyValuePair<string, string>("", ""));

            grvSegmentos.DataSource = lista;

            grvSegmentos.DataBind();

            grvFatoresComuns.DataSource = lista;

            grvFatoresComuns.DataBind();

            grvFatoresVinculados.DataSource = lista;

            grvFatoresVinculados.DataBind();
        }
    }
}