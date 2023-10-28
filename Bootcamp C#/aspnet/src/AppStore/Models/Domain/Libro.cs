

using System.ComponentModel.DataAnnotations;

namespace AppStore.Models.Domain
{
    public class Libro
    {   
        [Key]
        [Required]
        public int id {get;set;}
        public string? titulo{get;set;}
        public string? CreateDate{get;set;}
        public string? Imagen{get;set;}
        [Required]
        public string? Autor{get;set;}
        public virtual ICollection<Categoria> Categorias {get;set;}
        public virtual ICollection<LibroCategoria> LibroCategorias {get;set;}

    }
}