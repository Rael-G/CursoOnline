using CursoOnline.DominioTest._Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.DominioTest.Curso
{
	public class CursoTest
	{
		[Fact]
		public void DeveCriarCurso()
		{
			string nome = "informatica básica";
			double cargaHoraria = 20f;
			PublicoAlvo publicoAlvo = PublicoAlvo.Estudante;
			double valor = 950f;

			Curso curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

			Assert.Equal(nome, curso.Nome);
			Assert.Equal(valor, curso.Valor);
			Assert.Equal(publicoAlvo, curso.PublicoAlvo);
			Assert.Equal(valor, curso.Valor);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void NaoDeveCursoTerNomeInvalido(string nomeInvalido) 
		{
			string nome = "informatica básica";
			double cargaHoraria = 20f;
			PublicoAlvo publicoAlvo = PublicoAlvo.Estudante;
			double valor = 950f;

			Assert.Throws<ArgumentException> (() => new Curso(nomeInvalido, cargaHoraria, publicoAlvo, valor)).ComMensagem("Nome Inválido!");
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-2)]
		[InlineData(-100)]
		public void NãoDeveCursoTerCargaHorariaMenorQueUm( double cargaHorariaInvalida)
		{
			string nome = "informatica básica";
			double cargaHoraria = 20f;
			PublicoAlvo publicoAlvo = PublicoAlvo.Estudante;
			double valor = 950f;

			Assert.Throws<ArgumentException>(() => new Curso(nome, cargaHorariaInvalida, publicoAlvo, valor)).ComMensagem("Carga Horária Inválida!");

		
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-2)]
		[InlineData(-100)]
		public void NãoDeveCursoTerValorMenorOuIgualAZero(double ValorInvalido)
		{
			string nome = "informatica básica";
			double cargaHoraria = 20f;
			PublicoAlvo publicoAlvo = PublicoAlvo.Estudante;
			double valor = 950f;

			Assert.Throws<ArgumentException>(() => new Curso(nome, cargaHoraria, publicoAlvo, ValorInvalido)).ComMensagem("Valor Inválido!");
		}

	}

	public enum PublicoAlvo
	{
		Estudante,
		Universitário,
		Empregado,
		Empreendedor
	}

	public class Curso
	{
		public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
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
			CargaHoraria = cargaHoraria;
			PublicoAlvo = publicoAlvo;
			Valor = valor;
		}
	}
}
