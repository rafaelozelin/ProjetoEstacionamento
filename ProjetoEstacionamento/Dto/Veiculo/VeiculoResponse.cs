﻿using ProjetoEstacionamento.Enums;

namespace ProjetoEstacionamento.Dto.Veiculo
{
    public class VeiculoResponse
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string TipoVeiculo { get; set; }
        public DateTimeOffset Entrada { get; set; }
        public DateTimeOffset? Saida { get; set; }
    }
}
