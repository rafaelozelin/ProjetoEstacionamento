using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Enums;

namespace ProjetoEstacionamento.Dto.Vaga
{
    public class VagaVeiculoResponse
    {
        public int Quantidade { get; set; }
        public string TipoVaga { get; set; }
        public List<VeiculoResponse> Veiculos { get; set; }
    }
}
