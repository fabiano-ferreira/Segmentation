using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class MenuAplicacao
    {
        public int IdMenuAplicacao { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int IdPai { get; set; }
        public List<MenuAplicacao> MenuAplicacaoFilho { get; set; }
    }
}
