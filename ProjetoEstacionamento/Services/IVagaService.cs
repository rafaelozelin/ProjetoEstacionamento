using ProjetoEstacionamento.Dto.Vaga;

namespace ProjetoEstacionamento.Services
{
    public interface IVagaService
    {
        public Task Cadastrar(List<VagaRequest> vagaRequest);
        public Task<VagaResponse> Consultar();
        public Task<int> ConsultarVagasRestantes();
        public Task<int> ConsultarTotalVagas();
    }
}
