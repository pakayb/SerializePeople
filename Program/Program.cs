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
            Person person = new Person("John", new DateTime(1996, 01, 02), Person.Genders.Male);
            person.Serialize("");
            Console.WriteLine(person);
        }
    }
}
