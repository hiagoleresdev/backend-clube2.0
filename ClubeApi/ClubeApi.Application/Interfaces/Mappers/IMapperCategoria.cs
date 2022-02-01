using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.Mappers
{
    public interface IMapperCategoria
    {
        //Métodos a serem desenvolvidos para esta classe para maepamento
        Categoria MapperDTOToEntity(CategoriaDTO categoriaDTO);
    }
}
