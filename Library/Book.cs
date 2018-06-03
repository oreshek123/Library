using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /*1.	Объявить в консольном приложении класс Book с полями: название, стоимость, автор, год.
     Создать коллекцию элементов Book и заполнить тестовыми данными.
     С помощью класса BinaryFormatter сохранить состояние приложения в двоичный файл.*/
    [Serializable]
    public class Book
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

    }
}
