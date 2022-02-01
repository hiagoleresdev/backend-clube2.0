using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.Mappers
{
    public interface IMapperDependente
    {
        //Métodos a serem desenvolvidos para esta classe para maepamento
        Dependente MapperDTOToEntity(DependenteDTO dependenteDTO, Socio socio);
    }
}
