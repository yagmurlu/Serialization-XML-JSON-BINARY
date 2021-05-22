using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal kedi = new Animal("Kedi", 5, 10);
            Stream stream = File.Open("AnimalData.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, kedi);
            stream.Close();
            kedi = null;
            stream = File.Open("AnimalData.dat", FileMode.Open);
            bf = new BinaryFormatter();
            kedi = (Animal)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine(kedi.ToString());
            kedi.Weight = 15;
            XmlSerializer serializer = new XmlSerializer(typeof(Animal));
            using(TextWriter tw=new StreamWriter(@"C:\Users\aleyn\Desktop\kedi.xml"))
            {
                serializer.Serialize(tw, kedi);

            }

            kedi = null;
            XmlSerializer deserializer = new XmlSerializer(typeof(Animal));
            TextReader reader = new StreamReader(@"C:\Users\aleyn\Desktop\kedi.xml");
            object obj = deserializer.Deserialize(reader);
            kedi = (Animal)obj;
            reader.Close();
            Console.WriteLine(kedi.ToString());

            //**************************************

            List<Animal> animals = new List<Animal>
            {
                new Animal("Kanguru",55,15),
                new Animal("Civciv",3,1),
                new Animal("Zürafa",80,50)
            };
            using(Stream fs=new FileStream(@"C:\Users\aleyn\Desktop\hayvanlar.xml",FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Animal>));
                serializer2.Serialize(fs, animals);
            }
            animals = null;
            XmlSerializer serializer3 = new XmlSerializer(typeof(List<Animal>));
            using(FileStream fs2 = File.OpenRead(@"C:\Users\aleyn\Desktop\hayvanlar.xml"))
            {
                animals = (List<Animal>)serializer3.Deserialize(fs2);
            }
            foreach (Animal a in animals)
            {
                Console.WriteLine(a);
            }
            Console.ReadLine();
        }
    }
}
