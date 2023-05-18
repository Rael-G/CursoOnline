using CursoOnline.DominioTest._Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Curso
{
	public class CursoTest : IDisposable
	{
		private readonly ITestOutputHelper _output;
		private readonly string _nome;
		private readonly double _cargaHoraria;
		private readonly PublicoAlvo _publicoAlvo;
		private readonly double _valor;
		private readonly string _descricao;

		public CursoTest(ITestOutputHelper output) 
		{
			_output = output;
			_output.WriteLine("Construtor sendo executado!");

			_nome = "informatica básica";
			_cargaHoraria = 20f;
			_publicoAlvo = PublicoAlvo.Estudante;
			_valor = 950f;
			_descricao = "Uma descrição";
		}

		public void Dispose()
		{
			_output.WriteLine("Dispose sendo executado!");
		}

		[Fact]
		public void DeveCriarCurso()
		{

			Curso curso = CursoOnline.DominioTest._Builder.CursoBuilder.Novo().Build();

			Assert.Equal(_nome, curso.Nome);
			Assert.Equal(_descricao, curso.Descricao);
			Assert.Equal(_cargaHoraria, curso.CargaHoraria);
			Assert.Equal(_publicoAlvo, curso.PublicoAlvo);
			Assert.Equal(_valor, curso.Valor);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void NaoDeveCursoTerNomeInvalido(string nomeInvalido) 
		{
			Assert.Throws<ArgumentException> (() => CursoOnline.DominioTest._Builder.CursoBuilder.Novo().ComNome(nomeInvalido).Build()).ComMensagem("Nome Inválido!");
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-2)]
		[InlineData(-100)]
		public void NãoDeveCursoTerCargaHorariaMenorQueUm( double cargaHorariaInvalida)
		{
			Assert.Throws<ArgumentException>(() => CursoOnline.DominioTest._Builder.CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build()).ComMensagem("Carga Horária Inválida!");
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-2)]
		[InlineData(-100)]
		public void NãoDeveCursoTerValorMenorOuIgualAZero(double valorInvalido)
		{
			Assert.Throws<ArgumentException>(() => CursoOnline.DominioTest._Builder.CursoBuilder.Novo().ComValor(valorInvalido).Build()).ComMensagem("Valor Inválido!");
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
