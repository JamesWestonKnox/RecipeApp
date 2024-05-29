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

    }
}

//--------------------------------------------------------------- oooooo000000000 end of file 000000000oooooo ---------------------------------------------------------------\\