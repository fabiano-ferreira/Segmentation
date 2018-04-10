using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class VersaoProdutoFatorSegmentoBLL
    {
        private VersaoProdutoFatorSegmentoDAO _versaoProdutoFatorSegmento;

        public VersaoProdutoFatorSegmentoBLL()
        {
            if (_versaoProdutoFatorSegmento == null)
                _versaoProdutoFatorSegmento = new VersaoProdutoFatorSegmentoDAO();
        }

        public List<Segmento> ListarRelacaoSegmento(VersaoProdutoFatorSegmento entidade)
        {
            return _versaoProdutoFatorSegmento.ListarRelacaoSegmento(entidade);
        }
    }
}
