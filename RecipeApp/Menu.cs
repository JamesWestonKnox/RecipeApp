using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Menu
    {
        //Declaring List of recipes.
        private static List<Recipe> Recipes = new List<Recipe>();

        //app menu method which displays user menu
        public static void AppMenu()
        {
            
            int userChoice = 0;

            //do-while loop that display the user menu as long as the user does not select number 6 to exit
            do
            {
                //clears console and prints user menu
                Console.Clear();
                Console.WriteLine("*************************RECIPE APP**************************");
                Console.WriteLine("Please enter the number of your choice");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("1 -- Add a new recipe");
                Console.WriteLine("2 -- Display recipes");
                Console.WriteLine("3 -- Scale recipe");
                Console.WriteLine("4 -- Reset recipe scaling");
                Console.WriteLine("5 -- Clear Recipe data");
                Console.WriteLine("6 -- Exit application");

                //while loop containing a try-catch block which checks for format errors in the user choice
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
                    catch (FormatException e)
                    {
                        Console.WriteLine("Input was not in correct format.");
                        Console.WriteLine("Please choose a number between 1 and 6.");
                    }
                }

                //switch case which calls different methods depending on user choice
                switch (userChoice)
                {
                    case 1:
                        InputRecipe();
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
            while (userChoice != 6);         
        }

        public static void InputRecipe() 
        {
            Recipe newRecipe = new Recipe();

            Console.Clear();
            Console.WriteLine("*************************RECIPE APP**************************");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Enter new recipe details");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Please enter recipe name:");
            newRecipe.recipeName = Console.ReadLine();


            Console.WriteLine("Please enter the number of ingredients needed:");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Clear();
                Console.WriteLine($"Enter ingredient {i + 1} name:");
                string ingrName = Console.ReadLine();

                Console.WriteLine($"Enter ingredient {i + 1} quantity:");
                double ingrQty = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter ingredient {i + 1} unit:");
                string ingrUnit = Console.ReadLine();

                Console.WriteLine($"Enter ingredient {i + 1} calories:");

                bool correctInput = false;
                double ingrCalories = 0;
                while (!correctInput)
                {
                    try
                    {
                        ingrCalories = int.Parse(Console.ReadLine());
                        if (ingrCalories > 0)
                        {
                            correctInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number.");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Input was not in correct format.");
                        Console.WriteLine("Please enter a number.");
                    }
                }

                Console.WriteLine($"Select ingredient {i + 1} food group:");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("1 -- Starchy foods");
                Console.WriteLine("2 -- Vegetables and fruits");
                Console.WriteLine("3 -- Dry beans, peas, lentils and soya");
                Console.WriteLine("4 -- Chicken, fish, meat and eggs");
                Console.WriteLine("5 -- Milk and dairy products");
                Console.WriteLine("6 -- Fats and oil");
                Console.WriteLine("7 -- Water");

                string ingrFoodGroup = "";
                int userChoice = 0;

                correctInput = false;
                while (!correctInput)
                {
                    try
                    {
                        userChoice = int.Parse(Console.ReadLine());
                        if (userChoice >= 1 && userChoice <= 7)
                        {
                            correctInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Please choose a number between 1 and 7.");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Input was not in correct format.");
                        Console.WriteLine("Please choose a number between 1 and 7.");
                    }
                }

                switch (userChoice)
                {
                    case 1:
                        ingrFoodGroup = "Starchy foods";
                        break;

                    case 2:
                        ingrFoodGroup = "Vegetables and fruits";
                        break;

                    case 3:
                        ingrFoodGroup = "Dry beans, peas, lentils and soya";
                        break;

                    case 4:
                        ingrFoodGroup = "Chicken, fish, meat and eggs";
                        break;

                    case 5:
                        ingrFoodGroup = "Milk and dairy products";
                        break;

                    case 6:
                        ingrFoodGroup = "Fats and oil";
                        break;

                    case 7:
                        ingrFoodGroup = "Water";
                        break;

                    default:
                        break;
                }

                newRecipe.InputIngredient(ingrName, ingrQty, ingrUnit,ingrCalories,ingrFoodGroup);
            }

            Console.WriteLine("Please enter the number of steps:");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1} description:");
                newRecipe.InputStep(Console.ReadLine());
            }

            Recipes.Add(newRecipe);
        }



    }
}

//--------------------------------------------------------------- oooooo000000000 end of file 000000000oooooo ---------------------------------------------------------------\\