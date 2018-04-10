using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Campanha
    {
        public string Nome { get; set; }
        public int? IDCampanha { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Usuario Usuario { get; set; }
        public Modelo Modelo { get; set; }
        public List<CampanhaModelo> CampanhaModelo { get; set; }
    }
}
