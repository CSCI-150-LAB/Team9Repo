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
        private DateTime join_date;
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
            dashboardUser.Text = "Welcome " + getUser();
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
    }
}
