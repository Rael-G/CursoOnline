using CursoOnline.Web.Models;
using CursoOnline.Web.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CursoOnline.Web.Data
{
    [DbContext(typeof(ApplicationDbContext))]
    public class CursoRepository : ApplicationDbContext, ICursoRepository
    {
        //TODO? IsValid

        public CursoRepository(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public void Add(Curso curso)
        {
            base.Add(curso);
        }
        public void Update(Curso curso)
        {
            base.Update(curso);
        }
        public void Remove(Curso curso)
        {
            base.Remove(curso);
        }
        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }
        public Curso GetCursoByIdNoTracking(int id)
        {
            return base.Set<Curso>().AsNoTracking().FirstOrDefault(a => a.Id == id);
        }
        public async Task<Curso> GetCursoBy(int? id)
        {
            return await base.Curso.FindAsync(id);
        }

        public bool IsValid(int id, Curso cursoAlterado)
        {
            //Curso cursoOriginal = this.GetCursoByIdNoTracking(id);

            //return (cursoOriginal.Cpf == cursoAlterado.Cpf &&
            //cursoOriginal.Email == cursoAlterado.Email &&
            //cursoOriginal.PublicoAlvo == cursoAlterado.PublicoAlvo);
            return true;
        }
    }
}
