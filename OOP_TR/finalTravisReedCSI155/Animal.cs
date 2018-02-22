using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalTravisReedCSI155
{
    public class Animal
    {

        private string _animalName;

        public Animal(string animalName)
        {
            _animalName = animalName;
        }

        public string AnimalName
        { get { return _animalName; } }
    }
}
