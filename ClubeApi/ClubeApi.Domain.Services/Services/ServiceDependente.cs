using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Models;

namespace ClubeApi.Domain.Services.Services
{
    public class ServiceDependente : ServiceBase<Dependente>, IServiceDependente
    {
        //Atributo de referência ao repositório para implementa-lo
        private readonly IRepositoryDependente repository;

        //Construtor
        public ServiceDependente(IRepositoryDependente repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
