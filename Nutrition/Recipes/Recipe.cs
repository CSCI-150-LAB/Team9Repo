using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrition
{
    class Recipe
    {
        public string name, description, instructions;
        public List<Food> ingredients = new List<Food>();

        //Build recipe with only a name and unknown ingredients
        public Recipe(string name, string description, string instructions)
        {
            this.name = name;
            this.description = description;
            this.instructions = instructions;
        }

        //Build the complete recipe if ingredients are known
        public Recipe(string name, string description, string instructions, List<Food> ingredients)
        {
            this.name = name;
            this.description = description;
            this.instructions = instructions;
            this.ingredients = ingredients;
        }
    }
}
