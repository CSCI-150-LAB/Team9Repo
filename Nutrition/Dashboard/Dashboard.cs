using ScottPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Nutrition
{
    public partial class Dashboard : Form
    {
        private string username;
        private IDictionary<string, string> userData;
        private IDictionary<string, double> user_macro_sum;
        private DateTime last_login;
        private double userBMR;
        private double userBMI;
        private double userWeight;
        private bool isAdministrator = false;
        private int heightFeet;
        private int heightInch;
        private double calorieGoal;

        Database d = new Database();
        FoodEntry foodList = new FoodEntry();
        Food currentFood = null;
        private List<Food> foodData = new List<Food>();
        private List<Recipe> recipes = new List<Recipe>();
        private Timer t;

        public Dashboard(IDictionary<string, string> user)
        {
            username = user["username"];
            userData = d.GetUserData(username);

            //Set admin powers
            if (d.isAdmin(username))
                isAdministrator = true;

            userBMR = Double.Parse(userData["bmr"]);
            userBMI = Double.Parse(userData["bmi"]);
            userWeight = Math.Round(Double.Parse(userData["weight"]), 2);
            double feet = Double.Parse(userData["height_inches"]);
            heightFeet = (int)feet / 12;
            heightInch = (int)feet % 12;

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
            if (!isAdministrator) //Only show graphs to users--disabled for admins
            {
                plotBars();
                plotForms();
            }
            refreshCalData();
            bmrHSlabel.Text = "BMR: " + userBMR;
            HSbmiLabel.Text = "Starting BMI: " + userBMI;
            HSweightLabel.Text = "Current Weight: " + userWeight;
            HSheightLabel.Text = "Height: " + heightFeet + "ft " + heightInch + "in";

            /* string[] weightGoals = new string[] { "Maintain", "Lose", "Gain" };
             goalChangeBox.DataSource = weightGoals;*/
            fixGoal();

            //Get the promoted recipe from the db
            Recipe promoted = d.GetPromotedRecipe();
            recipeTitleLb.Text = promoted.name;
            recipeDashDesc.Text = promoted.description;
            recipeDashIns.Text = promoted.instructions;
            dashboardProRecipeID.Text = promoted.recipeid;
            foreach (Food item in promoted.ingredients)
                recipeDashItems.Items.Add(item.name);
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
            if (e.ClickedItem.Text == "Logout")
            {
                Environment.Exit(0);
            }
        }

        void fixGoal()
        {
            string flag = d.GetGoal(username);

            if (flag == "Maintain")
            {
                calorieGoal = userBMR;
                currGoalLabel.Text = "Current Goal: Maintain Weight";
            }
            else if (flag == "Lose")
            {
                calorieGoal = Math.Round(userBMR - 250, 2); //lose .5 lbs a week
                currGoalLabel.Text = "Current Goal: Lose 0.5lbs a week";
            }
            else
            {
                calorieGoal = Math.Round(userBMR + 250, 2); //gain .5 lbs a week
                currGoalLabel.Text = "Current Goal: Gain 0.5lbs a week";
            }
            calGoalLabel.Text = "Calorie Goal:\n" + calorieGoal;
        }

        private void goalChangeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string goal = goalChangeBox.SelectedItem.ToString();
            //MessageBox.Show("Goal changed to " + goal);//This pops up even when the tab isn't in focus and we didn't touch the drop down box

            d.SetGoal(username, goal);
            fixGoal();
        }

        //call these functions whenever the graphs need to update
        private void plotBars()
        {
            //Grab the values from the DB
            user_macro_sum = d.sumMacroData(username);

            //double cal = d.sumMacroData(username)["calories"];
            double carb = user_macro_sum["carbs"];
            double fat = user_macro_sum["fat"];
            double pro = user_macro_sum["protein"];

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
            List<Weight> THICCLOGG = d.GetWeightLog(username);

            bool isEmpty = !THICCLOGG.Any();
            if (isEmpty)
            {
                THICCLOGG.Add(new Weight(double.Parse(userData["weight"]), DateTime.Now));
            }
            Weight[] p = THICCLOGG.ToArray();

            int i2 = 0;
            foreach (Weight a in p)
            {
                i2++;
            }

            //clear previous data
            weightFormsPlot.Reset();

            //FIXME, not sure how to structure this, needs to get from database
            //autofill with 0 if data not avalible 
            double[] days = new double[i2];
            double[] userWeight = new double[i2];
            i2 = 0;
            foreach (Weight a in p)
            {
                days[i2] = a.date.ToOADate();
                userWeight[i2] = a.weight;
                i2++;
            }
            //needs to get the user entered data from database
            //autofill with 0 if data not avalible 

            weightFormsPlot.plt.PlotScatter(days, userWeight);

            //Label x and y axis
            weightFormsPlot.plt.XLabel("Days");
            weightFormsPlot.plt.YLabel("Pounds");
            weightFormsPlot.plt.Ticks(dateTimeX: true);

            weightFormsPlot.Render();
        }

        private void refreshCalData()
        {
            user_macro_sum = d.sumMacroData(username);

            //FIXME, needs to get user's goal calories
            calGoalLabel.Text = "Daily Calories:\n" + calorieGoal;
            calEatenLabel.Text = "Calories Eaten:\n" + Math.Round(user_macro_sum["calories"], 1);
            calRemainLabel.Text = "Remaining:\n" + Math.Round(userBMR - user_macro_sum["calories"], 1);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //Set the dashboard tab to be displayed first
            tabControl1.SelectedIndex = 0;
            //Hide the admin tab as default view
            if (tabControl1.TabPages.Contains(adminTab))
                tabControl1.TabPages.Remove(adminTab);
            //If the user is an admin put it back
            if (isAdministrator)
            {
                tabControl1.TabPages.Insert(4, adminTab);
                tabControl1.SelectedIndex = 4;
            }

            //Fill the drop down menus with food items
            FillFoodData();

            //Prefetch Data
            prefetch();

            //Set default view on Food entry and meal tabs
            logMeal_Click(sender, e); //Simulate a click to make it visible
            findRecipeButton_Click(sender, e); //Simulate a click to make it visible
        }

        /**
         * Prefetch last 10 meals, user BMR data, and the sum of the past 24 hours of food macros
         */
        private void prefetch()
        {
            dataGridView1.DataSource = d.getLastTenMeals(username);
            dataGridView1.Columns["usr"].Visible = false;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["date_logged"].Visible = false;
            dataGridView1.Columns["meal_type"].Visible = false;

            //Prefetch user BMR and the sum of the past 24 hours of macro data
            userData = d.GetUserData(username);
            user_macro_sum = d.sumMacroData(username);
            double bmr = double.Parse(userData["bmr"]);
            bmrLabel.Text = Convert.ToInt32(bmr).ToString();
            WeightChangeUpDown.Value = Convert.ToDecimal(d.GetUserData(username)["weight"]);
        }

        private void FillFoodData()
        {
            //Prefetch food box items from the database
            foodData = d.GetFoodItems();
            foodBox1.Items.Clear();//Reset the list
            foreach (Food i in foodData)
            {
                //Add items to the food box
                foodBox1.Items.Add(i.name);
            }

            DataTable foodList = d.GetFoodItems2();

            //Fill Food Entry box
            //  foodBox1.DataSource = foodList;
            //  foodBox1.DisplayMember = "item_name";
            //  foodBox1.ValueMember = "id";
            //   foodItems.Items.Clear();//Empty the first item added from the datasource event triggering
            //  targetLabel.Text = "N/A";

            //Fill Recipe drop down box
            ingredientsDropDown.DataSource = foodList;
            ingredientsDropDown.DisplayMember = "item_name";
            ingredientsDropDown.ValueMember = "id";
            recipeIngredientList.Items.Clear();//Empty the first item added from the datasource event triggering

            //Fill in new Recipe dropdown box
            newRecipeIngr.DataSource = foodList;
            newRecipeIngr.DisplayMember = "item_name";
            newRecipeIngr.ValueMember = "id";
            newRecipeList.Items.Clear();//Empty the first item added from the datasource event triggering

            //Prefetch recipes from the database
            recipes = d.GetRecipeList();
            recipeDropDown.DataSource = d.getRecipeList();
            recipeDropDown.DisplayMember = "name";
            recipeDropDown.ValueMember = "recipeid";

            //Fill in Admin tabs with food data
            if (isAdministrator)
            {
                //Edit food items
                adminFoodBox1.DataSource = foodList;
                adminFoodBox1.DisplayMember = "item_name";
                adminFoodBox1.ValueMember = "id";

                //Edit recipes
                adminRecipeBox1.DataSource = d.getRecipeList();
                adminRecipeBox1.DisplayMember = "name";
                adminRecipeBox1.ValueMember = "recipeid";

                adminRecipeIng.DataSource = foodList;
                adminRecipeIng.DisplayMember = "item_name";
                adminRecipeIng.ValueMember = "id";

                adminRecipeItems.Items.Clear();
            }
        }

        private void deleteMeal_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows
           .OfType<DataGridViewRow>()
           .Where(row => !row.IsNewRow)
           .ToArray();

            foreach (var row in selectedRows)
            {
                if (Program.debugMode)
                    MessageBox.Show("Deleting: " + dataGridView1.SelectedRows[0].Cells["item_name"].Value.ToString());
                int item = -1;
                string val = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                bool parsed = Int32.TryParse(val, out item);
                if (parsed)
                {
                    d.DeleteFoodEntry(item, username);
                    dataGridView1.Rows.Remove(row);
                }
            }
            prefetch();
            plotBars();
            plotForms();
            refreshCalData();
        }

        //Prevent application from running in the background
        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            d.InsertUserWeight(username, Math.Round(Convert.ToDouble(WeightChangeUpDown.Value), 2));
            d.UpdateUserWeight(username, Math.Round(Convert.ToDouble(WeightChangeUpDown.Value), 2));
            HSweightLabel.Text = "Current Weight: " + d.GetUserData(username)["weight"];
            plotForms();
            MessageBox.Show("Success!");
        }

        private void usePromotedRecipe_Click(object sender, EventArgs e)
        {
            string recipeid = dashboardProRecipeID.Text;
            findRecipeButton_Click(sender, e);//Simulate click on find recipe

            //Clear old values
            recipeNameBox.Clear();
            recipeDescription.Clear();
            recipeInsBox.Clear();
            recipeIngredientList.Items.Clear();

            //Populate with promoted recipe
            Recipe promoted = d.GetPromotedRecipe();
            recipeNameBox.Text = promoted.name;
            recipeDescription.Text = promoted.description;
            recipeInsBox.Text = promoted.instructions;
            foreach (Food i in promoted.ingredients)
                recipeIngredientList.Items.Add(i.name);

            //Switch to recipe tab
            tabControl1.SelectedIndex = 2;
        }
    }
}
