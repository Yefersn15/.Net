using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class Camion : Vehiculo
    {
        // Atributo adicional específico de Camion
        private double capacidadCarga; // en toneladas

        public Camion(string marca, string modelo, double kilometraje, double capacidadCarga)
            : base(marca, modelo, kilometraje)
        {
            this.capacidadCarga = capacidadCarga;
        }

        // Propiedad pública
        public double CapacidadCarga
        {
            get { return capacidadCarga; }
        }

        // Sobrescribir método para mostrar información
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Capacidad de Carga: {CapacidadCarga} toneladas");
            Console.WriteLine($"Tipo: Camión");
        }

        // Sobrescribir método protegido para cálculo específico de camiones
        protected override double CalcularCostoMantenimiento()
        {
            // Fórmula para camiones: costo base + $0.15 por km + factor de carga
            double costoBase = 500; // Costo base más alto para camiones
            double costoPorKilometro = Kilometraje * 0.15;
            double factorCarga = CapacidadCarga * 100; // $100 adicional por tonelada de capacidad

            return costoBase + costoPorKilometro + factorCarga;
        }
    }
}