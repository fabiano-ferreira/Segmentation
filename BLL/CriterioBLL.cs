using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class CriterioBLL
    {
        private CriterioDAO _criterio ;

        public CriterioBLL()
        {
            if (_criterio == null)
                _criterio = new CriterioDAO();
        }

        public void Novo(Criterio entidade)
        {
            _criterio.Novo(entidade);
        }

        public void Remover(Criterio entidade)
        {
            _criterio.Remover(entidade);
        }

        public void Editar(Criterio entidade)
        {
            _criterio.Editar(entidade);
        }

        public Criterio Listar(Criterio entidade)
        {
            return _criterio.Listar(entidade);
        }

        public List<Criterio> Listar()
        {
            return _criterio.Listar();
        }

        public void NovoAderencia(Criterio entidade)
        {
            _criterio.NovoAderencia(entidade);
        }

        public void RemoverAderencia(Criterio entidade)
        {
            _criterio.RemoverAderencia(entidade);
        }

        public void EditarFator(Criterio entidade)
        {
            _criterio.EditarFator(entidade);
        }

        public void NovoFator(Criterio entidade)
        {
            _criterio.NovoFator(entidade);
        }

        public void RemoverFator(Criterio entidade)
        {
            _criterio.RemoverFator(entidade);
        }

        public void EditarVariavel(Criterio entidade)
        {
            _criterio.EditarVariavel(entidade);
        }

        public void NovoVariavel(Criterio entidade)
        {
            _criterio.NovoVariavel(entidade);
        }

        public void RemoverVariavel(Criterio entidade)
        {
            _criterio.RemoverVariavel(entidade);
        }

        public Criterio ListarFator(Criterio entidade)
        {
            return _criterio.ListarFator(entidade);
        }

        public Criterio ListarVariavel(Criterio entidade)
        {
            return _criterio.ListarVariavel(entidade);
        }

        public List<Criterio> ListarVariavelLista(Criterio entidade)
        {
            return _criterio.ListarVariavelLista(entidade);
        }

        public Criterio ListarVariavelImportacao(Criterio entidade)
        {
            return _criterio.ListarVariavelImportacao(entidade);
        }

        public List<Criterio> ListarRelacaoFator(Criterio entidade)
        {
            return _criterio.ListarRelacaoFator(entidade);
        }

        public List<Criterio> ListarSemRelacaoFator(Criterio entidade)
        {
            return _criterio.ListarSemRelacaoFator(entidade);
        }

        public List<Criterio> ListarAderencia(Criterio entidade)
        {
            return _criterio.ListarAderencia(entidade);
        }

        public List<Criterio> RelacaoVariavelListar(Criterio entidade)
        {
            return _criterio.RelacaoVariavelListar(entidade);
        }

        public List<Criterio> RelacaoSemVariavelListar(Criterio entidade)
        {
            return _criterio.RelacaoSemVariavelListar(entidade);
        }

        public List<Criterio> ListarRelacaoLinhaNegocio(Criterio entidade)
        {
            return _criterio.ListarRelacaoLinhaNegocio(entidade);
        }

        public Criterio ListarAderenciaValor(Criterio entidade)
        {
            return _criterio.ListarAderenciaValor(entidade);
        }

        public List<Criterio> ListarLinhaNegocio(Criterio entidade)
        {
            return _criterio.ListarLinhaNegocio(entidade);
        }
    }
}
