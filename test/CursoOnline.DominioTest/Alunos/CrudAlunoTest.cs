using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using CursoOnline.Web.Controllers;
using CursoOnline.Web.Data;
using CursoOnline.Web.Models;
using CursoOnline.Web.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Moq;

namespace CursoOnline.DominioTest.Alunos
{
	public class CrudAlunoTest
	{

		private readonly Mock<ApplicationDbContext> _moqDbContext;
		private readonly AlunoController _controller;
		private readonly Aluno _aluno;

		public CrudAlunoTest()
		{
			var faker = new Faker();
			var random = new Random();
			string username = faker.Internet.UserName();
			string domain = faker.Internet.DomainName();

			_aluno = new Aluno
			{
				Nome = faker.Name.FullName(),
				Cpf = faker.Name.FullName(),
				Email = $"{username}@{domain}",
				PublicoAlvo = (PublicoAlvo)random.Next(0, 3)
			};

			_moqDbContext = new Mock<ApplicationDbContext>();
			_controller = new AlunoController(_moqDbContext.Object);
		}

		//TODO DeveArmazenarAluno
		
		[Fact]
		public async Task DeveArmazenarAluno()
		{
			await _controller.Create(_aluno);

			_moqDbContext.Verify(db => db.Add(It.IsAny<Aluno>()));

			_moqDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once);
		}

		//TODO ApenasNomeDeveSerEditado

		[Fact]
		public void ApenasNomeDeveSerEditado()
		{


		}
	}
}
