using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace funcionadenovo.Models
{
    public class Produtos
    {
        [Key]
        public string codigo { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
    }
}
