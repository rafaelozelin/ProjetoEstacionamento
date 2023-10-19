using ProjetoEstacionamento.Entities;
using ProjetoEstacionamento.Enums;

namespace ProjetoEstacionamento.Repositories.Interfaces
{
    public interface IVagaRepository
    {
        public Task Cadastrar(List<Vaga> vagas);
        public Task<List<Vaga>> Consultar();
        public Task<List<Vaga>> ConsultarPorTipos(List<TipoVaga> tipoVaga);
    }
}
