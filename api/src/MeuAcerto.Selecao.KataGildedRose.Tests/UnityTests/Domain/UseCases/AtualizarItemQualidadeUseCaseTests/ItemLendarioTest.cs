using System;
using FluentAssertions;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Domain.Enums;
using MeuAcerto.Selecao.KataGildedRose.Domain.UseCases;
using Xunit;

namespace MeuAcerto.Selecao.KataGildedRose.Tests.UnityTests.Domain.UseCases.AtualizarItemQualidadeUseCaseTests
{
    public class ItemLendarioTest
    {
        [Fact]
        public void AtualizarQualidade_ItemLendario_DentroPrazoValidade()
        {
            // Arrange
            DateTime tomorrow = DateTime.Today.AddDays(1);
            Item item = new Item
            {
                Id = 4, Nome = "Sulfuras, a Mão de Ragnaros", PrazoValidade = DateTime.Today.AddDays(10),
                Qualidade = 80, Categoria = ItemCategoria.Lendario
            };
            Item targetItem = new Item
            {
                Id = 4, Nome = "Sulfuras, a Mão de Ragnaros", PrazoValidade = DateTime.Today.AddDays(10),
                Qualidade = 80, Categoria = ItemCategoria.Lendario
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemLendario_ForaPrazoValidade()
        {
            // Arrange
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Item item = new Item
            {
                Id = 4, Nome = "Sulfuras, a Mão de Ragnaros", PrazoValidade = DateTime.Today.AddDays(10),
                Qualidade = 80, Categoria = ItemCategoria.Lendario
            };
            Item targetItem = new Item
            {
                Id = 4, Nome = "Sulfuras, a Mão de Ragnaros", PrazoValidade = DateTime.Today.AddDays(10),
                Qualidade = 80, Categoria = ItemCategoria.Lendario
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }
    }
}