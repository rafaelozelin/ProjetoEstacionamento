using AutoMapper;
using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Entities;
using ProjetoEstacionamento.Enums;
using ProjetoEstacionamento.Repositories;

namespace ProjetoEstacionamento.Services
{
    public class VanService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVagaRepository _vagaRepository;
        private readonly IMapper _mapper;

        public ETipoVeiculo TipoVeiculo => ETipoVeiculo.Van;

        public VanService(IVeiculoRepository veiculoRepository, IVagaRepository vagaRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _vagaRepository = vagaRepository;
            _mapper = mapper;
        }

        public async Task CadastrarAsync(VeiculoRequest veiculoRequest)
        {
            var i = 0;
            var dataEntrada = DateTime.Now;
            var tipoVagas = new List<ETipoVaga>() { ETipoVaga.Carro, ETipoVaga.Grande };

            var vagas = await _vagaRepository.ConsultarPorTipos(tipoVagas);

            if (!vagas.Any())
                throw new Exception("Solicitar criação do estacionamento de vans");

            var temVaga = VerificaVagas(vagas);

            if (!temVaga.Item1)
                throw new Exception("Não há vagas para vans");
            
            while (i < temVaga.Item3)
            {
                var veiculo = MontarVeiculo(veiculoRequest, temVaga.Item2, dataEntrada);
                await _veiculoRepository.CadastrarVeiculoAsync(veiculo);
                i++;
            } 
        }

        public async Task AtualizarAsync(VeiculoRequest veiculoRequest, int id)
        {
            if (veiculoRequest.Id != id)
                throw new Exception("Van não encontrada");

            var veiculo = await _veiculoRepository.GetById(id);

            if (veiculo is null)
                throw new Exception("Van não encontrada");

            var vans = await _veiculoRepository.GetByEntrada(veiculo.Entrada);

            foreach (var van in vans)
            {
                van.Placa = veiculo.Placa;
                van.Saida = DateTime.Now;
                await _veiculoRepository.AtulizarVeiculoAsync(veiculo);
            }
        }

        private Veiculo MontarVeiculo(VeiculoRequest veiculoRequest, int idVaga, DateTime dataEntrada)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoRequest);

            veiculo.Entrada = dataEntrada;
            veiculo.TipoVeiculo = ETipoVeiculo.Van;
            veiculo.IdVaga = idVaga;

            return veiculo;
        }

        private static (bool, int, int) VerificaVagas(List<Vaga> vagas)
        {
            var tipoVagas = new List<ETipoVaga>() { ETipoVaga.Grande, ETipoVaga.Carro };
            var temVaga = false;
            var quantidadeVagas = 0;
            var idVaga = 0;

            foreach (var tipo in tipoVagas)
            {
                var vagaEspecifica = vagas.Where(vaga => vaga.TipoVaga == tipo).First();

                var totalVagas = vagaEspecifica.Quantidade;
                var vagasEmUso = vagaEspecifica.Veiculos.Where(ve => ve.Saida is null).Count();

                if (vagasEmUso < totalVagas && vagaEspecifica.TipoVaga == ETipoVaga.Grande)
                {
                    temVaga = true;
                    idVaga = vagaEspecifica.Id;
                    quantidadeVagas = 1;
                    break;
                }

                if (((totalVagas - vagasEmUso) / 3) >= 1 && vagaEspecifica.TipoVaga == ETipoVaga.Carro)
                {
                    temVaga = true;
                    idVaga = vagaEspecifica.Id;
                    quantidadeVagas = 3;
                    break;
                }
            }

            return (temVaga, idVaga, quantidadeVagas);
        }
    }
}

