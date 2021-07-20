using System;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Domain.Enums;
using MeuAcerto.Selecao.KataGildedRose.Domain.Exceptions;
using MeuAcerto.Selecao.KataGildedRose.Domain.Interfaces.UseCases;

namespace MeuAcerto.Selecao.KataGildedRose.Domain.UseCases
{
    public class AtualizarItemQualidadeUseCase : IAtualizarItemQualidadeUseCase
    {
        public void AtualizarQualidade(Item item)
        {
            AtualizarQualidade(item, DateTime.Today);
        }
        
        public void AtualizarQualidade(Item item, DateTime compareDay)
        {
            switch (item.Categoria)
            {
                case ItemCategoria.Comum:
                    AtualizaItemComum(item, compareDay);
                    break;
                case ItemCategoria.Temporal:
                    AtualizaItemTemporal(item, compareDay);
                    break;
                case ItemCategoria.Ingresso:
                    AtualizaItemIngresso(item, compareDay);
                    break;
                case ItemCategoria.Lendario:
                    AtualizaItemLendario(item, compareDay);
                    break;
                case ItemCategoria.Conjurado:
                    AtualizaItemConjurado(item, compareDay);
                    break;
                default:
                    throw new InvalidItemCategoriaException("ItemCategoria inválido");
            }

            if (item.Qualidade < 0)
            {
                item.Qualidade = 0;
            }

            if (item.Categoria != ItemCategoria.Lendario && item.Qualidade > 50)
            {
                item.Qualidade = 50;
            }
        }

        private void AtualizaItemComum(Item item, DateTime compareDay)
        {
            item.Qualidade += compareDay.Date < item.PrazoValidade.Value.Date ? -1 : -2;
        }
        
        private void AtualizaItemTemporal(Item item, DateTime compareDay)
        {
            item.Qualidade += compareDay.Date < item.PrazoValidade.Value.Date ? +1 : +2;
        }

        private void AtualizaItemIngresso(Item item, DateTime compareDay)
        {
            int daysToExpire = (item.PrazoValidade.Value.Date - compareDay.Date).Days;
            item.Qualidade +=  daysToExpire switch
            {
                <= 0 => -item.Qualidade, // zera a qualidade do item 
                <= 5 => 3,
                <= 10 => 2,
                _ => 1,  // daysToExpire > 10
            };
        }

        private void AtualizaItemLendario(Item item, DateTime compareDay)
        {
        }

        private void AtualizaItemConjurado(Item item, DateTime compareDay)
        {
            AtualizaItemComum(item, compareDay);
            AtualizaItemComum(item, compareDay);
        }
    }
}