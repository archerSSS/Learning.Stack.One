using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {

        public DynArray<T> dyn;

        public Stack()
        {
            dyn = new DynArray<T>();
        }

        public int Size()
        {
            if (dyn.count != 0) return dyn.count;
            return 0;
        }

        public T Pop()
        {
            if (dyn.count > 0)
            {
                T val = dyn.GetItem(0);
                dyn.Remove(0);
                if (dyn.count == 0) return val;
                return val;
            }
            return default(T);
        }

        public void Push(T val)
        {
            if (val == null) return; 
            dyn.Insert(val, 0);
        }

        public T Peek()
        {
            if (dyn.count != 0)
            {
                return dyn.GetItem(0);
            }
            return default(T);
        }
    }
}