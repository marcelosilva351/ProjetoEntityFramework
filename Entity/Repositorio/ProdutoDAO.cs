using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Entity.Repositorio
{
    class produtoDAO : BaseRepositorio<Produto>
    {
        public produtoDAO(LojaContext contexto) : base(contexto)
        {

        }

        public override void Adicionar(Produto produto)
        {
            contexto.Produto.Add(produto);
            contexto.SaveChanges();
        }

        public override void Alterar(Produto produto)
        {
            Console.WriteLine("Digite o preço: ");
            double precoNovo = double.Parse(Console.ReadLine());
            produto.Preco = precoNovo;
            contexto.SaveChanges();

        }

        public override List<Produto> Listar()
        {
            return contexto.Produto.ToList();
        }

        public override void Remover(Produto t)
        {
            contexto.Produto.Remove(t);
            contexto.SaveChanges();
        }
    }
}
