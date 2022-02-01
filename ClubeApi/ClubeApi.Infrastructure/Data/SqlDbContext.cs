//Importações
using ClubeApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubeApi.Infrastructure.Data
{
    public class SqlDbContext : DbContext
    {
        //Declaração das entidades do contexto
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Mensalidade> Mensalidades { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        //Construtor sobrecarregado
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }

        //Método para aplicar especificações das entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
