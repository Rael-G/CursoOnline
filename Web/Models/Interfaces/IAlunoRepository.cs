using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Web.Models.Interfaces
{
    public interface IAlunoRepository
    {
        void Add(Aluno aluno);
        void Update(Aluno aluno);
        void Remove(Aluno aluno);
        Task SaveChangesAsync();
        Task<Aluno> GetAlunoBy(int? id);
        Aluno GetAlunoByIdNoTracking(int id);
        bool IsValid(int id, Aluno alunoAlterado);

        DbSet<Aluno> Aluno{ get; set; }
    }
}
