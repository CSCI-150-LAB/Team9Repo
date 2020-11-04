using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nutrition
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database p = new Database();
            Hash q = new Hash(passwordBox.Text);

            //Change pass if you forget it :D
            //p.changePassword("Kyle", q.getHash());

            if (p.CheckUserExists(usernameBox.Text))
            {
                //get the password hash from the database
                string db_hash = p.GetPasswordHash(usernameBox.Text);

                //check if the hash matches
                if (q.verifyPassword(db_hash, passwordBox.Text))
                {
                    //Prepare an associative data (key,pair)
                    IDictionary<string, string> userData = p.GetUserData(usernameBox.Text);

                    //Show the secret area we logged in and pass the user data to it
                    Dashboard logged_in = new Dashboard(userData);
                    logged_in.Show();

                    //Update the last login to right now.
                    p.UpdateLastLogin(usernameBox.Text);

                    //Close this login window
                    this.Close();
                }
                else
                    invalidLogin.Text = "Invalid username or password";
            }
            else
                invalidLogin.Text = "Invalid username or password";

            //POWER ABUSE
            //p.makeAdmin("Kyle");
        }
    }
}
