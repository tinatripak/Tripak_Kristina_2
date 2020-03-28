using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31laba._1
{
    /*
     Шеф повар. Визначити ієрархію овочів. Зробити салат. Підрахувати калорійність.
     Провести сортування овочів для салату на основі одного з параметрів. Знайти 
     овочі в салаті, відповідні заданому діапазону калорійності.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Vegetables avocado = new Vegetables("Avocados", 160, 100, 2, 14.66, 1.83);
            Vegetables cucumber = new Vegetables("Cucumbers", 15, 100, 0.7, 0.1, 3.0);
            Vegetables greens = new Vegetables("Greens", 12, 100, 1.2, 0.3, 1.3);
            Vegetables spinach = new Vegetables("Spinach", 17, 100, 2.7, 0.4, 0.8);
            Vegetables tomato = new Vegetables("Tomatos", 19, 100, 0.8, 0.3, 3.5);
            Chef salad = new Chef(avocado, cucumber, greens, spinach, tomato);
            salad.Hierarchy();
            salad.MixSalat();
            salad.SumKkal();
            salad.SortProteins();
            salad.ShowList();
            salad.FindByCalories();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
    class Vegetables
    {
        public string name;
        public int calories;
        public int grams;
        public double proteins;
        public double fats;
        public double carbohydrates;
        public Vegetables(string Name, int Calories, int Grams, double Proteins, double Fats, double Carbohydrates)
        {
            this.name = Name;
            this.calories = Calories;
            this.grams = Grams;
            this.proteins = Proteins;
            this.fats = Fats;
            this.carbohydrates = Carbohydrates;
        }
    }
    class Chef
    {
        public List<Vegetables> ListOfVegetables = new List<Vegetables>();
        public Chef(params Vegetables[] elements)
        {
            foreach (var n in elements)
            {
                AddNode(n);
            }
        }
        public void AddNode(Vegetables vegetables)
        {
            ListOfVegetables.Add(vegetables);
        }
        public void ShowList()
        {
            string name = "Name", calories = "Calories (kkal)", grams = "Grams", proteins = "Proteins (g)", fats = "Fats (g)", carbohydrates = "Carbohydrates (g)";
            Console.WriteLine($"{name,25}{calories,30}{grams,30}{proteins,30}{fats,30} {carbohydrates,30}");
            foreach (var n in ListOfVegetables)
            {
                Console.WriteLine($"{n.name,25}   |   {n.calories,25}   |   {n.grams,25}   |   {n.proteins,25}   |   {n.fats,25}   |   {n.carbohydrates,25}");
            }
        }
        public void Hierarchy()
        {
            Console.WriteLine(new string('-', 200));
            Console.WriteLine("Hierarchy of vegetables : ");
            Console.WriteLine();
            foreach (var n in ListOfVegetables)
            {
                List<string> hierarchy = new List<string>() { n.name };
                for (int i = 0; i < hierarchy.Count; i++)
                {
                    Console.WriteLine(" - " + hierarchy[i]);
                }
            }
        }
        public void MixSalat ()
        {
            Console.WriteLine(new string('-', 200));
            Console.WriteLine("Cook a salat of vegetables : ");
            Console.WriteLine();
            foreach (var n in ListOfVegetables)
            {
                List<string> hierarchy = new List<string>() { n.name };
                for (int i = 0; i < hierarchy.Count; i++)
                {
                    Console.WriteLine(hierarchy[i] + " : mash and put in a bowl");
                }
            }
        }
        public void SumKkal()
        {
            Console.WriteLine(new string('-', 200));
            int sum = 0;
            foreach (var n in ListOfVegetables)
            {
                sum += n.calories;
            }
            Console.WriteLine("Sum of kkal in our salat is : " + sum);
        }
        public void SortProteins()
        {
            Console.WriteLine(new string('-', 200));
            for (int i = 0; i < ListOfVegetables.Count; i++)
            {
                for (int j = i + 1; j < ListOfVegetables.Count; j++)
                {
                    if (ListOfVegetables[i].calories > ListOfVegetables[j].calories)
                    {
                        var temp = ListOfVegetables[i];
                        ListOfVegetables[i] = ListOfVegetables[j];
                        ListOfVegetables[j] = temp;
                    }
                }
            }
        }
        public void FindByCalories()
        {
            Console.WriteLine(new string('-', 200));
            Console.WriteLine("The name of the vegetable, the calories of which is in the range from 15 to 19 is : ");
            foreach (var n in ListOfVegetables)
            {
                if(n.calories>=15 && n.calories<=19)
                {
                    Console.WriteLine(" - " + n.name);
                }
            }
        }
    }
}
