using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.Mappers
{
    public interface IMapperMensalidade
    {
        //Métodos a serem desenvolvidos para esta classe para maepamento
        Mensalidade MapperDTOToEntity(MensalidadeDTO mensalidadeDTO, Socio socio);
    }
}
