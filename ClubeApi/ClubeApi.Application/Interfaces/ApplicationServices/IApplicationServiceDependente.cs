using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.ApplicationServices
{
    public interface IApplicationServiceDependente
    {
        //Métodos a serem desenvolvidos para a classe DTO(segue o padrão do repositório)
        int Add(DependenteDTO dependenteDTO);

        void Update(DependenteDTO dependenteDTO);

        void Delete(int id);

        IEnumerable<Dependente> GetAll();

        Dependente GetById(int id);
    }
}
