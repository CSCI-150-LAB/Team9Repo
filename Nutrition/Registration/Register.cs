﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nutrition
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        //used to determine if username entered is valid before continuing or displaying anything?

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text.Length <= 0 || (usernameBox.Text.Contains(" ")))
            {
                invalidLbl.Text = "Invalid username, please try again!";
                return;
            }
            if (passwordBox.Text.Length < 8 || passwordBox.Text.Length > 64 || passwordBox.Text.Contains(" "))
            {
                invalidLbl.Text = "Please enter a valid password";
                return;
            }

            Hash pass = new Hash(passwordBox.Text);
            Hash confirmP = new Hash(confirmPass.Text);

            if (!pass.verifyPassword(confirmP.getHash(), passwordBox.Text))
            {
                invalidLbl.Text = "Passwords must match!";
                return;
            }

            //Create an associative array to easily keep track of form items
            IDictionary<string, string> register = new Dictionary<string, string>();
            register["username"] = usernameBox.Text;
            register["password"] = pass.getHash();

            //default 0 to no admin privilege
            register["admin"] = "0";

            //Initially set all food allergies to 0 for false
            register["gluten"] = "0";
            register["peanut"] = "0";
            register["fish"] = "0";
            register["soy"] = "0";
            register["dairy"] = "0";

            //then check if any boxes were checked and mark those true
            if (dairyBox.Checked) {
                register["dairy"] = "1";
            }
            if (glutenBox.Checked)
            {
                register["gluten"] = "1";
            }
            if (peanutBox.Checked)
            {
                register["peanut"] = "1";
            }
            if (fishBox.Checked)
            {
                register["fish"] = "1";
            }
            if (soyBox.Checked)
            {
                register["soy"] = "1";
            }

            //Connect to database and register the user
            Database p = new Database();

            //Check if the user exists before registering
            if (!p.CheckUserExists(usernameBox.Text))
            {
                //pass the associative array to the register function
                p.RegisterUser(register);
                UserAssessment begin = new UserAssessment(usernameBox.Text);
                begin.Show();
                this.Close();
            }
            else
            {
                invalidLbl.Text = "User already exists try a different name";
            }
        }
    }
}
