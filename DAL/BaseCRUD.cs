using System.Collections.Generic;

namespace DAL
{
    public interface BaseCRUD<T>
    {
        void Novo(T entidade);
        void Remover(T entidade);
        void Editar(T entidade);
        T Listar(T entidade);
        List<T> Listar();
    }
}
