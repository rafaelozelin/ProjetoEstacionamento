﻿using ProjetoEstacionamento.Enums;

namespace ProjetoEstacionamento.Dto.Vaga
{
    public class VagaResponse
    {
        public int TotalVagas { get; set; }
        public int TotalVagasRestante { get; set; }
        public List<VagasDetalhada> VagasDetalhada { get; set; }
    }

    public class VagasDetalhada
    {
        public string TipoVaga { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeRestante { get; set; }
        public string StatusEstacionamento { get; set; }
    }
}
