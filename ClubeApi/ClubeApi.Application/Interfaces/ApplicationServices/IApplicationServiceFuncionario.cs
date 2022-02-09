using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.ApplicationServices
{
    public interface IApplicationServiceFuncionario
    {
        //Métodos a serem desenvolvidos para a classe DTO(segue o padrão do repositório)
        int Add(FuncionarioDTO funcionarioDTO);

        void Update(FuncionarioDTO funcionarioDTO);

        Funcionario GetById(int id);

        int Delete(int id);

        int Validate(string usuario, string senha);
    }
}
