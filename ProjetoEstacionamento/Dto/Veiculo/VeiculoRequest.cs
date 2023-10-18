using ProjetoEstacionamento.Enums;

namespace ProjetoEstacionamento.Dto.Veiculo
{
    public class VeiculoRequest
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public ETipoVeiculo TipoVeiculo { get; set; }
    }
}
