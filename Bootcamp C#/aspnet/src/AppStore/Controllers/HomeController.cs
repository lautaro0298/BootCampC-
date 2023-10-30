
using AppStore.Repositories.Abstract;
using AppStore.Repositories.Implementation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    public class HomeController: Controller
    {
        private readonly ILibroService _libroServis;
        public HomeController(ILibroService libro){
            _libroServis=libro;
        }
        public IActionResult Index(string term="",int currentPage=1){
            var libros =_libroServis.List(term,true,currentPage);
            return View(libros);
        }
        public IActionResult LibroDetail(int libroId){
           var libro= _libroServis.GetById(libroId);
           return View(libro);
        }
        public IActionResult About(){
            return View();
        }
    }

}