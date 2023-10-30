
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
      public DatabaseContext (DbContextOptions<DatabaseContext> options ): base(options){
        
      }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Libro>()
                .HasMany(x =>x.Categorias)
                .WithMany(x=>x.libros)
                .UsingEntity<LibroCategoria>(
                  s => s
                  .HasOne(p=>p.categoria)
                  .WithMany(p=>p.LibroCategorias)
                  .HasForeignKey(p=>p.CategoriaId),
                   j=>j
                  .HasOne(p=>p.libro)
                  .WithMany(p=>p.LibroCategorias)
                  .HasForeignKey(p=>p.LibroId),
                  j=>{
                    j.HasKey(t=> new {t.LibroId,t.CategoriaId});
                  }
                );
            
        }
        public DbSet<Categoria> categorias {get;set;}
        public DbSet<Libro> libros{get;set;}
        public DbSet<LibroCategoria> libroCategorias {get;set;}
    }
}