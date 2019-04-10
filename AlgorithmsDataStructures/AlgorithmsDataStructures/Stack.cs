using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {

        public DynArray<T> dyn;
        public T head;

        public Stack()
        {
            dyn = new DynArray<T>();
            // инициализация внутреннего хранилища стека
        }

        public int Size()
        {
            if (dyn.count != 0) return dyn.count;
            // размер текущего стека
            return 0;
        }

        public T Pop()
        {
            if (dyn.count > 0)
            {
                T val = head;
                dyn.Remove(0);
                if (dyn.count == 0) head = default(T);
                else head = dyn.GetItem(0);
                return val;
            }
            // ваш код
            return default(T); // null, если стек пустой
        }

        public void Push(T val)
        {
            if (val == null) return; 
            dyn.Append(val);
            head = dyn.GetItem(0);
            // ваш код
        }

        public T Peek()
        {
            if (dyn.count != 0)
            {
                return head;
            }
            return default(T); // null, если стек пустой
        }
    }
}