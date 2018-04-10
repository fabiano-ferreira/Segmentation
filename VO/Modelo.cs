using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Modelo
    {
        public int? IDModelo { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Usuario Usuario { get; set; }
        public TipoSegmento TipoSegmento { get; set; }
        public Grafico Grafico { get; set; }
        public Fator Fator { get; set; }
        public LinhaNegocio LinhaNegocio { get; set; }
        public TipoFator TipoFator { get; set; }
        public Variavel Variavel { get; set; }
        public TipoVariavel TipoVariavel { get; set; }
        public ClasseVariavel ClasseVariavel { get; set; }
        public TipoSaida TipoSaida { get; set; }
        public List<ModeloFator> ModeloFator { get; set; }
        public List<ModeloUsuario> ModeloUsuario { get; set; }
        public List<ModeloVariavel> ModeloVariavel { get; set; }
        public TipoDadoVariavel TipoDadoVariavel { get; set; }
        public Campanha Campanha { get; set; }

    }
}
