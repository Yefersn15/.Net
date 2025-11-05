using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2
{
    internal class Mascota
    {
        private string nombre { get; set; }
        private int edad { get; set; }
        private string tipo { get; set; }
        private double peso { get; set; }

        public Mascota(string nombre, int edad, string tipo, double peso)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.tipo = tipo;
            this.peso = peso;
        }
    }
}
