using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class TipoStatusUsuarioBLL
    {
        private TipoStatusUsuarioDAO _tipoStatusUsuario;

        public TipoStatusUsuarioBLL()
        {
            if (_tipoStatusUsuario == null)
                _tipoStatusUsuario = new TipoStatusUsuarioDAO();
        }

        public TipoStatusUsuario Listar(TipoStatusUsuario entidade)
        {
            return _tipoStatusUsuario.Listar(entidade);
        }

        public List<TipoStatusUsuario> Listar()
        {
            return _tipoStatusUsuario.Listar();
        }
    }
}
