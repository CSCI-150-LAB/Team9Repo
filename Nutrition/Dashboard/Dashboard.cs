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
        private IDictionary<string, double> user_macro_sum;
        private DateTime last_login;
        private double userBMR;
        private double userBMI;
        private double userWeight;
        private int heightFeet;
        private int heightInch;
        private double calorieGoal;

        Database d = new Database();
        FoodEntry foodList = new FoodEntry();
        Food currentFood = null;
        private List<string> foodData = new List<string>();
        private List<Recipe> recipes = new List<Recipe>();
        private Timer t;

        public Dashboard(IDictionary<string, string> user)
        {
            username = user["username"];
            userData = d.GetUserData(username);
            userBMR = Double.Parse(userData["bmr"]);
            userBMI = Double.Parse(userData["bmi"]);
            userWeight = Double.Parse(userData["weight"]);
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
            plotBars();
            plotForms();
            refreshCalData();
            bmrHSlabel.Text = "BMR: " + userBMR;
            HSbmiLabel.Text = "Starting BMI: " + userBMI;
            HSweightLabel.Text = "Current Weight: " + userData["weight"];
            HSheightLabel.Text = "Height: " + heightFeet + "ft " + heightInch + "in";

           /* string[] weightGoals = new string[] { "Maintain", "Lose", "Gain" };
            goalChangeBox.DataSource = weightGoals;*/
            fixGoal();
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

            //Fill the drop down menus with food items
            FillFoodData();

            //Prefetch Data
            prefetch();
        }

        /**
         * Prefetch last 10 meals, user BMR data, and the sum of the past 24 hours of food macros
         */
        private void prefetch()
        {
            dataGridView1.DataSource = d.getLastTenMeals2(username);
            dataGridView1.Columns["usr"].Visible = false;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["date_logged"].Visible = false;

            //Prefetch user BMR and the sum of the past 24 hours of macro data
            userData = d.GetUserData(username);
            user_macro_sum = d.sumMacroData(username);
            double bmr = double.Parse(userData["bmr"]);
            bmrLabel.Text = Convert.ToInt32(bmr).ToString();
        }

        private void FillFoodData()
        {
            //Prefetch food box items from the database
            foodData = d.GetFoodItems();
            foreach (string name in foodData)
            {
                //Add items to the food box
                foodBox1.Items.Add(name);

                //Add food items to the recipe tab
                ingredientsDropDown.Items.Add(name);
            }

            //Prefetch recipes from the database
            recipes = d.GetRecipeList();
            recipeDropDown.DataSource = d.getRecipeList();
            recipeDropDown.DisplayMember = "name";
            recipeDropDown.ValueMember = "recipeid";
        }

        private void deleteMeal_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows
           .OfType<DataGridViewRow>()
           .Where(row => !row.IsNewRow)
           .ToArray();

            foreach (var row in selectedRows)
            {
                MessageBox.Show("Deleting: " + dataGridView1.SelectedRows[0].Cells["item_name"].Value.ToString());
                int item = -1;
                string val = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                bool parsed = Int32.TryParse(val, out item);
                if (parsed)
                {
                    d.DeleteFoodEntry(item, username);
                    dataGridView1.Rows.Remove(row);
                    prefetch();
                    plotBars();
                    plotForms();
                    refreshCalData();
                }
            }
        }

        //Prevent application from running in the background
        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
