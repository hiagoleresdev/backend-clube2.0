using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubeApi.Infrastructure.Data.EntitiesConfigurations
{
    public class SocioConfiguration : IEntityTypeConfiguration<Socio>
    {
        public void Configure(EntityTypeBuilder<Socio> builder)
        {
            //Especificações da entidade Socio
            builder.ToTable("SOCIOS");

            builder.Property(socio => socio.NumeroCartao)
                .HasColumnName("NumeroCartao")
                .HasColumnType("NUMERIC(9)")
                .IsRequired();

            builder.Property(socio => socio.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("VARCHAR(11)")
                .IsRequired();

            builder.Property(socio => socio.Cep)
                .HasColumnName("Cep")
                .HasColumnType("CHAR(8)")
                .IsRequired();

            builder.Property(socio => socio.Uf)
                .HasColumnName("Uf")
                .HasColumnType("CHAR(2)")
                .IsRequired();

            builder.Property(socio => socio.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("VARCHAR(25)")
                .IsRequired();

            builder.Property(socio => socio.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            builder.Property(socio => socio.Logradouro)
                .HasColumnName("Logradouro")
                .HasColumnType("VARCHAR(30)")
                .IsRequired();

            builder.Property<int>("FkCategoria")
                .HasColumnName("FkCategoria");

            builder.HasOne(socio => socio.Categoria)
                .WithMany(categoria => categoria.Socios)
                .HasForeignKey("FkCategoria");

            builder.HasMany(socio => socio.Mensalidades)
                .WithOne(mensalidade => mensalidade.Socio);

            builder.HasMany(socio => socio.Dependentes)
                .WithOne(dependente => dependente.Socio);
        }
    }
}
