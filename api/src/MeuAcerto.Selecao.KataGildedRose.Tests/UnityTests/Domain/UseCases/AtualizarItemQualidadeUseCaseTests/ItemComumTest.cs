using System;
using FluentAssertions;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Domain.Enums;
using MeuAcerto.Selecao.KataGildedRose.Domain.UseCases;
using Xunit;

namespace MeuAcerto.Selecao.KataGildedRose.Tests.UnityTests.Domain.UseCases.AtualizarItemQualidadeUseCaseTests
{
    public class ItemComumTest
    {
        [Fact]
        public void AtualizarQualidade_ItemComum_DentroPrazoValidade()
        {
            // Arrange
            DateTime tomorrow = DateTime.Today.AddDays(1);
            Item item = new Item
            {
                Id = 1, Nome = "Corselete +5 DEX", PrazoValidade = tomorrow, Qualidade = 20,
                Categoria = ItemCategoria.Comum
            };
            Item targetItem = new Item
            {
                Id = 1, Nome = "Corselete +5 DEX", PrazoValidade = tomorrow, Qualidade = 19,
                Categoria = ItemCategoria.Comum
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemComum_ForaPrazoValidade()
        {
            // Arrange
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Item item = new Item
            {
                Id = 1, Nome = "Corselete +5 DEX", PrazoValidade = yesterday, Qualidade = 20,
                Categoria = ItemCategoria.Comum
            };
            Item targetItem = new Item
            {
                Id = 1, Nome = "Corselete +5 DEX", PrazoValidade = yesterday, Qualidade = 18,
                Categoria = ItemCategoria.Comum
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemComum_Qualiadade0()
        {
            // Arrange
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Item item = new Item
            {
                Id = 1, Nome = "Corselete +5 DEX", PrazoValidade = yesterday, Qualidade = 0,
                Categoria = ItemCategoria.Comum
            };
            Item targetItem = new Item
            {
                Id = 1, Nome = "Corselete +5 DEX", PrazoValidade = yesterday, Qualidade = 0,
                Categoria = ItemCategoria.Comum
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemComum_QualiadadeNegativa()
        {
            // Arrange
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Item item = new Item
            {
                Id = 1, Nome = "Corselete +5 DEX", PrazoValidade = yesterday, Qualidade = 1,
                Categoria = ItemCategoria.Comum
            };
            Item targetItem = new Item
            {
                Id = 1, Nome = "Corselete +5 DEX", PrazoValidade = yesterday, Qualidade = 0,
                Categoria = ItemCategoria.Comum
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }
    }
}