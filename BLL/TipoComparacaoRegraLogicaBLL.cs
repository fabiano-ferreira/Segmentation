using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class TipoComparacaoRegraLogicaBLL
    {
        private TipoComparacaoRegraLogicaDAO _tipoComparacaoRegraLogica;

        /// <summary>
        /// Initializes a new instance of the TipoComparacaoRegraLogicaBLL class.
        /// </summary>
        public TipoComparacaoRegraLogicaBLL()
        {
            if (_tipoComparacaoRegraLogica == null)
                _tipoComparacaoRegraLogica = new TipoComparacaoRegraLogicaDAO();
        }

        public TipoComparacaoRegraLogica Listar(TipoComparacaoRegraLogica entidade)
        {
            return _tipoComparacaoRegraLogica.Listar(entidade);
        }

        
    }
}
