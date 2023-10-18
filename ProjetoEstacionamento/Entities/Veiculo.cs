using ProjetoEstacionamento.Enums;

namespace ProjetoEstacionamento.Entities
{
    public class Veiculo : BaseEntity
    {
        public string Placa { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public ETipoVeiculo TipoVeiculo { get; set; }
        public int IdVaga { get; set; }
        public virtual Vaga Vaga { get; set; }
    }
}
