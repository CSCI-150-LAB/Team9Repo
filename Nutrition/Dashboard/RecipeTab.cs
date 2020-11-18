using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Nutrition
{
    public partial class Dashboard : Form
    {
        private void recipeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Recipe> recipes = d.GetRecipeList();
            textBox1.Text = recipes[2].name;
            recipeDescription.AppendText(recipes[2].description);
            recipeInsBox.AppendText(recipes[2].instructions);
            foreach (Food item in recipes[2].ingredients)
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
                    p.addIngredient(new Food(foodInfo[0], Int32.Parse(foodInfo[1]), Double.Parse(foodInfo[2]), Double.Parse(foodInfo[4]), Double.Parse(foodInfo[3]), Food.MealType.Dinner));
                }
                d.InsertRecipe(username, p.getRecipe().name, p.getRecipe().description, p.getRecipe().instructions, p.getRecipe().ingredients);
                recipeNameBox.Clear();
                recipeDescription.Clear();
                recipeInsBox.Clear();
                recipeIngredientList.Items.Clear();
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
    }
}
