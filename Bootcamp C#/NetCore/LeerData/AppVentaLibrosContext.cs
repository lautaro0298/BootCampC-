
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace LeerData{
    public class AppVentaLibrosContexto:DbContext //Reprecenta una seccion con la base de datos a la cual queremos conectarnos los Dbset representan tablas
    {
        private const string connectionString=@"workstation id=LibrosWeb.mssql.somee.com;packet size=4096;user id=lautaro0298l_SQLLogin_1;pwd=ozj6wowpom;data source=LibrosWeb.mssql.somee.com;persist security info=False;initial catalog=LibrosWeb;TrustServerCertificate=True";//Integrated Security=False;Trusted_Connection=False; para enviar usuario y contraseña y creo que el otro es para aceptarel certificado del cervidor
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibroAutor>().HasKey(xi => new{xi.AutorId, xi.LibroId});
        }
        public DbSet<Libro> Libro {get;set;}
        public DbSet<Precio> Precio{get;set;}
        public DbSet<Comentario> comentario{get;set;}
        public DbSet<Autor> autor{get;set;}
        public DbSet<LibroAutor> libroAutor{get;set;}
    }
}