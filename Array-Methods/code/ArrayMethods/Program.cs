using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayMethods {
    class FruitsAndVegs {
        public String Type { get; set; }
        public String Color { get; set; }
        public String Name { get; set; }
    };

    public class Program {
        static void Main(String[] args) {
            var data = new List<FruitsAndVegs> {
                new FruitsAndVegs { Type = "Fruit", Color = "Red", Name = "Red Apples" },
                new FruitsAndVegs { Type = "Fruit", Color = "Red", Name = "Blood Oranges" },
                new FruitsAndVegs { Type = "Vegetables", Color = "Red", Name = "Beets" },
                new FruitsAndVegs { Type = "Vegetables", Color = "Red", Name = "Red Peppers" },
                new FruitsAndVegs { Type = "Fruit", Color = "Yellow/Orange", Name = "Yellow Apples" },
                new FruitsAndVegs { Type = "Fruit", Color = "Yellow/Orange", Name = "Apricots" },
                new FruitsAndVegs { Type = "Vegetables", Color = "Yellow/Orange", Name = "Yellow Apples" },
                new FruitsAndVegs { Type = "Vegetables", Color = "Yellow/Orange", Name = "Apricots" },
                new FruitsAndVegs { Type = "Fruit", Color = "Blue/Purple", Name = "Blackberries" },
                new FruitsAndVegs { Type = "Fruit", Color = "Blue/Purple", Name = "Blueberries" },
                new FruitsAndVegs { Type = "Vegetables", Color = "Blue/Purple", Name = "Black Olives" },
                new FruitsAndVegs { Type = "Vegetables", Color = "Blue/Purple", Name = "Purple Asparagus" },
                new FruitsAndVegs { Type = "Fruit", Color = "White/Tan/Brown", Name = "Bananas" },
                new FruitsAndVegs { Type = "Fruit", Color = "White/Tan/Brown", Name = "Dates" },
                new FruitsAndVegs { Type = "Vegetables", Color = "White/Tan/Brown", Name = "Cauliflower" },
                new FruitsAndVegs { Type = "Vegetables", Color = "White/Tan/Brown", Name = "Garlic" },
                new FruitsAndVegs { Type = "Fruit", Color = "Green", Name = "Avocados" },
                new FruitsAndVegs { Type = "Fruit", Color = "Green", Name = "Green Apples" },
                new FruitsAndVegs { Type = "Vegetables", Color = "Green", Name = "Artichokes" },
                new FruitsAndVegs { Type = "Vegetables", Color = "Green", Name = "Arugula" }
            };

            Console.Title = "Array Methods";

            /* .:: ForEach ::. */
            Console.WriteLine(".:: ForEach ::.");
            Console.WriteLine("---------------");

            data.ForEach(item => Console.WriteLine(item));

            Console.WriteLine();

            /* .:: Map ::. */
            Console.WriteLine(".:: Map ::.");
            Console.WriteLine("-----------");

            data
                .Select(fruit => fruit.Name)
                .ToList()
                .ForEach(name => Console.WriteLine(name));

            Console.WriteLine();

            /* .:: Filter ::. */
            Console.WriteLine(".:: Filter ::.");
            Console.WriteLine("--------------");

            Console.WriteLine("Just fruits:");
            Console.WriteLine("------------");

            data
                .Where(item => item.Type == "Fruit")
                .Select(fruit => fruit.Name)
                .ToList()
                .ForEach(name => Console.WriteLine(name));

            Console.WriteLine();

            Console.WriteLine("Just green fruits:");
            Console.WriteLine("------------------");

            data
                .Where(item => item.Type == "Fruit" && item.Color == "Green")
                .Select(fruit => fruit.Name)
                .ToList()
                .ForEach(name => Console.WriteLine(name));

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}