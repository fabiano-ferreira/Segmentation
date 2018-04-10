using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class TipoSaidaBLL
    {
        private TipoSaidaDAO _tipoSaida;

        public TipoSaidaBLL()
        {
            if (_tipoSaida == null)
                _tipoSaida = new TipoSaidaDAO();
        }

        public TipoSaida Listar(TipoSaida entidade)
        {
            return _tipoSaida.Listar(entidade);
        }

        public List<TipoSaida> ListarTodos()
        {
            return _tipoSaida.ListarTodos();
        }
    }
}
