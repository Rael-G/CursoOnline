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
using CursoOnline.Web.Models.Interfaces;
using CursoOnline.Web.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CursoOnline.DominioTest.Alunos
{
    //REQUISITOS:
    //Apenas nome pode ser alterado;
    //cpf não pode estar repedito
    //TODO
    //cpfrepetido
    //refatorar para usar o builder
    //TODO
    //nova classe de testes pra testar o repositorio

    public class CrudAlunoTest
    {

        private readonly Mock<IAlunoRepository> _moqDbContext;
        private readonly AlunoController _controller;
        private readonly Aluno _aluno;
        private readonly Faker _faker;

        public CrudAlunoTest()
        {
            _moqDbContext = new Mock<IAlunoRepository>();
            _controller = new AlunoController(_moqDbContext.Object);

            _faker = new Faker();
            string email = _faker.Person.Email;

            _aluno = new Aluno
            {
                Nome = _faker.Name.FullName(),
                Cpf = _faker.Name.FullName(),
                Email = email,
                PublicoAlvo = (PublicoAlvo)_faker.Random.Number(0, 3)
            };
        }

        [Fact]
        public async Task DeveArmazenarAluno()
        {
            await _controller.Create(_aluno);

            _moqDbContext.Verify(db => db.Add(It.Is<Aluno>(a =>
                a.Nome.Equals(_aluno.Nome) &&
                a.Cpf.Equals(_aluno.Cpf) &&
                a.Email.Equals(_aluno.Email) &&
                a.PublicoAlvo.Equals(_aluno.PublicoAlvo)
                )));
            _moqDbContext.Verify(db => db.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task NomePodeSerEditado()
        {
            int id = _faker.Random.Int();
            _aluno.Id = id;
            string nomeAlterado = _faker.Name.FullName();
            var alunoAlterado = new Aluno { Id = _aluno.Id, Nome = nomeAlterado, Cpf = _aluno.Cpf, Email = _aluno.Email, PublicoAlvo = _aluno.PublicoAlvo };

            _moqDbContext.Setup(r => r.IsValid(id, alunoAlterado)).Returns(true);
            await _controller.Edit(id, alunoAlterado);

            _moqDbContext.Verify(db => db.Update(It.Is<Aluno>(a =>
            a.Id == _aluno.Id &&
            a.Cpf.Equals(_aluno.Cpf) &&
            a.Email.Equals(_aluno.Email) &&
            a.PublicoAlvo.Equals(_aluno.PublicoAlvo)
            )));
            _moqDbContext.Verify(db => db.SaveChangesAsync(), Times.Once);
        }

        [Theory]
        [InlineData(nameof(Aluno.Cpf))]
        [InlineData(nameof(Aluno.Email))]
        [InlineData(nameof(Aluno.PublicoAlvo))]
        public async void ApenasNomePodeEditado(string prop)
        {
            int id = _faker.Random.Int();
            _aluno.Id = id;
            string cpfAlterado = _faker.Name.FullName();
            string emailAlterado = $"{_faker.Internet.UserName()}@{_faker.Internet.DomainName()}";
            var publicoAlvoAlterado = (PublicoAlvo)0;
            while (publicoAlvoAlterado == _aluno.PublicoAlvo)
            {
                var random = new Random();
                publicoAlvoAlterado = (PublicoAlvo)random.Next(0, 3);
            }
            var alunoAlterado = new Aluno
            {
                Id = _aluno.Id,
                Nome = _aluno.Nome,
                Cpf = prop == nameof(Aluno.Cpf) ? cpfAlterado : _aluno.Cpf,
                Email = prop == nameof(Aluno.Email) ? emailAlterado : _aluno.Email,
                PublicoAlvo = prop == nameof(Aluno.PublicoAlvo) ? publicoAlvoAlterado : _aluno.PublicoAlvo
            };

            _moqDbContext.Setup(r => r.IsValid(id, alunoAlterado)).Returns(false);

            await _controller.Edit(id, alunoAlterado);

            _moqDbContext.Verify(r => r.SaveChangesAsync(), Times.Never);

        }
    }

}
