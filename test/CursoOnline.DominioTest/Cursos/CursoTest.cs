using Bogus;
using CursoOnline.Web.Models;
using CursoOnline.Web.Models.Enums;
using CursoOnline.DominioTest._Util;
using Xunit.Abstractions;
using Bogus.DataSets;

namespace CursoOnline.DominioTest.Cursos
{
	//TODO
	//refatorar para trabalhar com o validator
	public class CursoTest
	{
        private static Faker _faker = new Faker();

		[Fact]
		public void DeveCriarCurso()
		{
            string nome = _faker.Name.FullName();
            double cargaHoraria = _faker.Random.Number(1, 100);
            PublicoAlvo publicoAlvo = PublicoAlvo.Estudante;
            double valor = _faker.Random.Number(100, 1500);
            string descricao = _faker.Lorem.Paragraph();

            Curso curso = new Curso(nome, descricao, cargaHoraria, publicoAlvo, valor);

			Assert.Equal(nome, curso.Nome);
			Assert.Equal(descricao, curso.Descricao);
			Assert.Equal(cargaHoraria, curso.CargaHoraria);
			Assert.Equal(publicoAlvo, curso.PublicoAlvo);
			Assert.Equal(valor, curso.Valor);
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

		//TODO
		//?
		[Fact]
		public void DeveAlterarNome()
		{
			
		}

	}
}
