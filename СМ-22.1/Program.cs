using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СМ_22._1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Func<Task<int[]>, int> func2 = new Func<Task<int[]>, int>(MaxArray);
            Task<int> task2 = task1.ContinueWith<int>(func2);

            Func<Task<int[]>, int> func3 = new Func<Task<int[]>, int>(SumArray);
            Task<int> task3 = task1.ContinueWith<int>(func3);

            task1.Start();
            Console.ReadKey();
        }
        static int[] GetArray (object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
                Console.WriteLine($"{array[i]} ");
            }
            return array;
        }
        static int MaxArray(Task<int[]> task)
        {

            int[] array = task.Result;
            int max = array[0];
            for (int i = 0; i < array.Count(); i++)
            { 
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine("Максимальное значение {0}", max);
            return (max);
        }
        static int SumArray (Task<int[]> task)
        {

            int[] array = task.Result;
            int s = 0;
            for (int i = 0; i < array.Count(); i++)
            {
                s += array[i];
            }
            Console.WriteLine("Сумма чисел массива {0}", s);
            return (s);
        }
    }
}
