using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class RegraLogicaBLL
    {
        private RegraLogicaDAO _regraLogica;

        public RegraLogicaBLL()
        {
            if (_regraLogica == null)
                _regraLogica = new RegraLogicaDAO();
        }

        public void Novo(RegraLogica entidade)
        {
            _regraLogica.Novo(entidade);
        }

        public void Remover(RegraLogica entidade)
        {
            _regraLogica.Remover(entidade);
        }

        public void Editar(RegraLogica entidade)
        {
            _regraLogica.Editar(entidade);
        }

        public List<RegraLogica> Listar()
        {
            return _regraLogica.Listar();
        }

        public RegraLogica Listar(RegraLogica entidade)
        {
            return _regraLogica.Listar(entidade);
        }

        public List<RegraLogica> ListarPorVariavel(RegraLogica entidade)
        {
            return _regraLogica.ListarPorVariavel(entidade);
        }

        public List<VariavelRegraLogica> ListarVariavelLista(RegraLogica entidade)
        {
            return _regraLogica.ListarVariavelLista(entidade); 
        }

        public RegraLogica ValidarVariavel(Variavel entidade)
        {
            return _regraLogica.ValidarVariavel(entidade);
        }
    }
}
