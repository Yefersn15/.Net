using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class LibroDigital : Libro
    {
        private double tamanoArchivoMB { get; set; }

        public LibroDigital(string titulo, string autor, int numeroPaginas, double tamanoArchivoMB)
            : base(titulo, autor, numeroPaginas)
        {
            this.tamanoArchivoMB = tamanoArchivoMB;
        }

        // Propiedad pública
        public double TamanoArchivoMB
        {
            get { return tamanoArchivoMB; }
        }

        // Sobrescribir método para mostrar información
        public override void MostrarInformacion()
        {
            Console.WriteLine("=== INFORMACIÓN DEL LIBRO DIGITAL ===");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Número de páginas: {NumeroPaginas}");
            Console.WriteLine($"Tamaño del archivo: {TamanoArchivoMB} MB");
            Console.WriteLine(new string('-', 30));
        }

        // Sobrescribir método protegido para generar resumen específico
        protected override string GenerarResumen()
        {
            // Usa el resumen base y agrega información del archivo digital
            string resumenBase = base.GenerarResumen();
            return $"{resumenBase} - Archivo digital: {TamanoArchivoMB} MB";
        }

        // Método específico para libros digitales
        public void MostrarInformacionDescarga()
        {
            Console.WriteLine("=== INFORMACIÓN DE DESCARGA ===");
            Console.WriteLine($"Libro: {Titulo}");
            Console.WriteLine($"Tamaño: {TamanoArchivoMB} MB");
            Console.WriteLine($"Formato: Digital");
            Console.WriteLine(new string('-', 30));
        }
    }
}
