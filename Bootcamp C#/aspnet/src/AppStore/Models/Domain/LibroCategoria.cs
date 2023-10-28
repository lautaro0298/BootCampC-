using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppStore.Models.Domain
{
    public class LibroCategoria
    {
        public int id{get;set;}
        public int CategoriaId{get;set;}
        public int LibroId{get;set;}
        public Categoria categoria{get;set;}
        public Libro? libro{get;set;}
    }
}