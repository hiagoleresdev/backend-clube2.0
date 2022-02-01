using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.Mappers;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Mappers
{
    public class MapperFuncionario : IMapperFuncionario
    {
        public Funcionario MapperDTOToEntity(FuncionarioDTO funcionarioDTO)
        {
            Funcionario funcionario = new Funcionario()
            {
                Id = funcionarioDTO.Id,
                Nome = funcionarioDTO.Nome,
                Email = funcionarioDTO.Email,
                Usuario = funcionarioDTO.Usuario,
                Senha = funcionarioDTO.Senha
            };

            return funcionario;
        }
    }
}
