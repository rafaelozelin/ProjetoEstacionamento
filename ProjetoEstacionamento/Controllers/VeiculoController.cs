﻿using Microsoft.AspNetCore.Mvc;
using ProjetoEstacionamento.Dto.Veiculo;
using ProjetoEstacionamento.Factories;
using System.Net;

namespace ProjetoEstacionamento.Controllers
{
    [ApiController]
    [Route("api/v1/veiculo")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoServiceFactory _veiculoServiceFactory;

        public VeiculoController(IVeiculoServiceFactory veiculoServiceFactory)
        {
            _veiculoServiceFactory = veiculoServiceFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] VeiculoRequest veiculoRequest)
        {
            try
            {
                var servico = _veiculoServiceFactory.Create(veiculoRequest.TipoVeiculo);

                await servico.CadastrarAsync(veiculoRequest);

                return Ok();
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                  new
                  {
                      message = "Algo inesperado ocorreu",
                      detail = exception.Message
                  });
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] VeiculoRequest veiculoRequest, int id)
        {
            try
            {
                var servico = _veiculoServiceFactory.Create(veiculoRequest.TipoVeiculo);

                await servico.AtualizarAsync(veiculoRequest, id);

                return Ok();
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                  new
                  {
                      message = "Algo inesperado ocorreu",
                      detail = exception.Message
                  });
            }
        }
    }
}
