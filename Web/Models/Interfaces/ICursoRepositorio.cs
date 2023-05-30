
namespace CursoOnline.Web.Models.Interfaces
{
	public interface ICursoRepositorio
	{
		void Adicionar(Curso curso);
		Curso ObterPeloNome(string nome);
	}
}
