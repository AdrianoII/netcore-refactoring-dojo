using System;
using FluentAssertions;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Domain.Enums;
using MeuAcerto.Selecao.KataGildedRose.Domain.UseCases;
using Xunit;

namespace MeuAcerto.Selecao.KataGildedRose.Tests.UnityTests.Domain.UseCases.AtualizarItemQualidadeUseCaseTests
{
    public class ItemTemporalTest
    {
        [Fact]
        public void AtualizarQualidade_ItemTemporal_DentroPrazoValidade()
        {
            // Arrange
            DateTime tomorrow = DateTime.Today.AddDays(1);
            Item item = new Item
            {
                Id = 2, Nome = "Queijo Brie Envelhecido", PrazoValidade = tomorrow, Qualidade = 10,
                Categoria = ItemCategoria.Temporal
            };
            Item targetItem = new Item
            {
                Id = 2, Nome = "Queijo Brie Envelhecido", PrazoValidade = tomorrow, Qualidade = 11,
                Categoria = ItemCategoria.Temporal
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemTemporal_ForaPrazoValidade()
        {
            // Arrange
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Item item = new Item
            {
                Id = 2, Nome = "Queijo Brie Envelhecido", PrazoValidade = yesterday, Qualidade = 10,
                Categoria = ItemCategoria.Temporal
            };
            Item targetItem = new Item
            {
                Id = 2, Nome = "Queijo Brie Envelhecido", PrazoValidade = yesterday, Qualidade = 12,
                Categoria = ItemCategoria.Temporal
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemTemporal_Qualiadade0()
        {
            // Arrange
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Item item = new Item
            {
                Id = 2, Nome = "Queijo Brie Envelhecido", PrazoValidade = yesterday, Qualidade = 0,
                Categoria = ItemCategoria.Temporal
            };
            Item targetItem = new Item
            {
                Id = 2, Nome = "Queijo Brie Envelhecido", PrazoValidade = yesterday, Qualidade = 2,
                Categoria = ItemCategoria.Temporal
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemTemporal_Qualiadade50()
        {
            // Arrange
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Item item = new Item
            {
                Id = 2, Nome = "Queijo Brie Envelhecido", PrazoValidade = yesterday, Qualidade = 50,
                Categoria = ItemCategoria.Temporal
            };
            Item targetItem = new Item
            {
                Id = 2, Nome = "Queijo Brie Envelhecido", PrazoValidade = yesterday, Qualidade = 50,
                Categoria = ItemCategoria.Temporal
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }
    }
}