using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximPractice3course
{
    public static class Methods
    {
        // Поиск по периметру
        public static List<Driver> Method1(Driver[] drivers, int orderX, int orderY, int N, int M)
        {
            List<Driver> result = new List<Driver>();

            foreach (var d in drivers)
            {
                if (d.X == orderX && d.Y == orderY)
                {
                    result.Add(d);
                    break;
                }
            }
            int radius = 1;
            while (result.Count < 5 && result.Count < drivers.Length)
            {

                for (int dx = -radius; dx <= radius; dx++)
                {
                    for (int dy = -radius; dy <= radius; dy++)
                    {
                        if (dx == 0 && dy == 0)
                            continue;
                        if (Math.Abs(dx) != radius && Math.Abs(dy) != radius)
                            continue;
                        int nx = orderX + dx;
                        int ny = orderY + dy;
                        if ((nx < 0 || nx >= N) || (ny < 0 || ny >= M))
                            continue;

                        foreach (var d in drivers)
                        {
                            if (d.X == nx && d.Y == ny)
                            {
                                result.Add(d);
                                break;
                            }
                        }
                        if (result.Count >= 5)
                            break;
                    }
                }
                radius++;
            }

            return result;
        }

        // Сравнение дистанций всех водителей
        public static List<Driver> Method2(Driver[] drivers, int orderX, int orderY)
        {
            List<(Driver driver, int dist)> distances = new List<(Driver driver, int dist)>();
            List<Driver> result = new List<Driver>();

            foreach (var d in drivers)
            {
                int dx = Math.Abs(orderX - d.X);
                int dy = Math.Abs(orderY - d.Y);
                int dist = dx + dy;
                distances.Add((d, dist));
            }
            distances.Sort((a, b) => a.dist.CompareTo(b.dist));

            int driver_count = Math.Min(5, distances.Count);

            for (int i = 0; i < driver_count; i++)
            {
                result.Add(distances[i].driver);
            }
            return result;
        }

        // Использование  кучи из 5 ближайших водителей
        public static List<Driver> Method3(Driver[] drivers, int orderX, int orderY)
        {
            List<(int dist, Driver driver)> heap = new List<(int dist, Driver driver)>();
            List<Driver> result = new List<Driver>();

            void HeapAdd((int dist, Driver driver) item)
            {
                heap.Add(item);
                int i = heap.Count - 1;
                while (i > 0)
                {
                    int parent = (i - 1) / 2;
                    if (heap[parent].dist >= heap[i].dist)
                        break;
                    (heap[parent], heap[i]) = (heap[i], heap[parent]);
                    i = parent;
                }
            }
            void HeapPop()
            {
                int last = heap.Count - 1;
                heap[0] = heap[last];
                heap.RemoveAt(last);

                int i = 0;
                while (true)
                {
                    int left = 2 * i + 1;
                    int right = 2 * i + 2;
                    int largest = i;

                    if (left < heap.Count && heap[left].dist > heap[largest].dist)
                        largest = left;
                    if (right < heap.Count && heap[right].dist > heap[largest].dist)
                        largest = right;

                    if (largest == i)
                        break;
                    (heap[i], heap[largest]) = (heap[largest], heap[i]);
                    i = largest;
                }

            }
            foreach (var d in drivers)
            {
                int dx = Math.Abs(orderX - d.X);
                int dy = Math.Abs(orderY - d.Y);
                int dist = dx + dy;

                HeapAdd((dist, d));
                if (heap.Count > 5)
                    HeapPop();

            }
            foreach (var d in heap)
            {
                result.Add(d.driver);
            }
            return result;
        }
    }
}
