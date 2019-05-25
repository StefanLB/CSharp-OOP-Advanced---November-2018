using System;
using System.Collections.Generic;
using System.Text;

namespace _11.Threeuple
{
    public class MyTuple<T,U,V>
    {
        public MyTuple(T item1, U item2, V item3)
        {
            this.FirstItem = item1;
            this.SecondItem = item2;
            this.ThirdItem = item3;
        }

        public T FirstItem { get; set; }
        public U SecondItem { get; set; }
        public V ThirdItem { get; set; }
    }
}
