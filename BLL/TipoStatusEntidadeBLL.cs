using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class TipoStatusEntidadeBLL
    {
        private TipoStatusEntidadeDAO _tipoStatusEntidade;

        public TipoStatusEntidadeBLL()
        {
            if (_tipoStatusEntidade == null)
                _tipoStatusEntidade = new TipoStatusEntidadeDAO();
        }

        public TipoStatusEntidade Listar(TipoStatusEntidade entidade)
        {
            return _tipoStatusEntidade.Listar(entidade);
        }
    }
}
