using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using funcionadenovo.Models;

namespace funcionadenovo.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Tabela> tabelas { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SEPLAN-0368\SQLEXPRESS;Database=devPessoa;Trusted_Connection=True;");
        }
    }
}
