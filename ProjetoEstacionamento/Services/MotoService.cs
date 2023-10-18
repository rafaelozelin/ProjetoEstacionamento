using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Entities;
using ProjetoEstacionamento.Enums;
using ProjetoEstacionamento.Repositories;

namespace ProjetoEstacionamento.Services
{
    public class MotoService : IVeiculoService
    {
        public ETipoVeiculo TipoVeiculo => ETipoVeiculo.Moto;
        private readonly IVeiculoRepository _veiculoRepository;

        public MotoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task CadastrarAsync(VeiculoRequest veiculoRequest)
        {
            var moto = new Veiculo()
            {
                Placa = "xxx",
                Entrada = DateTime.Now,
                TipoVeiculo = ETipoVeiculo.Moto,
                IdVaga = 0
            };

            await _veiculoRepository.Cadastrar(moto);
        }
    }
}
