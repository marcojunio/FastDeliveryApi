using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FastDelivery.Domain.Entities;

namespace FastDelivery.Infra.Mappings{
    public class UserMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("USERS");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Login).HasColumnName("LOGIN").HasMaxLength(30).IsRequired();
            builder.Property(p => p.Password).HasColumnName("PASSWORD").HasMaxLength(30).IsRequired();
            builder.Property(p => p.Salt).HasColumnName("SALT").HasMaxLength(40).IsRequired();
            builder.Property(p => p.Role).HasColumnName("ROLE").HasMaxLength(30).IsRequired();
        }
    }
}