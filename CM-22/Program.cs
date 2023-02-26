using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_22
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел");
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n); 

            Func<Task<int[]>, int> func2 = new Func<Task<int[]>, int>(MaxArray);
            Task<int[]> task2 = task1.ContinueWith<int[]>(new Func<object, int[]>(GetArray));

            Action<Task<int[]>> action = new Action<Task<int[]>>(MaxArray);
            Task task3 = task2.ContinueWith(action);

            int[] GetArray =new int[a];
            int n = (int)a;
            Random random = new Random();
                for (int i = 0; i < n; i++)
                {
                    GetArray[i] = random.Next(0, 100);
                   Console.Write("{0} ", GetArray[i]);
                }
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
 