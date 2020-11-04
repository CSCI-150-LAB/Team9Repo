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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Username: " + usernameBox.Text + "\r\n" + "Password: " + passwordBox.Text);//Debug
            Database p = new Database();
            Hash q = new Hash(passwordBox.Text);

            //Change pass if you forget it :D
            //p.changePassword("Kyle", q.getHash());

            if (p.checkUserExists(usernameBox.Text))
            {
                //get the password hash from the database
                string db_hash = p.getPasswordHash(usernameBox.Text);

                //check if the hash matches
                if (q.verifyPassword(db_hash, passwordBox.Text))
                {
                    MessageBox.Show("Passwords match!");

                    //Prepare an associative data (key,pair)
                    IDictionary<string, string> userData = p.getUserData(usernameBox.Text + "1");

                    //Update the last login to right now.
                    p.updateLastLogin(usernameBox.Text);

                    //Show the secret area we logged in and pass the user data to it
                    Authenticated logged_in = new Authenticated(userData);
                    logged_in.Show();

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
