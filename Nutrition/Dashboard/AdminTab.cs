using System;
using System.Data;
using System.Windows.Forms;

namespace Nutrition
{
    partial class Dashboard
    {
        private void adminFoodBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Access DataTable members
            DataRowView drv = (DataRowView)adminFoodBox1.SelectedItem;
            string food = drv["item_name"].ToString();
            string id = drv["id"].ToString();

            Food facts = searchLocalDB(int.Parse(id), food);//pre-fill the food item with database values
                                                            // Food facts = searchLocalDB(food);

            adminFoodName.Text = facts.name;
            adminFoodCals.Text = facts.calories.ToString();
            adminFoodFat.Text = facts.fat.ToString();
            adminFoodCarb.Text = facts.carbs.ToString();
            adminFoodPro.Text = facts.protein.ToString();
            adminFoodID.Text = id;

            int calories = facts.calories;
            double fat = facts.fat;
            double carb = facts.carbs;
            double pro = facts.protein;
            int[] allergies = facts.allergies;
            checkAdminAllergies(allergies);//fill in allergies
        }

        private void checkAdminAllergies(int[] allergies)
        {
            adminGluten1.Checked = false;
            adminNut1.Checked = false;
            adminFish1.Checked = false;
            adminDairy1.Checked = false;
            adminSoy1.Checked = false;
            if (allergies[0] == 1)
                adminGluten1.Checked = true;
            if (allergies[1] == 1)
                adminNut1.Checked = true;
            if (allergies[2] == 1)
                adminFish1.Checked = true;
            if (allergies[3] == 1)
                adminDairy1.Checked = true;
            if (allergies[4] == 1)
                adminSoy1.Checked = true;
        }

        private void adminNewFood_Click(object sender, EventArgs e)
        {
            string name = adminFoodName.Text;
            if (name.Trim().Length == 0) //No name don't insert
                return;
            string cals = adminFoodCals.Text;
            string fats = adminFoodFat.Text;
            string carbs = adminFoodCarb.Text;
            string proteins = adminFoodPro.Text;

            if (cals.Length == 0 || fats.Length == 0 || carbs.Length == 0 || proteins.Length == 0) //No values don't insert
                return;

            //We aren't checking for numeric inputs but if we need to sanitize data we can verify input by using TryParse()
            int calories = int.Parse(cals);
            double fat = double.Parse(fats);
            double carb = double.Parse(carbs);
            double pro = double.Parse(proteins);
            int[] allergies = { 0, 0, 0, 0, 0 };
            if (adminGluten1.Checked)
                allergies[0] = 1;
            if (adminNut1.Checked)
                allergies[1] = 1;
            if (adminFish1.Checked)
                allergies[2] = 1;
            if (adminDairy1.Checked)
                allergies[3] = 1;
            if (adminSoy1.Checked)
                allergies[4] = 1;
            Food ins = new Food(-1, name, calories, fat, pro, carb, allergies);
            d.InsertFood(ins);
            FillFoodData(); //update list
        }

        private void adminDeleteFood_Click(object sender, EventArgs e)
        {
            string id = adminFoodID.Text;
            if (id == "--")
                return;
            d.DeleteFood(int.Parse(id), adminFoodName.Text);
            FillFoodData(); //update list
            //Reset form
            adminFoodBox1.ResetText();
            adminFoodName.Clear();
            adminFoodCals.Clear();
            adminFoodFat.Clear();
            adminFoodCarb.Clear();
            adminFoodPro.Clear();
            adminFoodID.Text = "--";
        }

