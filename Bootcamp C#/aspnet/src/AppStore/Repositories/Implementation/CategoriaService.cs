

using AppStore.Models.Domain;
using AppStore.Repositories.Abstract;

namespace AppStore.Repositories.Implementation
{
    public class CategoriaService : ICategoriaService
    {
        private readonly DatabaseContext databaseContext;

        public CategoriaService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IQueryable<Categoria> List()
        {
           return databaseContext.categorias.AsQueryable();
        }
    }
}