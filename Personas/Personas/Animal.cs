using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas
{
    internal class Animal
    {
        public string name { get; set; }
        private string species { get; set; }
        public int age { get; set; }
        public Animal(string name, string species, int age)
        {
            this.name = name;
            this.species = species;
            this.age = age;
        }
        protected void showInfo()
        {
            Console.WriteLine($"Name: {name}, Species: {species}, Age: {age}");
        }

        public void ShowPublicInfo()
        {
            showInfo();
        }
    }
}
