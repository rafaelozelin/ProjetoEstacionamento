using AutoMapper;
using ProjetoEstacionamento.Dto.Vaga;
using ProjetoEstacionamento.Entities;

namespace ProjetoEstacionamento.Profiles
{
    public class VagaProfile : Profile
    {
        public VagaProfile()
        {
            CreateMap<Vaga, VagaRequest>();
            CreateMap<Vaga, VagaResponse>();

            CreateMap<VagaRequest, Vaga>();
            CreateMap<VagaResponse, Vaga>();
        }
    }
}
