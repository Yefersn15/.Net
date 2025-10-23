using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Aprendiz
    {
        public string nombre { get; set; }
        public int anioNacimiento { get; set; }
        public int edad { get; set; }
        public string programa { get; set; }
        public int ficha { get; set; }
        public string ciudad { get; set; }
        public string direccion { get; set; }

        public Aprendiz(string nombre, int anioNacimiento, string programa, int ficha, string ciudad, string direccion)
        {
            this.nombre = nombre;
            this.anioNacimiento = anioNacimiento;
            this.programa = programa;
            this.ficha = ficha;
            this.ciudad = ciudad;
            this.direccion = direccion;
            // Calcular la edad automáticamente al crear el objeto
            CalcularEdad();
        }

        public void MostrarInfo()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Año de nacimiento: " + anioNacimiento);
            Console.WriteLine("Edad: " + edad);
            Console.WriteLine("Programa: " + programa);
            Console.WriteLine("Ficha: " + ficha);
            Console.WriteLine("Ciudad: " + ciudad);
            Console.WriteLine("Dirección: " + direccion);
        }

        public void CalcularEdad()
        {
            int añoActual = DateTime.Now.Year;
            edad = añoActual - anioNacimiento;
        }

        public void VerificarEdad()
        {
            // Asegurarnos de que la edad esté actualizada
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
    }
}