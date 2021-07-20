using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Repositorio
{
    abstract class BaseRepositorio<T> : IRepositorioCRUD
    {
        protected LojaContext contexto;

        public BaseRepositorio(LojaContext contexto)
        {
            this.contexto = contexto;
        }

        public abstract void Adicionar(T t);

        public abstract void Alterar(T t);

     

        public abstract void Remover(T t);

        public abstract List<T> Listar();
        
    }
}