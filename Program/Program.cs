using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerializePeople;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Johnn", new DateTime(1997, 01, 02), Person.Genders.Male);
            person.Serialize("");
            Console.WriteLine(person);
            person = null;
            person = Person.Deserialize();
            Console.WriteLine(person);
            Console.ReadLine();
        }
    }
}
