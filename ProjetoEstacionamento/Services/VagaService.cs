using AutoMapper;
using ProjetoEstacionamento.Dto.Vaga;
using ProjetoEstacionamento.Entities;
using ProjetoEstacionamento.Enums;
using ProjetoEstacionamento.Extensions;
using ProjetoEstacionamento.Repositories;

namespace ProjetoEstacionamento.Services
{
    public class VagaService : IVagaService
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IMapper _mapper;

        public VagaService(IMapper mapper, IVagaRepository vagaRepository)
        {
            _mapper = mapper;
            _vagaRepository = vagaRepository;
        }

        public async Task Cadastrar(List<VagaRequest> vagaRequest)
        { 
            var vagas = vagaRequest.Select(v => _mapper.Map<Vaga>(v)).ToList();

            await _vagaRepository.Cadastrar(vagas);
        }

        public async Task<VagaResponse> Consultar()
        {
            var vagas = await _vagaRepository.Consultar();

            var result = new VagaResponse
            {
                TotalVagas = vagas.Sum(v => v.Quantidade),
                TotalVagasRestante = VerificarVagasRestante(vagas),
                VagasDetalhada = vagas.Select(vaga => new VagasDetalhada
                {
                    TipoVaga = vaga.TipoVaga.GetDescription(),
                    QuantidadeTotal = vaga.Quantidade,
                    QuantidadeRestante = vaga.Quantidade - vaga.Veiculos.Where(ve => ve.Saida is null).Count(),
                    StatusEstacionamento = VerificarStatus(vaga).GetDescription()
                }).ToList()
            }; 

            return result;
        }

        public async Task<int> ConsultarVagasRestantes()
        {
            var vagas = await _vagaRepository.Consultar();

            return VerificarVagasRestante(vagas);
        }

        public async Task<int> ConsultarTotalVagas()
        {
            var vagas = await _vagaRepository.Consultar();

            return vagas.Sum(v => v.Quantidade);
        }

        private static int VerificarVagasRestante(List<Vaga> vagas)
        {
            return vagas.Sum(v => v.Quantidade) - vagas.SelectMany(va => va.Veiculos.Where(ve => ve.Saida is null)).Count();
        }

        private static EStatusEstacionamento VerificarStatus(Vaga vaga)
        {
            var quantidadeRestante = vaga.Veiculos.Where(ve => ve.Saida is null).Count();
            var quantidadeTotal = vaga.Quantidade;

            if (quantidadeTotal == quantidadeRestante)
                return EStatusEstacionamento.Vazio;
            else if (quantidadeRestante == 0)
                return EStatusEstacionamento.Cheio;

            return EStatusEstacionamento.HaVagas;
        }
    }
}
