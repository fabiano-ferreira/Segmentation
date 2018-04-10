using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Perfil
    {
        public int? IDPerfil { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Usuario Usuario { get; set; }
        public PermissaoSistema PermissaoSistema { get; set; }
        public List<PerfilPermissaoSistema> PerfilPermissaoSistema { get; set; }
    }
}
