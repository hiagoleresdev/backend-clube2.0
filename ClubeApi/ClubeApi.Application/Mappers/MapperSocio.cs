using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.Mappers;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Mappers
{
    public class MapperSocio : IMapperSocio
    {
        public Socio MapperDTOToEntity(SocioDTO socioDTO, Categoria categoria)
        {
            Socio socio = new Socio()
            {
                Id = socioDTO.Id,
                Nome = socioDTO.Nome,
                Email = socioDTO.Email,
                NumeroCartao = socioDTO.NumeroCartao,
                Telefone = socioDTO.Telefone,
                Cep = socioDTO.Cep,
                Uf = socioDTO.Uf,
                Cidade = socioDTO.Cidade,
                Bairro = socioDTO.Bairro,
                Logradouro = socioDTO.Logradouro,
                Categoria = categoria
            };

            return socio;
        }
    }
}
