using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Cursos.Interfaces;
using CursoOnline.DominioTest._Builder;
using CursoOnline.DominioTest._Util;
using Moq;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos
{
	public class ArmazenadorDeCursoTest
	{
		private readonly ITestOutputHelper _output;
		private readonly CursoDto _cursoDto;
		private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;
		private readonly ArmazenadorDeCurso _armazenadorDeCurso;

		public ArmazenadorDeCursoTest(ITestOutputHelper output)
		{
			var faker = new Faker();
			_output = output;

			_cursoDto = new CursoDto
			{
				Nome = faker.Name.JobTitle(),
				Descricao = faker.Lorem.Letter(),
				CargaHoraria = faker.Random.Number(1, 100),
				PublicoAlvo = "Estudante",
				Valor = faker.Random.Number(10, 600),
			};

			_cursoRepositorioMock = new Mock<ICursoRepositorio>();
			_armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
		}


		[Fact]
		public void DeveCriarCurso()
		{
			_armazenadorDeCurso.Armazenar(_cursoDto);

			_cursoRepositorioMock.Verify(r => r.Adicionar(It.Is<Curso>(c =>
				c.Nome == _cursoDto.Nome && c.Descricao == _cursoDto.Descricao &&
				c.CargaHoraria == _cursoDto.CargaHoraria && c.Valor == _cursoDto.Valor))); ;
		}

		[Fact]
		public void NaoDeveAdicionarCursoComMesmoNomeDeOutroJaSalvo()
		{
			var CursoJaSalvo = CursoBuilder.Novo().ComNome(_cursoDto.Nome).Build();

			_cursoRepositorioMock.Setup(r => r.ObterPeloNome(_cursoDto.Nome)).Returns(CursoJaSalvo);

			Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(
				_cursoDto)).ComMensagem("Nome do Curso já consta no Banco de dados");
		}

		[Fact]
		public void NaoDeveInformarPublicoAlvoInvalido()
		{
			var publicoAlvoInvalido = "Médico";
			_cursoDto.PublicoAlvo = publicoAlvoInvalido;

			Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(
				_cursoDto)).ComMensagem("Publico Alvo Inválido");
		}
	}
}

