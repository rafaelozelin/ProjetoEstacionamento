using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Enums;

namespace ProjetoEstacionamento.Services.Interfaces
{
    public interface IVeiculoService
    {
        public TipoVeiculo TipoVeiculo { get; }
        Task CadastrarAsync(VeiculoRequest veiculoRequest);
        Task AtualizarAsync(VeiculoRequest veiculoRequest, int id);
        Task<List<VeiculoResponse>> ListarAsync(); 
    }
}
