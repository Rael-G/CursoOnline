using CursoOnline.Web.Models.Enums;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CursoOnline.Web.Models
{
    //TODO
    //privar os sets
    //alterar apenas nome

    public class Aluno
	{
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
		[DisallowNull]
		public string Nome { get; set; }
		[Required]
		[DisplayName("CPF")]
		public string Cpf { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
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
