using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Models;

namespace ClubeApi.Infrastructure.Data.Repositories
{
    public class RepositoryCategoria : RepositoryBase<Categoria>, IRepositoryCategoria
    {
        //Atributo de contexto para controle do banco
        private readonly SqlDbContext context;

        //Construtor
        public RepositoryCategoria(SqlDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
