using LeerData;

public class Precio{
public int PrecioId{get;set;}
public decimal PrecioActual{get;set;}
public decimal Promocion{get;set;}
public int LibroId{get;set;}
public Libro Libro{get;set;}// ancla esto se utiliza para que exista una relacion a nivel objeto en entity framework
}