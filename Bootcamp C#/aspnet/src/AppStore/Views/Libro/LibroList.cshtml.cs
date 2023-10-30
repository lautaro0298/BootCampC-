using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AppStore.Views.Libro
{
    public class LibroList : PageModel
    {
        private readonly ILogger<LibroList> _logger;

        public LibroList(ILogger<LibroList> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}