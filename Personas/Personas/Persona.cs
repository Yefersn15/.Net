using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas
{
    internal class Persona
    {
        public string Nombre { get; set; }
        private int Edad { get; set; }

        public Persona(string nombre, int edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;
        }

        private void mostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}");
        }

        public void MostrarInformacionPublico()
        {
            mostrarInformacion();
        }
    }
}
