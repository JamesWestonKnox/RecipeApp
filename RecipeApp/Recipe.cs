using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Recipe
    {
        public static string ingrName;
        public static string ingrUnitMeasurement;
        public static List<double> ingrQtyList = new List<double>();
        public static List<string> stepDescription = new List<String>();
        public static Dictionary<string, string> ingredientsDictionary = new Dictionary<string, string>();

        public static void InputRecipe()
        { 
            Console.WriteLine("****************RECIPE APP*****************");
            Console.WriteLine("Enter new recipe details");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Please enter the number of ingredients needed:");
            int numIngredients = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < numIngredients; i++) 
            {
                Console.Clear();
                Console.WriteLine("Please enter ingredient name:");
                ingrName = Console.ReadLine();
                Console.WriteLine("Please enter ingredient quantity:");
                ingrQtyList.Add(int.Parse(Console.ReadLine()));
                Console.WriteLine("Please enter ingredient unit measurement:");
                ingrUnitMeasurement = Console.ReadLine();
                ingredientsDictionary.Add(ingrName, ingrUnitMeasurement);
            }

            Console.WriteLine("Please enter number of steps");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++) 
            {
                Console.Clear();
                Console.WriteLine("Please enter step description");
                stepDescription.Add(Console.ReadLine());
            }
            
        }
    }
}
