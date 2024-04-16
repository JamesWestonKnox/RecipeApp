using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Recipe
    {
        public static string ingrName;
        public static string ingrUnitMeasurement;
        public static int numIngredients;
        public static int numSteps;
        public static List<double> ingrQty = new List<double>();
        public static List<double> originalQty = new List<double>();
        public static List<string> stepDescription = new List<String>();
        public static Dictionary<string, string> ingredientsDictionary = new Dictionary<string, string>();

        public static void InputRecipe()
        {
            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Enter new recipe details");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Please enter the number of ingredients needed:");
            numIngredients = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < numIngredients; i++) 
            {
                Console.Clear();
                Console.WriteLine("*************************RECIPE APP**************************");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Enter new recipe details");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Please enter ingredient name:");
                ingrName = Console.ReadLine();
                Console.WriteLine("Please enter ingredient quantity:");
                ingrQty.Add(int.Parse(Console.ReadLine()));
                Console.WriteLine("Please enter ingredient unit measurement:");
                ingrUnitMeasurement = Console.ReadLine();
                ingredientsDictionary.Add(ingrName, ingrUnitMeasurement);
            }
            for (int i = 0; i < ingrQty.Count(); i++)
            {
                originalQty.Add(ingrQty[i]);
            }

            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Enter new recipe details");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Please enter number of steps");
            numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++) 
            {
                Console.Clear();
                Console.WriteLine("*************************RECIPE APP**************************");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Enter new recipe details");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Please enter step description");
                stepDescription.Add(Console.ReadLine());
            }
            
        }

        public static void DisplayRecipe()
        {
            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Saved Recipe");
            Console.WriteLine("-------------------------------------------------------------");

            if (numIngredients != 0)
            {
                Console.WriteLine("Ingredients");
                Console.WriteLine("-------------------------------------------------------------");

                int i = 0;
                foreach (KeyValuePair<string, string> keyValuePair in ingredientsDictionary)
                {
                    Console.WriteLine("Ingredient {0}: " + ingrQty[i] + " " + keyValuePair.Value + " of " + keyValuePair.Key, i+1);
                    i++;
                }

                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Steps");
                Console.WriteLine("-------------------------------------------------------------");
                
                int j = 0;
                foreach(string step in stepDescription)
                {
                    Console.WriteLine("Step {0}: " + stepDescription[j], j+1);
                    j++;
                }

                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No recipe stored");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
            }
        }

        public static void ScaleRecipe()
        {
            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Recipe Scaling");
            Console.WriteLine("-------------------------------------------------------------");

            if (numIngredients != 0)
            {

                Console.WriteLine("Please choose a scaling amount");
                Console.WriteLine("1 -- 0.5 (Half)");
                Console.WriteLine("2 -- 2 (Double)");
                Console.WriteLine("3 -- 3 (Triple)");

                int scalingChoice = int.Parse(Console.ReadLine());

                if (scalingChoice == 1)
                {
                    for (int i = 0; i < numIngredients; i++)
                    {
                        ingrQty[i] = ingrQty[i] * 0.5;
                    }
                    Console.WriteLine("Recipe quantites have been halved");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadKey();
                }
                else if (scalingChoice == 2)
                {
                    for (int i = 0; i < numIngredients; i++)
                    {
                        ingrQty[i] = ingrQty[i] * 2;
                    }
                    Console.WriteLine("Recipe quantites have been doubled");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadKey();
                }
                else if (scalingChoice == 3)
                {
                    for (int i = 0; i < numIngredients; i++)
                    {
                        ingrQty[i] = ingrQty[i] * 3;
                    }
                    Console.WriteLine("Recipe quantites have been tripled");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No recipe stored");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
            }
        }

        public static void ResetRecipeScale()
        {
            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Recipe reset");
            Console.WriteLine("-------------------------------------------------------------");

            if (numIngredients != 0)
            {
                for (int i = 0; i < ingrQty.Count(); i++)
                {
                    ingrQty[i] = originalQty[i];
                }

                Console.WriteLine("Recipe quantities have been reset to orginal values");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No recipe stored");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
            }
        }

        public static void ClearRecipe()
        {
            numIngredients = 0;
            ingredientsDictionary.Clear();
            ingrQty.Clear();
            stepDescription.Clear();
            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Delete recipe");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Recipe has been deleted");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
        }
    }
}
