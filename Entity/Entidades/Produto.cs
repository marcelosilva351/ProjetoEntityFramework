using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Marca Marca { get; set; }

        public int Quantidade { get; set; }

        IList<VendaProduto> vendas = new List<VendaProduto>();

        public Produto(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
         
            Quantidade = quantidade;
        }

        public override bool Equals(object obj)
        {
            Produto produto = obj as Produto;
            return Nome.Equals(produto.Nome);
        }

        public override string ToString()
        {
            return $"ID: {Id}, NOME: {Nome}, PREÇO: {Preco}, MARCA: {Marca.Nome}, QUANTIDADE: {Quantidade}";
        }

    }
}
