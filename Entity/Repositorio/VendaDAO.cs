using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Entity.Repositorio
{
    class VendaDAO : BaseRepositorio<Venda>
    {
        public VendaDAO(LojaContext contexto) : base(contexto)
        {

        }
        public override void Adicionar(Venda t)
        {
            contexto.Venda.Add(t);
            contexto.SaveChanges();
        }

        public override void Alterar(Venda t)
        {
            throw new InvalidOperationException("Não é possivel alterar uma venda");
        }

        public override List<Venda> Listar()
        {
            return contexto.Venda.ToList();
            contexto.SaveChanges();

        }

        public override void Remover(Venda t)
        {
            contexto.Venda.Remove(t);

        }
    }
}
