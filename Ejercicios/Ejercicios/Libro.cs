using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class Libro
    {

        private string titulo { get; set; }
        private string autor { get; set; }
        private int numeroPaginas { get; set; }

        public Libro(string titulo, string autor, int numeroPaginas)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.numeroPaginas = numeroPaginas;
        }

        // Propiedades públicas para consulta
        public string Titulo
        {
            get { return titulo; }
        }

        public string Autor
        {
            get { return autor; }
        }

        public int NumeroPaginas
        {
            get { return numeroPaginas; }
        }

        // Método público para mostrar información básica
        public virtual void MostrarInformacion()
        {
            Console.WriteLine("=== INFORMACIÓN DEL LIBRO ===");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Número de páginas: {NumeroPaginas}");
            Console.WriteLine(new string('-', 30));
        }

        // Método privado para actualizar número de páginas (solo personal biblioteca)
        private void ModificarNumeroPaginas(int nuevoNumeroPaginas)
        {
            if (nuevoNumeroPaginas > 0)
            {
                numeroPaginas = nuevoNumeroPaginas;
                Console.WriteLine($"Número de páginas actualizado a: {nuevoNumeroPaginas}");
            }
            else
            {
                Console.WriteLine("Error: El número de páginas debe ser mayor a cero.");
            }
        }

        // Método público que usa el método privado (solo personal autorizado)
        public void ActualizarNumeroPaginas(int nuevoNumeroPaginas, string claveBiblioteca)
        {
            if (claveBiblioteca == "BIBLIO123") // Simulación de autenticación
            {
                ModificarNumeroPaginas(nuevoNumeroPaginas);
            }
            else
            {
                Console.WriteLine("Error: No tiene permisos para modificar el número de páginas.");
            }
        }

        // Método protegido para generar resumen
        protected virtual string GenerarResumen()
        {
            return $"\"{Titulo}\" por {Autor} - {NumeroPaginas} páginas";
        }

        // Método público que usa el método protegido
        public void MostrarResumen()
        {
            Console.WriteLine($"Resumen: {GenerarResumen()}");
        }
    }
}