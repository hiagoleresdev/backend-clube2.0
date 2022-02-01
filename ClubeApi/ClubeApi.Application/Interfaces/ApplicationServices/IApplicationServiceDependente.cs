using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.ApplicationServices
{
    public interface IApplicationServiceDependente
    {
        //Métodos a serem desenvolvidos para a classe DTO(segue o padrão do repositório)
        void Add(DependenteDTO dependenteDTO);

        void Update(DependenteDTO dependenteDTO);

        void Delete(int id);

        //IEnumerable<DependenteDTO> GetAll();
        IEnumerable<Dependente> GetAll();

        //DependenteDTO GetById(int id);
        Dependente GetById(int id);
    }
}
