
using AppStore.Models.Domain;
using AppStore.Models.DTO;
using AppStore.Repositories.Abstract;

namespace AppStore.Repositories.Implementation
{
    public class LibroService : ILibroService
    {
        private readonly DatabaseContext ctx;
        public LibroService(DatabaseContext ctxparam){
            ctx=ctxparam;
        }
        public bool Add(Libro libro)
        {
            try{
                ctx.libros!.Add(libro);
                ctx.SaveChanges();
                foreach(int categoriaId in libro.categorias!){
                    var  LibroCategoria = new LibroCategoria{
                        LibroId=libro.id,
                        CategoriaId=categoriaId
                    };
                    ctx.libroCategorias!.Add(LibroCategoria);
                    
                }
                ctx.SaveChanges();
                    return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
          try
          {
            var data = GetById(id);
            if(data==null){
                return false;
            }
            var LibroCategoria=ctx.libroCategorias!.Where(a=>a.LibroId==id);
            ctx.libroCategorias.RemoveRange(LibroCategoria);
            ctx.libros.Remove(data);
            ctx.SaveChanges();
            return true;
          }
          catch (Exception e)
          {
            
            return false;
          }
        }

        public Libro GetById(int id)
        {
            return ctx.libros!.Find(id)!;
        }

        public List<int> GetCategoriaByLibroId(int libroId)
        {
            return ctx.libroCategorias!.Where(a=>a.LibroId==libroId).Select(a=>a.CategoriaId).ToList();
        }

        public LibroListVm List(string term = "", bool paging = false, int currentPage = 0)
        {
            var data= new LibroListVm();
            var list = ctx.libros!.ToList();
            if(string.IsNullOrEmpty(term)){
                term=term.ToLower();
                list=list.Where(x=>x.titulo!.ToLower().StartsWith(term)).ToList();

            }
            if(paging){
                int  PageSize=5;
                int count = list.Count;
                int TotalPages= (int)Math.Ceiling(count/(double)PageSize);
                list =list.Skip((currentPage-1)*PageSize).Take(PageSize).ToList();
                data.PageSize=PageSize;
                data.currentPage=currentPage;
                data.TotalPages=TotalPages;

            }
            foreach(var libro in list){
                var categoria = (
                    from Categoria in ctx.categorias
                    join lc in ctx.libroCategorias!
                    on Categoria.id equals lc.CategoriaId
                    where lc.LibroId == libro.id
                    select Categoria.Nombre
                ).ToList();
                string categiriaNombres = string.Join(",",categoria);
                libro.CategoriaNombres = categiriaNombres;
            
            }
            data.LibroList= list.AsQueryable();

            return data;
        }

        public bool Update(Libro libro)
        {
            try
            {
                var categoriasParaEliminar = ctx.libroCategorias.Where(a=>a.LibroId==libro.id);
                foreach(var categoria in categoriasParaEliminar)
                {
                    ctx.libroCategorias!.Remove(categoria);
                }
                foreach (var categoriaId in libro.categorias!)
                {
                    var libroCategoria = new LibroCategoria { CategoriaId=categoriaId , LibroId =libro.id};
                    ctx.libroCategorias!.Add(libroCategoria);
                }
                ctx.libros!.Update(libro);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                
                return false;
            }
        }
    }
}