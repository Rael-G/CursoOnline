using CursoOnline.Web.Models.Enums;
using Elfie.Serialization;
using System.ComponentModel.DataAnnotations;
using CursoOnline.Web._base;
using System.Diagnostics.CodeAnalysis;

namespace CursoOnline.Web.Models
{
	public class Curso
	{
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false)]
		[DisallowNull]
		public string Nome { get; set; }

		public string Descricao { get; set; }

		[Required]
		[Display(Name = "Carga Horaria")]
		[Range(0, int.MaxValue)]
		public double CargaHoraria { get; set; }

		[Display(Name = "Público Alvo")]
		public PublicoAlvo PublicoAlvo { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		[Range(0, int.MaxValue)]
		public double Valor { get; set; }

		public Curso() { }

		public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
		{
			Nome = nome;
			Descricao = descricao;
			CargaHoraria = cargaHoraria;
			PublicoAlvo = publicoAlvo;
			Valor = valor;
		}
	}
}
