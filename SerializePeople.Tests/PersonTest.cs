using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SerializePeople;

namespace SerializePeople.Tests
{
    [TestFixture]
    public class PersonTest
    {

        [Test]
        public void PersonConstructor_WithValidData_CreatePersonObject()
        {
            var birthDate = new DateTime(1999, 11, 10);
            var person = new Person("John", birthDate, Person.Genders.Male);
            Assert.AreEqual("John",person.Name);
            Assert.AreEqual(birthDate,person.BirthDate);
            Assert.AreEqual(Person.Genders.Male,person.Gender);
            Assert.AreEqual(20,person.Age);
            
        }

        [Test]
        public void PersonConstructor_BirthDayIsAfterThisMounthButInThisYear_GiveTheCorrectAge()
        {
            var testDateTime = DateTime.Now;
            testDateTime = testDateTime.AddYears(-30);
            if (testDateTime.Month<12)
            {
                testDateTime = testDateTime.AddMonths(1);
            }
            var person = new Person("John", testDateTime,Person.Genders.Male);
            Assert.AreEqual(29,person.Age);
        }

        [Test]
        public void PersonConstructor_BirthDayIsTomorrow_GiveTheCorrectAge()
        {
            var testDateTime = DateTime.Now;
            testDateTime = testDateTime.AddYears(-20);
            testDateTime = testDateTime.AddDays(1);
            var person = new Person("John",testDateTime,Person.Genders.Male);
            Assert.AreEqual(19,person.Age);
        }

        [Test]
        public void PersonConstructor_BirthDayIsToday_GiveTheCorrectAge()
        {
            var testDate = DateTime.Now;
            testDate = testDate.AddYears(-23);
            var person = new Person("Barna",testDate,Person.Genders.Male);
            Assert.AreEqual(23,person.Age);
        }

        [Test]
        public void PersonTostring_ValidData_GiveTheCorrectStringBack()
        {
            var person = new Person("John", new DateTime(2000,01,01),Person.Genders.Male );
            var expectedString = "Name: John | Gender: Male | Age: 19";
            Assert.AreEqual(expectedString, person.ToString());
        }
    }
}
