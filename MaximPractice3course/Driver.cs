using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximPractice3course
{
    public class Driver
    {
        public int Id;
        public int X;
        public int Y;
        public Driver(int Id, int X, int Y)
        {
            this.Id = Id;
            this.X = X;
            this.Y = Y;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Таксист номер {Id}: X - {X}, Y - {Y}");
        }
    }
}
