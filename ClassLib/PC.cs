using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    /*i.	3–4 поля (марка, серийный номер и т.д.),  
       ii.	свойства (к каждому полю),  
       iii.	конструкторы (по умолчанию, с параметрами),  
       iv.	методы, моделирующие функционирование ПЭВМ (включение/выключение, перегрузку). 
       */
    [Serializable]
    public class PC
    {
        public string Mark { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public bool SwitchOn { get; set; }
        public List<string> Processes { get; set; }

        public PC(string mark, string model, string serialNumber)
        {
            Mark = mark;
            Model = model;
            SerialNumber = serialNumber;
        }

        public PC()
        {
            
        }

        public void On()
        {
            Random Rnd = new Random();
            SwitchOn = true;
            Processes = new List<string>();
            for (int i = 0; i < Rnd.Next(1,50); i++)
            {
                string str = "#process" + Rnd.Next(100, 999);
                Processes.Add(str);
            }
        }

        public void Off()
        {
            SwitchOn = false;
            Processes = null;
        }

        public void Restart()
        {
            SwitchOn = false;
            Processes = null;

            Random Rnd = new Random();
            SwitchOn = true;
            Processes = new List<string>();
            for (int i = 0; i < Rnd.Next(1, 50); i++)
            {
                string str = "#process" + Rnd.Next(100, 999);
                Processes.Add(str);
            }
        }
    }
}
