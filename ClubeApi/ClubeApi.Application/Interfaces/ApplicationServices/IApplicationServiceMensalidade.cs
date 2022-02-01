using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.ApplicationServices
{
    public interface IApplicationServiceMensalidade
    {
        //Métodos a serem desenvolvidos para a classe DTO(segue o padrão do repositório)
        void Add(MensalidadeDTO mensalidadeDTO);

        void Update(MensalidadeDTO mensalidadeDTO);

        void Delete(int id);

        //IEnumerable<MensalidadeDTO> GetAll();
        IEnumerable<Mensalidade> GetAll();

        //MensalidadeDTO GetById(int id);
        Mensalidade GetById(int id);
    }
}
