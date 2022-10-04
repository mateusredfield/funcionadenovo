using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcionadenovo.Models
{
    public class Tabela
    {
        public IEnumerable<Pessoas> Pessoas{ get; set; }
        public IEnumerable<Produtos> Produtos{ get; set; }
    }
}
