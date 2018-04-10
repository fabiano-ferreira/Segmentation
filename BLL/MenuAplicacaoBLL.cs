using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class MenuAplicacaoBLL
    {
        private MenuAplicacaoDAO _menuApplicacao;

        public MenuAplicacaoBLL()
        {
            if (_menuApplicacao == null)
                _menuApplicacao = new MenuAplicacaoDAO();
        }

        public List<MenuAplicacao> ListarPermissao(Usuario entidade)
        {
            return _menuApplicacao.ListarPermissao(entidade);
        }
    }
}
