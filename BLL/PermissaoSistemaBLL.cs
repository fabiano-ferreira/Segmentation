using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class PermissaoSistemaBLL
    {
        private PermissaoSistemaDAO _permissaoSistema;

        public PermissaoSistemaBLL()
        {
            if (_permissaoSistema == null)
                _permissaoSistema = new PermissaoSistemaDAO();
        }

        public PermissaoSistema Listar(PermissaoSistema entidade)
        {
            return _permissaoSistema.Listar(entidade);
        }

        public List<PermissaoSistema> Listar()
        {
            return _permissaoSistema.Listar();
        }

        public List<PermissaoSistema> ListarSemRelacaoPerfil(PermissaoSistema entidade)
        {
            return _permissaoSistema.ListarSemRelacaoPerfil(entidade);
        }

        public List<PermissaoSistema> ListarSemRelacaoUsuario(PermissaoSistema entidade)
        {
            return _permissaoSistema.ListarSemRelacaoUsuario(entidade);
        }

        public List<PermissaoSistema> ListarUsuario(PermissaoSistema entidade)
        {
            return _permissaoSistema.ListarUsuario(entidade);
        }

        public List<PermissaoSistema> ListarPerfil(PermissaoSistema entidade)
        {
            return _permissaoSistema.ListarPerfil(entidade);
        }

        public void NovoUsuario(PermissaoSistema entidade)
        {
            _permissaoSistema.NovoUsuario(entidade);
        }

        public void RemoverUsuario(PermissaoSistema entidade)
        {
            _permissaoSistema.RemoverUsuario(entidade);
        }
    }
}
