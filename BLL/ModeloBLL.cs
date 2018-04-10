using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class ModeloBLL
    {
        private ModeloDAO _modelo;

        public ModeloBLL()
        {
            if (_modelo == null)
                _modelo = new ModeloDAO();
        }

        public void Novo(Modelo entidade)
        {
            _modelo.Novo(entidade);
        }

        public void Remover(Modelo entidade)
        {
            _modelo.Remover(entidade);
        }

        public void Editar(Modelo entidade)
        {
            _modelo.Editar(entidade);
        }

        public Modelo Listar(Modelo entidade)
        {
            return _modelo.Listar(entidade);
        }

        public List<Modelo> Listar()
        {
            return _modelo.Listar();
        }

        public Modelo ListarFator(Modelo entidade)
        {
            return _modelo.ListarFator(entidade);
        }

        public List<Modelo> ListarFator()
        {
            return _modelo.ListarFator();
        }

        public void NovoFator(Modelo entidade)
        {
            _modelo.NovoFator(entidade);
        }

        public void RemoverFator(Modelo entidade)
        {
            _modelo.RemoverFator(entidade);
        }

        public List<Usuario> ListarUsuario(Modelo entidade)
        {
            return _modelo.ListarUsuario(entidade);
        }

        public List<Modelo> ListarUsuario()
        {
            return _modelo.ListarUsuario();
        }

        public void NovoUsuario(Modelo entidade)
        {
            _modelo.NovoUsuario(entidade);
        }

        public void RemoverUsuario(Modelo entidade)
        {
            _modelo.RemoverUsuario(entidade);
        }

        public Modelo ListarVariavel(Modelo entidade)
        {
            return _modelo.ListarVariavel(entidade);
        }

        public List<Modelo> ListarVariavel()
        {
            return _modelo.ListarVariavel();
        }

        public void NovoVariavel(Modelo entidade)
        {
            _modelo.NovoVariavel(entidade);
        }

        public void RemoverVariavel(Modelo entidade)
        {
            _modelo.RemoverVariavel(entidade);
        }

        public Modelo ListarVariavelImportacao(Modelo entidade)
        {
            return _modelo.ListarVariavelImportacao(entidade);
        }

        public List<Modelo> CampanhaListar(Modelo entidade)
        {
            return _modelo.CampanhaListar(entidade);
        }

        public List<Usuario> UsuarioSemRelacaoUsuarioListar(Modelo entidade)
        {
            return _modelo.UsuarioSemRelacaoUsuarioListar(entidade);
        }

        public List<Modelo> RelacaoVariavelListar(Modelo entidade)
        {
            return _modelo.RelacaoVariavelListar(entidade);
        }

    }
}
