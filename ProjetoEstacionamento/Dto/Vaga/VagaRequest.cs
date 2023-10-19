using ProjetoEstacionamento.Enums;

namespace ProjetoEstacionamento.Dto.Vaga
{
    public class VagaRequest
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public TipoVaga TipoVaga { get; set; } 
    }
}
