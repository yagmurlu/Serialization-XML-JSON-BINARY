using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Json_Serial
{
    class Program
    {
        static void Main(string[] args)
        {
            Insan ınsans = new Insan()
            {
                Name = "Muhammed",
                Age = 5

            };
            string filePath = "data.json";//data.save olarak kaydettim
            DataSerializer dataSerializer = new DataSerializer();
            Insan ınsan = null;
            dataSerializer.JsonSerialize(ınsans, filePath);
            ınsan = dataSerializer.JsonDeserialize(typeof(Insan), filePath) as Insan;
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
        public void JsonSerialize(object data, string filePath)
        {
            
            JsonSerializer jsonSerializer = new JsonSerializer();

            if (File.Exists(filePath)) File.Delete(filePath);
            StreamWriter writer = new StreamWriter(filePath);
            JsonWriter jsonWriter = new JsonTextWriter(writer);
            jsonSerializer.Serialize(jsonWriter,data);
            jsonWriter.Close();
            writer.Close();
        }
        public object JsonDeserialize(Type dataType, string filePath)
        {
            JObject obj = null;
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);
                JsonReader jsonReader = new JsonTextReader(reader);
                obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                jsonReader.Close();
                reader.Close();
            }
            return obj.ToObject(dataType);
        }
    }
}
