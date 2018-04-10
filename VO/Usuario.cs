using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Usuario
    {
        public int? IDUsuario { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public Boolean MudarSenha { get; set; }
        public Boolean Acesso { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public string LogUsuario { get; set; }
        public TipoStatusUsuario TipoStatusUsuario { get; set; }
        public LinhaNegocio LinhaNegocio { get; set; }
        public List<Perfil> Perfil { get; set; }
    }
}

