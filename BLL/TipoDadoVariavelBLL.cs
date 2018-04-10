using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class TipoDadoVariavelBLL
    {
        private TipoDadoVariavelDAO _tipoDadoVariavel;

        /// <summary>
        /// Initializes a new instance of the TipoDadoVariavel class.
        /// </summary>
        public TipoDadoVariavelBLL()
        {
            if (_tipoDadoVariavel == null)
                _tipoDadoVariavel = new TipoDadoVariavelDAO();
        }

        public TipoDadoVariavel Listar(TipoDadoVariavel entidade)
        {
            return _tipoDadoVariavel.Listar(entidade);
        }

        public List<TipoDadoVariavel> ListarTodos()
        {
            return _tipoDadoVariavel.ListarTodos();
        }
    }
}
