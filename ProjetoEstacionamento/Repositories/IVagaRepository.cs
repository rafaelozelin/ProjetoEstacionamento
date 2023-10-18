using ProjetoEstacionamento.Entities;

namespace ProjetoEstacionamento.Repositories
{
    public interface IVagaRepository
    {
        public Task Cadastrar(List<Vaga> vagas);
        public Task<List<Vaga>> Consultar();
    }
}
