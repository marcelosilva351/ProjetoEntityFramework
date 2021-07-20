using System.Collections.Generic;

namespace Entity
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        IList<Produto> produtos = new List<Produto>();
        public Marca(string nome)
        {
            Nome = nome;
        }

        public override bool Equals(object obj)
        {
            Marca marca = obj as Marca;
            return Id.Equals(marca.Id);
        }

        public override string ToString()
        {
            return $"ID: {Id}, NOME: {Nome}";
        }
    }
}