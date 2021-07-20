using System;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuAcerto.Selecao.KataGildedRose.API.Controllers
{
    /// <summary>
    /// API para a entidade Item, respondendo nas rotas /item e /api/item.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        /// <summary>
        /// Atualiza a qualidade de todos os itens do estoque, de acordo com o número de dias fornecidos.
        /// </summary>
        /// <param name="dias">Número de dias que sera utilizado para atualizar o estoque.</param>
        /// <response code="200">Estoque atualizado com sucesso.</response>
        /// <response code="400">Falha ao atualizar estoque.</response>
        /// <response code="404">Falha ao buscar item do estoque para ser atualizado</response>
        [HttpGet("[action]/{dias:int:min(0)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AtualizarQualidade(int dias)
        {
            try
            {
                _estoqueService.AtualizarQualidadeEstoque(dias);
                return Ok();
            }
            catch (EntityNotFoundException<Item>)
            {
                return NotFound();
            }
            catch (UpdateFailedException<Item>)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}