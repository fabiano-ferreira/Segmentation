using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class LogImportacaoEntidadeBLL
    {
        private LogImportacaoEntidadeDAO _logImportacaoEntidade;

        public LogImportacaoEntidadeBLL()
        {
            if (_logImportacaoEntidade == null)
                _logImportacaoEntidade = new LogImportacaoEntidadeDAO();
        }

        public void Novo(LogImportacaoEntidade entidade)
        {
            _logImportacaoEntidade.Novo(entidade);
        }

        public LogImportacaoEntidade Listar(LogImportacaoEntidade entidade)
        {
            return _logImportacaoEntidade.Listar(entidade);
        }

        public List<LogImportacaoEntidade> Listar()
        {
            return _logImportacaoEntidade.Listar();
        }

    }
}
