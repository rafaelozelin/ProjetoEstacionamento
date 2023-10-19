using ProjetoEstacionamento.Entities;
using ProjetoEstacionamento.Enums;

namespace ProjetoEstacionamento.Repositories.Interfaces
{
    public interface IVeiculoRepository
    {
        public Task CadastrarVeiculoAsync(Veiculo veiculo);
        public Task<Veiculo> GetById(int id);
        public Task AtulizarVeiculoAsync(Veiculo veiculo);
        public Task<List<Veiculo>> GetByEntrada(DateTime entrada);
        public Task<List<Veiculo>> GetByTipo(TipoVeiculo tipoVeiculo);
    }
}
