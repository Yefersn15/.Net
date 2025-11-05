using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class Gerente : Empleado
    {
        private string departamento { get; set; }
        private double bonoGerencia { get; set; }

        public Gerente(string nombre, string cargo, double salario, string departamento, double bonoGerencia)
            : base(nombre, cargo, salario)
        {
            this.departamento = departamento;
            this.bonoGerencia = bonoGerencia;
        }

        // Propiedades públicas
        public string Departamento
        {
            get { return departamento; }
        }

        public double BonoGerencia
        {
            get { return bonoGerencia; }
        }

        // Sobrescribir método para mostrar información
        public override void MostrarInformacion()
        {
            Console.WriteLine("=== INFORMACIÓN DEL GERENTE ===");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Departamento: {Departamento}");

            // Usar método protegido para obtener salario
            double salarioBase = ObtenerSalario();
            Console.WriteLine($"Salario Base: ${salarioBase:F2}");

            // Calcular y mostrar bono total
            double bonoTotal = CalcularBonoTotal();
            Console.WriteLine($"Bono de Gerencia: ${BonoGerencia:F2}");
            Console.WriteLine($"Bono Total: ${bonoTotal:F2}");
            Console.WriteLine($"Salario Total: ${(salarioBase + bonoTotal):F2}");
            Console.WriteLine(new string('-', 30));
        }

        // Método que usa el método protegido de la clase base
        public double CalcularBonoTotal()
        {
            // Usar método protegido para obtener salario
            double salarioBase = ObtenerSalario();

            // Bono total = bono base + bono específico de gerencia
            double bonoBase = CalcularBonoBase();
            return bonoBase + BonoGerencia;
        }

        // Sobrescribir método protegido para cálculo de bono base específico de gerentes
        protected override double CalcularBonoBase()
        {
            // Gerentes reciben 15% en lugar del 10% base
            return ObtenerSalario() * 0.15;
        }

        // Método específico de gerente para mostrar resumen ejecutivo
        public void MostrarResumenEjecutivo()
        {
            double salarioBase = ObtenerSalario();
            double bonoTotal = CalcularBonoTotal();
            double salarioTotal = salarioBase + bonoTotal;

            Console.WriteLine("=== RESUMEN EJECUTIVO ===");
            Console.WriteLine($"Gerente: {Nombre}");
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Compensación Total: ${salarioTotal:F2}");
            Console.WriteLine($" - Salario Base: ${salarioBase:F2}");
            Console.WriteLine($" - Bono Total: ${bonoTotal:F2}");
            Console.WriteLine(new string('=', 40));
        }
    }
}