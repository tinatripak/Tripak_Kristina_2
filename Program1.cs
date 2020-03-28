using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31laba._2
{
    /*
     * Створити об'єкт класу Чашка, використовуючи клас Кришка, Корпус.
     * Методи: Відкрити, закрити, заповнити, вилити вміст, виводити  на екран рівень заповненості чашки.
     */
    class Program
    {
        static void Main(string[] args)
        {
            string Name = "";
            Cap cap = new Cap(Name);
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("Do you want to close or open?");
            Console.WriteLine("1. Close");
            Console.WriteLine("2. Open");
            int n = int.Parse(Console.ReadLine());
            if (n == 1) cap.Close();
            if (n == 2) cap.Open();
            Console.WriteLine(new string('-', 80));
            Body body = new Body(Name);
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("Do you want to fill or pour?");
            Console.WriteLine("1. Fill");
            Console.WriteLine("2. Pour");
            int m = int.Parse(Console.ReadLine());
            if (m == 1)
            {
                body.Filling();
                Console.WriteLine(new string('-', 80));
                Cup cup = new Cup(Name);
                cup.AmountOfWater();
            }
            if (m == 2) body.Pour();
        }
        public class Cup
        {
            public string name;
            public Cap cap;
            public Body body;
            public Cup(string Name)
            {
                this.name = Name;
            }
            public void CreateACup()
            {
                this.cap = new Cap(name);
                this.body = new Body(name);
            }
            public void ConnectCap(object o)
            {
                Console.WriteLine($"The cap is a part of the cup{o}");
            }
            public void ConnectBody(object o)
            {
                Console.WriteLine($"The body is a part of the cup{o}");
            }
            public void AmountOfWater()
            {
                Console.WriteLine("Do you want to add some water or not?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.WriteLine(new string('-', 80));
                int n = int.Parse(Console.ReadLine());
                if(n==2)
                {
                    Console.WriteLine("There is no water in the cup");
                }
                if (n == 1)
                {
                    Console.WriteLine("How much do you want to add wate (from 0 to 1) : ");
                    double water = double.Parse(Console.ReadLine());
                    if(water>0 && water<1)
                        Console.WriteLine("The cup is "+ water +" full");
                    if(water == 1)
                        Console.WriteLine("The cup is full");
                }
            }
        }
        public class Cap : Cup
        {
            public Cap(string name) : base(name)
            {
                ConnectCap(name);
            }
            public void Close()
            {
                Console.WriteLine("Lower the cap and the cup is closed");
            }
            public void Open()
            {
                Console.WriteLine("Lift the cap and the cup is open");
            }
        }
        public class Body : Cup
        {
            public Body(string name) : base(name)
            {
                ConnectBody(name);
            }
            public void Filling()
            {
                Console.WriteLine("Fill the cup with water");
            }
            public void Pour()
            {
                Console.WriteLine("Pour water from a mug");
            }
        }
    }
}
