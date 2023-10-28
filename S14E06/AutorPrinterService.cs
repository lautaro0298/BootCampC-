namespace App05
{
    public class AutorPrinterService
    {
        private readonly IRepository<Autor> _repository;

        public AutorPrinterService(IRepository<Autor> repository)
        {
            _repository = repository;
        }

        public void PrintAutores()
        {
            var autores = _repository.List().ToArray();
            Array.Sort(autores);
            Console.WriteLine("Imprimiento Autores desde el metodo PrintAutores");
            for (int i = 0; i < autores.Length; i++)
            {
                Console.WriteLine(autores[i]);
            }
        }
    }
}
