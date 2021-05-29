using System;
using System.Text.Json;
namespace Json_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human()
            {
                Name = "Jabal",
                Age = 30
            };
            string json = JsonSerializer.Serialize<Human>(human);
            Console.WriteLine(json);
            Human deserialized = JsonSerializer.Deserialize<Human>(json);
            Console.WriteLine(deserialized.Name+":"+deserialized.Age);
        }
    }
}
