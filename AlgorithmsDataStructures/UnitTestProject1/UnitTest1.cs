using System;
using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Добавляет назначенное количество элементов Sphere count в хранилище стека.
        private Stack<Sphere> MakeStack(int count)
        {
            Stack<Sphere> stack = new Stack<Sphere>();
            for (int i = 0; i < count; i++)
            {
                stack.Push(new Sphere(i + 1));
            }
            return stack;
        }

        // Добавляет назначенное количество элементов Sphere count в хранилище стека.
        // Добавляет назначенное количество элементов SphereGreen greenCount в хранилище стека.
        // Элементы SphereGreen добавляются в первую очередь.
        private Stack<Sphere> MakeStack(int count, int greenCount)
        {
            Stack<Sphere> stack = new Stack<Sphere>();
            for (int i = 0; i < count; i++)
            {
                if (i < greenCount) { stack.Push(new SphereGreen(i)); }
                else stack.Push(new Sphere(i + 1));
            }
            return stack;
        }


        // Добавляет элементы и копирует головной элемент методом Peek()
        [TestMethod]
        public void TestMakeStackPeek_1()
        {
            Stack<Sphere> stack = MakeStack(2);
            Sphere s1 = stack.Peek();
            Sphere s2 = stack.Peek();
            Assert.AreEqual(2, s1.GetDiameter());
            Assert.AreEqual(2, s2.GetDiameter());
        }


        // Добавляет 4 элемента и вытаскивает 4 элемента. Хранилище стека остается пустым.
        [TestMethod]
        public void TestMakeStackPop_1()
        {
            Stack<Sphere> stack = MakeStack(4);
            Sphere s1 = stack.Pop();
            Sphere s2 = stack.Pop();
            Sphere s3 = stack.Pop();
            Sphere s4 = stack.Pop();
            Assert.AreEqual(4, s1.GetDiameter());
            Assert.AreEqual(3, s2.GetDiameter());
            Assert.AreEqual(2, s3.GetDiameter());
            Assert.AreEqual(1, s4.GetDiameter());
        }


        // Добавляет 4 элемента и пытается вытащить 5 элементов. Отслеживает значение головного элемента.
        [TestMethod]
        public void TestMakeStackPop_2()
        {
            Sphere s1;
            Sphere s2;
            Sphere s3;
            Sphere s4;
            Sphere s5;
            Stack<Sphere> stack = MakeStack(4);

            s1 = stack.Pop();
            Assert.AreEqual(4, s1.GetDiameter());

            s2 = stack.Pop();
            Assert.AreEqual(3, s2.GetDiameter());

            s3 = stack.Pop();
            Assert.AreEqual(2, s3.GetDiameter());

            s4 = stack.Pop();
            Assert.AreEqual(1, s4.GetDiameter());

            s5 = stack.Pop();
            Assert.AreEqual(4, s1.GetDiameter());
            Assert.AreEqual(3, s2.GetDiameter());
            Assert.AreEqual(2, s3.GetDiameter());
            Assert.AreEqual(1, s4.GetDiameter());
            Assert.AreEqual(null, s5);
        }


        // Добавляет в хвост один элемент. Копирует головной элемент сохраняя целостность стека.
        [TestMethod]
        public void TestPushPeek()
        {
            Sphere sphere = new Sphere(1);
            Stack<Sphere> stack = new Stack<Sphere>();
            stack.Push(sphere);
            Sphere s1 = stack.Peek();
            Assert.AreEqual(sphere, s1);
        }


        // Проверка размера хранилища стека
        [TestMethod]
        public void TestSize_1()
        {
            Sphere sphere1 = new Sphere(1);
            Sphere sphere2 = new Sphere(2);

            Stack<Sphere> stack = new Stack<Sphere>();
            Assert.AreEqual(0, stack.Size());

            stack.Push(sphere1);
            Assert.AreEqual(1, stack.Size());

            stack.Push(sphere2);
            Assert.AreEqual(2, stack.Size());
        }


        // Проверка размера хранилища стека с чередой добавлений и извлечений
        [TestMethod]
        public void TestSize_2()
        {
            Sphere sphere1 = new Sphere(1);
            Sphere sphere2 = new Sphere(2);
            Sphere sphere3 = new Sphere(3);
            Sphere sphere4 = new Sphere(4);

            Stack<Sphere> stack = new Stack<Sphere>();
            stack.Push(sphere1);
            stack.Push(sphere2);
            stack.Push(sphere3);
            
            Assert.AreEqual(3, stack.Size());

            stack.Pop();
            Assert.AreEqual(2, stack.Size());

            stack.Push(sphere4);
            Assert.AreEqual(3, stack.Size());

            stack.Pop();
            stack.Pop();
            Assert.AreEqual(1, stack.Size());
        }


        // Проверка размера хранилища стека. Одно извлечение. Размер изначально: 0. Итог: 0.
        [TestMethod]
        public void TestSize_3()
        {
            Stack<Sphere> stack = new Stack<Sphere>();
            
            stack.Pop();
            Assert.AreEqual(0, stack.Size());
        }


        // Проверка на отсутствие изменений размера при добавлении пустого значения
        [TestMethod]
        public void TestSize_4()
        {
            Stack<Sphere> stack = new Stack<Sphere>();
            stack.Push(null);

            Assert.AreEqual(0, stack.Size());
        }


        // Добавляет в хвост один элемент. Вытаскивает один элемент из головы, после чего стек станет пустым.
        [TestMethod]
        public void TestPushPop_1()
        {
            Sphere sphere = new Sphere(1);
            Stack<Sphere> stack = new Stack<Sphere>();
            stack.Push(sphere);
            Sphere s1 = stack.Pop();
            Assert.AreEqual(sphere, s1);
        }


        // Добавляет в хвост три элемента. Производится попытка вытащить четыре элемента.
        // Четвертый должен быть null, а стек пустым в итоге.
        [TestMethod]
        public void TestPushPop_2()
        {
            Sphere sphere1 = new Sphere(1);
            Sphere sphere2 = new Sphere(2);
            Sphere sphere3 = new Sphere(3);
            Stack<Sphere> stack = new Stack<Sphere>();
            stack.Push(sphere1);
            stack.Push(sphere2);
            stack.Push(sphere3);
            Sphere s1 = stack.Pop();
            Sphere s2 = stack.Pop();
            Sphere s3 = stack.Pop();
            Sphere s4 = stack.Pop();
            Assert.AreEqual(sphere3, s1);
            Assert.AreEqual(sphere2, s2);
            Assert.AreEqual(sphere1, s3);
            Assert.AreEqual(null, s4);
        }


        // Череда добавлений и извлечений. В последствии остаток хранилища: один элемент.
        [TestMethod]
        public void TestPushPop_3()
        {
            Sphere sphere1 = new Sphere(1);
            Sphere sphere2 = new Sphere(2);
            Sphere sphere3 = new Sphere(3);
            Sphere sphere4 = new Sphere(4);

            Stack<Sphere> stack = new Stack<Sphere>();
            stack.Push(sphere1);
            stack.Push(sphere2);
            
            Sphere s1 = stack.Pop();
            Assert.AreEqual(sphere2, s1);

            stack.Push(sphere3);
            stack.Push(sphere4);

            Sphere s2 = stack.Pop();
            Sphere s3 = stack.Pop();

            Assert.AreEqual(sphere4, s2);
            Assert.AreEqual(sphere3, s3);

            Assert.AreEqual(1, stack.Size());
        }


        [TestMethod]
        public void TestPushPopSize_1()
        {
            Stack<Sphere> stack = new Stack<Sphere>();
            Stack<Sphere> stack2 = new Stack<Sphere>();
            stack.Push(new Sphere(1));
            stack.Push(new Sphere(2));
            stack.Push(new Sphere(3));
            Assert.AreEqual(3, stack.Size());
            stack2.Push(stack.Pop());
            Assert.AreEqual(2, stack.Size());
            Assert.AreEqual(1, stack2.Size());
        }


        [TestMethod]
        public void TestPushPopSize_2()
        {
            Stack<Sphere> stack = new Stack<Sphere>();
            for (int i = 0; i < 17; i++)
            {
                stack.Push(new Sphere(i + 1));
            }
            Assert.AreEqual(17, stack.Size());
            for (int i = 0; i < 18; i++)
            {
                stack.Pop();
            }
            Assert.AreEqual(0, stack.Size());
        }


        [TestMethod]
        public void TestPushPopPeek_1()
        {
            Stack<Sphere> stack = new Stack<Sphere>();
            Sphere sp = new Sphere(1);
            stack.Push(sp);
            for (int i = 2; i < 19; i++)
            {
                stack.Push(new Sphere(i));
                Assert.AreEqual(i, stack.Peek().GetDiameter());
            }
            for (int i = 1; i < 19; i++)
            {
                stack.Pop();
                sp = stack.Peek();
                if (stack.Size() != 0) Assert.AreEqual(18 - i, stack.Peek().GetDiameter());
                else Assert.AreEqual(null, stack.Peek());
            }
        }
        

        [TestMethod]
        public void TestPushPopSizePeek_1()
        {
            Stack<Sphere> stack = new Stack<Sphere>();
            stack.Push(new Sphere(1));
            Assert.AreEqual(1, stack.Size());
            stack.Pop();
            Assert.AreEqual(0, stack.Size());
            Assert.AreEqual(null, stack.Peek());
            stack.Pop();
            Assert.AreEqual(0, stack.Size());

            stack.Push(new Sphere(2));
            stack.Push(new Sphere(3));
            Assert.AreEqual(2, stack.Size());
            Assert.AreEqual(3, stack.Peek().GetDiameter());
        }


        [TestMethod]
        public void TestPushPopSizePeek_2()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            Assert.AreEqual(1, stack.Size());
            stack.Pop();
            Assert.AreEqual(0, stack.Size());
            Assert.AreEqual(0, stack.Peek());
            stack.Pop();
            Assert.AreEqual(0, stack.Size());

            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(2, stack.Size());
            Assert.AreEqual(3, stack.Peek());
        }


        [TestMethod]
        public void TestPushPopSizePeek_3()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            Assert.AreEqual(1, stack.Size());
            stack.Pop();
            Assert.AreEqual(0, stack.Size());
            Assert.AreEqual(0, stack.Peek());
            stack.Pop();
            Assert.AreEqual(0, stack.Size());

            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(2, stack.Size());
            Assert.AreEqual(3, stack.Peek());
        }
        

        [TestMethod]
        public void TestBalance_1()
        {
            bool b = IsBalanced("()))((()");
            Assert.AreEqual(true, b);
        }


        public bool IsBalanced(String str)
        {
            if (str.Length % 2 > 0) { return false; }

            Stack<String> stack = new Stack<string>();
            for (int i = 0; i < str.Length; i++)
            {
                if (stack.Size() == 0)
                {
                    stack.Push(str.Substring(i, 1));
                    continue;
                }
                if (str.Substring(i, 1) == stack.Peek()) stack.Push(str.Substring(i, 1));
            }
            if (stack.Size() == (str.Length / 2)) return true; 
            return false;
        }
    }
}
