using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Serializable]
    public class MyList<T> : IEnumerable
    {
        private readonly List<T> _myList = new List<T>();
        public void Add(T obj) => _myList.Add(obj);



        public bool Remove(T obj) => _myList.Remove(obj);


        public IEnumerator GetEnumerator()
        {
            return _myList.GetEnumerator();
        }
    }
}
