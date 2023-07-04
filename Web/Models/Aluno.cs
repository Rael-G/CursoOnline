using CursoOnline.Web.Models.Enums;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace CursoOnline.Web.Models
{
	public class Aluno
	{
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
		[DisallowNull]
		public string Nome { get; set; }
		public string Cpf { get; set; }
		public string Email { get; set; }
		public PublicoAlvo PublicoAlvo { get; set; }

		public Aluno() { }

		public Aluno(string nome, string cpf, string email, PublicoAlvo publicoAlvo)
		{
			Nome = nome;
			Cpf = cpf;
			Email = email;
			PublicoAlvo = publicoAlvo;
		}
	}
}
