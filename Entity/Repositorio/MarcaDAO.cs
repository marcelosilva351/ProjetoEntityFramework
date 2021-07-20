using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using System.Linq;

namespace Entity.Repositorio
{
    class MarcaDAO : BaseRepositorio<Marca>
    {

        public MarcaDAO(LojaContext contexto) : base(contexto)
        {

        }

        public override void Adicionar(Marca marca)
        {
            contexto.Marca.Add(marca);
            contexto.SaveChanges();
        }

        public override void Alterar(Marca t)
        {
            throw new InvalidOperationException("Não é possivel alterar uma marca");
        }

        public override void Remover(Marca marca)
        {
            contexto.Remove(marca);
            contexto.SaveChanges();
        }
        public override List<Marca> Listar()
        {
            return contexto.Marca.ToList();
        }
    }
}
      