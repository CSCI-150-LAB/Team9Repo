using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrition
{
    class BMR_Calculator
    {
        private int heightIn = 0;
        private double weight = 0;
        private ActivityLevel levels;
        private string gender;
        private int age;

        public void SetGender(string gender)
        {
            if (gender == "male" || gender == "female")
            {
                this.gender = gender; //set private data 
            }
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public void SetActivityLevel(ActivityLevel levels)
        {
            this.levels = levels;
        }
        public ActivityLevel GetActivityLevels()
        {
            return levels;
        }

        public void SetHeight(int height)
        {
            heightIn = height;
        }

        public double GetHeight()
        {
            return heightIn;
        }

        public void SetWeight(double weight)
        {
            if (weight > 0)
                this.weight = weight;
        }

        public double GetWeight()
        {
            return weight;
        }

        public double CalculateBMR() //takes from database and assessment form
        {
            double bmr = 0.0;
            bmr = (4.536 * weight) + (15.88 * heightIn) - (5 * age) + 5; //calculate user BMR

            //  string sql = "SELECT * from [dbo].[Users] where [Gender] = @gender";

            //these are incomplete BMR's, no activity level
            if (gender == "Female")
            {
                return bmr - 161;
            }
            else
            {
                return bmr - 5;
            }

        }
        public double BMR_ActivityLevel() //takes the BMR and multiplies it by user activity level
        {
            double activeLevel = 0.0;

            if (levels == ActivityLevel.Zero)
            {
                activeLevel = 1.2;
            }
            else if (levels == ActivityLevel.Light)
            {
                activeLevel = 1.375;
            }
            else if (levels == ActivityLevel.Moderate)
            {
                activeLevel = 1.55;
            }
            else if (levels == ActivityLevel.Very)
            {
                activeLevel = 1.725;
            }
            else if (levels == ActivityLevel.Extra)
            {
                activeLevel = 1.9;
            }

            //this is complete BMR
            return CalculateBMR() * activeLevel;
        }
        
    /*    public void UpdateUser(string user, string height_feet, string height_inches, string weight, string bmr, string bmi)
        {
            string sql = "UPDATE [dbo].[Users] SET [height_feet] = @feet, " +
                "[height_inches] = @inches," +
                "[weight] = @weight," +
                "[bmr] = @bmr," +
                "[bmi] = @bmi WHERE [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@feet", height_feet);
                    command.Parameters.AddWithValue("@inches", height_inches);
                    command.Parameters.AddWithValue("@weight", weight);
                    command.Parameters.AddWithValue("@bmr", bmr);
                    command.Parameters.AddWithValue("@bmi", bmi);
                    command.Parameters.AddWithValue("@user", user);
                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        MessageBox.Show("Failed to update " + user);
                }
            }
        }*/
    }
}