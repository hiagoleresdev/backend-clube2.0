using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.Mappers
{
    public interface IMapperFuncionario
    {
        //Métodos a serem desenvolvidos para esta classe para maepamento
        Funcionario MapperDTOToEntity(FuncionarioDTO funcionarioDTO);
    }
}
