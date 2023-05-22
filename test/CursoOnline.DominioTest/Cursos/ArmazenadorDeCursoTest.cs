using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Cursos.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.DominioTest.Cursos
{
	public class ArmazenadorDeCursoTest
	{
		[Fact]
		public void DeveCriarCurso()
		{
			CursoDto cursoDto = new CursoDto
			{
				Nome = "informatica básica",
				Descricao = "Uma descrição",
				CargaHoraria = 20f,
				PublicoAlvoId = 1,
				Valor = 950f
			};

			var cursoRepositorioMock = new Mock<ICursoRepositorio>();

			var armazenadorDeCurso = new ArmazenadorDeCurso(cursoRepositorioMock.Object);

			armazenadorDeCurso.Armazenar(cursoDto);

			cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()));
		}
	}

	public interface ICursoRepositorio
	{
		void Adicionar(Curso curso);
	}

	internal class ArmazenadorDeCurso
	{
		private readonly ICursoRepositorio _cursoRepositorio;

		public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
		{
			_cursoRepositorio = cursoRepositorio;
		}

		internal void Armazenar(CursoDto cursoDto)
		{
			var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, 
				cursoDto.CargaHoraria, PublicoAlvo.Estudante, cursoDto.Valor);

			_cursoRepositorio.Adicionar(curso);
		}
	}

	internal class CursoDto
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public float CargaHoraria { get; set; }
		public int PublicoAlvoId { get; set; }
		public float Valor { get; set; }
	}
}

