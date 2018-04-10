using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class LinhaNegocioBLL
    {
        private LinhaNegocioDAO _linhaNegocio;

        public LinhaNegocioBLL()
        {
            if (_linhaNegocio == null)
                _linhaNegocio = new LinhaNegocioDAO();
        }

        public void Novo(LinhaNegocio entidade)
        {
            _linhaNegocio.Novo(entidade);
        }

        public void Remover(LinhaNegocio entidade)
        {
            _linhaNegocio.Remover(entidade);
        }

        public void Editar(LinhaNegocio entidade)
        {
            _linhaNegocio.Editar(entidade);
        }

        public LinhaNegocio Listar(LinhaNegocio entidade)
        {
            return _linhaNegocio.Listar(entidade);
        }

        public List<LinhaNegocio> Listar()
        {
            return _linhaNegocio.Listar();
        }

        public LinhaNegocio ListarClasseVariavel(LinhaNegocio entidade)
        {
            return _linhaNegocio.ListarClasseVariavel(entidade);
        }

        public List<LinhaNegocio> ListarClasseVariavel()
        {
            return _linhaNegocio.ListarClasseVariavel();
        }

        public void NovoClasseVariavel(LinhaNegocio entidade)
        {
            _linhaNegocio.NovoClasseVariavel(entidade);
        }

        public void RemoverClasseVariavel(LinhaNegocio entidade)
        {
            _linhaNegocio.RemoverClasseVariavel(entidade);
        }

        public LinhaNegocio ListarProdutoNivel(LinhaNegocio entidade)
        {
            return _linhaNegocio.ListarProdutoNivel(entidade);
        }

        public List<LinhaNegocio> ListarProdutoNivel()
        {
            return _linhaNegocio.ListarProdutoNivel();
        }

        public void NovoProdutoNivel(string idLinhaNegocio, string idProdutoNivel)
        {
            _linhaNegocio.NovoProdutoNivel(idLinhaNegocio, idProdutoNivel);
        }

        public void RemoverProdutoNivel(LinhaNegocio entidade)
        {
            _linhaNegocio.RemoverProdutoNivel(entidade);
        }

        public List<Usuario> ListarUsuario(LinhaNegocio entidade)
        {
            return _linhaNegocio.ListarUsuario(entidade);
        }

        public List<LinhaNegocio> ListarUsuario()
        {
            return _linhaNegocio.ListarUsuario();
        }

        public void NovoUsuario(LinhaNegocio entidade)
        {
            _linhaNegocio.NovoUsuario(entidade);
        }

        public void RemoverUsuario(LinhaNegocio entidade)
        {
            _linhaNegocio.RemoverUsuario(entidade);
        }
    }
}
