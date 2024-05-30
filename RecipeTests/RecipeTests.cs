using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RecipeApp;

namespace RecipeAppTests
{
    [TestClass]
    public class RecipeTests
    {
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