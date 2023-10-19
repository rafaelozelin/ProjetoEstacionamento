using AutoMapper;
using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Entities;
using ProjetoEstacionamento.Extensions;

namespace ProjetoEstacionamento.Profiles
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<Veiculo, VeiculoRequest>();
            CreateMap<Veiculo, VeiculoResponse>()
                .ForMember(dto => dto.TipoVeiculo, opts => opts.MapFrom(domain => domain.TipoVeiculo.GetDescription()));

            CreateMap<VeiculoRequest, Veiculo>();
            CreateMap<VeiculoResponse, Veiculo>();
        }
    }
}
