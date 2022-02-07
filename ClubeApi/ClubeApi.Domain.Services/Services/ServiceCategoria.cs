using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Models;

namespace ClubeApi.Domain.Services.Services
{
    public class ServiceCategoria : ServiceBase<Categoria>, IServiceCategoria
    {
        //Atributo de referência ao repositório para implementa-lo
        private readonly IRepositoryCategoria repository;

        //Construtor
        public ServiceCategoria(IRepositoryCategoria repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
