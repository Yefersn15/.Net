using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Auto
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public int anio { get; set; }
        public string color { get; set; }

        public Auto(string marca, string modelo, int anio, string color)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.anio = anio;
            this.color = color;
        }

        public void MostrarInfo()
        {
            Console.WriteLine("Marca: " + marca);
            Console.WriteLine("Modelo: " + modelo);
            Console.WriteLine("Año: " + anio);
            Console.WriteLine("Color: " + color);
        }


    }
}
