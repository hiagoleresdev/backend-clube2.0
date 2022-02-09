using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Application.Interfaces.Mappers;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.ApplicationServices
{
    public class ApplicationServiceSocio : IApplicationServiceSocio
    {
        //Atributos de referência às estrutura de serviço e mapeamento
        private readonly IServiceSocio serviceSocio;
        private readonly IServiceCategoria serviceCategoria;
        private readonly IMapperSocio mapper;

        //Construtor
        public ApplicationServiceSocio(IServiceSocio serviceSocio, IServiceCategoria serviceCategoria, IMapperSocio mapper)
        {
            this.serviceSocio = serviceSocio;
            this.serviceCategoria = serviceCategoria;
            this.mapper = mapper;
        }

        public int Add(SocioDTO socioDTO)
        {
            Categoria categoria = serviceCategoria.GetById(socioDTO.FkCategoria);
            Socio socio = mapper.MapperDTOToEntity(socioDTO, categoria);
            return serviceSocio.Add(socio);
        }

        public int Delete(int id)
        {
            return serviceSocio.Delete(id);
        }

        public IEnumerable<Socio> GetAll()
        {
            IEnumerable<Socio> socios = serviceSocio.GetAll();
            return socios;
        }

        public Socio GetById(int id)
        {
            Socio socio = serviceSocio.GetById(id);
            return socio;
        }

        public void Update(SocioDTO socioDTO)
        {
            Categoria categoria = serviceCategoria.GetById(socioDTO.FkCategoria);
            Socio socio = mapper.MapperDTOToEntity(socioDTO, categoria);
            serviceSocio.Update(socio);
        }
    }
}
