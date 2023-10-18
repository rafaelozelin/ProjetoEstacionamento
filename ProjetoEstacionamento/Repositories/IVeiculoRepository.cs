using ProjetoEstacionamento.Entities;

namespace ProjetoEstacionamento.Repositories
{
    public interface IVeiculoRepository
    {
        public Task Cadastrar(Veiculo veiculo);
    }
}
