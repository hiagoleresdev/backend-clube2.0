using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Application.Interfaces.Mappers;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.ApplicationServices
{
    public class ApplicationServiceDependente : IApplicationServiceDependente
    {
        //Atributos de referência às estrutura de serviço e mapeamento
        private readonly IServiceDependente serviceDependente;
        private readonly IServiceSocio serviceSocio;
        private readonly IMapperDependente mapper;

        //Construtor
        public ApplicationServiceDependente(IServiceDependente serviceDependente, IServiceSocio serviceSocio, IMapperDependente mapper)
        {
            this.serviceDependente = serviceDependente;
            this.serviceSocio = serviceSocio;
            this.mapper = mapper;
        }

        public void Add(DependenteDTO dependenteDTO)
        {
            Socio socio = serviceSocio.GetById(dependenteDTO.FkSocio);
            Dependente dependente = mapper.MapperDTOToEntity(dependenteDTO, socio);
            serviceDependente.Add(dependente);
        }

        public void Delete(int id)
        {
            serviceDependente.Delete(id);
        }

        public IEnumerable<Dependente> GetAll()
        {
            IEnumerable<Dependente> dependentes = serviceDependente.GetAll();
            return dependentes;
        }

        public Dependente GetById(int id)
        {
            Dependente dependente = serviceDependente.GetById(id);
            return dependente;
        }

        public void Update(DependenteDTO dependenteDTO)
        {
            Socio socio = serviceSocio.GetById(dependenteDTO.FkSocio);
            Dependente dependente = mapper.MapperDTOToEntity(dependenteDTO, socio);
            serviceDependente.Update(dependente);
        }
    }
}
