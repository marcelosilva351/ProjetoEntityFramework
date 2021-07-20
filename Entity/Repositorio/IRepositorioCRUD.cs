using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Repositorio
{
    interface IRepositorioCRUD<T>
    {
        public void Adicionar(T t);
        public void Remover(T t);
        public void Alterar(T t );
     

        public List<T> Listar(T t);
    }
}
