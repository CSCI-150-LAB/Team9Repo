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


//TODO:
//GRAPH API: https://stackoverflow.com/questions/10622674/chart-creating-dynamically-in-net-c-sharp
//https://docs.microsoft.com/en-us/previous-versions/dd489237(v=vs.140)?redirectedfrom=MSDN
//https://docs.microsoft.com/en-us/previous-versions/dd489233(v=vs.140)?redirectedfrom=MSDN
//https://stackoverflow.com/questions/38713649/how-could-i-display-a-graph-on-windowsforms
namespace Nutrition
{
    public partial class LogFood : Form
    {
        Database d = new Database();

        private string username;
        public LogFood(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void foodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string food = foodBox.SelectedItem.ToString();
            foodItems.Items.Add(food);

            List<string> facts = d.GetFoodData(food);
            nameBox.Text = facts[0];
            calorieBox.Text = facts[1];
            fatBox.Text = facts[2];
            carbBox.Text = facts[3];
            proteinBox.Text = facts[4];

            if (targetLabel.Text == "N/A")
                targetLabel.Text = facts[1];
            else
            {
                int sum = Int32.Parse(targetLabel.Text) + Int32.Parse(facts[1]);
                targetLabel.Text = sum.ToString();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //TODO: Use structs for list data: https://stackoverflow.com/questions/41171511/arrays-inside-a-list/41171582
            /* Database test = new Database();
             IDictionary<string, string> register = new Dictionary<string, string>
             {
                 ["username"] = "Kyle",
                 ["password"] = "asdasdasda",
                 ["admin"] = "0",
                 ["gluten"] = "1",
                 ["peanut"] = "0",
                 ["fish"] = "0",
                 ["soy"] = "0",
                 ["dairy"] = "0"
             };
             if (!test.CheckUserExists("Kyle"))
             {
                 test.RegisterUser(register);
             }
             test.FINISH_HIM("Kyle", 20, "Male", 69, 150, 20, 30);
             IDictionary<string, string> user = test.GetUserData("Kyle");
             if (user.Count() > 0)
             {
                 MessageBox.Show("Gender: [" + user["gender"] + "]");
                 if (user["age"].Length != 0)
                 {
                     MessageBox.Show(int.Parse(user["age"]).ToString());
                 }
             }*/
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
            IDictionary<string, string> user = d.GetUserData("Kyle");
            bmrLabel.Text = user["bmr"];
        }

        private void foodItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = foodItems.SelectedIndex;
            if (index == -1)
                return;

            List<string> facts = d.GetFoodData(foodItems.SelectedItem.ToString());
            nameBox.Text = facts[0];
            calorieBox.Text = facts[1];
            fatBox.Text = facts[2];
            carbBox.Text = facts[3];
            proteinBox.Text = facts[4];
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
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
    }
}
