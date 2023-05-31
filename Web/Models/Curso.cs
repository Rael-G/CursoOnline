﻿using CursoOnline.Web.Models.Enums;

namespace CursoOnline.Web.Models
{
	public class Curso
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public double CargaHoraria { get; set; }
		public PublicoAlvo PublicoAlvo { get; set; }
		public double Valor { get; set; }

		public Curso() { }

		public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
		{
			if (nome == string.Empty || nome == null)
			{
				throw new ArgumentException("Nome Inválido!");
			}

			if (cargaHoraria < 1)
			{
				throw new ArgumentException("Carga Horária Inválida!");
			}

			if (valor <= 1)
			{
				throw new ArgumentException("Valor Inválido!");
			}

			Nome = nome;
			Descricao = descricao;
			CargaHoraria = cargaHoraria;
			PublicoAlvo = publicoAlvo;
			Valor = valor;
		}
	}
}