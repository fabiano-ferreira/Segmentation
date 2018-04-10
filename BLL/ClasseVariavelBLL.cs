using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class ClasseVariavelBLL
    {
        private ClasseVariavelDAO _ClasseVariavel;

        public ClasseVariavelBLL()
        {
            if (_ClasseVariavel == null)
                _ClasseVariavel = new ClasseVariavelDAO();
        }

        public void Novo(ClasseVariavel entidade)
        {
            _ClasseVariavel.Novo(entidade);
        }

        public void Remover(ClasseVariavel entidade)
        {
            _ClasseVariavel.Remover(entidade);
        }

        public void Editar(ClasseVariavel entidade)
        {
            _ClasseVariavel.Editar(entidade);
        }

        public ClasseVariavel Listar(ClasseVariavel entidade)
        {
            return _ClasseVariavel.Listar(entidade);
        }

        public List<ClasseVariavel> Listar()
        {
            return _ClasseVariavel.Listar();
        }


        public string Validar(ClasseVariavel entidade)
        {
            return _ClasseVariavel.Validar(entidade);
        }

    }
}
