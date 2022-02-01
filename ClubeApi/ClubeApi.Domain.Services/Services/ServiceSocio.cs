using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Models;

namespace ClubeApi.Domain.Services.Services
{
    public class ServiceSocio : ServiceBase<Socio>, IServiceSocio
    {
        //Atributo de referência ao repositório para implementa-lo
        private readonly IRepositorySocio repository;

        //Construtor
        public ServiceSocio(IRepositorySocio repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
