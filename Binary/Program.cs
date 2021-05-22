using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Binary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Insan ınsans = new Insan()
            {
                Name = "Yağmur",
                Age=22
                
            };  
            string filePath = "data.dat";//data.save olarak da kaydettim//debug da
            DataSerializer dataSerializer = new DataSerializer();
            Insan ınsan = null;
            dataSerializer.BinarySerialize(ınsans,filePath);
            ınsan = dataSerializer.BinaryDeserialize(filePath) as Insan;
            Console.WriteLine("Name: "+ınsan.Name);
            Console.WriteLine("Age: "+ınsan.Age); 
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
        public void BinarySerialize(object data,string filePath)
        {
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileStream = File.Create(filePath);
            bf.Serialize(fileStream, data);
            fileStream.Close();
        }
        public object BinaryDeserialize(string filePath)
        {
            object obj = null;
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                obj = bf.Deserialize(fileStream);
                fileStream.Close();
            }
            return obj;

        }
    }
}
