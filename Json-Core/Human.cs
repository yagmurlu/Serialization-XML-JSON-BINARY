using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_Core
{
    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }


        public Human(string name="",int age=0)
        {
            Name = name;
            Age = age;
        }
    }
}
