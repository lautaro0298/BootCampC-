
using AppStore.Models.Domain;
using AppStore.Repositories.Abstract;
using AppStore.Repositories.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppStore.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        private readonly ILibroService libroService;
        private readonly IFileService fileService;
        private readonly ICategoriaService categoriaService;

        public LibroController(ILibroService libroService, IFileService fileService, ICategoriaService categoriaService)
        {
            this.libroService = libroService;
            this.fileService = fileService;
            this.categoriaService = categoriaService;
        }
        [HttpPost]
        public IActionResult add(Libro libro)
        {
            libro.categoriasList = categoriaService
            .List().Select(a => new SelectListItem { Text = a.Nombre, Value = a.id.ToString() });
            var mod = ModelState.IsValid;
            if (!ModelState.IsValid)
            {
                // Obtener una lista de errores de validación
                var errores = ModelState.Values.SelectMany(v => v.Errors);

                // Puedes imprimir los errores en la consola para depuración
                foreach (var error in errores)
                {
                    Console.WriteLine(error.ErrorMessage); // Muestra el mensaje de error
                }
                return View(libro);
            }
            if (libro.ImagenFile != null)
            {
                var resultado = fileService.SaveImage(libro.ImagenFile);
                if (resultado.Item1 == 0)
                {
                    TempData["Msg"] = "La imagen no puedo ser guardada exitosamente ";
                    return View(libro);
                }
                var ImagenName = resultado.Item2;
                libro.Imagen = ImagenName;

            }
            var resultadoLibro = libroService.Add(libro);
            if (resultadoLibro)
            {
                TempData["Msg"] = "Se agrego correctamente";
                return RedirectToAction(nameof(Add));

            }
            TempData["Msg"] = "Errores guardando el libro";
            return View(libro);
        }
        public IActionResult Add()
        {

            var libro = new Libro();
            libro.categoriasList = categoriaService.List()
                .Select(a => new SelectListItem { Text = a.Nombre, Value = a.id.ToString() });

            return View(libro);
        }
        public IActionResult Edit(int id)

        {
            var libro = libroService.GetById(id);
            var categoriaDelibro = libroService.GetCategoriaByLibroId(id);
            var MultiSelectListCategorias = new MultiSelectList(categoriaService.List(), "id", "Nombre", categoriaDelibro);
            libro.MultiCategoriaList = MultiSelectListCategorias;

            return View(libro);
        }
        [HttpPost]
        public IActionResult Edit(Libro libro)
        {
            var categoriaDelibro = libroService.GetCategoriaByLibroId(libro.id);
            var MultiSelectListCategorias = new MultiSelectList(categoriaService.List(), "id", "Nombre", categoriaDelibro);
            libro.MultiCategoriaList = MultiSelectListCategorias;
            if (!ModelState.IsValid)
            {
                return View(libro);
            }
            if (libro.ImagenFile != null)
            {
                var fileResultado = fileService.SaveImage(libro.ImagenFile);
                if (fileResultado.Item1 == 0)
                {
                    TempData["Msg"] = "La imagen no puedo ser guardada exitosamente ";
                    return View(libro);
                }
                var ImagenName = fileResultado.Item2;
                libro.Imagen = ImagenName;

            }
            var resultadoLibro = libroService.Update(libro);
            if (!resultadoLibro)
            {
                TempData["Msg"] = "Errores guardando el libro";
                return View(libro);

            }
            TempData["Msg"] = "Se actualizo exitosamante el libro";
            return View(libro);

        }
        public IActionResult LibroList()
        {
            var libros = libroService.List();
            return View(libros);
        }
        public IActionResult Delete(int id)
        {
            libroService.Delete(id);
            return RedirectToAction(nameof(LibroList));
        }
    }
}