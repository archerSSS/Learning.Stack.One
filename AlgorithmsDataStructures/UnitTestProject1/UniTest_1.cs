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
            //Assert.AreEqual(59, StackCalc("8 2 + 5 * 9 + ="));
            //Assert.AreEqual(20, StackCalc("13 5 * 2 - 43 - ="));
            //Assert.AreEqual(2, StackCalc("7 * 2 - 3 - ="));
        }


        [TestMethod]
        public void TestBalance_1()
        {
            bool b = IsBalanced("()))((()");
            Assert.AreEqual(true, b);
        }



        // 
        public int StackCalc(String str)
        {
            Stack<string> stack1 = new Stack<string>();
            Stack<string> stack2 = new Stack<string>();
            char[] chrs = str.ToCharArray();
            bool combine = false;
            for (int i = chrs.Length - 1; i >= 0; i--)
            {
                if (chrs[i] != ' ')
                {
                    if (combine) stack1.Push(chrs[i].ToString() + stack1.Pop());
                    else stack1.Push(chrs[i].ToString());
                    combine = true;
                }
                else combine = false;
            }
            

            for (int i = 0; stack1.Size() != 0; i++)
            {




                //if (stack1.Peek() == "+" && stack2.Size() > 1) stack2.Push((Convert.ToInt32(stack2.Pop()) + Convert.ToInt32(stack2.Pop())).ToString());
                //else if (stack1.Peek() == "-" && stack2.Size() > 1) stack2.Push((-Convert.ToInt32(stack2.Pop()) + Convert.ToInt32(stack2.Pop())).ToString());
                //else if (stack1.Peek() == "*" && stack2.Size() > 1) stack2.Push((Convert.ToInt32(stack2.Pop()) * Convert.ToInt32(stack2.Pop())).ToString());
                //else if (stack1.Peek() == "=" && stack2.Size() == 1) return Convert.ToInt32(stack2.Pop());
                //else stack2.Push(stack1.Peek());
                //stack1.Pop();
            }
            return 0;
        }


        // Проверка на сбалансированность строки
        // Обрабатывает строку четной длинны включающую в себя два разных символа,
        // если количество обоих символов в строке совпадает, возвращает значение true
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
