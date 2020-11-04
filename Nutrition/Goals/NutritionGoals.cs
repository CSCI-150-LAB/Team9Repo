using Nutrition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NutritionLog
{//TODO: If losing/gaining/maintaining do something
    class NutritionGoals
    {
        private int bmi, bmr;
        private string username;

        public enum Status { Maintenance, Lose_it, Gain };
        public NutritionGoals(string username, Status status)
        {
            this.username = username;
            //Pull BMI/BMR from DB
            Database d = new Database();
            bmr = d.GetBMR(username);
            bmi = d.GetBMI(username);
        }

        //Set a goal and save it to the database
        public void setGoal(int calories)
        {
            Database d = new Database();
            d.SetGoal(username,calories);
        }

        //Return a percentage value without the % sign
        //TODO: Use this with the graph class
        public int getGoalProgress()
        {
            Database d = new Database();
            int total = d.GetGoal(username);
            int current = d.sumUserCalories(username);
            if(total == 0)
            {
                return -1;
            }
            else
            {
                return (current / total) * 100;
            }
        }


        //Get & Set BMI
        public int BMI
        {
            get { return bmi; }
            set { bmi = value; }
        }

        //Get & Set BMR
        public int BMR
        {
            get { return bmr; }
            set { bmr = value; }
        }

    }
}
