using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Nutrition
{
    public partial class Dashboard
    {//TODO: https://stackoverflow.com/questions/14105265/dropdownlist-datasource
        private void recipeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear old values
            recipeNameBox.Clear();
            recipeDescription.Clear();
            recipeInsBox.Clear();
            recipeIngredientList.Items.Clear();

            //string name = ((DataRowView)recipeDropDown.SelectedItem)["name"].ToString();

            int index = recipeDropDown.SelectedIndex;

            recipeNameBox.Text = recipes[index].name;
            recipeDescription.AppendText(recipes[index].description);
            recipeInsBox.AppendText(recipes[index].instructions);
            foreach (Food item in recipes[index].ingredients)
                recipeIngredientList.Items.Add(item.name);
        }

        private void saveRecipe_Click(object sender, EventArgs e)
        {
            if (recipeNameBox.Text.Length == 0)
                MessageBox.Show("Error: Recipe needs a name");
            else if (recipeDescription.Text.Length == 0)
                MessageBox.Show("Error: Recipe needs a description");
            else if (recipeInsBox.Text.Length == 0)
                MessageBox.Show("Error: Recipe needs instructions");
            else if (recipeIngredientList.Items.Count == 0)
                MessageBox.Show("Error: Recipe needs ingredients");
            else
            {
                RecipeMaker p = new RecipeMaker(recipeNameBox.Text, recipeDescription.Text, recipeInsBox.Text);
                foreach (string food in recipeIngredientList.Items)
                {
                    List<string> foodInfo = d.GetFoodData(food);
                    int[] allergies = getAllergies(foodInfo);
                    p.addIngredient(new Food(foodInfo[0], Int32.Parse(foodInfo[1]), Double.Parse(foodInfo[2]), Double.Parse(foodInfo[4]), Double.Parse(foodInfo[3]), allergies, Food.MealType.Dinner));
                }
                d.InsertRecipe(username, p.getRecipe().name, p.getRecipe().description, p.getRecipe().instructions, p.getRecipe().ingredients);
                recipeNameBox.Clear();
                recipeDescription.Clear();
                recipeInsBox.Clear();
                recipeIngredientList.Items.Clear();
                recipes = d.GetRecipeList();
                recipeDropDown.DataSource = d.getRecipeList();
                MessageBox.Show("Saved " + p.getRecipe().name + " to the database");
            }
        }

        private void ingredientsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string food = ingredientsDropDown.SelectedItem.ToString();
            recipeIngredientList.Items.Add(food);
        }

        private void deleteIngredientBut_Click(object sender, EventArgs e)
        {
            int index = recipeIngredientList.SelectedIndex;
            if (index > -1)
            {
                recipeIngredientList.Items.RemoveAt(index);
                recipeIngredientList.SelectedIndex = index - 1;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string food in recipeIngredientList.Items)
            {
                List<string> facts = d.GetFoodData(food);
                nameBox.Text = facts[0];
                calorieBox.Text = facts[1];
                fatBox.Text = facts[2];
                carbBox.Text = facts[3];
                proteinBox.Text = facts[4];

                int calories = int.Parse(facts[1]);
                double fat = double.Parse(facts[2]);
                double carb = double.Parse(facts[3]);
                double pro = double.Parse(facts[4]);
                int[] allergies = getAllergies(facts);
                checkAllergies(allergies);//fill in allergies
                Food item = new Food(facts[0], calories, fat, pro, carb, allergies, Food.MealType.Dinner);
                foodItems.Items.Add(item.name);//TODO Add mealType in form
                foodList.addNewFood(item);//TODO Add mealType in form

                if (targetLabel.Text == "N/A")
                    targetLabel.Text = facts[1];
                else
                {
                    int sum = int.Parse(targetLabel.Text) + calories;
                    targetLabel.Text = sum.ToString();
                }
            }
            tabControl1.SelectedTab = tabPage2;

        }
    }
}