        private void adminUpdateFood_Click(object sender, EventArgs e)
        {
            string id = adminFoodID.Text;
            if (id == "--") //Item not set
                return;

            string name = adminFoodName.Text;
            string cals = adminFoodCals.Text;
            string fats = adminFoodFat.Text;
            string carbs = adminFoodCarb.Text;
            string proteins = adminFoodPro.Text;

            if (searchLocalDB(int.Parse(id), name) == null) //Item doesn't exist in the DB nothing to update
                return;

            int calories = int.Parse(cals);
            double fat = double.Parse(fats);
            double carb = double.Parse(carbs);
            double pro = double.Parse(proteins);
            int[] allergies = { 0, 0, 0, 0, 0 };
            if (adminGluten1.Checked)
                allergies[0] = 1;
            if (adminNut1.Checked)
                allergies[1] = 1;
            if (adminFish1.Checked)
                allergies[2] = 1;
            if (adminDairy1.Checked)
                allergies[3] = 1;
            if (adminSoy1.Checked)
                allergies[4] = 1;
            Food ins = new Food(int.Parse(id), name, calories, fat, pro, carb, allergies);
            d.UpdateFood(ins); //Update existing food item
            FillFoodData(); //update list
        }
        private void adminFoodName_Click(object sender, EventArgs e)
        {
            //Select all the text to make it easier to edit names
            adminFoodName.SelectAll();
            adminFoodName.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        /// Recipe Tab 
        ////////////////////////////////////////////////////////////////////////////////////////////

        private void adminRecipeBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            adminRecipeName.Clear();
            adminRecipeDesc.Clear();
            adminRecipeIns.Clear();
            adminRecipeItems.Items.Clear();

            //string name = ((DataRowView)recipeDropDown.SelectedItem)["name"].ToString();

            int index = adminRecipeBox1.SelectedIndex;

            adminRecipeName.Text = recipes[index].name;
            adminRecipeDesc.AppendText(recipes[index].description);
            adminRecipeIns.AppendText(recipes[index].instructions);
            foreach (Food item in recipes[index].ingredients)
                adminRecipeItems.Items.Add(item.name);
        }

        private void adminDeleteRecipe_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)adminRecipeBox1.SelectedItem;
            string food = drv["name"].ToString();
            string id = drv["recipeid"].ToString();
            int index = adminRecipeBox1.SelectedIndex;
            if (index > -1 && adminRecipeName.Text.Length > 0)
            {
                string maker = d.GetRecipeMaker(id);
                d.DeleteRecipe(id, maker);
                adminRecipeBox1.DataSource = d.getRecipeList();
                recipes = d.GetRecipeList();
                adminRecipeName.Clear();
                adminRecipeDesc.Clear();
                adminRecipeIns.Clear();
                adminRecipeItems.Items.Clear();
            }
        }

        private void adminDeleteRecipeIngredient_Click(object sender, EventArgs e)
        {
            int index = adminRecipeItems.SelectedIndex;
            if (index > -1)
            {
                adminRecipeItems.Items.RemoveAt(index);
                adminRecipeItems.SelectedIndex = index - 1;
            }
        }

        private void adminUpdateRecipe_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)adminRecipeBox1.SelectedItem;
            // string food = drv["name"].ToString();
            string id = drv["recipeid"].ToString();
            int index = adminRecipeBox1.SelectedIndex;
            if (index > -1 && adminRecipeName.Text.Length > 0)
            {
                if (adminRecipeName.Text.Length == 0)
                    MessageBox.Show("Error: Recipe needs a name");
                else if (adminRecipeDesc.Text.Length == 0)
                    MessageBox.Show("Error: Recipe needs a description");
                else if (adminRecipeIns.Text.Length == 0)
                    MessageBox.Show("Error: Recipe needs instructions");
                else if (adminRecipeItems.Items.Count == 0)
                    MessageBox.Show("Error: Recipe needs ingredients");
                else
                {
                    RecipeMaker p = new RecipeMaker(adminRecipeName.Text, adminRecipeDesc.Text, adminRecipeIns.Text);
                    foreach (string foods in adminRecipeItems.Items)
                    {
                        Food foodInfo = searchLocalDB(foods);
                        p.addIngredient(foodInfo);
                    }
                    d.UpdateRecipe(p.getRecipe(), id);
                    adminRecipeBox1.DataSource = d.getRecipeList();
                    recipes = d.GetRecipeList();
                    adminRecipeName.Clear();
                    adminRecipeDesc.Clear();
                    adminRecipeIns.Clear();
                    adminRecipeItems.Items.Clear();
                }
            }
        }

        private void adminPromoteRecipe_Click(object sender, EventArgs e)
        {
            //Update promotions table with recipe info
        }

        private void adminRecipeIng_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)adminRecipeIng.SelectedItem;
            string food = drv["item_name"].ToString();
            string id = drv["id"].ToString();
            adminRecipeItems.Items.Add(food);
        }
    }
}
