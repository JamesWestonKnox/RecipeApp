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
                Console.WriteLine("****************RECIPE APP*****************");
                Console.WriteLine("Please enter the number of your choice");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("1 -- Add a new recipe");
                Console.WriteLine("2 -- Display recipe");
                Console.WriteLine("3 -- Scale recipe");
                Console.WriteLine("4 -- Reset recipe scaling");
                Console.WriteLine("5 -- Clear Recipe data");
                Console.WriteLine("6 -- Exit application");

                userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Recipe.InputRecipe();
                        break;

                    case 2:
                        Recipe.DisplayRecipe();
                        break;

                    case 6:
                        break;
                }
            }
            while (userChoice != 6);
        }
    }
}
