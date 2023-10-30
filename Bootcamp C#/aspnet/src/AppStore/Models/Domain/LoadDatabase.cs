

using Microsoft.AspNetCore.Identity;

namespace AppStore.Models.Domain
{
    public class LoadDatabase
    {
        public static async Task InsertarData(DatabaseContext databaseContext, UserManager<ApplicationUser> Usuariomanager,RoleManager<IdentityRole> roleManager)// esto son lo manejadores de Usuario desde mi usuario creado y roles de aspnet
        {
            if(!roleManager.Roles.Any()){
                await roleManager.CreateAsync(new IdentityRole("ADMIN"));
            }
            if(!Usuariomanager.Users.Any())
            {
                var usuario = new ApplicationUser{
                    Nombre="lautaro",
                    Email="lautaro@lautaro.com"
                    ,UserName="lautaro.0298"
                };
                await Usuariomanager.CreateAsync(usuario,"PassLauta1.");
                await Usuariomanager.AddToRoleAsync(usuario,"ADMIN");
            }
            if(!databaseContext.categorias!.Any()){
              await  databaseContext.categorias!.AddRangeAsync(
                new Categoria {Nombre="Drama"},
                new Categoria{Nombre="Comedia"},
                new Categoria{Nombre="Accion"},
                new Categoria{Nombre="Terror"},
                new Categoria{Nombre="Aventura"}

            );
            await databaseContext.SaveChangesAsync();
            if(!databaseContext.libros!.Any()){
                await databaseContext.libros!.AddRangeAsync(
                    new Libro{
                        titulo="El libro de la mancha",
                        CreateDate="06/06/2012",
                        Imagen="quijote.jpg",
                        Autor="Miguel Cervanter"
                    },
                      new Libro{
                        titulo="Harry el sucio potter",
                        CreateDate="06/08/2000",
                        Imagen="harry.jpg",
                        Autor="El bananero"
                    }
                );
            }
            await databaseContext.SaveChangesAsync();
            if(!databaseContext.libroCategorias!.Any()){
                await databaseContext.libroCategorias!.AddRangeAsync(
                    new LibroCategoria {
                        CategoriaId=1,LibroId=1
                    },
                     new LibroCategoria {
                        CategoriaId=2,LibroId=2
                    }
                );
            }
            await databaseContext.SaveChangesAsync();
            }
        }
    }
}