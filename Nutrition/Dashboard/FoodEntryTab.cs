using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Nutrition
{
    partial class Dashboard : Form
    {
        private void foodBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string food = foodBox1.SelectedItem.ToString();
            currentFood = null;
            foodItems.Items.Add(food);

            List<string> facts = d.GetFoodData(food);//pre-fill the food item with database values
            nameBox.Text = facts[0];
            calorieBox.Text = facts[1];
            fatBox.Text = facts[2];
            carbBox.Text = facts[3];
            proteinBox.Text = facts[4];

            int calories = int.Parse(facts[1]);
            double fat = double.Parse(facts[2]);
            double carb = double.Parse(facts[3]);
            double pro = double.Parse(facts[4]);
            foodList.addNewFood(new Food(nameBox.Text, calories, fat, pro, carb, Food.MealType.Dinner));//TODO Add mealType in form

            if (targetLabel.Text == "N/A")
                targetLabel.Text = facts[1];
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
    }
}
