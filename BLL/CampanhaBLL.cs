using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class CampanhaBLL
    {
        private CampanhaDAO _campanha;


        public CampanhaBLL()
        {
            if (_campanha == null)
                _campanha = new CampanhaDAO();
        }

        public void Novo(Campanha entidade) 
        {
            _campanha.Novo(entidade); 
        } 

        public void Remover(Campanha entidade)
        {
            _campanha.Remover(entidade);
        }

        public void Editar(Campanha entidade)
        {
            _campanha.Editar(entidade);
        }

        public List<Campanha> Listar()
        {
            return _campanha.Listar();
        }

        public List<Campanha> ListarRelacaoUsuario(Campanha entidade)
        {
            return _campanha.ListarRelacaoUsuario(entidade);
        }

        public Campanha Listar(Campanha entidade)
        {
            return _campanha.Listar(entidade);
        }

        public List<Campanha> ListarModelo()
        {
            return _campanha.ListarModelo();
        }

        public Campanha ListarModelo(Campanha entidade)
        {
            return _campanha.ListarModelo(entidade);
        }

        public void NovoUsuario(Campanha entidade)
        {
            _campanha.NovoUsuario(entidade);
        }

        public void RemoverUsuario(Campanha entidade)
        {
            _campanha.RemoverUsuario(entidade);
        }

        public List<Usuario> ListarUsuario(Campanha entidade)
        {
            return _campanha.ListarUsuario(entidade);
        }

        public List<Usuario> ListarUsuarioSemRelacao(Campanha entidade)
        {
            return _campanha.ListarUsuarioSemRelacao(entidade);
        }

        public void NovoModelo(Campanha entidade)
        {
            _campanha.NovoModelo(entidade);
        }

        public void ModeloRemover(Campanha entidade)
        {
            _campanha.ModeloRemover(entidade);
        }
    }
}
