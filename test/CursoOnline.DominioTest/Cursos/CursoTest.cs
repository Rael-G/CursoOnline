using Bogus;
using CursoOnline.Web.Models;
using CursoOnline.Web.Models.Enums;
using CursoOnline.DominioTest._Util;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos
{
	//TODO Converter classe para trabalhar com o framework

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
			var faker = new Faker();

			_nome = faker.Name.FullName();
			_cargaHoraria = faker.Random.Number(1, 100);
			_publicoAlvo = PublicoAlvo.Estudante;
			_valor = faker.Random.Number(100, 1500);
			_descricao = faker.Lorem.Paragraph();
		}

		public void Dispose()
		{
			_output.WriteLine("Dispose sendo executado!");
		}

		[Fact]
		public void DeveCriarCurso()
		{

			Curso curso = new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);

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
			Assert.Throws<ArgumentException> (() => _Builder.CursoBuilder.Novo().ComNome(nomeInvalido).Build()).ComMensagem(CursoOnline.Web._base.Resource.NomeInvalido);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-2)]
		[InlineData(-100)]
		public void NãoDeveCursoTerCargaHorariaMenorQueUm( double cargaHorariaInvalida)
		{
			Assert.Throws<ArgumentException>(() => _Builder.CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build()).ComMensagem(CursoOnline.Web._base.Resource.CargaInvalida);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-2)]
		[InlineData(-100)]
		public void NãoDeveCursoTerValorMenorOuIgualAZero(double valorInvalido)
		{
			Assert.Throws<ArgumentException>(() => _Builder.CursoBuilder.Novo().ComValor(valorInvalido).Build()).ComMensagem(CursoOnline.Web._base.Resource.ValorInvalido);
		}

		[Fact]
		public void DeveAlterarNome()
		{
			
		}

	}
}
