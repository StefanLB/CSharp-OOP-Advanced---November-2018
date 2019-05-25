﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _10.Tuple
{
    public class MyTuple<T,U>
    {
        public MyTuple(T item1, U item2)
        {
            this.FirstItem = item1;
            this.SecondItem = item2;
        }

        public T FirstItem { get; set; }
        public U SecondItem { get; set; }
    }
}
