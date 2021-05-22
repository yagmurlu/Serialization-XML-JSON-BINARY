using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace json2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader _StreamReader = new StreamReader(@"C:\Users\aleyn\Desktop\Person.json"))
            {
                string jsonData = _StreamReader.ReadToEnd();
                List<Person> listPerson =JsonConvert.DeserializeObject<List<Person>>(jsonData);

                foreach (var _Person in listPerson)
                {
                    Console.WriteLine("Adı:{0} Soyadı:{1} Yaşı:{2}", _Person.Name, _Person.LastName,_Person.Age);
                }
            }
            Console.Read();
        }
        
    }
}
