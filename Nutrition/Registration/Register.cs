using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debug information: " + "\n" + "Username: " + usernameBox.Text + "\n" + "Allergies Selected: " + allergiesToString());

            Hash pass = new Hash(passwordBox.Text);

            //Create an associative array to easily keep track of form items
            IDictionary<string, string> register = new Dictionary<string, string>();
            register["username"] = usernameBox.Text;
            register["password"] = pass.getHash();

            //default 0 to no admin privilege
            register["admin"] = "0";

            //Convert selected food allergies into a list
            List<string> allergies = allergiesToString().Split(',').ToList();

            //Initially set all food allergies to 0 for false
            register["gluten"] = "0";
            register["peanut"] = "0";
            register["fish"] = "0";
            register["soy"] = "0";
            register["dairy"] = "0";


            for (int i = 0; i < allergies.Count; i++)
            {
                //No allergies break loop
                if (allergies[i] == "(None)")
                    break;

                //Some allergies set them to 1 for true
                switch (allergies[i])
                {
                    case "Gluten":
                        register["gluten"] = "1";
                        break;
                    case "Peanut":
                        register["peanut"] = "1";
                        break;
                    case "Fish":
                        register["fish"] = "1";
                        break;
                    case "Soy":
                        register["soy"] = "1";
                        break;
                    case "Dairy":
                        register["dairy"] = "1";
                        break;
                }
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
                MessageBox.Show("User already exists try a different name");
            }
        }

        //Convert selected allergy items (from the combo box) to a string
        private String allergiesToString()
        {
            var arr = allergyBox.SelectedItems.Cast<Object>().Select(item => item.ToString()).ToArray();
            String items = "";
            if (arr.Length == 0)
                return "(None)";
            else
                for (int i = 0; i < arr.Length; i++)
                {
                    items += arr[i];
                    if (i + 1 < arr.Length)
                        items += ",";
                }
            return items;
        }
    }
}
