using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RecipeApp;

namespace RecipeAppTests
{
    [TestClass]
    public class RecipeTests
    {
        /// <summary>
        /// Method to unit test the total calories
        /// </summary>
        [TestMethod]
        public void TestTotalCalories()
        {
            var recipe = new Recipe();
            recipe.InputIngredient("Pasta", 100, "grams", 70, "Starchy Foods");
            recipe.InputIngredient("Mince", 50, "grams", 100, "Meat");

            double totalCalories = recipe.CalculateTotalCalories();

            Assert.AreEqual(170, totalCalories, "Total calories should be 170");
        }
    }
}

//--------------------------------------------------------------- oooooo000000000 end of file 000000000oooooo ---------------------------------------------------------------\\