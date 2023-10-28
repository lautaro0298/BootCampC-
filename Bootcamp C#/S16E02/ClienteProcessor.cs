namespace App06
{
    public class ClienteProcessor : IProcessor<Cliente>, ILogger
    {

        public void Process(Cliente input)
        {
            Console.WriteLine($"Processing Cliente: {input}");
        }

        public static void GenericStaticProcess<TGeneric>(TGeneric input)
        {
            Console.WriteLine($"Executando GenericStaticProcess {input}");
        }

        public void Log<T>(T input)
        {
            Console.WriteLine($"Ejecutando el metodo generico void LOG : {input}");
        }
    }
}
