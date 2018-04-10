using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class TipoSegmentoBLL
    {
        private TipoSegmentoDAO _tipoSegmento;

        public TipoSegmentoBLL()
        {
            if (_tipoSegmento == null)
                _tipoSegmento = new TipoSegmentoDAO();
        }

        public void Novo(TipoSegmento entidade)
        {
            _tipoSegmento.Novo(entidade);
        }

        public void Editar(TipoSegmento entidade)
        {
            _tipoSegmento.Editar(entidade);
        }

        public TipoSegmento Listar(TipoSegmento entidade)
        {
            return _tipoSegmento.Listar(entidade);
        }

        public List<TipoSegmento> Listar()
        {
            return _tipoSegmento.Listar();
        }

        public Modelo Listar(Modelo entidade)
        {
            return _tipoSegmento.Listar(entidade);
        }

        public List<TipoSegmento> ListarLinhaNegocio(TipoSegmento entidade)
        {
            return _tipoSegmento.ListarLinhaNegocio(entidade);
        }

        public void Remover(TipoSegmento entidade)
        {
            _tipoSegmento.Remover(entidade);
        }
    }
}
