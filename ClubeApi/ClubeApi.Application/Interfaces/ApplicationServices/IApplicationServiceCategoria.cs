using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.ApplicationServices
{
    public interface IApplicationServiceCategoria
    {
        //Métodos a serem desenvolvidos para a classe DTO(segue o padrão do repositório)
        void Add(CategoriaDTO categoriaDTO);

        void Update(CategoriaDTO categoriaDTO);

        //CategoriaDTO GetById(int id);
        Categoria GetById(int id);

        void Delete(int id);

        //IEnumerable<CategoriaDTO> GetAll();
        IEnumerable<Categoria> GetAll();
    }
}
