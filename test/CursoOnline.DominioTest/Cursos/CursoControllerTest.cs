using Bogus;
using CursoOnline.Web.Models;
using CursoOnline.Web.Models.Interfaces;
using CursoOnline.DominioTest._Builder;
using CursoOnline.DominioTest._Util;
using Moq;
using Xunit.Abstractions;
using CursoOnline.Web.Models.Enums;
using CursoOnline.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.DominioTest.Cursos
{

	//TODO Converter essa classe pra funcionar com os recursos do framework

	public class CursoControllerTest
	{
		private readonly ITestOutputHelper _output;
		private readonly Curso _curso;
		private readonly Mock<ICursoRepository> _cursoRepositorioMock;
		private readonly CursoController _controller;

		public CursoControllerTest(ITestOutputHelper output)
		{
			var faker = new Faker();
			_output = output;

			_curso = new Curso
			{
				Nome = faker.Name.JobTitle(),
				Descricao = faker.Lorem.Letter(),
				CargaHoraria = faker.Random.Number(1, 100),
				PublicoAlvo = PublicoAlvo.Empreendedor,
				Valor = faker.Random.Number(10, 600),
			};

			_cursoRepositorioMock = new Mock<ICursoRepository>();
            _controller = new CursoController(_cursoRepositorioMock.Object);
		}


		[Fact]
		public void DeveCriarCurso()
		{
			_controller.Create(_curso);

			_cursoRepositorioMock.Verify(r => r.Add(It.Is<Curso>(c =>
				c.Nome == _curso.Nome && c.Descricao == _curso.Descricao &&
				c.CargaHoraria == _curso.CargaHoraria && c.Valor == _curso.Valor))); ;
		}

		[Fact]
		public void NaoDeveAdicionarCursoComMesmoNomeDeOutroJaSalvo()
		{
			var CursoJaSalvo = CursoBuilder.Novo().ComNome(_curso.Nome).Build();
			CursoJaSalvo.Id = 10;

		}

		[Fact]
		public void NaoDeveInformarPublicoAlvoInvalido()
		{

		}
	}
}

