using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Enums;

namespace ProjetoEstacionamento.Services
{
    public interface IVeiculoService
    {
        public ETipoVeiculo TipoVeiculo { get; }
        Task CadastrarAsync(VeiculoRequest veiculoRequest);
        Task AtualizarAsync(VeiculoRequest veiculoRequest, int id);
    }
}
