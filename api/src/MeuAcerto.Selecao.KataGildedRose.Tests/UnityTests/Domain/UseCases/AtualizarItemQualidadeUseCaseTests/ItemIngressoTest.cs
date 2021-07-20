using System;
using FluentAssertions;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Domain.Enums;
using MeuAcerto.Selecao.KataGildedRose.Domain.UseCases;
using Xunit;

namespace MeuAcerto.Selecao.KataGildedRose.Tests.UnityTests.Domain.UseCases.AtualizarItemQualidadeUseCaseTests
{
    public class ItemIngressoTest
    {
        [Fact]
        public void AtualizarQualidade_ItemIngresso_PrazoValidadeMaior10()
        {
            // Arrange
            DateTime targetDay = DateTime.Today.AddDays(11);
            Item item = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = targetDay,
                Qualidade = 20,
                Categoria = ItemCategoria.Ingresso
            };
            Item targetItem = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = targetDay,
                Qualidade = 21,
                Categoria = ItemCategoria.Ingresso
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemIngresso_PrazoValidadeMenor11()
        {
            // Arrange
            DateTime targetDay = DateTime.Today.AddDays(10);
            Item item = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = targetDay,
                Qualidade = 20,
                Categoria = ItemCategoria.Ingresso
            };
            Item targetItem = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = targetDay,
                Qualidade = 22,
                Categoria = ItemCategoria.Ingresso
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemIngresso_PrazoValidadeMenor6()
        {
            // Arrange
            DateTime targetDay = DateTime.Today.AddDays(5);
            Item item = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = targetDay,
                Qualidade = 20,
                Categoria = ItemCategoria.Ingresso
            };
            Item targetItem = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = targetDay,
                Qualidade = 23,
                Categoria = ItemCategoria.Ingresso
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }
        
        [Fact]
        public void AtualizarQualidade_ItemIngresso_ForaPrazoValidade()
        {
            // Arrange
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Item item = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = yesterday,
                Qualidade = 50,
                Categoria = ItemCategoria.Ingresso
            };
            Item targetItem = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = yesterday,
                Qualidade = 0,
                Categoria = ItemCategoria.Ingresso
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemIngresso_Qualiadade0()
        {
            // Arrange
            DateTime targetDay = DateTime.Today.AddDays(1);
            Item item = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = targetDay,
                Qualidade = 0,
                Categoria = ItemCategoria.Ingresso
            };
            Item targetItem = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = targetDay,
                Qualidade = 3,
                Categoria = ItemCategoria.Ingresso
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }

        [Fact]
        public void AtualizarQualidade_ItemIngresso_Qualiadade50()
        {
            // Arrange
            DateTime tomorrow = DateTime.Today.AddDays(1);
            Item item = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = tomorrow,
                Qualidade = 50,
                Categoria = ItemCategoria.Ingresso
            };
            Item targetItem = new Item
            {
                Id = 6,
                Nome = "Ingressos para o concerto do TAFKAL80ETC",
                PrazoValidade = tomorrow,
                Qualidade = 50,
                Categoria = ItemCategoria.Ingresso
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();

            // Act
            useCase.AtualizarQualidade(item);

            // Assert
            item.Should().BeEquivalentTo(targetItem);
        }
    }
}