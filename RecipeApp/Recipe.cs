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

        //Method to prompt user for recipe input and populates arrays
        public static void InputRecipe()
        {
            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Enter new recipe details");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Please enter the number of ingredients needed:");

            //while loop and try-catch block checking that user inputs an interger
            bool correctInput = false;
            while (!correctInput)
            {
                try
                {
                    numIngredients = int.Parse(Console.ReadLine());
                    correctInput = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input was not in correct format.");
                    Console.WriteLine("Please enter a number.");
                }
            }
            
            //for-loop that populates ingredients according to number of ingredients entered by user
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

                correctInput = false;
                while (!correctInput)
                {
                    try
                    {
                        ingrQty.Add(int.Parse(Console.ReadLine()));
                        correctInput = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Input was not in correct format.");
                        Console.WriteLine("Please enter a number.");
                    }
                }

                Console.WriteLine("Please enter ingredient unit measurement:");
                ingrUnitMeasurement = Console.ReadLine();
                ingredientsDictionary.Add(ingrName, ingrUnitMeasurement);
            }

            //for-loop that populates new list according to the number of elements in ingrQty 
            for (int i = 0; i < ingrQty.Count(); i++)
            {
                //List that can be reverted to should the user choose to reset recipe
                originalQty.Add(ingrQty[i]);
            }

            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Enter new recipe details");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Please enter number of steps");

            correctInput = false;
            while (!correctInput)
            {
                try
                {
                    numSteps = int.Parse(Console.ReadLine());
                    correctInput = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input was not in correct format.");
                    Console.WriteLine("Please enter a number.");
                }
            }

            //for-loop that populates steps array
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

        //Display Recipe method that displays all recipe information, if no recipe has been saved it will display a message.
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

                //for-each loop printing ingredient details for every ingredient in the ingredientsDictionary
                int i = 0;
                foreach (KeyValuePair<string, string> keyValuePair in ingredientsDictionary)
                {
                    Console.WriteLine("Ingredient {0}: " + ingrQty[i] + " " + keyValuePair.Value + " of " + keyValuePair.Key, i+1);
                    i++;
                }

                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Steps");
                Console.WriteLine("-------------------------------------------------------------");
                
                //for-each loop printing step details for each step in stepDescription list
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

        //Scale recipe method to allow user to change recipe quantities
        public static void ScaleRecipe()
        {
            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Recipe Scaling");
            Console.WriteLine("-------------------------------------------------------------");

            //if statement that displays scaling menu as long as a recipe is stored
            if (numIngredients != 0)
            {
                int scalingChoice = 0;
                Console.WriteLine("Please choose a scaling amount");
                Console.WriteLine("1 -- 0.5 (Half)");
                Console.WriteLine("2 -- 2 (Double)");
                Console.WriteLine("3 -- 3 (Triple)");

                bool correctInput = false;

                while (!correctInput)
                {
                    try
                    {
                        scalingChoice = int.Parse(Console.ReadLine());
                        if (scalingChoice >= 1 && scalingChoice <= 3)
                        {
                            correctInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Please choose a number between 1 and 3.");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Input was not in correct format.");
                        Console.WriteLine("Please choose a number between 1 and 3.");
                    }
                }


                //if-else statment that adjust quantites according to the user choice otherwise displays no recipe message
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

        //reset recipe method that resets recipe values to original
        public static void ResetRecipeScale()
        {
            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Recipe reset");
            Console.WriteLine("-------------------------------------------------------------");

            if (numIngredients != 0)
            {
                //for loop changing list values back to orignal values using the orginalQty list created earlier
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

        //clear recipe method that clears all lists and dictionarys and sets numIngredients to 0
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

//--------------------------------------------------------------- oooooo000000000 end of file 000000000oooooo ---------------------------------------------------------------\\