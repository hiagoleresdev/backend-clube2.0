using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Interfaces.ApplicationServices
{
    public interface IApplicationServiceCategoria
    {
        //Métodos a serem desenvolvidos para a classe DTO(segue o padrão do repositório
        int Add(CategoriaDTO categoriaDTO);

        void Update(CategoriaDTO categoriaDTO);

        Categoria GetById(int id);

        int Delete(int id);

        IEnumerable<Categoria> GetAll();
    }
}
