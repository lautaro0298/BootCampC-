using System;
using System.Net;
using System.Net.Security;
using Microsoft.EntityFrameworkCore;
namespace LeerData
    {
        class Progam
        {
          //  .AsNoTracking() sirve para hacer la transaccion y no guardarlo en la cache
            static void Main(string[] args){
                  //  ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

              using(var db=new AppVentaLibrosContexto())//creamos instancia de la base de datos
              {
                   var libros=db.Libro.Include(x=>x.PrecioPromocion).AsNoTracking();
                   foreach(var Libro in libros){
                    Console.WriteLine(Libro.Titulo+" ------ "+Libro.PrecioPromocion.PrecioActual);
                   }
              }
            
            }
        }
    }
