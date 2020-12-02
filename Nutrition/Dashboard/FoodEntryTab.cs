﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Nutrition
{
    partial class Dashboard
    {//TODO: https://stackoverflow.com/questions/17365965/how-do-i-add-an-image-in-my-datagridviewimagecolumn
        private void foodBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Access DataTable members
            DataRowView drv = (DataRowView)foodBox1.SelectedItem;
            string food = drv["item_name"].ToString();
            string id = drv["id"].ToString();

            //string food = ((DataRowView)foodBox1.SelectedItem)["item_name"].ToString();
            currentFood = null;
            foodItems.Items.Add(food);

            Food facts = d.GetFoodData(int.Parse(id), food);//pre-fill the food item with database values
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
            foodList.addNewFood(new Food(nameBox.Text, calories, fat, pro, carb, allergies, Food.MealType.Dinner));//TODO Add mealType in form

            if (targetLabel.Text == "N/A")
                targetLabel.Text = facts.calories.ToString();
            else
            {
                int sum = int.Parse(targetLabel.Text) + calories;
                targetLabel.Text = sum.ToString();
            }
        }

        private void foodItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = foodItems.SelectedIndex;
            if (index == -1)
                return;

            Food fact = foodList.searchByName(foodItems.SelectedItem.ToString());

            //Take note of current food
            currentFood = fact;

            nameBox.Text = fact.name;
            calorieBox.Text = fact.calories.ToString();
            fatBox.Text = fact.fat.ToString();
            carbBox.Text = fact.carbs.ToString();
            proteinBox.Text = fact.protein.ToString();
            checkAllergies(fact.allergies);
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            currentFood = null;
            foodItems.Items.Clear();
            targetLabel.Text = "N/A";
            nameBox.Text = "";
            calorieBox.Text = "";
            fatBox.Text = "";
            carbBox.Text = "";
            proteinBox.Text = "";
        }

        private void saveFoodButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (string name in foodItems.Items)
            {
                Food raw_facts = foodList.searchByName(name);
                IDictionary<string, string> nutrition = new Dictionary<string, string>
                {
                    ["username"] = username,
                    ["item_name"] = raw_facts.name,
                    ["cals"] = raw_facts.calories.ToString(),
                    ["fat"] = raw_facts.fat.ToString(),
                    ["carbs"] = raw_facts.carbs.ToString(),
                    ["protein"] = raw_facts.protein.ToString(),
                    ["meal_type"] = ((int)raw_facts.type).ToString() //Cast with (int) to get the Enum value instead of the enum string value
                };
                d.insertUserTracking(nutrition);
                i++;
            }
            //Check if any items were added to the form
            if (i > 0)
            {
                clearAllButton_Click(sender, e); //clear the food entry form
                prefetch(); //Update the last 10 meal data and user data to reflect the new consumed items

                //refresh the graph visuals
                plotBars();
                plotForms();
                refreshCalData();
                //Optional show how many items were saved
                if (Program.debugMode)
                    MessageBox.Show("Saved " + i + " list items!");
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int index = foodItems.SelectedIndex;
            if (index > -1)
            {
                List<string> facts = d.GetFoodData(foodItems.SelectedItem.ToString());

                foodItems.Items.RemoveAt(index);
                foodItems.SelectedIndex = index - 1;

                int sum = int.Parse(targetLabel.Text) - int.Parse(facts[1]);
                if (sum > 0)
                    targetLabel.Text = sum.ToString();
                else
                    targetLabel.Text = "N/A";
            }
        }
        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            if (currentFood != null)
            {
                Food changed = currentFood;
                changed.name = nameBox.Text;
                foodList.updateItem(currentFood, changed);
            }
        }

        private void calorieBox_TextChanged(object sender, EventArgs e)
        {
            if (currentFood != null)
            {
                Food changed = currentFood;
                changed.calories = int.Parse(calorieBox.Text);
                foodList.updateItem(currentFood, changed);
            }
        }

        private void fatBox_TextChanged(object sender, EventArgs e)
        {
            if (currentFood != null)
            {
                Food changed = currentFood;
                changed.fat = double.Parse(fatBox.Text);
                foodList.updateItem(currentFood, changed);
            }
        }

        private void carbBox_TextChanged(object sender, EventArgs e)
        {
            if (currentFood != null)
            {
                Food changed = currentFood;
                changed.carbs = double.Parse(carbBox.Text);
                foodList.updateItem(currentFood, changed);
            }
        }

        private void proteinBox_TextChanged(object sender, EventArgs e)
        {
            if (currentFood != null)
            {
                Food changed = currentFood;
                changed.protein = double.Parse(proteinBox.Text);
                foodList.updateItem(currentFood, changed);
            }
        }
        private void allergyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            //Show allergy items
            if (allergyCheckbox.Checked)
            {
                List<string> foods = d.GetNoAllergyFoodItems(username);
                foodBox1.Items.Clear();//Clear box to remove potential allergy conflicts
                foreach (string name in foods)
                {
                    foodBox1.Items.Add(name);
                }
            }
            else //Show all items
            {
                foodBox1.Items.Clear();//Clear box to prevent duplicates
                foreach (string name in foodData)
                {
                    foodBox1.Items.Add(name);
                }
            }
        }


        private void logMeal_Click(object sender, EventArgs e)
        {
            if (foodTabControl.Visible && foodTabControl.TabPages.Contains(addMealTab))
            {
                foodTabControl.Visible = false;
                foodTabControl.TabPages.Remove(addMealTab);
            }
            else
            {
                foodTabControl.Visible = true;
                if (!foodTabControl.TabPages.Contains(addMealTab))
                    foodTabControl.TabPages.Insert(0, addMealTab);
                if (foodTabControl.TabPages.Contains(addNewFoodTab))
                    foodTabControl.TabPages.Remove(addNewFoodTab);
            }
        }

        private void newFoodItem_Click(object sender, EventArgs e)
        {
            if (foodTabControl.Visible && foodTabControl.TabPages.Contains(addNewFoodTab))
            {
                foodTabControl.Visible = false;
                foodTabControl.TabPages.Remove(addNewFoodTab);
            }
            else
            {
                foodTabControl.Visible = true;
                if (!foodTabControl.TabPages.Contains(addNewFoodTab))
                    foodTabControl.TabPages.Insert(0, addNewFoodTab);
                if (foodTabControl.TabPages.Contains(addMealTab))
                    foodTabControl.TabPages.Remove(addMealTab);
            }
        }

        private void saveNewFoodButton_Click(object sender, EventArgs e)
        {
            int gluten = 0, nuts = 0, fish = 0, dairy = 0, soy = 0;
            if (newFoodGlut.Checked)
                gluten = 1;
            if (newFoodNut.Checked)
                nuts = 1;
            if (newFoodFish.Checked)
                fish = 1;
            if (newFoodDair.Checked)
                dairy = 1;
            if (newFoodSoy.Checked)
                soy = 1;

            int[] allergies = new int[] { gluten, nuts, fish, dairy, soy };

            Food newItem = new Food(newFoodName.Text, int.Parse(newFoodCal.Text), double.Parse(newFoodFat.Text), double.Parse(newFoodPro.Text), double.Parse(newFoodCarb.Text), allergies);
            d.InsertFood(newItem);
            FillFoodData();//update combobox
        }

        //Put the allergies from the food data into an array for the food class
        private int[] getAllergies(List<string> foodData)
        {
            List<string> facts = foodData;
            string gluten, nuts, fish, dairy, soy;
            gluten = facts[5];
            nuts = facts[6];
            fish = facts[7];
            dairy = facts[8];
            soy = facts[9];
            int[] allergies = new int[] { int.Parse(gluten), int.Parse(nuts), int.Parse(fish), int.Parse(dairy), int.Parse(soy) };
            return allergies;
        }

        private void checkAllergies(int[] allergies)
        {
            glutenBox.Checked = false;
            nutBox.Checked = false;
            fishBox.Checked = false;
            dairyBox.Checked = false;
            soyBox.Checked = false;
            if (allergies[0] == 1)
                glutenBox.Checked = true;
            if (allergies[1] == 1)
                nutBox.Checked = true;
            if (allergies[2] == 1)
                fishBox.Checked = true;
            if (allergies[3] == 1)
                dairyBox.Checked = true;
            if (allergies[4] == 1)
                soyBox.Checked = true;
        }
    }
}
