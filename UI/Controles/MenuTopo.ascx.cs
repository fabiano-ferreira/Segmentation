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
using BLL;
using VO;
using System.Collections.Generic;
using System.Web.Script;
using System.Web.Services;

namespace UI.Controles
{
    public partial class MenuTopo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario dadosUsuario = new Usuario();
            dadosUsuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
            lblUsuario.Text = dadosUsuario.Nome;
        }
    }

}