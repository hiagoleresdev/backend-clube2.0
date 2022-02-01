using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubeApi.Infrastructure.Data.EntitiesConfigurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            //Especificações da entidade Pessoa
            builder.ToTable("PESSOAS");

            builder.HasKey(pessoa => pessoa.Id);

            builder.Property(pessoa => pessoa.Nome)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR(30)")
                .IsRequired();

            builder.Property(pessoa => pessoa.Email)
               .HasColumnName("Email")
               .HasColumnType("VARCHAR(30)")
               .IsRequired();
        }
    }
}
