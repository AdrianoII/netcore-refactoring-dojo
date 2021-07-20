using System;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;

namespace MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services
{
    public interface IItemService : ICrudReadOnlyService<Item>
    {
        /// <summary>
        /// Atualiza a qualidade do item especificado de acordo com a categoria do mesmo.
        /// </summary>
        Item AtualizarQualidade(long id, bool isIndependentOp = true);
        Item AtualizarQualidade(long id, DateTime compareDay, bool isIndependentOp = true);
    }
}