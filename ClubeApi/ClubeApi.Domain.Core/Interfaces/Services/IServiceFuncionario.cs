using ClubeApi.Domain.Models;

namespace ClubeApi.Domain.Core.Interfaces.Services
{
    public interface IServiceFuncionario
    {
        //Métodos a serem desenvolvidos para esta classe(segue o padrão do repositório)
        int Add(Funcionario obj);

        Funcionario GetById(int id);

        void Update(Funcionario obj);

        int Delete(int id);

        int Validate(string usuario, string senha);
    }
}
