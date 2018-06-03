using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ClassLib;

namespace SerializConsolApp
{
    public class Program
    {
        /*c.	В функции Main() данного проекта создать коллекцию (на базе обобщенного класса List<T> )
         и добавить в коллекцию 4–5 объектов класса «РС». */
        static void Main(string[] args)
        {
            MyList<PC> myListPc = new MyList<PC>();
            PC pc = new PC("Asus","VivoBook pro","65616516");
            PC pc2 = new PC("Acer","Predator","15614845451");
            PC pc3 = new PC("Apple","MacBook Pro","51646846");
            PC pc4 = new PC("Lenovo","UltraBook","136165313");
            PC pc5 = new PC("Dell","Book","45345413544");

            myListPc.Add(pc);
            myListPc.Add(pc2);
            myListPc.Add(pc3);
            myListPc.Add(pc4);
            myListPc.Add(pc5);

           Service service = new Service();
            service.BinarySerializeForMyClass(myListPc, @"E:/listSerial.txt");

            
        }
    }
   
}
