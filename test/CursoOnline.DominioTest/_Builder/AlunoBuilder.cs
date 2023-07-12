using Bogus;
using Bogus.Extensions.Brazil;
using CursoOnline.Web.Models;
using CursoOnline.Web.Models.Enums;
using System;

namespace AlunoOnline.DominioTest._Builder
{
	class AlunoBuilder
	{
		static Faker _faker = new Faker();
        private string _nome = _faker.Name.FullName();
		private string _cpf = _faker.Person.Cpf();
		private string _email = _faker.Person.Email;
        private PublicoAlvo _publicoAlvo = (PublicoAlvo)_faker.Random.Number(0, 3);

        public static AlunoBuilder Novo() 
		{
			return new AlunoBuilder();
		}

        public AlunoBuilder ComNome(string nome)
		{
			_nome = nome;
			return this;
		}

        public AlunoBuilder ComCpf(string nome)
        {
            _nome = nome;
            return this;
        }

        public AlunoBuilder ComEmail(string nome)
        {
            _nome = nome;
            return this;
        }

        public AlunoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
		{
			_publicoAlvo = publicoAlvo; 
			return this;
		}

		public Aluno Build()
		{
			return new Aluno(_nome, _cpf, _email, _publicoAlvo);
		}
	}
}
