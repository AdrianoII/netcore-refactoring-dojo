using System;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;

namespace MeuAcerto.Selecao.KataGildedRose.Domain.Interfaces.UseCases
{
    public interface IAtualizarItemQualidadeUseCase
    {
        /// <summary>
        /// Caso de uso que acomoda as regras de como atualizar a qualidade de um item com base em sua categoria.
        /// </summary>
        /// <param name="item"></param>
        void AtualizarQualidade(Item item);
        void AtualizarQualidade(Item item, DateTime compareDay);
    }
}