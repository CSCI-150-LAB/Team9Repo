using ScottPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Nutrition
{
    public partial class Dashboard : Form
    {
        private string username;
        private IDictionary<string, string> userData;
        private DateTime join_date; //FIXME: what is this needed for?
        private DateTime last_login;
        private double userBMR;
        private double userBMI;
        private double userWeight;
        private int heightFeet;
        private int heightInch;

        Database d = new Database();
        FoodEntry foodList = new FoodEntry();
        Food currentFood = null;
        private Timer t;

        public Dashboard(IDictionary<string, string> user)
        {
            username = user["username"];
            userData = d.GetUserData(username);
            userBMR = Double.Parse(d.GetUserData(username)["bmr"]);
            userBMI = Double.Parse(d.GetUserData(username)["bmi"]);
            userWeight = Double.Parse(d.GetUserData(username)["weight"]);
            //heightFeet = (Int32.Parse(d.GetUserData(username)["height_inches"])) / 12;
            //heightInch = (Int32.Parse(d.GetUserData(username)["height_inches"])) % 12;

            DateTime.TryParse(userData["last_login"], out last_login);//parse string to DateTime type

            /*   data["username"]
                data["admin_powers"]
                data["gluten_allergy"]
                data["peanut_allergy"]
                data["fish_allergy"]
                data["soy_allergy"]
                data["dairy_allergy"] 
                data["join_date"] 
                data["last_login"]
            */
            InitializeComponent();
            userDropDown.Text = "Welcome, " + getUser();
            lastLoginLabel.Text = "You last logged in " + getLastLogin();
            healthUserWelcome.Text = username + "'s Personal Health Summary";
            StartTimer();

            plotBars();
            plotForms();

            //FIXME, needs to get user's goal calories
            calGoalLabel.Text = "Daily Calorie Recomendation\n" + userBMR;

            bmrHSlabel.Text = "BMR: " + userBMR;
            HSbmiLabel.Text = "Starting BMI: " + userBMI;
            HSweightLabel.Text = "Current Weight: " + d.GetUserData(username)["weight"];
            HSheightLabel.Text = "Height: " + heightFeet + "ft " + heightInch + "in";


            string[] weightGoals = new string[] { "Maintain", "Loose", "Gain" };
            goalChangeBox.DataSource = weightGoals;

            //label1.Text = "Current Goal: " + d.GetGoal(username);
        }

        private void StartTimer()
        {
            t = new Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToString();
        }


        public string getUser()
        {
            return username;
        }

        public DateTime getLastLogin()
        {
            return last_login;
        }

        private void dropDownItem_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            //MessageBox.Show(e.ClickedItem.Text);
            if (e.ClickedItem.Text == "Help")
            {
                MessageBox.Show("Ask again later");
            }
            else if (e.ClickedItem.Text == "Logout")
            {
                Environment.Exit(0);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //  MessageBox.Show(e.ClickedItem.Text);
            if (e.ClickedItem.Text == "Add Foods")
            {
                LogFood f = new LogFood(this.username);
                f.Show();
            }
            else if (e.ClickedItem.Text == "Health Summary")
            {
                IDictionary<string, double> data = d.sumMacroData(this.username);
                MessageBox.Show("Protein Sum: " + data["protein"] + "\nFat Sum: " + data["fat"] + "\nCarbs: " + data["carbs"] + "\nCalories: " + data["calories"]);
            }
        }

        //call these functions whenever the graphs need to update
        private void plotBars()
        {
            //double cal = d.sumMacroData(username)["calories"];
            double carb = d.sumMacroData(username)["carbs"];
            double fat = d.sumMacroData(username)["fat"];
            double pro = d.sumMacroData(username)["protein"];

            //macro range calculated from user's BMR
            //ploted as calories recomended for each item

            //upper part of range
            double recHighCarb = Math.Round(userBMR * 0.6, 2);
            double recHighPro = Math.Round(userBMR * 0.35, 2);
            double recHighFat = Math.Round(userBMR * 0.35, 2);
            //lower part of range
            double recLowCarb = Math.Round(userBMR * 0.44, 2);
            double recLowPro = Math.Round(userBMR * 0.09, 2);
            double recLowFat = Math.Round(userBMR * 0.19, 2);

            //generate the 2 color bar graph
            double[] y1Recomended = { recHighCarb, recHighPro, recHighFat };
            double[] y1Below = { recLowCarb, recLowPro, recLowFat };

            //user's actual bar graph
            double[] y2Actual = { carb * 4, pro * 4, fat * 9 }; //database stores as grams, converted to calories then plotted
            double[] xMacros = { 1, 2, 3 };

            // plot the data
            barsFormsPlot.Reset();

            // generates "recomended range" based on user BMR
            barsFormsPlot.plt.PlotBar(xMacros, y1Recomended, null, "Recomended Range", barWidth: .3, xOffset: -.2);
            //below range
            barsFormsPlot.plt.PlotBar(xMacros, y1Below, null, "Below Recomended", barWidth: .3, xOffset: -.2);

            //User's entered macros
            barsFormsPlot.plt.PlotBar(xMacros, y2Actual, null, "Actual", barWidth: 0.3, xOffset: .2);

            //labels the x axis 
            string[] labels = { "Carbs", "Protein", "Fats" };
            barsFormsPlot.plt.Axis(y1: 0);

            barsFormsPlot.plt.Grid(enableVertical: false, lineStyle: LineStyle.Dot);
            barsFormsPlot.plt.Axis(y1: 0);

            //creates legend
            barsFormsPlot.plt.Legend(location: legendLocation.upperRight);
            barsFormsPlot.plt.XTicks(xMacros, labels); //labels the 3 bars

            //lables y axis 
            barsFormsPlot.plt.YLabel("Calories");

            barsFormsPlot.Render();
        }

        private void plotForms()
        {
            //clear previous data
            weightFormsPlot.Reset();

            //FIXME, not sure how to structure this, needs to get from database
            //autofill with 0 if data not avalible 
            double[] days = { 1, 2, 3, 4, 5, 6, 7 };

            //needs to get the user entered data from database
            //autofill with 0 if data not avalible 
            double[] userWeight = { 130, 130, 128, 127, 129, 127, 126 };
            weightFormsPlot.plt.PlotScatter(days, userWeight);

            //Label x and y axis
            weightFormsPlot.plt.XLabel("Days");
            weightFormsPlot.plt.YLabel("Pounds");

            weightFormsPlot.Render();
        }


        private void barsFormsPlot_Load_1(object sender, EventArgs e) //plots user's macros for the day
        {
           
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

                //Optional show how many items were saved
                MessageBox.Show("Saved " + i + " list items!");
            }
        }

        private void foodBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string food = foodBox1.SelectedItem.ToString();
            currentFood = null;
            foodItems.Items.Add(food);

            List<string> facts = d.GetFoodData(food);//pre-fill the form with database values
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //Set the dashboard tab to be displayed first
             tabControl1.SelectedIndex = 0;

            //Prefetch food box items from the database into the form
            //Is there a better way?
            List<string> foods = d.GetFoodItems();
            foreach (string name in foods)
            {
                foodBox1.Items.Add(name);
            }

            //Prefetch Data
            prefetch();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

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

        /**
         * Prefetch last 10 meals, user BMR data, and the sum of the past 24 hours of food macros
         */
        private void prefetch()
        {
            List<string> lastTen = d.getLastTenMeals(username);
            consumedBox.Items.Clear(); //Empty any existing items
            foreach (string food in lastTen)
            {
                consumedBox.Items.Add(food);
            }

            //Prefetch user BMR and the sum of the past 24 hours of macro data
            IDictionary<string, string> user = d.GetUserData(username);
            IDictionary<string, double> user_macro_sum = d.sumMacroData(username);
            double bmr = double.Parse(user["bmr"]);
            bmrLabel.Text = Convert.ToInt32(bmr).ToString();
        }

        private void deleteMeal_Click(object sender, EventArgs e)
        {
            foreach(string item in consumedBox.CheckedItems)
            {
                //d.DeleteFoodEntry(item, username);
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
