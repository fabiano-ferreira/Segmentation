using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class LogNovoBLL
    {
        private LogNovoDAO _logNovo;

        public LogNovoBLL()
        {
            if (_logNovo == null)
                _logNovo = new LogNovoDAO();
        }

        public void Novo(LogNovo entidade)
        {
            _logNovo.Novo(entidade);
        }
    }
}
