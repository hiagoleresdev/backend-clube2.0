using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.ApplicationServices
{
    public interface IApplicationServiceSocio
    {
        //Métodos a serem desenvolvidos para a classe DTO(segue o padrão do repositório)
        int Add(SocioDTO socioDTO);

        void Update(SocioDTO socioDTO);

        int Delete(int id);

        IEnumerable<Socio> GetAll();

        Socio GetById(int id);
    }
}
