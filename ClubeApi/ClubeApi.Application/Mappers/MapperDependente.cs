using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.Mappers;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Mappers
{
    public class MapperDependente : IMapperDependente
    {
        public Dependente MapperDTOToEntity(DependenteDTO dependenteDTO, Socio socio)
        {
            Dependente dependente = new Dependente()
            {
                Id = dependenteDTO.Id,
                Nome = dependenteDTO.Nome,
                Email = dependenteDTO.Email,
                NumeroCartao = dependenteDTO.NumeroCartao,
                Parentesco = dependenteDTO.Parentesco,
                Socio = socio
            };

            return dependente;
        }
    }
}
