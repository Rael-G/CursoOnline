using CursoOnline.Web.Models.Enums;
using Elfie.Serialization;
using System.ComponentModel.DataAnnotations;
using CursoOnline.Web._base;
using System.Diagnostics.CodeAnalysis;

namespace CursoOnline.Web.Models
{
	public class Curso
	{
		public Guid Id { get; set; }

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
			if (nome == string.Empty || nome == null)
			{
				throw new ArgumentException(CursoOnline.Web._base.Resource.NomeInvalido);
			}

			if (cargaHoraria < 1)
			{
				throw new ArgumentException(CursoOnline.Web._base.Resource.CargaInvalida);
			}

			if (valor <= 1)
			{
				throw new ArgumentException(CursoOnline.Web._base.Resource.ValorInvalido);
			}

			Nome = nome;
			Descricao = descricao;
			CargaHoraria = cargaHoraria;
			PublicoAlvo = publicoAlvo;
			Valor = valor;
		}
	}
}
