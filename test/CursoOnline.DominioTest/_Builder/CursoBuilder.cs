using Bogus;
using CursoOnline.Web.Models;
using CursoOnline.Web.Models.Enums;

namespace CursoOnline.DominioTest._Builder
{
	internal class CursoBuilder
	{
        static Faker _faker = new Faker();

        private string _nome = _faker.Name.JobTitle();
		private double _cargaHoraria = _faker.Random.Number(1, 100);
		private double _valor = _faker.Random.Number(1, 1000);
		private string _descricao = _faker.Lorem.Paragraph();
        private PublicoAlvo _publicoAlvo = (PublicoAlvo)_faker.Random.Number(0, 3);

        public static CursoBuilder Novo() 
		{
			return new CursoBuilder();
		}

		public CursoBuilder ComNome(string nome)
		{
			_nome = nome;
			return this;
		}

		public CursoBuilder ComDescricao(string descricao)
		{
			_descricao = descricao;
			return this;
		}

		public CursoBuilder ComCargaHoraria(double cargaHoraria)
		{
			_cargaHoraria = cargaHoraria;
			return this;
		}

		public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
		{
			_publicoAlvo = publicoAlvo; 
			return this;
		}

		public CursoBuilder ComValor(double valor)
		{
			_valor = valor;
			return this;
		}

		public Curso Build()
		{
			return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
		}
	}
}
