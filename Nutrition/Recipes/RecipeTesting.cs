using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nutrition
{
    public partial class RecipeTesting : Form
    {
        Database d = new Database();
        public RecipeTesting()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<string> foood = d.GetFoodItems();
            foreach (string item in foood)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index > -1)
            {
                listBox1.Items.RemoveAt(index);
                listBox1.SelectedIndex = index - 1;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string food = comboBox1.SelectedItem.ToString();
            listBox1.Items.Add(food);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            RecipeMaker p = new RecipeMaker(textBox1.Text);
            foreach (string food in listBox1.Items)
            {
                List<string> foodInfo = d.GetFoodData(food);
                p.addIngredient(new Food(foodInfo[0], Int32.Parse(foodInfo[1]), Double.Parse(foodInfo[2]), Double.Parse(foodInfo[4]), Double.Parse(foodInfo[3]), Food.MealType.Dinner));
            }
            richTextBox1.AppendText(p.getRecipe().name);
            richTextBox1.AppendText("\n");
            foreach(Food f in p.getRecipe().ingredients)
            {
                richTextBox1.AppendText("["+f.name +"] Protein: " +f.protein);
                richTextBox1.AppendText("\n");
            }
        }
    }
}
