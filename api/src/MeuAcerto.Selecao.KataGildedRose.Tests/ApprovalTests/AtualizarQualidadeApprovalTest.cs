using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Domain.Enums;
using MeuAcerto.Selecao.KataGildedRose.Domain.UseCases;
using Xunit;

namespace MeuAcerto.Selecao.KataGildedRose.Tests.ApprovalTests
{
    [UseReporter(typeof(DiffReporter))]
    public class AtualizarQualidadeApprovalTest
    {
        private DateTime Today { get; set; }
        
        private int getDate(Item item, int dia)
        {
            int daysToSubtract = item.Categoria == ItemCategoria.Lendario ? 0 : dia;
            return (item.PrazoValidade.Value.Date - Today.Date).Days - daysToSubtract;
        }
        
        [Fact]
        public void AtualizarEstoque_30Dias()
        {
            // Arrange
            Today = DateTime.Today;
            IList<Item> itens = new List<Item>
            {
                new()
                {
                    Id = 1, Nome = "Corselete +5 DEX", PrazoValidade = Today.AddDays(10), Qualidade = 20,
                    Categoria = ItemCategoria.Comum
                },
                new()
                {
                    Id = 2, Nome = "Queijo Brie Envelhecido", PrazoValidade = Today.AddDays(2), Qualidade = 0,
                    Categoria = ItemCategoria.Temporal
                },
                new()
                {
                    Id = 3, Nome = "Elixir do Mangusto", PrazoValidade = Today.AddDays(5), Qualidade = 7,
                    Categoria = ItemCategoria.Comum
                },
                new()
                {
                    Id = 4, Nome = "Sulfuras, a Mão de Ragnaros", PrazoValidade = Today,
                    Qualidade = 80, Categoria = ItemCategoria.Lendario
                },
                new()
                {
                    Id = 5, Nome = "Sulfuras, a Mão de Ragnaros", PrazoValidade = Today.AddDays(-1),
                    Qualidade = 80, Categoria = ItemCategoria.Lendario
                },
                new()
                {
                    Id = 6,
                    Nome = "Ingressos para o concerto do TAFKAL80ETC",
                    PrazoValidade = Today.AddDays(15),
                    Qualidade = 20,
                    Categoria = ItemCategoria.Ingresso
                },
                new()
                {
                    Id = 7,
                    Nome = "Ingressos para o concerto do TAFKAL80ETC",
                    PrazoValidade = Today.AddDays(10),
                    Qualidade = 49,
                    Categoria = ItemCategoria.Ingresso
                },
                new()
                {
                    Id = 8,
                    Nome = "Ingressos para o concerto do TAFKAL80ETC",
                    PrazoValidade = Today.AddDays(5),
                    Qualidade = 49,
                    Categoria = ItemCategoria.Ingresso
                },
                new()
                {
                    Id = 9, Nome = "Bolo de Mana Conjurado", PrazoValidade = Today.AddDays(3), Qualidade = 6,
                    Categoria = ItemCategoria.Conjurado
                }
            };
            AtualizarItemQualidadeUseCase useCase = new AtualizarItemQualidadeUseCase();
            StringBuilder output = new StringBuilder();

            // Act
            for (int day = 0; day < 31; day++)
            {
                output.Append("-------- dia " + day + " --------\n");
                output.Append("Nome, PrazoValidade, Qualidade\n");
                output.Append(itens.Select(i =>
                        i.Nome + ", " + getDate(i, day) + ", " + i.Qualidade)
                    .Aggregate((cur, next) => cur + "\n" + next));

                for (int itemIndex = 0; itemIndex < itens.Count; itemIndex++)
                {
                    useCase.AtualizarQualidade(itens[itemIndex], Today.AddDays(day));
                }

                output.Append("\n\n");
            }

            // Assert
            Approvals.Verify(output.ToString());
        }
    }
}