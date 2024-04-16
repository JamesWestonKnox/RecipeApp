using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Menu
    {
        Recipe myRecipe = new Recipe();
        public static void AppMenu()
        {
            int userChoice = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("*************************RECIPE APP**************************");
                Console.WriteLine("Please enter the number of your choice");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("1 -- Add a new recipe");
                Console.WriteLine("2 -- Display recipe");
                Console.WriteLine("3 -- Scale recipe");
                Console.WriteLine("4 -- Reset recipe scaling");
                Console.WriteLine("5 -- Clear Recipe data");
                Console.WriteLine("6 -- Exit application");


                bool correctInput = false;
                while (!correctInput)
                {
                    try
                    {
                        userChoice = int.Parse(Console.ReadLine());
                        if (userChoice >= 1 && userChoice <= 6)
                        {
                            correctInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Please choose a number between 1 and 6.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Incorrect Input Format. Please choose a number between 1 and 6.");
                    }
                }
                switch (userChoice)
                {
                    case 1:
                        Recipe.InputRecipe();
                        break;

                    case 2:
                        Recipe.DisplayRecipe();
                        break;

                    case 3:
                        Recipe.ScaleRecipe();
                        break;

                    case 4:
                        Recipe.ResetRecipeScale();
                        break;
                    case 5:
                        Recipe.ClearRecipe();
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
            while (userChoice != 6);         
        }
    }
}