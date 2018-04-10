using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VO
{
    public class Variavel
    {
        public int IDVariavel { get; set; }
        public int IdFilho { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Significado { get; set; }
        public string MetodoCientificoObtencao { get; set; }
        public string MetodoPraticoObtencao { get; set; }
        public string PerguntaSistema { get; set; }
        public string InteligenciaSistemicaModelo { get; set; }
        public string Comentario { get; set; }
        public int ColunaImportacao { get; set; }
        public string Expressão { get; set; }

        //atributos externos usados somente para regra de negocio
        //**********************
        public int IdPai { get; set; }
        public int Status { get; set; }
        //**********************

        public Modelo Modelo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public TipoVariavel TipoVariavel { get; set; }
        public ClasseVariavel ClasseVariavel { get; set; }
        public TipoSaida TipoSaida { get; set; }
        public Usuario Usuario { get; set; }
        public Criterio Criterio { get; set; }
        public RegraLogica RegraLogica { get; set; }
        public List<CriterioVariavel> CriterioVariavel { get; set; }
        public List<Variavel> VariavelFilho { get; set; }
        public List<CalculoVariavel> CalculoVariavel { get; set; }
        public TipoDadoVariavel TipoDadoVariavel { get; set; }
        public List<VariavelRegraLogica> VariavelRegraLogicaLista { get; set; }
        public List<VariavelCalculoVariavel> VariavelCalculoVariavel { get; set; }
        public LinhaNegocio LinhaNegocio { get; set; }

        public Variavel()
        {
            this.VariavelFilho = new List<Variavel>();
        }
    }
}
