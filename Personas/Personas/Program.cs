using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Crear una persona y mostrar su información pública");
            Console.WriteLine("2. Crear un animal y mostrar su información pública");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Persona persona1 = new Persona("Juan", 30);
                    persona1.Nombre = "Pedro";
                    persona1.MostrarInformacionPublico();
                    break;

                    case 2:
                    Animal animal1 = new Animal("Fido", "Perro", 5);
                    animal1.name = "Max";
                    animal1.ShowPublicInfo();
                    break;
            }
        }
    }
}
