using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Practicadz
{
    internal class Program
    {
        static void ConclusionNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
                Thread.Sleep(100);
            }
        }

        static int SquareCalculation(int num)
        {
            return (num * num);
        }

        static int FactorialCalculation(int num)
        {
            if (num == 1)
            {
                return 1;
            }

            return num * FactorialCalculation(num - 1);
        }

        static async Task<int>AsyncFactorialCalculation(int num)
        {
            int factorial = await Task.Run(() => FactorialCalculation(num));
            Console.WriteLine("\nДелаем небольшую задержку на 8 секунд и...");
            Thread.Sleep(8000);

            return factorial;
        }
        static async Task Main(string[] args)
        {
            //УПРАЖНЕНИЕ 1.
            Console.WriteLine("УПРАЖНЕНИЕ 1.\n");
     
            Thread Thread1 = new Thread(ConclusionNumbers);
            Thread Thread2 = new Thread(ConclusionNumbers);
            Thread Thread3 = new Thread(ConclusionNumbers);

            Thread1.Start();
            Thread2.Start();
            Thread3.Start();
            
            Thread1.Join();
            Thread2.Join();
            Thread3.Join();


            //УПРАЖНЕНИЕ 2.
            Console.WriteLine("\nУПРАЖНЕНИЕ 2.\n");

            int a = 3;

            int square = SquareCalculation(a);
            Console.WriteLine($"Возведение в квадрат числа {a}: {a}^2 = {square}");

            int factorial = await AsyncFactorialCalculation(a);
            Console.WriteLine($"Факториал числа {a}: {a}! = {factorial}");

            
            //УПРАЖНЕНИЕ 3.
            Console.WriteLine("УПРАЖНЕНИЕ 3.\n");

            Refl Object = new Refl();

            Type myType = Object.GetType();
            MethodInfo[] methods = myType.GetMethods();

            Console.WriteLine("Методы:");

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}
