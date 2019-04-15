using System;
using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{

    [TestClass]
    public class UniTest_1
    {

        [TestMethod]
        public void CalculateTest_1()
        {
            Stack<string> stack1 = PushStrings("8 2 + 5 * 9 + =");
            Stack<string> stack2 = PushStrings("13 5 * 2 - 43 - =");
            Stack<string> stack3 = PushStrings("7 * 2 - 3 - =");

            Assert.AreEqual(59, CalcStack(stack1));
            Assert.AreEqual(20, CalcStack(stack2));
            Assert.AreEqual(2, CalcStack(stack3));
        }


        [TestMethod]
        public void TestBalance_1()
        {
            bool b1 = IsBalanced("()))((()");
            bool b2 = IsBalanced("(()");
            bool b3 = IsBalanced("())())");
            bool b4 = IsBalanced("");

            Assert.AreEqual(true, b1);
            Assert.AreEqual(false, b2);
            Assert.AreEqual(false, b3);
            Assert.AreEqual(true, b4);
        }


        // Создает Стек.
        //
        // Включает в себя элементы из строк.
        // Из входящего строчного аргумента после каждого пробела выделяется новый элемент.
        // Пробелы в качестве элементов исключаются.
        //
        public Stack<String> PushStrings(String str)
        {
            Stack<string> stack = new Stack<string>();
            char[] chrs = str.ToCharArray();
            bool combine = false;
            for (int i = chrs.Length - 1; i >= 0; i--)
            {
                if (chrs[i] != ' ')
                {
                    if (combine) stack.Push(chrs[i].ToString() + stack.Pop());
                    else stack.Push(chrs[i].ToString());
                    combine = true;
                }
                else combine = false;
            }
            return stack;
        }


        // Решение выражений.
        //
        // Извлекает и обрабатывает строчные элементы из Стека влючающие в себя числа и знаки (+ - * =)
        // Числовые строки переводит во второй Стек, а операторы используются для результата вычисления двух строчных элементов из второго Стека.
        // В случае если во втором Стеке меньше двух элементов, то оператор вычислений игнорируется и просто удаляется.
        // Если первый Стек содержит символ '=', то возвращает целочисленный результат переводя единственный элемент из второго Стека.
        //
        public int CalcStack(Stack<String> stack1)
        {
            Stack<string> stack2 = new Stack<string>();
            
            for (int i = 0; stack1.Size() != 0; i++)
            {
                if (stack1.Peek() == "+")
                {
                    if (stack2.Size() > 1) stack2.Push((Convert.ToInt32(stack2.Pop()) + Convert.ToInt32(stack2.Pop())).ToString());
                }
                else if (stack1.Peek() == "-")
                {
                    if (stack2.Size() > 1) stack2.Push((-Convert.ToInt32(stack2.Pop()) + Convert.ToInt32(stack2.Pop())).ToString());
                }
                else if (stack1.Peek() == "*")
                {
                    if (stack2.Size() > 1) stack2.Push((Convert.ToInt32(stack2.Pop()) * Convert.ToInt32(stack2.Pop())).ToString());
                }
                else if (stack1.Peek() == "=")
                {
                    if (stack2.Size() == 1) return Convert.ToInt32(stack2.Pop());
                }
                else stack2.Push(stack1.Peek());
                stack1.Pop();
            }
            return 0;
        }


        // Сбалансированность.
        //
        // Проверка на сбалансированность строки
        // Обрабатывает строку четной длинны включающую в себя два разных символа,
        // если количество обоих символов в строке совпадает, возвращает значение true
        //
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
