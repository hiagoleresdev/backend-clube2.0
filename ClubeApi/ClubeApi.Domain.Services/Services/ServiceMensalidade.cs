using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Models;

namespace ClubeApi.Domain.Services.Services
{
    public class ServiceMensalidade : ServiceBase<Mensalidade>, IServiceMensalidade
    {
        //Atributo de referência ao repositório para implementa-lo
        private readonly IRepositoryMensalidade repository;

        //Construtor
        public ServiceMensalidade(IRepositoryMensalidade repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
