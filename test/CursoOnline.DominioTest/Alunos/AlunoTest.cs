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
    //TODO
    //cpf valido
    //cpf invalido
	//deve alterar nome
	//refatorar para usar o builder


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
		public void DeveCriarAluno()
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
		public void NaoDeveTerNomeInvalido(string nomeInvalido)
		{
			Aluno aluno = new Aluno(nomeInvalido, _cpf, _email, _publicoAlvo);

			var validationResults = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(aluno, new ValidationContext(aluno), validationResults, true);

			Assert.False(isValid);
			Assert.NotEmpty(validationResults);
		}

		[Fact]
		public void DeveAceitarEmailCorreto()
		{
			Bogus.Faker faker = new Bogus.Faker();
			string emailCorreto = faker.Person.Email;
			Aluno aluno = new Aluno(_nome, _cpf, emailCorreto, _publicoAlvo);

			var validationResults = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(aluno, new ValidationContext(aluno), validationResults, true);

			Assert.True(isValid);
			Assert.Empty(validationResults);

		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		[InlineData("email@")]
        [InlineData("email mail.com")]
        [InlineData("email@@mail.com")]
        public void NaoDeveAceitarEmailIncorreto(string emailIncorreto)
		{
			Aluno aluno = new Aluno(_nome, _cpf, emailIncorreto, _publicoAlvo);

			var validationResults = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(aluno, new ValidationContext(aluno), validationResults, true);

			Assert.False(isValid);
			Assert.NotEmpty(validationResults);
		}

		

	}



}
