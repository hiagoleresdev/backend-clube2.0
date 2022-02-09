using ClubeApi.Domain.Models;

namespace ClubeApi.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryFuncionario
    {
        //Métodos a serem desenvolvidos para esta classe
        //Método para verificar cadastro repetido
        int Verify(Funcionario funcionario);

        //Método para cadastrar funcionário
        int Add(Funcionario obj);

        //Método para selecionar funcionário por ID
        Funcionario GetById(int id);

        //Método para atualizar funcionário
        void Update(Funcionario obj);

        //Método para deletar funcionário
        int Delete(int id);

        //Método para validar usuário do funcionário
        int Validate(string usuario, string senha);
    }
}
