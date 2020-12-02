using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrition
{
    class Food
    {
        public string name;
        public int calories;
        public int[] allergies;//0 = gluten,1 = nuts,2 = fish,3 = dairy ,4 = soy
        public double fat, protein, carbs;
        public MealType type;

        public enum MealType { Breakfast = 0, Lunch = 1, Dinner = 2 };
        public Food(string name, int calories, double fat, double protein, double carbs, int[] allergies, MealType type)
        {
            this.name = name;
            this.calories = calories;
            this.fat = fat;
            this.protein = protein;
            this.carbs = carbs;
            this.allergies = allergies;
            this.type = type;
        }

        public Food(string name, int calories, double fat, double protein, double carbs, int[] allergies)
        {
            this.name = name;
            this.calories = calories;
            this.fat = fat;
            this.protein = protein;
            this.carbs = carbs;
            this.allergies = allergies;
        }
    }
}
