using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nutrition
{
    public partial class Authenticated : Form
    {
        private string username;
        private IDictionary<string, string> userData;
        private DateTime join_date;
        private DateTime last_login;

        public Authenticated(IDictionary<string, string> user)
        {
            username = user["username"];
            Database p = new Database();
            userData = p.getUserData(username);
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
            statusBar1.Text = "Welcome " + getUser() + "! You last logged in " + getLastLogin();
        }

        public string getUser()
        {
            return username;
        }

        public DateTime getLastLogin()
        {
            return last_login;
        }

        private void statusBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
