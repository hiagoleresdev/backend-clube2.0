using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubeApi.Infrastructure.Data.EntitiesConfigurations
{
    public class DependenteConfiguration : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            //Especificações da entidade Dependente
            builder.ToTable("DEPENDENTES");

            builder.Property(socio => socio.NumeroCartao)
                .HasColumnName("NumeroCartao")
                .HasColumnType("NUMERIC(9)")
                .IsRequired();

            builder.Property(dependente => dependente.Parentesco)
                .HasColumnName("Parentesco")
                .HasColumnType("VARCHAR(10)")
                .IsRequired();

            builder.Property<int>("FkSocio")
                .HasColumnName("FkSocio");

            builder.HasOne(dependente => dependente.Socio)
                .WithMany(socio => socio.Dependentes)
                .HasForeignKey("FkSocio");
        }
    }
}
