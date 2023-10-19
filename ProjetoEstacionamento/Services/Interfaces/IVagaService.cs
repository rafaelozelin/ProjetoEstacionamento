using ProjetoEstacionamento.Dto.Vaga;

namespace ProjetoEstacionamento.Services.Interfaces
{
    public interface IVagaService
    {
        public Task Cadastrar(List<VagaRequest> vagaRequest);
        public Task<VagaResponse> Consultar();
        public Task<int> ConsultarVagasRestantes();
        public Task<int> ConsultarTotalVagas();
        public Task<List<VagaVeiculoResponse>> ListarVeiculos();
    }
}
