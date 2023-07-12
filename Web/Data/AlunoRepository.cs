using CursoOnline.Web.Models;
using CursoOnline.Web.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CursoOnline.Web.Data
{
    [DbContext(typeof(ApplicationDbContext))]
    public class AlunoRepository : ApplicationDbContext, IAlunoRepository
    {

        public AlunoRepository(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public void Add(Aluno aluno)
        {
            base.Add(aluno);
        }
        public void Update(Aluno aluno)
        {
            base.Update(aluno);
        }
        public void Remove(Aluno aluno)
        {
            base.Remove(aluno);
        }
        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }
        public Aluno GetAlunoByIdNoTracking(int id)
        {
            return base.Set<Aluno>().AsNoTracking().FirstOrDefault(a => a.Id == id);
        }
        public async Task<Aluno> GetAlunoBy(int? id)
        {
            return await base.Aluno.FindAsync(id);
        }

        public bool IsValid(int id, Aluno alunoAlterado)
        {
            Aluno alunoOriginal = this.GetAlunoByIdNoTracking(id);

            return (alunoOriginal.Cpf == alunoAlterado.Cpf &&
            alunoOriginal.Email == alunoAlterado.Email &&
            alunoOriginal.PublicoAlvo == alunoAlterado.PublicoAlvo);
        }
    }
}
