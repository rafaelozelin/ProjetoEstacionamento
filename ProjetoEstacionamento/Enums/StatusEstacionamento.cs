using System.ComponentModel;
using System.Runtime.Serialization;

namespace ProjetoEstacionamento.Enums
{
    public enum StatusEstacionamento
    {
        [EnumMember]
        [Description("Cheio")]
        Cheio = 0,

        [EnumMember]
        [Description("Vazio")]
        Vazio = 1,

        [EnumMember]
        [Description("Há vagas")]
        HaVagas = 2,
    }
}
