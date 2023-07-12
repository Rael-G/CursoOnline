using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Web.Models.Interfaces
{
    public interface ICursoRepository
    {
        void Add(Curso curso);
        void Update(Curso curso);
        void Remove(Curso curso);
        Task SaveChangesAsync();
        Task<Curso> GetCursoBy(int? id);
        Curso GetCursoByIdNoTracking(int id);
        bool IsValid(int id, Curso cursoAlterado);

        DbSet<Curso> Curso{ get; set; }
    }
}
