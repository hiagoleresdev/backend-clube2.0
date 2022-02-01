using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubeApi.Infrastructure.Data.EntitiesConfigurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //Especificações da entidade Categoria
            builder.ToTable("CATEGORIAS");

            builder.HasKey(categoria => categoria.Id);

            builder.Property(categoria => categoria.Tipo)
                .HasColumnName("Tipo")
                .HasColumnType("VARCHAR(10)")
                .IsRequired();

            builder.Property(categoria => categoria.Meses)
                .HasColumnName("Meses")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.HasMany(categoria => categoria.Socios)
                .WithOne(socio => socio.Categoria);
        }
    }
}
