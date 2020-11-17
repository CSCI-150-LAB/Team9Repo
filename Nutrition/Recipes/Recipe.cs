using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrition
{
    class Recipe
    {
        public string name;
        public List<Food> ingredients = new List<Food>();

        //Build recipe with only a name and unknown ingredients
        public Recipe(string name)
        {
            this.name = name;
        }
        
        //Build the complete recipe if ingredients are known
        public Recipe(string name, List<Food> ingredients)
        {
            this.name = name;
            this.ingredients = ingredients;
        }
    }
}
