using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class Empleado
    {
        private string nombre { get; set; }
        private string cargo { get; set; }
        private double salario { get; set; }
        public Empleado(string nombre, string cargo, double salario)
        {
            this.nombre = nombre;
            this.cargo = cargo;
            this.salario = salario;
        }

        // Propiedades públicas para acceso controlado
        public string Nombre
        {
            get { return nombre; }
        }

        public string Cargo
        {
            get { return cargo; }
        }

        // El salario solo tiene get público, no set
        public double Salario
        {
            get { return salario; }
        }

        // Método público para mostrar datos generales - todos pueden consultar
        public virtual void MostrarInformacion()
        {
            Console.WriteLine("=== INFORMACIÓN DEL EMPLEADO ===");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Salario Base: ${Salario:F2}");
            Console.WriteLine(new string('-', 30));
        }

        // Método privado para modificar salario - solo área administrativa internamente
        private void ModificarSalario(double nuevoSalario)
        {
            if (nuevoSalario > 0)
            {
                salario = nuevoSalario;
                Console.WriteLine($"Salario actualizado a: ${nuevoSalario:F2}");
            }
            else
            {
                Console.WriteLine("Error: El salario debe ser mayor a cero.");
            }
        }

        // Método público que usa el método privado internamente (simulando área administrativa)
        public void ActualizarSalario(double nuevoSalario, string claveAdministrativa)
        {
            if (claveAdministrativa == "ADMIN123") // Simulación de autenticación
            {
                ModificarSalario(nuevoSalario);
            }
            else
            {
                Console.WriteLine("Error: No tiene permisos para modificar salarios.");
            }
        }

        // Método protegido para consultar salario - accesible desde subclases
        protected double ObtenerSalario()
        {
            return salario;
        }

        // Método protegido para cálculo de bono base
        protected virtual double CalcularBonoBase()
        {
            // Bono base del 10% del salario
            return Salario * 0.10;
        }
    }
}