Base x = new Base();
Base y = new Derived();

x.EjecutarEnBase();
y.EjecutarEnBase();

Console.WriteLine();

Derived z = new Derived();
z.EjecutarEnDerivada();
z.EjecutarEnBase();



IProducer<Base> prodBase = null!;
Base bs = prodBase.Produce();


IProducer<Derived> prodDerived = null!;
Derived ds = prodDerived.Produce();
Base bs1 = prodDerived.Produce();

IConsumer<Base> consBase = null!;
consBase.Consume(new Base());
consBase.Consume(new Derived());

IConsumer<Derived> consDerived = null!;
consDerived.Consume(new Derived());

interface IProducer<out T>
{
    T Produce();
}

interface IConsumer<in T>
{
    void Consume(T obj);
}





class Base
{
    public void EjecutarEnBase() => Console.WriteLine($"Ejecutando desde {GetType().Name}");

}


class Derived : Base
{
    public void EjecutarEnDerivada() => Console.WriteLine($"Ejecutando derivada {GetType().Name}");
}