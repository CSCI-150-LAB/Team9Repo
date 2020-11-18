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

            List<Recipe> recipes = d.GetRecipeList();
            foreach (Recipe item in recipes)
            {
                comboBox2.Items.Add(item.name);
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

            RecipeMaker p = new RecipeMaker(textBox1.Text, descriptionBox.Text,instructionBox.Text);
            foreach (string food in listBox1.Items)
            {
                List<string> foodInfo = d.GetFoodData(food);
                p.addIngredient(new Food(foodInfo[0], Int32.Parse(foodInfo[1]), Double.Parse(foodInfo[2]), Double.Parse(foodInfo[4]), Double.Parse(foodInfo[3]), Food.MealType.Dinner));
            }
            d.InsertRecipe("Kyle", p.getRecipe().name,p.getRecipe().description,p.getRecipe().instructions, p.getRecipe().ingredients);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Recipe> recipes = d.GetRecipeList();
            textBox1.Text = recipes[2].name;
            descriptionBox.AppendText(recipes[2].description);
            instructionBox.AppendText(recipes[2].instructions);
            foreach (Food item in recipes[2].ingredients)
                listBox1.Items.Add(item.name);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
