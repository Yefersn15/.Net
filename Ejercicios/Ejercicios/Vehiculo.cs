using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class Vehiculo
    {
        private string marca { get; set; }
        private string modelo { get; set; }
        private double kilometraje { get; set; }

        public Vehiculo(string marca, string modelo, double kilometraje)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.kilometraje = kilometraje;
        }
        // Propiedades públicas para acceso controlado
        public string Marca
        {
            get { return marca; }
        }

        public string Modelo
        {
            get { return modelo; }
        }

        public double Kilometraje
        {
            get { return kilometraje; }
            // Solo el sistema puede modificar el kilometraje (privado set)
            private set { kilometraje = value; }
        }

        // Método público para mostrar información - cualquier usuario autorizado puede consultar
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Kilometraje: {Kilometraje} km");
        }

        // Método protegido para cálculo interno - solo accesible por clases hijas
        protected virtual double CalcularCostoMantenimiento()
        {
            // Fórmula base: $0.10 por cada kilómetro
            return Kilometraje * 0.10;
        }

        // Método público para obtener el costo (usa el método protegido internamente)
        public double ObtenerCostoMantenimiento()
        {
            return CalcularCostoMantenimiento();
        }

        // Método para actualizar kilometraje (solo el sistema puede modificar)
        public void ActualizarKilometraje(double nuevoKilometraje)
        {
            if (nuevoKilometraje >= Kilometraje)
            {
                Kilometraje = nuevoKilometraje;
                Console.WriteLine($"Kilometraje actualizado a: {Kilometraje} km");
            }
            else
            {
                Console.WriteLine("Error: El nuevo kilometraje no puede ser menor al actual.");
            }
        }
    }
}