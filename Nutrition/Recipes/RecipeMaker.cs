using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrition
{
    class RecipeMaker
    {
        public string name;
        public List<Food> ingredients;

        //Build recipe with only a name and unknown ingredients
        public RecipeMaker(string name)
        {
            this.name = name;
        }
        
        //Build the complete recipe if ingredients are known
        public RecipeMaker(string name, List<Food> ingredients)
        {
            this.name = name;
            this.ingredients = ingredients;
        }
    }
}
