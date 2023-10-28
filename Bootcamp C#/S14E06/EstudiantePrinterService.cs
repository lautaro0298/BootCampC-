namespace App05
{
    public class EstudiantePrinterService
    {
        private readonly IRepository<Estudiante> _estudianteRepository;

        public EstudiantePrinterService(IRepository<Estudiante> estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public void PrintEstudiantes(int max = 100)
        {
            var estudiantes = _estudianteRepository.List().Take(max);//.ToArray();
            //Array.Sort(estudiantes);
            //Console.WriteLine("Imprimiendo Lista de Estudiantes desde el Metodo PrintEstudiantes");
            //for (int i = 0; i < estudiantes.Length ; i++)
            //{
            //    Console.WriteLine(estudiantes[i]);
            //}
            PrintEstudiantesConsola(estudiantes);
        }

        private void PrintEstudiantesConsola(IEnumerable<Estudiante> estudiantes)
        {
            Console.WriteLine("Estudiantes:");
            foreach (var estudiante in estudiantes)
            { 
                Console.WriteLine(estudiante);
            }
        }
        
    }
}
