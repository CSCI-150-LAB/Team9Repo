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

        public Dashboard(IDictionary<string, string> user)
        {
            username = user["username"];
            Database p = new Database();
            userData = p.GetUserData(username);
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
            dashboardUser.Text = "Welcome, " + getUser();
            lastLoginLabel.Text = "You last logged in " + getLastLogin();
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

        private void logout_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //MessageBox.Show(e.ClickedItem.Text);
            Environment.Exit(0);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          //  MessageBox.Show(e.ClickedItem.Text);
            if(e.ClickedItem.Text == "Add Foods")
            {
                LogFood f = new LogFood(this.username);
                f.Show();
            }
            else if(e.ClickedItem.Text == "Health Summary")
            {
                Database bb = new Database();

                IDictionary<string,double> data = bb.sumMacroData(this.username);
                MessageBox.Show("Protein Sum: " + data["protein"] +"\nFat Sum: " + data["fat"]+"\nCarbs: "+data["carbs"]+"\nCalories: "+data["calories"]);
            }
        }

        private void statusBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void barsFormsPlot_Load_1(object sender, EventArgs e)
        {
            //needs to get from database - either calories from each or grams
            double[] y1Recomended = { 60, 35, 35 };
            double[] y1Below = { 44, 9, 19 };
            double[] y2Actual = { 60, 15, 40 };
            double[] xMacros = { 1, 2, 3 };

            // plot the data
            barsFormsPlot.Reset();

            //should generate "recomended range" based on user BMR
            //FIXME: make colors nicer
            barsFormsPlot.plt.PlotBar(xMacros, y1Recomended, null, "Recomended Range", barWidth: .3, xOffset: -.2);
            //below range
            barsFormsPlot.plt.PlotBar(xMacros, y1Below, null, null, barWidth: .3, xOffset: -.2);

            //User's entered macros
            barsFormsPlot.plt.PlotBar(xMacros, y2Actual, null, "Actual", barWidth: 0.3, xOffset: .2);

            string[] labels = { "Carbs", "Protein", "Fats" };
            barsFormsPlot.plt.Axis(y1: 0);
            barsFormsPlot.plt.Grid(enableVertical: false, lineStyle: LineStyle.Dot);
            barsFormsPlot.plt.Axis(y1: 0);
            barsFormsPlot.plt.Legend(location: legendLocation.upperRight);
            barsFormsPlot.plt.XTicks(xMacros, labels); //labels the 3 bars

            barsFormsPlot.Render();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
