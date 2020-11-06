using System;
using System.Collections.Generic;
using System.Text;

namespace UserAssessment
{
    class BMI_Calculator
    {
        private int height;
        private int weight;
        private double UserBMI;

        public void CalculateUserBMI()
        {
            UserBMI = Convert.ToDouble((703 * weight) / (height * height));

        }
    }
}
