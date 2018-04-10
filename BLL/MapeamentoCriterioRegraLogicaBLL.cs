using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;


namespace BLL
{
    public class MapeamentoCriterioRegraLogicaBLL
    {
        private MapeamentoCriterioRegraLogicaDAO _mapeamentoCriterioRegraLogica;

        /// <summary>
        /// Initializes a new instance of the MapeamentoCriterioRegraLogicaBLL class.
        /// </summary>
        public MapeamentoCriterioRegraLogicaBLL()
        {
            if (_mapeamentoCriterioRegraLogica == null)
                _mapeamentoCriterioRegraLogica = new MapeamentoCriterioRegraLogicaDAO();
        }

        public void Novo(MapeamentoCriterioRegraLogica entidade)
        {
            _mapeamentoCriterioRegraLogica.Novo(entidade);
        }

        public void Remover(MapeamentoCriterioRegraLogica entidade)
        {
            _mapeamentoCriterioRegraLogica.Remover(entidade);
        }

        public void Editar(MapeamentoCriterioRegraLogica entidade)
        {
            _mapeamentoCriterioRegraLogica.Editar(entidade);
        }

        public MapeamentoCriterioRegraLogica Listar(MapeamentoCriterioRegraLogica entidade)
        {
            return _mapeamentoCriterioRegraLogica.Listar(entidade);
        }
    }
}
