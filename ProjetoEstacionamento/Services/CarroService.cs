using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Entities;
using ProjetoEstacionamento.Enums;
using ProjetoEstacionamento.Repositories;

namespace ProjetoEstacionamento.Services
{
    public class CarroService : IVeiculoService
    {
        public ETipoVeiculo TipoVeiculo => ETipoVeiculo.Carro;
        private readonly IVeiculoRepository _veiculoRepository;

        public CarroService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task CadastrarAsync(VeiculoRequest veiculoRequest)
        {
            var carro = new Veiculo()
            {
                Placa = "xxx",
                Entrada = DateTime.Now,
                TipoVeiculo = ETipoVeiculo.Carro,
                IdVaga = 1
            };

            await _veiculoRepository.Cadastrar(carro);
        }
    }
}
