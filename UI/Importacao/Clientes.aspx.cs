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

namespace UI.Importacao
{
    public partial class Clientes : System.Web.UI.Page
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

            grvClientes.DataSource = lista;

            grvClientes.DataBind();
        }
    }
}
