using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Entities;
using ProjetoEstacionamento.Enums;
using ProjetoEstacionamento.Repositories;

namespace ProjetoEstacionamento.Services
{
    public class VanService : IVeiculoService
    {
        public ETipoVeiculo TipoVeiculo => ETipoVeiculo.Van;
        private readonly IVeiculoRepository _veiculoRepository;

        public VanService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task CadastrarAsync(VeiculoRequest veiculoRequest)
        {
            var van = new Veiculo()
            {
                Placa = "yyy",
                Entrada = DateTime.Now,
                TipoVeiculo = ETipoVeiculo.Van,
                IdVaga = 1
            };

            await _veiculoRepository.Cadastrar(van);
        }
    }
}
