using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SerializePeople
{
    [Serializable]
    public class Person
    {
        public string Name { get; }
        public DateTime BirthDate { get; }
        public Genders Gender { get; }
        public int Age { get; private set; }

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

        public override string ToString()
        {
            return $"Name: {Name} | Gender: {Gender} | Age: {Age}";
        }
    }
}
