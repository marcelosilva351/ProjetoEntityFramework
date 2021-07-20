using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    class Venda
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }

        public List<VendaProduto> produtos { get; set; } = new List<VendaProduto>();

        


    }
}
