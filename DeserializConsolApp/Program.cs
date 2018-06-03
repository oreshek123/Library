using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ClassLib;

namespace DeserializConsolApp
{
    class Program
    {
        
        static void Main(string[] args)
        {

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"E:\listSerial.txt", FileMode.OpenOrCreate))
            {
                MyList<PC> pcs = (MyList<PC>)bf.Deserialize(fs);

                foreach (PC item in pcs)
                {
                    Console.WriteLine(item.Mark + "\n" + item.Model + "\n" + item.SerialNumber);
                    Console.WriteLine("-------------------------");
                }
            }  
        }
    }
   
}
