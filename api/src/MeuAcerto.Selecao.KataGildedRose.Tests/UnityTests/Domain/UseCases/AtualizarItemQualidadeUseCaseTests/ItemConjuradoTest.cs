using System;
using FluentAssertions;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Domain.Enums;
using MeuAcerto.Selecao.KataGildedRose.Domain.UseCases;
using Xunit;

namespace MeuAcerto.Selecao.KataGildedRose.Tests.UnityTests.Domain.UseCases.AtualizarItemQualidadeUseCaseTests
{
    public class ItemConjuradoTest
    {
        [Fact]
        public void AtualizarQualidade_ItemConjurado_DentroPrazoValidade()
        {
            // Arrange
            DateTime tomorrow = DateTime.Today.AddDays(1);
            Item item = new Item
            {
                Id = 9, Nome = "Bolo de Mana Conjurado", PrazoValidade = tomorrow, Qualidade = 6,
                Categoria = ItemCategoria.Conjurado
            };
            Item targetItem = new Item
            {
                Id = 9, Nome = "Bolo de Mana Conjurado", PrazoValidade = tomorrow, Qualidade = 4,
                Categoria = ItemCategoria.Conjurado
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemConjurado_ForaPrazoValidade()
        {
            // Arrange
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Item item = new Item
            {
                Id = 9, Nome = "Bolo de Mana Conjurado", PrazoValidade = yesterday, Qualidade = 6,
                Categoria = ItemCategoria.Conjurado
            };
            Item targetItem = new Item
            {
                Id = 9, Nome = "Bolo de Mana Conjurado", PrazoValidade = yesterday, Qualidade = 2,
                Categoria = ItemCategoria.Conjurado
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemConjurado_Qualiadade0()
        {
            // Arrange
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Item item = new Item
            {
                Id = 9, Nome = "Bolo de Mana Conjurado", PrazoValidade = yesterday, Qualidade = 0,
                Categoria = ItemCategoria.Conjurado
            };
            Item targetItem = new Item
            {
                Id = 9, Nome = "Bolo de Mana Conjurado", PrazoValidade = yesterday, Qualidade = 0,
                Categoria = ItemCategoria.Conjurado
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemConjurado_QualiadadeNegativa()
        {
            // Arrange
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Item item = new Item
            {
                Id = 9, Nome = "Bolo de Mana Conjurado", PrazoValidade = yesterday, Qualidade = 1,
                Categoria = ItemCategoria.Conjurado
            };
            Item targetItem = new Item
            {
                Id = 9, Nome = "Bolo de Mana Conjurado", PrazoValidade = yesterday, Qualidade = 0,
                Categoria = ItemCategoria.Conjurado
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }
    }
}