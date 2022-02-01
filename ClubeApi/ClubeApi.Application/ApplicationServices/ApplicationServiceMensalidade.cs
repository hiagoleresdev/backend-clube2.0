using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Application.Interfaces.Mappers;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.ApplicationServices
{
    public class ApplicationServiceMensalidade : IApplicationServiceMensalidade
    {
        //Atributos de referência às estrutura de serviço e mapeamento
        private readonly IServiceMensalidade serviceMensalidade;
        private readonly IServiceSocio serviceSocio;
        private readonly IMapperMensalidade mapper;

        //Construtor
        public ApplicationServiceMensalidade(IServiceMensalidade serviceMensalidade, IServiceSocio serviceSocio, IMapperMensalidade mapper)
        {
            this.serviceMensalidade = serviceMensalidade;
            this.serviceSocio = serviceSocio;
            this.mapper = mapper;
        }

        public void Add(MensalidadeDTO mensalidadeDTO)
        {
            Socio socio = serviceSocio.GetById(mensalidadeDTO.FkSocio);
            Mensalidade mensalidade = mapper.MapperDTOToEntity(mensalidadeDTO, socio);
            serviceMensalidade.Add(mensalidade);
        }

        public void Delete(int id)
        {
            serviceMensalidade.Delete(id);
        }

        public IEnumerable<Mensalidade> GetAll()
        {
            IEnumerable<Mensalidade> mensalidades = serviceMensalidade.GetAll();
            return mensalidades;
        }

        public Mensalidade GetById(int id)
        {
            Mensalidade mensalidade = serviceMensalidade.GetById(id);
            return mensalidade;
        }

        public void Update(MensalidadeDTO mensalidadeDTO)
        {
            Socio socio = serviceSocio.GetById(mensalidadeDTO.FkSocio);
            Mensalidade mensalidade = mapper.MapperDTOToEntity(mensalidadeDTO, socio);
            serviceMensalidade.Update(mensalidade);
        }
    }
}
