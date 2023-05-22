using CursoOnline.Dominio.Cursos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dominio.Cursos
{
	public class Curso
	{
		public string Nome { get; private set; }
		public string Descricao { get; set; }
		public double CargaHoraria { get; private set; }
		public PublicoAlvo PublicoAlvo { get; private set; }
		public double Valor { get; private set; }

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
