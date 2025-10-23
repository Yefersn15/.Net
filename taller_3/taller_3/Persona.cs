using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller_3
{
    internal class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int id { get; set; }
        public string genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int edad { get; set; }
        public string programa { get; set; }
        public int ficha { get; set; }
        public string telefono { get; set; }

        public Persona(string nombre, string apellido, int id, string genero, DateTime fechaNacimiento, string programa, int ficha, string telefono)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.id = id;
            this.genero = genero;
            this.fechaNacimiento = fechaNacimiento;
            this.programa = programa;
            this.ficha = ficha;
            this.telefono = telefono;
            CalcularEdad();
        }

        public void CalcularEdad()
        {
            DateTime fechaActual = DateTime.Now;
            edad = fechaActual.Year - fechaNacimiento.Year;

            // Ajustar si aún no ha cumplido años este año
            if (fechaActual.Month < fechaNacimiento.Month ||
                (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day))
            {
                edad--;
            }
        }

        public void VerificarEdad()
        {
            CalcularEdad();
            if (edad >= 18)
            {
                Console.WriteLine(nombre + " es mayor de edad.");
            }
            else
            {
                Console.WriteLine(nombre + " es menor de edad.");
            }
        }

        // Método para imprimir detalles de la persona
        public void ImprimirDetalles()
        {
            Console.WriteLine("\n=== DETALLES DE LA PERSONA ===");
            Console.WriteLine($"Nombre: {nombre} {apellido}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Género: {genero}");
            Console.WriteLine($"Fecha de Nacimiento: {fechaNacimiento:dd/MM/yyyy}");
            Console.WriteLine($"Edad: {edad} años");
            Console.WriteLine($"Programa: {programa}");
            Console.WriteLine($"Ficha: {ficha}");
            Console.WriteLine($"Teléfono: {telefono}");
        }

        // Método para calcular la edad en días
        public void CalcularEdadEnDias()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan diferencia = fechaActual - fechaNacimiento;
            int dias = (int)diferencia.TotalDays;

            Console.WriteLine($"\n{nombre} tiene {dias} días de vida.");
        }

        // Método para editar la información de la persona
        public void EditarInformacion()
        {
            Console.WriteLine("\n=== EDITAR INFORMACIÓN ===");

            Console.WriteLine("Ingrese el nuevo nombre (actual: " + nombre + "):");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
                nombre = nuevoNombre;

            Console.WriteLine("Ingrese el nuevo apellido (actual: " + apellido + "):");
            string nuevoApellido = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoApellido))
                apellido = nuevoApellido;

            Console.WriteLine("Ingrese el nuevo género F/M (actual: " + genero + "):");
            string nuevoGenero = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoGenero))
            {
                if (nuevoGenero.ToUpper() == "F" || nuevoGenero.ToUpper() == "M")
                    genero = nuevoGenero.ToUpper();
                else
                    Console.WriteLine("Género no válido. Se mantiene el actual.");
            }

            Console.WriteLine($"Ingrese la nueva fecha de nacimiento (actual: {fechaNacimiento:dd/MM/yyyy}):");
            Console.WriteLine("Año:");
            int año = int.Parse(Console.ReadLine());
            Console.WriteLine("Mes:");
            int mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Día:");
            int dia = int.Parse(Console.ReadLine());

            DateTime nuevaFecha = new DateTime(año, mes, dia);
            fechaNacimiento = nuevaFecha;
            CalcularEdad(); // Recalcular la edad

            Console.WriteLine("Ingrese el nuevo programa (actual: " + programa + "):");
            string nuevoPrograma = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoPrograma))
                programa = nuevoPrograma;

            Console.WriteLine("Ingrese la nueva ficha (actual: " + ficha + "):");
            string nuevaFicha = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaFicha))
                ficha = int.Parse(nuevaFicha);

            Console.WriteLine("Ingrese el nuevo teléfono (actual: " + telefono + "):");
            string nuevoTelefono = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoTelefono))
                telefono = nuevoTelefono;

            Console.WriteLine("Información actualizada exitosamente.");
        }
    }

    // Clase GestionPersonas separada
    internal class GestionPersonas
    {
        public List<Persona> personas { get; set; } = new List<Persona>();

        // Método para agregar nueva persona
        public void AgregarPersona()
        {
            Console.WriteLine("\n=== AGREGAR NUEVA PERSONA ===");

            Console.WriteLine("Ingrese el nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido:");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese el ID (documento de identidad):");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el género (F/M):");
            string genero = Console.ReadLine().ToUpper();
            while (genero != "F" && genero != "M")
            {
                Console.WriteLine("Género no válido. Ingrese F o M:");
                genero = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("=== FECHA DE NACIMIENTO ===");
            Console.WriteLine("Ingrese el año de nacimiento:");
            int año = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el mes de nacimiento (1-12):");
            int mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el día de nacimiento:");
            int dia = int.Parse(Console.ReadLine());

            DateTime fechaNacimiento = new DateTime(año, mes, dia);

            Console.WriteLine("Ingrese el programa:");
            string programa = Console.ReadLine();

            Console.WriteLine("Ingrese la ficha:");
            int ficha = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el teléfono:");
            string telefono = Console.ReadLine();

            Persona nuevaPersona = new Persona(nombre, apellido, id, genero, fechaNacimiento, programa, ficha, telefono);
            personas.Add(nuevaPersona);

            Console.WriteLine($"Persona {nombre} {apellido} agregada exitosamente con ID: {id}");
        }

        // Método para buscar persona por ID
        public Persona BuscarPorId(int id)
        {
            return personas.FirstOrDefault(p => p.id == id);
        }

        // Método para mostrar menú y gestionar opciones
        public void MenuGestion()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== GESTIÓN DE PERSONAS ===");
                Console.WriteLine("1. Agregar persona");
                Console.WriteLine("2. Editar persona");
                Console.WriteLine("3. Imprimir detalles");
                Console.WriteLine("4. Calcular edad en días");
                Console.WriteLine("5. Listar todas las personas");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opción:");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarPersona();
                        break;
                    case 2:
                        EditarPersona();
                        break;
                    case 3:
                        ImprimirDetallesPersona();
                        break;
                    case 4:
                        CalcularEdadDiasPersona();
                        break;
                    case 5:
                        ListarPersonas();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        private void EditarPersona()
        {
            Console.WriteLine("\nIngrese el ID de la persona a editar:");
            int id = int.Parse(Console.ReadLine());

            Persona persona = BuscarPorId(id);
            if (persona != null)
            {
                persona.EditarInformacion();
            }
            else
            {
                Console.WriteLine($"No se encontró ninguna persona con ID: {id}");
            }
        }

        private void ImprimirDetallesPersona()
        {
            Console.WriteLine("\nIngrese el ID de la persona:");
            int id = int.Parse(Console.ReadLine());

            Persona persona = BuscarPorId(id);
            if (persona != null)
            {
                persona.ImprimirDetalles();
            }
            else
            {
                Console.WriteLine($"No se encontró ninguna persona con ID: {id}");
            }
        }

        private void CalcularEdadDiasPersona()
        {
            Console.WriteLine("\nIngrese el ID de la persona:");
            int id = int.Parse(Console.ReadLine());

            Persona persona = BuscarPorId(id);
            if (persona != null)
            {
                persona.CalcularEdadEnDias();
            }
            else
            {
                Console.WriteLine($"No se encontró ninguna persona con ID: {id}");
            }
        }

        private void ListarPersonas()
        {
            if (personas.Count == 0)
            {
                Console.WriteLine("No hay personas registradas.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE PERSONAS ===");
            foreach (var persona in personas)
            {
                Console.WriteLine($"ID: {persona.id} | Nombre: {persona.nombre} {persona.apellido} | Edad: {persona.edad} | Fecha Nac: {persona.fechaNacimiento:dd/MM/yyyy} | Programa: {persona.programa}");
            }
        }
    }
}