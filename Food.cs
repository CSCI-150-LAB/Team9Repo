using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionLog
{
    class Food
    {
        public string name;
        public int calories, fat, protein, carbs;
        public MealType type;

        public enum MealType { Breakfast = 0, Lunch = 1, Dinner = 2 };
        public Food(string name, int calories, int fat, int protein, int carbs, MealType type)
        {
            this.name = name;
            this.calories = calories;
            this.fat = fat;
            this.protein = protein;
            this.carbs = carbs;
            this.type = type;
        }
    }
}
