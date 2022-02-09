using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Application.Interfaces.Mappers;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.ApplicationServices
{
    public class ApplicationServiceFuncionario : IApplicationServiceFuncionario
    {
        //Atributos de referência às estrutura de serviço e mapeamento
        private readonly IServiceFuncionario service;
        private readonly IMapperFuncionario mapper;

        //Construtor
        public ApplicationServiceFuncionario(IServiceFuncionario service, IMapperFuncionario mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public int Add(FuncionarioDTO funcionarioDTO)
        {
            Funcionario funcionario = mapper.MapperDTOToEntity(funcionarioDTO);
            return service.Add(funcionario);
        }

        public int Delete(int id)
        {
            return service.Delete(id);
        }

        public Funcionario GetById(int id)
        {
            Funcionario funcionario = service.GetById(id);
            return funcionario;
        }

        public void Update(FuncionarioDTO funcionarioDTO)
        {
            Funcionario funcionario = mapper.MapperDTOToEntity(funcionarioDTO);
            service.Update(funcionario);
        }

        public int Validate(string usuario, string senha)
        {
            return service.Validate(usuario, senha);
        }
    }
}
