using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using RandomNameGenerator;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            //List<Book> books = service.GenerateBooks();
            

            List<Person> persons = service.GeneratePersons();
            //BinaryFormatter formatter = new BinaryFormatter();
            //service.JsonSerialization(persons,"PersonsJson.json");
            if (service.DesirealizePersons("PersonsJson.json") != null)
                service.DesirealizePersons("PersonsJson.json").ForEach(f =>
                {
                    Console.WriteLine($"{f.Name}\n{f.SerName}\n{f.DateOfBirth}");
                });
            else
                ErrorInfo();
          
            
            //service.BinarySerialization(ref books);
            //service.BinaryDeserialization();

            //service.SoapSerialization(ref persons);
            //service.SoapDeserialization();


        }
        static void ErrorInfo()
        {
            Console.WriteLine("Error");
        }
    }
}
