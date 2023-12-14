using HomeWork12;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork12
{
    internal class Program
    {
        static void PrintNum()
        {
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
        }
        static async Task<long> PrintFact(int value)
        {
            await Task.Delay(8000);

            long factorial = 1;
            for (int i = 1; i <= value; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        static long SearchObject(int value)
        {
            return value * value;
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Задание 1:");
            Thread yep1 = new Thread(new ThreadStart(PrintNum));
            Thread yep2 = new Thread(new ThreadStart(PrintNum));
            Thread yep3 = new Thread(new ThreadStart(PrintNum));

            yep1.Start();
            yep2.Start();
            yep3.Start();

            yep1.Join();
            yep2.Join();
            yep3.Join();

            Console.WriteLine("\nЗадание 2:");
            Console.WriteLine("Введите число: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                Task<long> factorial = PrintFact(value);
                long square = SearchObject(value);
                Console.WriteLine("Подождите...\nОперации выполняются...");
                long factorialResult = await factorial;
                Console.WriteLine($"Квадрат числа: {square}");
                Console.WriteLine($"Факториал числа: {factorialResult}");
            }
            else
                Console.WriteLine("Введите число!");

            Console.WriteLine("\nЗадание 3");
            Refl reflInstance = new Refl();

            string[] methodNames = GetMethodNames(reflInstance);
            foreach (var methodName in methodNames)
            {
                Console.WriteLine(methodName);
            }
        }
        public static string[] GetMethodNames(object obj)
        {
            Type type = obj.GetType();
            MethodInfo[] methods = type.GetMethods();
            string[] methodNames = new string[methods.Length];

            for (int i = 0; i < methods.Length; i++)
            {
                methodNames[i] = methods[i].Name;
            }

            return methodNames;
        }
    }


}
