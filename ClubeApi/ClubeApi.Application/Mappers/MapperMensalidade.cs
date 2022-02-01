using ClubeApi.Application.DTOs;
using ClubeApi.Application.Interfaces.Mappers;
using ClubeApi.Domain.Models;

namespace ClubeApi.Application.Mappers
{
    public class MapperMensalidade : IMapperMensalidade
    {
        public Mensalidade MapperDTOToEntity(MensalidadeDTO mensalidadeDTO, Socio socio)
        {
            Mensalidade mensalidade = new Mensalidade()
            {
                Id = mensalidadeDTO.Id,
                DataVencimento = mensalidadeDTO.DataVencimento,
                ValorInicial = mensalidadeDTO.ValorInicial,
                DataPagamento = mensalidadeDTO.DataPagamento,
                Juros = mensalidadeDTO.Juros,
                ValorFinal = mensalidadeDTO.ValorFinal,
                Quitada = mensalidadeDTO.Quitada,
                Socio = socio
            };

            return mensalidade;
        }
    }
}
