using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CursoOnline.Web.Models;

namespace CursoOnline.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CursoOnline.Web.Models.Curso> Curso { get; set; } = default!;

        public DbSet<CursoOnline.Web.Models.Aluno> Aluno { get; set; } = default!;
    }
}
