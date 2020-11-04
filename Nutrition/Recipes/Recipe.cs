using NutritionLog;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Nutrition.Recipes
{
    class Recipe
    {
       private List<Food> foodItems;
        Recipe()
        {
            foodItems = new List<Food>();
        }

        void addIngredient(Food item)
        {
            foodItems.Add(item);
        }
        void addRecipe(string name, List<Food> ingredients)
        {
            foreach(Food item in ingredients)
            {
                foodItems.Add(item);
            }
        }

        void deleteRecipe(string name)
        {

        }

        List<Food> getRecipe()
        {
            return foodItems;
        }
    }
}
