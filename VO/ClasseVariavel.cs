using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class ClasseVariavel
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public Usuario Usuario { get; set; }
        public int? IDClasseVariavel { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        
    }

  
}
