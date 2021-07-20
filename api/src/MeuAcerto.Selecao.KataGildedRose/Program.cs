using System;
using System.Collections.Generic;

namespace MeuAcerto.Selecao.KataGildedRose
{
	class Program
	{
		public static void Main(string[] args)
		{
			IList<Item> itens = new List<Item>{
				new Item {Nome = "Corselete +5 DEX", PrazoValidade = 10, Qualidade = 20},
				new Item {Nome = "Queijo Brie Envelhecido", PrazoValidade = 2, Qualidade = 0},
				new Item {Nome = "Elixir do Mangusto", PrazoValidade = 5, Qualidade = 7},
				new Item {Nome = "Sulfuras, a Mão de Ragnaros", PrazoValidade = 0, Qualidade = 80},
				new Item {Nome = "Sulfuras, a Mão de Ragnaros", PrazoValidade = -1, Qualidade = 80},
				new Item
				{
					Nome = "Ingressos para o concerto do TAFKAL80ETC",
					PrazoValidade = 15,
					Qualidade = 20
				},
				new Item
				{
					Nome = "Ingressos para o concerto do TAFKAL80ETC",
					PrazoValidade = 10,
					Qualidade = 49
				},
				new Item
				{
					Nome = "Ingressos para o concerto do TAFKAL80ETC",
					PrazoValidade = 5,
					Qualidade = 49
				},
				// Este item conjurado ainda não funciona direto!
				new Item {Nome = "Bolo de Mana Conjurado", PrazoValidade = 3, Qualidade = 6}
			};

			var app = new GildedRose(itens);


			for (var i = 0; i < 30; i++)
			{
				Console.WriteLine("-------- dia " + i + " --------");
				Console.WriteLine("Nome, PrazoValidade, Qualidade");
				for (var j = 0; j < itens.Count; j++)
				{
					Console.WriteLine(itens[j].Nome + ", " + itens[j].PrazoValidade + ", " + itens[j].Qualidade);
				}
				app.AtualizarQualidade();
			}
		}

	}
}
