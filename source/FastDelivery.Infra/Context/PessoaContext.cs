using Microsoft.EntityFrameworkCore;
using FastDelivery.Domain.Entities;
using FastDelivery.Infra.Mappings;

namespace FastDelivery.Infra.Context{
    public class PessoaContext : DbContext {

        public PessoaContext(DbContextOptions<PessoaContext> options):base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
        public DbSet<PessoaEntity> Pessoas { get;set;}
        public DbSet<UserEntity> Users { get;set;}
    }
}