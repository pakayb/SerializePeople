using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    [Serializable]
    public class Person :IDeserializationCallback,ISerializable
    {
        private static string FileName = "Person.bin";
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Genders Gender { get; set; }
        [NonSerialized]private int _age;
        public int Age { get => _age; set => _age = value; }

        public enum Genders
        {
            Male,
            Female
        }

        public Person()
        {
        }

        public Person(string name, DateTime birthDate, Genders gender)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Age = CalculateAge(birthDate);
        }

        private int CalculateAge(DateTime birthDate)
        {
            var now = DateTime.Now;
            var age = (now.Year - birthDate.Year);
            if (birthDate.Month > now.Month || birthDate.Month == now.Month && birthDate.Day > now.Day )
            {
                age--;
            }

            return age;
        }

        public void Serialize(string output)
        {
            Stream stream = new FileStream(FileName,FileMode.Create, FileAccess.Write,FileShare.None);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream,this);
            stream.Close();
        }

        public static Person Deserialize()
        {
            Person person = new Person();
            Stream stream = new FileStream(FileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            person = (Person)formatter.Deserialize(stream);
            stream.Close();
            return person;
        }

        public override string ToString()
        {
            return $"Name: {Name} | Gender: {Gender} | Age: {Age}";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("BirthDate",BirthDate);
            info.AddValue("Gender",Gender);
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            BirthDate = info.GetDateTime("BirthDate");
            Gender = (Genders) info.GetValue("Gender", typeof(Genders));
            Age = CalculateAge(this.BirthDate);
        }

        public void OnDeserialization(object sender)
        {
            Age = CalculateAge(BirthDate);
        }
    }
}
