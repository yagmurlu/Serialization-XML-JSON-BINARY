using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace XML
{
    public class Program
    {
        static void Main(string[] args)
        {
            Insan ınsans = new Insan()
            {
                Name = "Ömer",
                Age = 3
            };
            string filePath = @"C: \Users\aleyn\Desktop\Serializer.xml";
            DataSerializer dataSerializer = new DataSerializer();
            Insan ınsan = null;
            dataSerializer.XMLserializer(typeof(Insan), ınsans, filePath);
            ınsan = dataSerializer.XMLDeserialize(typeof(Insan), filePath) as Insan;
            Console.WriteLine("Name: " + ınsan.Name);
            Console.WriteLine("Age: " + ınsan.Age);
            Console.ReadLine();
        }
    }
    [Serializable]
    public class Insan
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class DataSerializer
    {
        public void XMLserializer(Type dataType,object data,string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            //dosyanın varlığını kontrol ediyoruz
            if (File.Exists(filePath)) File.Delete(filePath);
            TextWriter writer = new StreamWriter(filePath);
            xmlSerializer.Serialize(writer, data);
            writer.Close();
        }
        public object XMLDeserialize(Type dataType,string filePath)
        {
            object obj = null;
            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            if (File.Exists(filePath))
            {
                TextReader reader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(reader);
                reader.Close();
            }
            return obj;
        }
    }
}
