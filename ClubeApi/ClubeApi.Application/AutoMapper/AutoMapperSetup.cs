using AutoMapper;
using ClubeApi.Application.DTOs;
using ClubeApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClubeApi.Application.AutoMapper
{
    public class AutoMapperSetup: Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<Pessoa, PessoaDTO>();
            CreateMap<Socio, SocioDTO>();
            CreateMap<Categoria, CategoriaDTO>();

            #endregion


            #region DomainToViewModel

            CreateMap<PessoaDTO, Pessoa>();
            CreateMap<SocioDTO, Socio>();
            CreateMap<CategoriaDTO, Categoria>();

            #endregion
        }
    }
}
