using Nutrition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//set height x
//set weight x
//set age x
//set gender x
//set activity level x

namespace Nutrition
{
    public partial class UserAssessment : Form
    {
        private BMR_Calculator bmrCalculator = new BMR_Calculator();
        private Database database = new Database();
        private string username;
        public UserAssessment(string username)
        {
            this.username = username;
            InitializeComponent();
            InitializeGUI();
        }

        //Initialize start up settings of the GUI
        private void InitializeGUI()
        {
            this.Text = "Registration";
            radioButtonAct1.Checked = true; //defaulted to the lowest activity level
        }

        private void InputAge()
        {
            //convert to int type and send to BMR class
            int userAge = Convert.ToInt32(numericUpDownAge.Value);
            bmrCalculator.SetAge(userAge);
        }

        private void InputGender()
        {
            //set the gender variable in BMR class
            if(radioButtonMale.Checked)
            {
                bmrCalculator.SetGender("male");
            }
            else if(radioButtonFemale.Checked)
            {
                bmrCalculator.SetGender("female");
            }
        }

        private void InputHeightInches()
        {
            //converts the numericUpDown values to ints
            int feet = Convert.ToInt32(numericUpDownFeet.Value);
            int inches = Convert.ToInt32(numericUpDownInch.Value);

            //calculate total height in inches, easier for BMR/BMI equations 
            int totalHeight = inches + (feet * 12);
            //send the value to the BMR class
            bmrCalculator.SetHeight(totalHeight);
        }

        private void InputWeight()
        {
            //convert to usable type
            double weightInPounds = Convert.ToDouble(numericUpDownPounds.Value);
            //send to BMR class
            bmrCalculator.SetWeight(weightInPounds);
        }

        //set the user selected value
        private void ActivityLevelCheck()
        {
            if (radioButtonAct1.Checked)
                bmrCalculator.SetActivityLevel(ActivityLevel.Zero);
            else if (radioButtonAct2.Checked)
                bmrCalculator.SetActivityLevel(ActivityLevel.Light);
            else if (radioButtonAct3.Checked)
                bmrCalculator.SetActivityLevel(ActivityLevel.Moderate);
            else if (radioButtonAct4.Checked)
                bmrCalculator.SetActivityLevel(ActivityLevel.Very);
            else if (radioButtonAct5.Checked)
                bmrCalculator.SetActivityLevel(ActivityLevel.Extra);
        }
        private void buttonRegister2_Click(object sender, EventArgs e)
        {
            //Call functions to grab form data
            InputHeightInches();
            InputAge();
            InputWeight();
            InputGender();
            ActivityLevelCheck();
            bmrCalculator.CalculateBMI();
            bmrCalculator.CalculateBMR();

            //debug
            MessageBox.Show("Username: " + username + "\nHeight: " + bmrCalculator.GetHeight() + "\n" +
                "Age: " + numericUpDownAge.Value + "\n" +
                "Weight: " + bmrCalculator.GetWeight() + "\n" +
                "Activity level val: " + bmrCalculator.GetBMR());

            //when "Complete Registration" button is clicked, data saved to database
            //FIXME needs to get username from the registration form
            database.FINISH_HIM(username, bmrCalculator.GetAge(), bmrCalculator.GetGender(), bmrCalculator.GetHeight(),
                bmrCalculator.GetWeight(), bmrCalculator.GetBMR(), bmrCalculator.GetBMI());
        }
    }
}
