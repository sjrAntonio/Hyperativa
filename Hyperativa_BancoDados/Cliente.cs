using System;
using System.Collections.Generic;
using System.Text;

namespace Hyperativa_BancoDados
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public int Lote { get; set; }
        public string NomeCliente { get; set; } 
        public string NumeroCartaoCredito { get; set; }
    }
}
