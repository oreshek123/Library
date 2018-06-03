using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Service
    {
        public void BinarySerializeForMyClass(object obj, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream sw = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(sw, obj);
            }
        }
    }
}
