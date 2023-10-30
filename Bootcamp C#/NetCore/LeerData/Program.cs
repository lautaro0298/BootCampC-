using System;
using System.Net;
using System.Net.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace LeerData
{
    class Progam
    {
        //  .AsNoTracking() sirve para hacer la transaccion y no guardarlo en la cache
        static void Main(string[] args)
        {
            //  ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            using (var db = new AppVentaLibrosContexto())//creamos instancia de la base de datos
            {
             
                var autor=db.autor.Single(x=>x.Nombre=="Roman");
                if(autor!=null){
                    db.Remove(autor);
                    var estado=db.SaveChanges();
                    Console.WriteLine("Estado de transaccion==>"+estado);
                }

            }
        }
    }
    
}

