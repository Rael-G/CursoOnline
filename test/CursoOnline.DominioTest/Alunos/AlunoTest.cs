using CursoOnline.Web.Models.Enums;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CursoOnline.Web.Models;

namespace CursoOnline.DominioTest.Alunos
{

	
	public class AlunoTest
	{
		public readonly string _nome = "Joao Lucas Almeida";
		public readonly string _cpf = "12345678901";
		public readonly string _email = "amail@mail.com";
		public readonly PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;

		public AlunoTest() 
		{
			
		}

		[Fact]
		public void DeveCriarAlunoTest()
		{
			Aluno aluno = new Aluno(_nome, _cpf, _email, _publicoAlvo);

			Assert.Equal(_nome, aluno.Nome);
			Assert.Equal(_cpf, aluno.Cpf);
			Assert.Equal(_email, aluno.Email);
			Assert.Equal(_publicoAlvo, aluno.PublicoAlvo);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void NaoDeveAlunoTerNomeInvalido(string nomeInvalido)
		{
			Aluno aluno = new Aluno(nomeInvalido, "", "", PublicoAlvo.Empreendedor);

			var validationResults = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(aluno, new ValidationContext(aluno), validationResults, true);

			Assert.False(isValid);
			Assert.NotEmpty(validationResults);
		}

		//Todo

	}



}
