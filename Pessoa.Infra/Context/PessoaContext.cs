using Microsoft.EntityFrameworkCore;
using Pessoa.Domain.Entities;
using Pessoa.Infra.Mappings;

namespace Pessoa.Infra.Context{
    public class PessoaContext : DbContext {

        public PessoaContext(DbContextOptions<PessoaContext> options):base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMapping());
        }
        public DbSet<PessoaEntity> Pessoas { get;set;}
    }
}