using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using VO;

namespace UI
{
    /// <summary>
    /// Summary description for Menu
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Menu : System.Web.Services.WebService
    {
        [WebMethod(EnableSession=true)]
        public string Generate()
        {
            MenuAplicacaoBLL oMenuAplicacao = new MenuAplicacaoBLL();
            List<MenuAplicacao> dadosMenuAplicacao = new List<MenuAplicacao>();
            Usuario dadosUsuario = new Usuario();
            List<MenuAplicacao> dadosMenuFilho = new List<MenuAplicacao>();
            int id = 0;
            string menuModel = String.Empty;
            dadosUsuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];

            dadosMenuAplicacao = oMenuAplicacao.ListarPermissao(dadosUsuario);

            for (int i = 0; i < dadosMenuAplicacao.Count; i++)
            {
                if (dadosMenuAplicacao[i].IdPai == 0)
                {
                    if (string.IsNullOrEmpty(dadosMenuAplicacao[i].Endereco))
                    {
                        id++;
                        menuModel += String.Concat("<li id='", id, "'><a href='#'>", dadosMenuAplicacao[i].Nome, "</a><ul>");

                        for (int j = 0; j < dadosMenuAplicacao.Count; j++)
                        {
                            if (dadosMenuAplicacao[j].IdPai != 0 && dadosMenuAplicacao[j].IdPai == dadosMenuAplicacao[i].IdMenuAplicacao)
                            {
                                if (string.IsNullOrEmpty(dadosMenuAplicacao[j].Endereco))
                                {
                                    id++;
                                    menuModel += String.Concat("<li id='", id, "'><a href='#'>", dadosMenuAplicacao[j].Nome, "</a><ul>");
                                    for (int l = 0; l < dadosMenuAplicacao.Count; l++)
                                    {
                                        if (dadosMenuAplicacao[l].IdPai == dadosMenuAplicacao[j].IdMenuAplicacao)
                                        {
                                            id++;
                                            menuModel += String.Concat("<li id='", id, "'><a href='", dadosMenuAplicacao[l].Endereco, "'>", dadosMenuAplicacao[l].Nome, "</a></li>");
                                        }
                                    }
                                    menuModel += "</ul></li>";
                                }
                                else
                                {
                                    id++;
                                    menuModel += String.Concat("<li id='", id, "'><a href='", dadosMenuAplicacao[j].Endereco, "'>", dadosMenuAplicacao[j].Nome, "</a></li>");
                                }
                            }
                        }
                        id++;
                        menuModel += String.Concat("</ul></li><li id='", id, "' itemtype='separator'></li>");

                    }
                    else
                    {
                        menuModel += String.Concat("<li id='", id, "'><a href=", dadosMenuAplicacao[i].Endereco, ">", dadosMenuAplicacao[i].Nome, "</a></li>");
                    }
                }
            }

            return menuModel;
        }
    }
}
