using ProjetoEstacionamento.Enums;
using System;

namespace ProjetoEstacionamento.Entities
{
    public class Vaga : BaseEntity
    {
        public int Quantidade { get; set; }
        public ETipoVaga TipoVaga { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
