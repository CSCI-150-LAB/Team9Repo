using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace food
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Allergies_Enter(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
                IDictionary<string, string> register = new Dictionary<string, string>();
                register['FoodName'] = FoodName.Text;
                register['Calories'] = calories.Text;
                register['Protein'] = protein.Text;
                register['Carbohydrates'] = carbs.Text;
                register['Fats'] = fats.Text;
                register['Allergies'] = Allergies_Enter;
            //Connect to database 

            Database p = new Database();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
