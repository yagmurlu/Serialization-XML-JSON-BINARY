using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Json
{
    [Serializable()]
    public class Insan:ISerializable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Insan() { }
        public Insan(
            string name = "",
            string surname="",
            int age=0
            )
        {
            Name = name;
            Surname = surname;
            Age = age;
        }


        public override string ToString()
        {
            return string.Format("Adı{0} soyadı{1} yaşı{2}",Name,Surname,Age);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Surname",Surname);
            info.AddValue("Age", Age);
        }
        public Insan(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Surname = (string)info.GetValue("Surname", typeof(string));
            Age = (int)info.GetValue("Age", typeof(int));
        }
    }
    
  
}
