using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubeApi.Infrastructure.Data.EntitiesConfigurations
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //Especificações da entidade Pessoa
            builder.ToTable("FUNCIONARIOS");

            builder.Property(pessoa => pessoa.Usuario)
                .HasColumnName("Usuario")
                .HasColumnType("VARCHAR(16)")
                .IsRequired();

            builder.Property(pessoa => pessoa.Senha)
               .HasColumnName("senha")
               .HasColumnType("CHAR(10)")
               .IsRequired();
        }
    }
}
