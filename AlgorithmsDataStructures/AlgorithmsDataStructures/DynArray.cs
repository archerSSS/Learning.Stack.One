﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    public class DynArray<T>
    {

        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }


        public void MakeArray(int new_capacity)
        {
            if (array != null)
            {
                if (new_capacity < 16) new_capacity = 16;
                capacity = new_capacity;
            }
            else
            {
                array = new T[count];
                capacity = new_capacity;
            }
        }


        public T GetItem(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            return array[index];
            return default(T);
        }


        public void Append(T itm)
        {
            T[] temp_array = new T[count + 1];
            array.CopyTo(temp_array, 0);
            temp_array[count] = itm;
            array = temp_array;
            count++;
            if (count > capacity) MakeArray(capacity * 2);
        }


        public void Insert(T itm, int index)
        {
            if (index < 0 || index > count) throw new IndexOutOfRangeException();
            if (index == count) Append(itm);
            else
            {
                T[] temp_array = new T[count + 1];
                array.CopyTo(temp_array, 0);
                for (int i = count; i >= index; i--)
                {
                    temp_array[i] = array[i - 1];
                }
                temp_array[index] = itm;
                array = temp_array;
                count++;
                if (count > capacity) MakeArray(capacity * 2);
            }
        }


        public void Remove(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            T[] temp_array = new T[count - 1];
            for (int i = count - 2; i >= 0; i--)
            {
                if (i >= index) temp_array[i] = array[i + 1];
                else temp_array[i] = array[i];
            }
            array = temp_array;
            count--;
            if (count < capacity / 2) { MakeArray((int)(capacity / 1.5)); }
        }
    }
}
