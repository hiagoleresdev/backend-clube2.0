using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.ApplicationServices
{
    public interface IApplicationServiceFuncionario
    {
        //Métodos a serem desenvolvidos para a classe DTO(segue o padrão do repositório)
        void Add(FuncionarioDTO funcionarioDTO);

        void Update(FuncionarioDTO funcionarioDTO);

        //FuncionarioDTO GetById(int id);
        Funcionario GetById(int id);

        void Delete(int id);

        int Validate(string usuario, string senha);
    }
}
