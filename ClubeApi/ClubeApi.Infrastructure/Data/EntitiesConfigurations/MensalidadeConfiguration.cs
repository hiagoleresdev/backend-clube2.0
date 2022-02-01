using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubeApi.Infrastructure.Data.EntitiesConfigurations
{
    public class MensalidadeConfiguration : IEntityTypeConfiguration<Mensalidade>
    {
        public void Configure(EntityTypeBuilder<Mensalidade> builder)
        {
            //Especificações da entidade mensalidade
            builder.ToTable("MENSALIDADES");

            builder.HasKey(mensalidade => mensalidade.Id);

            builder.Property(mensalidade => mensalidade.DataVencimento)
                .HasColumnName("Vencimento")
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(mensalidade => mensalidade.ValorInicial)
               .HasColumnName("ValorInicial")
               .HasColumnType("FLOAT")
               .IsRequired();

            builder.Property(mensalidade => mensalidade.Juros)
               .HasColumnName("Juros")
               .HasColumnType("INTEGER")
               .HasDefaultValue(8)
               .IsRequired();

            builder.Property(mensalidade => mensalidade.DataPagamento)
               .HasColumnName("DataPagamento")
               .HasColumnType("DATE");

            builder.Property(mensalidade => mensalidade.ValorFinal)
               .HasColumnName("ValorFinal")
               .HasColumnType("FLOAT");

            builder.Property(mensalidade => mensalidade.Quitada)
               .HasColumnName("Quitada")
               .HasColumnType("BIT")
               .IsRequired();

            builder.Property<int>("FkSocio")
                .HasColumnName("FkSocio");

            builder.HasOne(mensalidade => mensalidade.Socio)
                .WithMany(socio => socio.Mensalidades)
                .HasForeignKey("FkSocio");
        }
    }
}
