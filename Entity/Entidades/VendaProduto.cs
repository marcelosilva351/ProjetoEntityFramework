using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    class VendaProduto
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int VendaId { get; set; }
        public Produto Produto { get; set; }

        public Venda Venda { get; set; }
       

        public override string ToString()
        {
            return $"Venda: {Venda.Descricao} Produto: {Produto.Nome}, Valor total neste produto: {Venda.Valor}";

        }
    }


}
