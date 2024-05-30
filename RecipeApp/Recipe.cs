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
   /// Recipe class
   /// </summary>
    public class Recipe
    {
        public string recipeName { get; set; }
        public Dictionary<string, List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>> ingredients { get; set; } = new Dictionary<string, List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>>();
        public List<string> steps { get; set; } = new List<string>();
        public Dictionary<string, List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>> originalIngredientsQty { get; set; } = new Dictionary<string, List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>>();

        public delegate void HighCalorieContent (string message);
        public event HighCalorieContent HighCalorieContentWarning;

        public Recipe() { }

        public Recipe(string recipeName)
        {
            this.recipeName = recipeName;
        }
       
        /// <summary>
        /// Method to input ingrendients into the ingredients dictionary in a new recipe object,using values inputted through InputRecipe method in menu.cs
        /// </summary>
        /// <param name="ingrName"></param>
        /// <param name="ingrQty"></param>
        /// <param name="ingrUnit"></param>
        /// <param name="ingrCalories"></param>
        /// <param name="ingrFoodGroup"></param>
        public void InputIngredient(string ingrName, double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)
        {
            if (ingredients.ContainsKey(ingrName))
            {
                Console.WriteLine("Ingredient already added to recipe.");
            }
            else
            {
                ingredients[ingrName] = new List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>();
                originalIngredientsQty[ingrName] = new List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>();
            }

            ingredients[ingrName].Add((ingrQty, ingrUnit, ingrCalories, ingrFoodGroup));
            originalIngredientsQty[ingrName].Add((ingrQty, ingrUnit, ingrCalories, ingrFoodGroup));
        }

        /// <summary>
        /// Method to add a step to the step list in the recipe object
        /// </summary>
        /// <param name="step"></param>
        public void InputStep(string step)
        {
            steps.Add(step);
        }

        /// <summary>
        /// Method to display all recipe details of a specific recipe
        /// </summary>
        public void DisplayRecipe()
        {
            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"Recipe: {recipeName}");
            Console.WriteLine();
            Console.WriteLine("Ingredients:");
            Console.WriteLine();
            foreach (var ingredient in ingredients)
            {
                foreach (var (ingrQty, ingrUnit, ingrCalories, ingrFoodGroup) in ingredient.Value)
                {
                    Console.WriteLine($"{ingrQty} {ingrUnit} of {ingredient.Key}");
                    Console.WriteLine($"Calories: {ingrCalories}");
                    Console.WriteLine($"Food type: {ingrFoodGroup}");
                    Console.WriteLine();
                }
            }

            double totalCalories = CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");
            Console.WriteLine();
            
            if (totalCalories > 300)
            {
                HighCalorieContentWarning?.Invoke("Warning: Total calories exceed 300!");
                Console.WriteLine();
            }

            Console.WriteLine("Steps:");
            Console.WriteLine();

            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"Step {i + 1}: {steps[i]}");
            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
        }

        /// <summary>
        /// Method to scale recipe ingrdients according to the user choice in the ScaleRecipes method in Menu.cs
        /// </summary>
        /// <param name="scalingValue"></param>
        public void ScaleRecipe(double scalingValue)
        {
            foreach (var ingredient in ingredients.Keys.ToList())
            {
                var scaledIngredients = new List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>();
                foreach (var (ingrQty, ingrUnit, ingrCalories, ingrFoodGroup) in ingredients[ingredient])
                {
                    scaledIngredients.Add((ingrQty * scalingValue, ingrUnit, ingrCalories * scalingValue, ingrFoodGroup));
                }
                ingredients[ingredient] = scaledIngredients;
            }
        }

        /// <summary>
        /// Method to reset recipe ingredients back to default by setting the ingredient list to the original list
        /// </summary>
        public void ResetRecipe()
        {
            foreach (var ingredient in ingredients.Keys.ToList())
            {
                ingredients[ingredient] = new List<(double ingrQty, string ingrUnit, double ingrCalories, string ingrFoodGroup)>(originalIngredientsQty[ingredient]);
            }
        }

        /// <summary>
        /// Method that loops through each ingredient in the ingredients dictionary and adds its ingrCalories to a total calorie double.
        /// </summary>
        /// <returns></returns>
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients.Values)
            {
                foreach (var (ingrQty, ingrUnit, ingrCalories, ingrFoodGroup) in ingredient)
                {
                    totalCalories = totalCalories + ingrCalories;
                }
            }
            return totalCalories;
        }
    }
}

//--------------------------------------------------------------- oooooo000000000 end of file 000000000oooooo ---------------------------------------------------------------\\