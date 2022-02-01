using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.ApplicationServices
{
    public interface IApplicationServiceSocio
    {
        //Métodos a serem desenvolvidos para a classe DTO(segue o padrão do repositório)
        void Add(SocioDTO socioDTO);

        void Update(SocioDTO socioDTO);

        void Delete(int id);

        //IEnumerable<SocioDTO> GetAll();
        IEnumerable<Socio> GetAll();

        //SocioDTO GetById(int id);
        Socio GetById(int id);
    }
}
