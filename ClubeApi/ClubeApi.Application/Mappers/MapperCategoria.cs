using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.Mappers;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Mappers
{
    public class MapperCategoria : IMapperCategoria
    {
        public Categoria MapperDTOToEntity(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = new Categoria()
            {
                Id = categoriaDTO.Id,
                Tipo = categoriaDTO.Tipo,
                Meses = categoriaDTO.Meses
            };

            return categoria;
        }
    }
}
