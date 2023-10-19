using AutoMapper;
using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Entities;
using ProjetoEstacionamento.Enums;
using ProjetoEstacionamento.Repositories;

namespace ProjetoEstacionamento.Services
{
    public class CarroService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVagaRepository _vagaRepository;
        private readonly IMapper _mapper;

        public ETipoVeiculo TipoVeiculo => ETipoVeiculo.Carro;

        public CarroService(IVeiculoRepository veiculoRepository, IVagaRepository vagaRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _vagaRepository = vagaRepository;
            _mapper = mapper;
        }

        public async Task CadastrarAsync(VeiculoRequest veiculoRequest)
        {
            var tipoVagas = new List<ETipoVaga>() { ETipoVaga.Carro, ETipoVaga.Grande };

            var vagas = await _vagaRepository.ConsultarPorTipos(tipoVagas);

            if (!vagas.Any())
                throw new Exception("Solicitar criação do estacionamento de carros");

            var temVaga = VerificaVagas(vagas);

            if (!temVaga.Item1)
                throw new Exception("Não há vagas para carros");

            var veiculo = MontarVeiculo(veiculoRequest, temVaga.Item2);

            await _veiculoRepository.CadastrarVeiculoAsync(veiculo);
        }

        public async Task AtualizarAsync(VeiculoRequest veiculoRequest, int id)
        {
            if (veiculoRequest.Id != id)
                throw new Exception("Carro não encontrado");

            var veiculo = await _veiculoRepository.GetById(id);

            if (veiculo is null)
                throw new Exception("Carro não encontrado");

            veiculo.Placa = veiculoRequest.Placa;
            veiculo.Saida = DateTime.Now;

            await _veiculoRepository.AtulizarVeiculoAsync(veiculo);
        }

        private Veiculo MontarVeiculo(VeiculoRequest veiculoRequest, int idVaga)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoRequest);

            veiculo.Entrada = DateTime.Now;
            veiculo.TipoVeiculo = ETipoVeiculo.Carro;
            veiculo.IdVaga = idVaga;

            return veiculo;
        }

        private static (bool, int) VerificaVagas(List<Vaga> vagas)
        {
            var tipoVagas = new List<ETipoVaga>() { ETipoVaga.Carro, ETipoVaga.Grande };
            var temVaga = false;
            var idVaga = 0;

            foreach (var tipo in tipoVagas)
            {
                var vagaEspecifica = vagas.Where(vaga => vaga.TipoVaga == tipo).First();

                var totalVagas = vagaEspecifica.Quantidade;
                var vagasEmUso = vagaEspecifica.Veiculos.Where(ve => ve.Saida is null).Count();

                if (vagasEmUso < totalVagas)
                {
                    temVaga = true;
                    idVaga = vagaEspecifica.Id;
                    break;
                }
            }

            return (temVaga, idVaga);
        }
    }
}

