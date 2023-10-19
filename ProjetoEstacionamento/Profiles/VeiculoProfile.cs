using AutoMapper;
using ProjetoEstacionamento.Dto;
using ProjetoEstacionamento.Dto.Vaga;
using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Entities;

namespace ProjetoEstacionamento.Profiles
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<Veiculo, VeiculoRequest>();
            CreateMap<Veiculo, VeiculoResponse>();

            CreateMap<VeiculoRequest, Veiculo>();
            CreateMap<VeiculoResponse, Veiculo>();
        }
    }
}
