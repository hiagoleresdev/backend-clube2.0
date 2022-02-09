using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Application.Interfaces.Mappers;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.ApplicationServices
{
    public class ApplicationServiceCategoria : IApplicationServiceCategoria
    {
        //Atributos de referência às estrutura de serviço e mapeamento
        private readonly IServiceCategoria service;
        private readonly IMapperCategoria mapper;

        //Construtor
        public ApplicationServiceCategoria(IServiceCategoria service, IMapperCategoria mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public int Add(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = mapper.MapperDTOToEntity(categoriaDTO);
            return service.Add(categoria);
        }

        public int Delete(int id)
        {
            return service.Delete(id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            IEnumerable<Categoria> categorias = service.GetAll();
            return categorias;
        }

        public Categoria GetById(int id)
        {
            Categoria categoria = service.GetById(id);
            return categoria;
        }

        public void Update(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = mapper.MapperDTOToEntity(categoriaDTO);
            service.Update(categoria);
        }
    }
}
