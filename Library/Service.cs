using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RandomNameGenerator;

namespace Library
{
    public class Service
    {
        private Random Rnd = new Random();
        private BinaryFormatter BinaryFormatter = new BinaryFormatter();
        private SoapFormatter SoapFormatter = new SoapFormatter();

        public List<Book> GenerateBooks()
        {
            List<Book> books = new List<Book>();
            for (int i = 0; i < Rnd.Next(1, 20); i++)
            {
                Book book = new Book()
                {
                    Author = RandomNameGenerator.NameGenerator.GenerateLastName(),
                    Name = RandomNameGenerator.NameGenerator.GenerateFirstName((Gender)Rnd.Next(0, 2)),
                    Price = Rnd.Next(300, 5000),
                    Year = Rnd.Next(1960, 2018)
                };
                books.Add(book);
            }

            return books;
        }

        public List<Person> GeneratePersons()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < Rnd.Next(1, 20); i++)
            {
                Person person = new Person()
                {
                    Name = RandomNameGenerator.NameGenerator.GenerateFirstName((Gender)Rnd.Next(0, 2)),
                    SerName = RandomNameGenerator.NameGenerator.GenerateLastName(),
                    DateOfBirth = DateTime.Now.AddDays(-3000),
                    PhoneNumber = "8701" + Rnd.Next(100, 999) + Rnd.Next(10, 100) + Rnd.Next(10, 100)
                };
                Thread.Sleep(30);
                persons.Add(person);
            }

            return persons;
        }

        public void BinarySerialization(ref List<Book> books)
        {
            using (FileStream fs = new FileStream("Books.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter.Serialize(fs, books);
            }
        }

        public void SoapSerialization(ref List<Person> persons)
        {
            using (FileStream fs = new FileStream("Persons.soap", FileMode.OpenOrCreate))
            {
                SoapFormatter.Serialize(fs, persons.ToArray());
            }
        }

        public void BinaryDeserialization()
        {
            using (FileStream fs = new FileStream("Books.dat", FileMode.OpenOrCreate))
            {
                List<Book> lib = (List<Book>)BinaryFormatter.Deserialize(fs);
                PrintBooks(ref lib);
            }
        }

        public void PrintBooks(ref List<Book> books)
        {
            foreach (Book item in books)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Author);
                Console.WriteLine(item.Year);
                Console.WriteLine("-----------------");
            }
        }

        public void SoapDeserialization()
        {
            List<Person> list = null;
            using (FileStream fs = new FileStream("Persons.soap", FileMode.OpenOrCreate))
            {
                Person[] persons = (Person[])SoapFormatter.Deserialize(fs);
                list = persons.ToList();
            }
            PrintPeoples(ref list);
        }

        public void PrintPeoples(ref List<Person> persons)
        {
            foreach (Person item in persons)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.SerName);
                Console.WriteLine(item.PhoneNumber);
                Console.WriteLine(item.DateOfBirth);
                Console.WriteLine("-----------------");
            }
        }

        public void JsonSerialization(List<Person> persons, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.Write(JsonConvert.SerializeObject(persons));
                }

                Console.WriteLine("Данные были сериализированы успешно!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Person> DesirealizePersons(string fileName)
        {
            if (File.Exists(fileName))
                using (StreamReader sr = new StreamReader(fileName))
                    return JsonConvert.DeserializeObject<List<Person>>(sr.ReadToEnd());
            return null;
        }

        
    }

    
}