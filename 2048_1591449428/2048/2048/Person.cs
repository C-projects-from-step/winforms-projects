using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    [Serializable]
    class Person
    {
        public string Name {get; set;}
        public int Points { get; set; }
        public string Board { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Points}";
        }
    }
}
