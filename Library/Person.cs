using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /*4.	Из csv файла (имя; фамилия; телефон; год рождения) прочитать записи в коллекцию.
     Каждая запись коллекции должна иметь тип Person.
     Сериализовать коллекцию с помощью класса SoapFormatter и сохранить в файл.*/
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public string SerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
