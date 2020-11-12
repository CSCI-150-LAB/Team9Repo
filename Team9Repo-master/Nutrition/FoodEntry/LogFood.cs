using Nutrition;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutrition
{
    public partial class LogFood : Form
    {
        //Create database and food entry instance
        Database d = new Database();
        FoodEntry foodList = new FoodEntry();
        Food currentFood = null;

        private string username;
        public LogFood(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void foodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string food = foodBox.SelectedItem.ToString();
            currentFood = null;
            foodItems.Items.Add(food);

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
            foodList.addNewFood(new Food(nameBox.Text, calories,fat, pro, carb, Food.MealType.Dinner));

            //currentFood = new Food(nameBox.Text, calories, fat, pro, carb, Food.MealType.Dinner);
            if (targetLabel.Text == "N/A")
                targetLabel.Text = facts[1];
            else
            {
                int sum = int.Parse(targetLabel.Text) + calories;
                targetLabel.Text = sum.ToString();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //TODO: Use structs for list data: https://stackoverflow.com/questions/41171511/arrays-inside-a-list/41171582
        

            int i = 0;
            foreach (string name in foodItems.Items)
            {
                List<string> facts = d.GetFoodData(name);
                IDictionary<string, string> nutrition = new Dictionary<string, string>
                {
                    ["username"] = username,
                    ["item_name"] = facts[0],
                    ["cals"] = facts[1],
                    ["fat"] = facts[2],
                    ["carbs"] = facts[3],
                    ["protein"] = facts[4],
                    ["meal_type"] = "2"
                };
                d.insertUserTracking(nutrition);
                i++;
            }
            //Clear after submission
            if (i > 0)
            {
                clearButton_Click(sender, e);
                MessageBox.Show("Saved " + i + " list items!");
            }
        }

        private void Log_Load(object sender, EventArgs e)
        {
            List<string> foods = d.GetFoodItems();
            foreach (string name in foods)
            {
                foodBox.Items.Add(name);
            }

            //TODO: Implement real users username
            IDictionary<string, string> user = d.GetUserData(username);
            bmrLabel.Text = user["bmr"];
        }

        private void foodItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = foodItems.SelectedIndex;
            if (index == -1)
                return;

            List<string> facts = d.GetFoodData(foodItems.SelectedItem.ToString());
            Food fact2 = foodList.searchByName(foodItems.SelectedItem.ToString());

            //Take note of current food
            currentFood = fact2;

            nameBox.Text = fact2.name;
          //  nameBox.Text = facts[0,1,2,3,4];
            calorieBox.Text = fact2.calories.ToString();
            fatBox.Text = fact2.fat.ToString();
            carbBox.Text = fact2.carbs.ToString();
            proteinBox.Text = fact2.protein.ToString();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            currentFood = null;
            foodItems.Items.Clear();
            targetLabel.Text = "N/A";
            nameBox.Text ="";
            calorieBox.Text = "";
            fatBox.Text = "";
            carbBox.Text = "";
            proteinBox.Text = "";
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
    }
}
