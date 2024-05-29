using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    /// <summary>
    /// </summary>
    internal class Recipe
    {
        public string recipeName { get; set; }
        public Dictionary<string, List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>> ingredients { get; set; } = new Dictionary<string, List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>>();
        public List<string> steps { get; set; } = new List<string>();
        public Dictionary<string, List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>> originalIngredientsQty { get; set; } = new Dictionary<string, List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>>();

        public Recipe() { }

        public Recipe(string recipeName)
        {
            this.recipeName = recipeName;
        }

        public void InputIngredient(string ingrName, double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)
        {
            if (ingredients.ContainsKey(ingrName))
            {

            }
            else
            {
                ingredients[ingrName] = new List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>();
                originalIngredientsQty[ingrName] = new List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>();
            }

            ingredients[ingrName].Add((ingrQty, ingrUnit, ingrCalories, ingrFoodGroup));
            originalIngredientsQty[ingrName].Add((ingrQty, ingrUnit, ingrCalories, ingrFoodGroup));
        }

        public void InputStep(string step)
        {
            steps.Add(step);
        }

        public void DisplayRecipe()
        {
            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"Recipe: {recipeName}");
            Console.WriteLine("-------------------------------------------------------------");

            Console.WriteLine("Ingredients:");
            Console.WriteLine("-------------------------------------------------------------");
            foreach (var ingredient in ingredients)
            {
                foreach (var (ingrQty, ingrUnit, ingrCalories, ingrFoodGroup) in ingredient.Value)
                {
                    Console.WriteLine($"{ingrQty} {ingrUnit} of {ingredient.Key}");
                    Console.WriteLine($"Calories: {ingrCalories}");
                    Console.WriteLine($"Food type: {ingrFoodGroup}");
                    Console.WriteLine("-------------------------------------------------------------");
                }
            }

            Console.WriteLine("Steps:");
            Console.WriteLine("-------------------------------------------------------------");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"Step {i + 1}: {steps[i]}");
            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
        }
    }
}

//--------------------------------------------------------------- oooooo000000000 end of file 000000000oooooo ---------------------------------------------------------------\\