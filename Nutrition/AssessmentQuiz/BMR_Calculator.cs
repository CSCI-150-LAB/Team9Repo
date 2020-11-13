using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrition
{
    class BMR_Calculator //also does BMI
    {
        private int heightIn = 0;
        private double weight = 0;
        private ActivityLevel levels;
        private string gender;
        private int age;
        private double BMI;
        private double BMR;

        public void SetGender(string gender)
        {
            if (gender == "male" || gender == "female")
            {
                this.gender = gender; //set private data 
            }
        }

        public string GetGender()
        {
            return gender;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public int GetAge()
        {
            return age;
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

        public void CalculateBMR() //takes from database and assessment form
        {
            double bmr = 0.0;

            //calculate user BMR without activity level
            bmr = (4.536 * weight) + (15.88 * heightIn) - (5 * age) + 5; 

            if (gender == "Female")
            {
                bmr = bmr - 161;
            }
            else
            {
                bmr = bmr - 5;
            }

            //multiply by activity level
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
            BMR = bmr * activeLevel;
        }
        
        public double GetBMR()
        {
            return BMR;
        }

        //calcuate user BMI
        public void CalculateBMI()
        {
            BMI = (weight * 703) / (heightIn * heightIn);
        }

        public double GetBMI()
        {
            return BMI;
        }
    }
}