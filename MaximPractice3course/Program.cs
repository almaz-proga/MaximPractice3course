
using System;

namespace MaximPractice3course
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность сетки N: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Введите размерность сетки M: ");
            int M = int.Parse(Console.ReadLine());

            Console.Write("Введите кол-во таксистов на сетке: ");
            int drivers_count = int.Parse(Console.ReadLine());
            while (drivers_count < 0 || drivers_count > N * M)
            {
                Console.WriteLine("Вы ввели некорректные данные!");
                Console.Write("Введите кол-во таксистов на сетке: ");
                drivers_count = int.Parse(Console.ReadLine());
            }
            Driver[] drivers = new Driver[drivers_count];
            Random rand = new Random();
            int id = 1;
            HashSet<string> used_positions = new HashSet<string>();
            for (int i = 0; i < drivers_count; i++)
            {
                int x, y;
                string key;
                do
                {
                    x = rand.Next(0, N);
                    y = rand.Next(0, M);
                    key = $"{x}-{y}";
                }
                while (used_positions.Contains(key));
                used_positions.Add(key);

                drivers[i] = new Driver(id, x, y);
                id++;
            }
            int[] order_point = { rand.Next(0, N), rand.Next(0, M) };
            int orderX = order_point[0];
            int orderY = order_point[1];
            Console.WriteLine($"Точка заказа: X - {orderX}, Y - {orderY}");
            List<Driver> found1 = Methods.Method1(drivers, orderX, orderY, N, M);

            Console.WriteLine($"Ближайшие {found1.Count} водителей по 1 методу: ");
            foreach (var d in found1)
            {
                d.ShowInfo();
            }
            Console.WriteLine("Остальные водители: ");
            foreach (var d in drivers)
            {
                if (!found1.Contains(d))
                {
                    d.ShowInfo();
                }
            }
            Console.WriteLine();
            List<Driver> found2 = Methods.Method2(drivers, orderX, orderY);
            Console.WriteLine($"Ближайшие {found2.Count} водителей по 2 методу: ");
            foreach (var d in found2)
            {
                d.ShowInfo();
            }

            Console.WriteLine("Остальные водители: ");
            foreach (var d in drivers)
            {
                if (!found2.Contains(d))
                {
                    d.ShowInfo();
                }
            }
            Console.WriteLine();
            List<Driver> found3 = Methods.Method3(drivers, orderX, orderY);
            Console.WriteLine($"Ближайшие {found3.Count} водителей по 3 методу: ");
            foreach (var d in found3)
            {
                d.ShowInfo();
            }

            Console.WriteLine("Остальные водители: ");
            foreach (var d in drivers)
            {
                if (!found3.Contains(d))
                {
                    d.ShowInfo();
                }
            }
        }
    }
}
