using System;
using System.Collections.Generic;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuAcerto.Selecao.KataGildedRose.API.Controllers
{
    /// <summary>
    /// API para as funcionalidades do Estoque, respondendo nas rotas /api/estoque e /estoque
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// Busca todos os itens.
        /// </summary>
        /// <response code="200">Itens persistidos.</response>
        /// <response code="400">Falha ao buscar itens.</response> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Item>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Item>> Get()
        {
            try
            {
                return Ok(_itemService.All());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Tenta buscar o item identificado pelo id fornecido.
        /// </summary>
        /// <param name="id">Identicador do item desejado.</param>
        /// <response code="200">Item dejesado.</response>
        /// <response code="400">Falha ao buscar item.</response>
        /// <response code="404">Item não encontrado.</response>
        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Item> Get(long id)
        {
            try
            {
                Item item = _itemService.Read(id);
                return Ok(item);
            }
            catch (EntityNotFoundException<Item>)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Adicionar o item fornecido.
        /// </summary>
        /// <param name="item">Entidade para ser adicionada.</param>
        /// <response code="200">Item adicionado com sucesso.</response>
        /// <response code="400">Falha ao adicionar item.</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] Item item)
        {
            try
            {
                _itemService.Create(item);
                return Ok();
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

        /// <summary>
        /// Persiste as mudanças feitas no item fornecido
        /// </summary>
        /// <param name="item">Entidade para ser atualizado.</param>
        /// <response code="200">Item atualizado com sucesso.</response>
        /// <response code="400">Falha ao atualizar item.</response> 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(Item item)
        {
            try
            {
                _itemService.Update(item);
                return Ok();
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

        /// <summary>
        /// Tenta remover o item identificado com o id.
        /// </summary>
        /// <param name="id">Identicador do item a ser removido.</param>
        /// <response code="200">Item removido com sucesso.</response>
        /// <response code="400">Falha ao remover item.</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(long id)
        {
            try
            {
                _itemService.Delete(id);
                return Ok();
            }
            catch (DeleteFailedException<Item>)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Atualiza a qualidade do item especificado, caso o mesmo exista.
        /// </summary>
        /// <param name="id">Identicador do item a ser atualizado.</param>
        /// <response code="200">Qualidade do item atualizada com sucesso.</response>
        /// <response code="400">Falha ao qualidade do item.</response>
        /// <response code="404">Falha ao encontrar item para ser atualizado.</response>
        [HttpGet("{id:long}/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Item> AtualizarQualidade(long id)
        {
            try
            {
                Item item = _itemService.AtualizarQualidade(id);
                return Ok(item);
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