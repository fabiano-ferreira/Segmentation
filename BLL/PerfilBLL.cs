using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class PerfilBLL
    {
        private PerfilDAO _perfil;

        public PerfilBLL()
        {
            if (_perfil == null)
                _perfil = new PerfilDAO();
        }

        public void Novo(Perfil entidade)
        {
            _perfil.Novo(entidade);
        }

        public void Remover(Perfil entidade)
        {
            _perfil.Remover(entidade);
        }

        public void Editar(Perfil entidade)
        {
            _perfil.Editar(entidade);
        }

        public Perfil Listar(Perfil entidade)
        {
            return _perfil.Listar(entidade);
        }

        public List<Perfil> Listar()
        {
            return _perfil.Listar();
        }

        public Perfil ListarPermissaoSistemaPerfil(Perfil entidade)
        {
            return _perfil.ListarPermissaoSistemaPerfil(entidade);
        }

        public List<Perfil> ListarPermissaoSistemaPerfil()
        {
            return _perfil.ListarPermissaoSistemaPerfil();
        }

        public void NovoPermissaoSistema(Perfil entidade)
        {
            _perfil.NovoPermissaoSistema(entidade);
        }

        public void RemoverPermissaoSistema(Perfil entidade)
        {
            _perfil.RemoverPermissaoSistema(entidade);
        }

        public void NovoUsuario(Perfil entidade)
        {
            _perfil.NovoUsuario(entidade);
        }

        public void RemoverUsuario(Perfil entidade)
        {
            _perfil.RemoverUsuario(entidade);
        }

        public List<Perfil> ListarSemRelacaoUsuario(Perfil entidade)
        {
            return _perfil.ListarSemRelacaoUsuario(entidade);
        }

        public List<Perfil> ListarUsuario(Perfil entidade)
        {
            return _perfil.ListarUsuario(entidade);
        }
    }
}
