/*
using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MaximPractice3course
{
    [MemoryDiagnoser]
    [RankColumn]
    public class Benchmarks
    {
        [Params(10, 100, 1000)]
        public int drivers_count;

        private Driver[] drivers;
        private int orderX, orderY;
        private int N = 100, M = 100;
        private Random rand = new Random();

        [GlobalSetup]
        public void Setup()
        {
            drivers = new Driver[drivers_count];

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
            orderX = order_point[0];
            orderY = order_point[1];
            Console.WriteLine($"Точка заказа: X - {orderX}, Y - {orderY}");
        }
        [Benchmark(Baseline = true)]
        public void Method1_Bench()
        {
            Methods.Method1(drivers, orderX, orderY, N, M);
        }
        [Benchmark]
        public void Method2_Bench()
        {
            Methods.Method2(drivers, orderX, orderY);
        }
        [Benchmark]
        public void Method3_Bench()
        {
            Methods.Method3(drivers, orderX, orderY);
        }
    }
    class BenchmarkRunnerProgram
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
*/