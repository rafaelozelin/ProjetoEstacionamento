using System.ComponentModel;
using System.Runtime.Serialization;

namespace ProjetoEstacionamento.Enums
{
    public enum ETipoVeiculo
    {
        [EnumMember]
        [Description("Moto")]
        Moto = 0,

        [EnumMember]
        [Description("Carro")]
        Carro = 1,

        [EnumMember]
        [Description("Van")]
        Van = 2,
    }
}
