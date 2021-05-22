using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

using System.Net;

using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Dynamic;
using Newtonsoft.Json.Converters;

namespace Json
{
    public class Program
    {
        //[STAThread]
        public static void Main(string[] args)
        {
            string path = @"C:\Users\aleyn\Desktop\deneme.json";
            List<Insan> ınsans = new List<Insan>
           {
               new Insan("Kadir","Gür",28),
               new Insan("Selma","Canlı",25),
               new Insan("Kağan","Öztürk",23),
               new Insan("Emre","Öz",23)
           };
            //open file stream
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, ınsans);
            }
            ////dosya okuma
            //StreamReader stream_read = new StreamReader(path);
            //string js_data = stream_read.ReadToEnd();// dosyayı okuruz.
            //List<Insan> veriler = JsonConvert.DeserializeObject<List<Insan>>(js_data);
            // json datasını convert edip, Veriler clasından türettiğimiz nesneye aktarıyoruz.


            //**********************
            // read file into a string and deserialize JSON to a type//File.ReadAllText


            string json = "[{\"Name\":\"name\",\"Surname\":\"surname\",\"Age\":\"age\"}]";
            //Insan ınsan = JsonConvert.DeserializeObject<Insan>(json);


            dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());

            Console.WriteLine($"Deserialized JSON into {config.GetType()}");

            foreach (var enabledEndpoint in ((IEnumerable<dynamic>)config.endpoints).Where(t => t.enabled))
            {
                Console.WriteLine($"{enabledEndpoint.Name} is enabled");
            }
            //// deserialize JSON directly from a file
            //using (StreamReader file = File.OpenText(path))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    Insan ınsan2 = (Insan)serializer.Deserialize(file, typeof(Insan));
            //}

            // console yazdırma
            //Console.WriteLine(json);
            Console.Read();
        }          
    }
}