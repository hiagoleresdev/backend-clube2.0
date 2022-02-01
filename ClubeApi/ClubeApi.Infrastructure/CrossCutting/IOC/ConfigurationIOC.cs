using Autofac;
using ClubeApi.Application.ApplicationServices;
using ClubeApi.Application.Interfaces.ApplicationServices;
using ClubeApi.Application.Interfaces.Mappers;
using ClubeApi.Application.Mappers;
using ClubeApi.Domain.Core.Interfaces.Repositories;
using ClubeApi.Domain.Core.Interfaces.Services;
using ClubeApi.Domain.Services.Services;
using ClubeApi.Infrastructure.Data.Repositories;

namespace ClubeApi.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            //Inversão de controle com injeções de dependência
            #region IOC

            builder.RegisterType<ApplicationServiceSocio>().As<IApplicationServiceSocio>();
            builder.RegisterType<ApplicationServiceDependente>().As<IApplicationServiceDependente>();
            builder.RegisterType<ApplicationServiceFuncionario>().As<IApplicationServiceFuncionario>();
            builder.RegisterType<ApplicationServiceMensalidade>().As<IApplicationServiceMensalidade>();
            builder.RegisterType<ApplicationServiceCategoria>().As<IApplicationServiceCategoria>();

            builder.RegisterType<ServiceSocio>().As<IServiceSocio>();
            builder.RegisterType<ServiceDependente>().As<IServiceDependente>();
            builder.RegisterType<ServiceFuncionario>().As<IServiceFuncionario>();
            builder.RegisterType<ServiceMensalidade>().As<IServiceMensalidade>();
            builder.RegisterType<ServiceCategoria>().As<IServiceCategoria>();

            builder.RegisterType<RepositorySocio>().As<IRepositorySocio>();
            builder.RegisterType<RepositoryDependente>().As<IRepositoryDependente>();
            builder.RegisterType<RepositoryFuncionario>().As<IRepositoryFuncionario>();
            builder.RegisterType<RepositoryMensalidade>().As<IRepositoryMensalidade>();
            builder.RegisterType<RepositoryCategoria>().As<IRepositoryCategoria>();

            builder.RegisterType<MapperSocio>().As<IMapperSocio>();
            builder.RegisterType<MapperDependente>().As<IMapperDependente>();
            builder.RegisterType<MapperFuncionario>().As<IMapperFuncionario>();
            builder.RegisterType<MapperMensalidade>().As<IMapperMensalidade>();
            builder.RegisterType<MapperCategoria>().As<IMapperCategoria>();

            #endregion
        }
    }
}
