using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class GraficoBLL
    {
        private GraficoDAO _grafico;

        public GraficoBLL()
        {
            if (_grafico == null)
                _grafico = new GraficoDAO();
        }

        public void Novo(Grafico entidade)
        {
            _grafico.Novo(entidade); 
        }

        public void Remover(Grafico entidade)
        {
            _grafico.Remover(entidade);
        }

        public void Editar(Grafico entidade)
        {
            _grafico.Editar(entidade);
        }

        public Grafico Listar(Grafico entidade)
        {
            return _grafico.Listar(entidade);
        }

        public List<Grafico> Listar()
        {
            return _grafico.Listar();
        }

        public Grafico ListarQuadrante(Grafico entidade)
        {
            return _grafico.ListarQuadrante(entidade);
        }

        public List<Grafico> ListarQuadrante()
        {
            return _grafico.ListarQuadrante();
        }
    }
}
