using ProjetoEstacionamento.Entities;

namespace ProjetoEstacionamento.Repositories
{
    public interface IVeiculoRepository
    {
        public Task CadastrarVeiculoAsync(Veiculo veiculo);
        public Task<Veiculo> GetById(int id);
        public Task AtulizarVeiculoAsync(Veiculo veiculo);
        public Task<List<Veiculo>> GetByEntrada(DateTime entrada);
    }
}
