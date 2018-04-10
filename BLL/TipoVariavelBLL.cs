using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class TipoVariavelBLL
    {
        private TipoVariavelDAO _tipoVariavel;

        public TipoVariavelBLL()
        {
            if (_tipoVariavel == null)
                _tipoVariavel = new TipoVariavelDAO();
        }

        public TipoVariavel Listar(TipoVariavel entidade)
        {
            return _tipoVariavel.Listar(entidade);
        }

        public List<TipoVariavel> ListarTodos()
        {
            return _tipoVariavel.ListarTodos();
        }
    }
}
