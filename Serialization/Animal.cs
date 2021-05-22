using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace Serialization
{
    [Serializable()]

    public class Animal:ISerializable
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
 
        public Animal() { }
        public Animal(string name = "İsimsiz",
            double weight = 0,
            double height = 0)
        {
            Name = name;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return string.Format("{0} isimli {1} kiloda {2} boyundadır.", Name, Weight, Height);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Weight", Weight);
            info.AddValue("Height", Height);
        }
        public Animal(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Weight = (double)info.GetValue("Weight", typeof(double));
            Height = (double)info.GetValue("Height", typeof(double));
        }
    }
}
