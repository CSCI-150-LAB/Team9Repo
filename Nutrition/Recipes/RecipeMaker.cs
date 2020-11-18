using System;
using System.Collections.Generic;
using System.Linq;

namespace Nutrition
{
    class RecipeMaker
    {
        //Make an instance of the recipe object
        private Recipe recipe;

        //Constructor
        public RecipeMaker(string name, string description, string instructions)
        {
            //Create a new object of the recipe maker with a given recipe name
            recipe = new Recipe(name, description,instructions);
        }

        //Method 1. Add single items to build recipes
        public void addIngredient(Food item)
        {
            recipe.ingredients.Add(item);
        }

        //Method 2. Add full recipe ingredients in one go
        public void addIngredient(List<Food> items)
        {
            recipe.ingredients = items;
        }

        //Remove food item from recipe
        public void deleteIngredient(string name)
        {
            //Check if the ingredient exists using a predicate search (search by food name)
            var del = recipe.ingredients.SingleOrDefault(r => r.name == name);
            if (del != null) //null check
                recipe.ingredients.Remove(del); //Remove the ingredient
        }

        //Return the recipe
        //Contains the string name and List<Food> ingredient list
        public Recipe getRecipe()
        {
            return recipe;
        }
    }
}
