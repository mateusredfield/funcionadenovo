using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using funcionadenovo.Models;

namespace funcionadenovo.Data
{
    public class PessoaContexto : DbContext
    {//pessoa ou pessoa contexto
        public PessoaContexto(DbContextOptions<PessoaContexto> options) :base(options)
        { 
        }
        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SEPLAN-0368\SQLEXPRESS;Database=devPessoa;Trusted_Connection=True;");
        }
    }
}
