namespace App05
{
    public class EstudianteRepository : IRepository<Estudiante>
    {
        private NombreCompleto[] _nombres = new NombreCompleto[10];

        public EstudianteRepository()
        {
            _nombres[0] = new ("Vaxi", "Drez");
            _nombres[1] = new ("Maria", "Drez");
            _nombres[2] = new ("Nestor", "Arcila");
            _nombres[3] = new ("Joaquin", "Camino");
            _nombres[4] = new ("Roberto", "Dulanto");
            _nombres[5] = new ("Juan", "Garcia");
            _nombres[6] = new ("Luisa", "Ramirez");
            _nombres[7] = new ("Luis", "Ojeda");
            _nombres[8] = new ("Angela", "Arias");
            _nombres[9] = new ("Ramiro", "Lopez");
        }

        public IEnumerable<Estudiante> List()
        {
            int index = 0;
            while (index < _nombres.Length)
            {
                yield return new Estudiante(_nombres[index].Nombre, _nombres[index].Apellido);
                index++;
            }
        }
    }
}
