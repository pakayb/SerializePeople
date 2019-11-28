using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    [Serializable]
    public class Person
    {
        private static string FileName = "Person.bin";
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Genders Gender { get; set; }
        public int Age { get; set; }

        public enum Genders
        {
            Male,
            Female
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

        public override string ToString()
        {
            return $"Name: {Name} | Gender: {Gender} | Age: {Age}";
        }
    }
}
