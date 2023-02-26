using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Action<Task<int[]>> action = new Action<Task<int[]>>(MaxArray);
            Task task2 = task1.ContinueWith(action);
        }
       
        static void MaxArray(int[] array)
        {
            for (int i = 0; i < array.Count(); i++)
            {
                int s = 0;
                {
                    s += array[i];
                }
                int max = array[0];
                foreach (int a in array)
                {
                    if (a > max)
                        max = a;
                }
                Console.Write($"{max},{s}");
            }
        }
    }
}
