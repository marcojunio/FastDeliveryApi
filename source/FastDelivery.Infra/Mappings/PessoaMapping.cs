using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FastDelivery.Domain.Entities;

namespace FastDelivery.Infra.Mappings{ 
    public class PessoaMapping : IEntityTypeConfiguration<PessoaEntity>
    { 
        public void Configure(EntityTypeBuilder<PessoaEntity> modelBuilder)
        {

            modelBuilder.ToTable("PESSOA");
            modelBuilder.HasKey(p => p.Id);

            modelBuilder.Property(p => p.Id).HasColumnName("ID").IsRequired().HasMaxLength(32);
            modelBuilder.Property(p => p.Nome).HasColumnName("NOME").IsRequired().HasMaxLength(30);
            modelBuilder.Property(p => p.Sobrenome).HasColumnName("SOBRENOME").IsRequired().HasMaxLength(30);
            modelBuilder.Property(p => p.Idade).HasColumnName("IDADE").IsRequired().HasColumnType<int>("NUMBER").HasMaxLength(3);

            modelBuilder.OwnsOne(p => p.Documento, d =>
            {
                d.Property(p => p.Documento)
                .HasMaxLength(20)
                .HasColumnName("DOCUMENTO")
                .IsRequired();

                d.Property(p => p.TipoDocumento)
                .HasColumnName("TIPO_PESSOA")
                .HasMaxLength(1)
                .IsRequired();
            });

            modelBuilder.OwnsOne(p => p.Email, e => {
                e.Property(p => p.Endereco).HasColumnName("EMAIL").IsRequired();
            });
        }
    }
}