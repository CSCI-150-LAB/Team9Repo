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

        private void ingredientsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)ingredientsDropDown.SelectedItem;
            string food = drv["item_name"].ToString();
            string id = drv["id"].ToString();
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
        private void useRecipeButton_Click(object sender, EventArgs e)
        {
            foreach (string food in recipeIngredientList.Items)
            {
                Food facts = searchLocalDB(food);
                nameBox.Text = facts.name;
                calorieBox.Text = facts.calories.ToString();
                fatBox.Text = facts.fat.ToString();
                carbBox.Text = facts.carbs.ToString();
                proteinBox.Text = facts.protein.ToString();

                int calories = facts.calories;
                double fat = facts.fat;
                double carb = facts.carbs;
                double pro = facts.protein;
                int[] allergies = facts.allergies;
                checkAllergies(allergies);//fill in allergies
                Food item = new Food(facts.id, facts.name, calories, fat, pro, carb, allergies, Food.MealType.Dinner);
                foodItems.Items.Add(item.name);//TODO Add mealType in form
                foodList.addNewFood(item);//TODO Add mealType in form

                if (targetLabel.Text == "N/A")
                    targetLabel.Text = facts.calories.ToString();
                else
                {
                    int sum = int.Parse(targetLabel.Text) + calories;
                    targetLabel.Text = sum.ToString();
                }
            }

            //After clicking use this recipe swap to the food entry tab
            tabControl1.SelectedTab = tabPage2;

            //If the tab control is not visible or the wrong tab is being displayed--fix it
            if (!foodTabControl.Visible || !foodTabControl.TabPages.Contains(addMealTab))
            {
                //Show the control
                foodTabControl.Visible = true;
                //Remove the unused tab
                foodTabControl.TabPages.Remove(addNewFoodTab);
                //If we are on the wrong tab and the one we want is missing--add it back
                if (!foodTabControl.TabPages.Contains(addMealTab))
                    foodTabControl.TabPages.Insert(0, addMealTab);
            }
        }
        private void findRecipeButton_Click(object sender, EventArgs e)
        {
            if (recipeControl.Visible && recipeControl.TabPages.Contains(findRecipeTab))
            {
                recipeControl.Visible = false;
                recipeControl.TabPages.Remove(findRecipeTab);
            }
            else
            {
                recipeControl.Visible = true;
                if (!recipeControl.TabPages.Contains(findRecipeTab))
                    recipeControl.TabPages.Insert(0, findRecipeTab);
                if (recipeControl.TabPages.Contains(addRecipeTab))
                    recipeControl.TabPages.Remove(addRecipeTab);
            }
        }

        private void addRecipeButton_Click(object sender, EventArgs e)
        {
            if (recipeControl.Visible && recipeControl.TabPages.Contains(addRecipeTab))
            {
                recipeControl.Visible = false;
                recipeControl.TabPages.Remove(addRecipeTab);
            }
            else
            {
                recipeControl.Visible = true;
                if (!recipeControl.TabPages.Contains(addRecipeTab))
                    recipeControl.TabPages.Insert(0, addRecipeTab);
                if (recipeControl.TabPages.Contains(findRecipeTab))
                    recipeControl.TabPages.Remove(findRecipeTab);
            }
        }

        private void newRecipeIngr_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)newRecipeIngr.SelectedItem;
            string food = drv["item_name"].ToString();
            string id = drv["id"].ToString();
            newRecipeList.Items.Add(food);
        }

        private void newRecipeDeleteIng_Click(object sender, EventArgs e)
        {
            int index = newRecipeList.SelectedIndex;
            if (index > -1)
            {
                newRecipeList.Items.RemoveAt(index);
                newRecipeList.SelectedIndex = index - 1;
            }
        }

        private void saveNewRecipeButton_Click(object sender, EventArgs e)
        {
            if (newRecipeName.Text.Length == 0)
                MessageBox.Show("Error: Recipe needs a name");
            else if (newRecipeDesc.Text.Length == 0)
                MessageBox.Show("Error: Recipe needs a description");
            else if (newRecipeIns.Text.Length == 0)
                MessageBox.Show("Error: Recipe needs instructions");
            else if (newRecipeList.Items.Count == 0)
                MessageBox.Show("Error: Recipe needs ingredients");
            else
            {
                RecipeMaker p = new RecipeMaker(newRecipeName.Text, newRecipeDesc.Text, newRecipeIns.Text);
                foreach (string food in newRecipeList.Items)
                {
                    Food foodInfo = searchLocalDB(food);
                    p.addIngredient(foodInfo);
                }
                d.InsertRecipe(username, p.getRecipe().name, p.getRecipe().description, p.getRecipe().instructions, p.getRecipe().ingredients);
                newRecipeName.Clear();
                newRecipeDesc.Clear();
                newRecipeIns.Clear();
                newRecipeList.Items.Clear();
                recipes = d.GetRecipeList();
                recipeDropDown.DataSource = d.getRecipeList();
                if (Program.debugMode)
                    MessageBox.Show("Saved " + p.getRecipe().name + " to the database");
            }
        }
    }
}
