namespace recipe
{
    partial class RecipeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.nutritionItemId = new System.Windows.Forms.Label();
            this.RecipeName = new System.Windows.Forms.TextBox();
            this.RecipeInfo = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.totalProteinLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.totalCarbsLbl = new System.Windows.Forms.Label();
            this.totalFatLbl = new System.Windows.Forms.Label();
            this.totalCalLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.deleteItem = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.addNewItemButton = new System.Windows.Forms.Button();
            this.carbsTextBox = new System.Windows.Forms.TextBox();
            this.pastItemsCombo = new System.Windows.Forms.ComboBox();
            this.caloriesTextBox = new System.Windows.Forms.TextBox();
            this.fatTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.proteinTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addFoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recipeSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.healthSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.addFoodToolStripMenuItem,
            this.recipeSearchToolStripMenuItem,
            this.healthSummaryToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(519, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "&Exit";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.helpToolStripMenuItem.Text = "&Dashboard";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 27);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(485, 20);
            this.dateTimePicker.TabIndex = 20;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // nutritionItemId
            // 
            this.nutritionItemId.AutoSize = true;
            this.nutritionItemId.Location = new System.Drawing.Point(12, 60);
            this.nutritionItemId.Name = "nutritionItemId";
            this.nutritionItemId.Size = new System.Drawing.Size(64, 13);
            this.nutritionItemId.TabIndex = 24;
            this.nutritionItemId.Text = "Find Recipe";
            this.nutritionItemId.Visible = false;
            // 
            // RecipeName
            // 
            this.RecipeName.Location = new System.Drawing.Point(82, 57);
            this.RecipeName.Name = "RecipeName";
            this.RecipeName.Size = new System.Drawing.Size(418, 20);
            this.RecipeName.TabIndex = 31;
            this.RecipeName.TextChanged += new System.EventHandler(this.RecipeName_TextChanged_1);
            // 
            // RecipeInfo
            // 
            this.RecipeInfo.FormattingEnabled = true;
            this.RecipeInfo.Location = new System.Drawing.Point(15, 83);
            this.RecipeInfo.Name = "RecipeInfo";
            this.RecipeInfo.Size = new System.Drawing.Size(485, 134);
            this.RecipeInfo.TabIndex = 32;
            this.RecipeInfo.SelectedIndexChanged += new System.EventHandler(this.RecipeInfo_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.totalProteinLbl);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.totalCarbsLbl);
            this.panel1.Controls.Add(this.totalFatLbl);
            this.panel1.Controls.Add(this.totalCalLbl);
            this.panel1.Location = new System.Drawing.Point(15, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 146);
            this.panel1.TabIndex = 33;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 117);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Carbs";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalProteinLbl
            // 
            this.totalProteinLbl.AutoSize = true;
            this.totalProteinLbl.Location = new System.Drawing.Point(57, 95);
            this.totalProteinLbl.Name = "totalProteinLbl";
            this.totalProteinLbl.Size = new System.Drawing.Size(10, 13);
            this.totalProteinLbl.TabIndex = 34;
            this.totalProteinLbl.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Macro Information";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(17, 95);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 13);
            this.label22.TabIndex = 33;
            this.label22.Text = "Protein";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Calories";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Fat";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalCarbsLbl
            // 
            this.totalCarbsLbl.AutoSize = true;
            this.totalCarbsLbl.Location = new System.Drawing.Point(57, 117);
            this.totalCarbsLbl.Name = "totalCarbsLbl";
            this.totalCarbsLbl.Size = new System.Drawing.Size(10, 13);
            this.totalCarbsLbl.TabIndex = 28;
            this.totalCarbsLbl.Text = "-";
            // 
            // totalFatLbl
            // 
            this.totalFatLbl.AutoSize = true;
            this.totalFatLbl.Location = new System.Drawing.Point(57, 72);
            this.totalFatLbl.Name = "totalFatLbl";
            this.totalFatLbl.Size = new System.Drawing.Size(10, 13);
            this.totalFatLbl.TabIndex = 24;
            this.totalFatLbl.Text = "-";
            // 
            // totalCalLbl
            // 
            this.totalCalLbl.AutoSize = true;
            this.totalCalLbl.Location = new System.Drawing.Point(57, 50);
            this.totalCalLbl.Name = "totalCalLbl";
            this.totalCalLbl.Size = new System.Drawing.Size(10, 13);
            this.totalCalLbl.TabIndex = 22;
            this.totalCalLbl.Text = "-";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.deleteItem);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.addNewItemButton);
            this.panel2.Controls.Add(this.carbsTextBox);
            this.panel2.Controls.Add(this.pastItemsCombo);
            this.panel2.Controls.Add(this.caloriesTextBox);
            this.panel2.Controls.Add(this.fatTextBox);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.nameTextBox);
            this.panel2.Controls.Add(this.proteinTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(15, 386);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(485, 281);
            this.panel2.TabIndex = 34;
            // 
            // deleteItem
            // 
            this.deleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteItem.Location = new System.Drawing.Point(282, 115);
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(100, 82);
            this.deleteItem.TabIndex = 31;
            this.deleteItem.Text = "Delete";
            this.deleteItem.UseVisualStyleBackColor = true;
            this.deleteItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(14, 234);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(150, 36);
            this.label17.TabIndex = 30;
            this.label17.Text = "Amounts should be in grams";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Choose an existing item:";
            // 
            // addNewItemButton
            // 
            this.addNewItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewItemButton.Location = new System.Drawing.Point(282, 34);
            this.addNewItemButton.Name = "addNewItemButton";
            this.addNewItemButton.Size = new System.Drawing.Size(100, 58);
            this.addNewItemButton.TabIndex = 1;
            this.addNewItemButton.Text = "Add";
            this.addNewItemButton.UseVisualStyleBackColor = true;
            this.addNewItemButton.Click += new System.EventHandler(this.addNewItemButton_Click);
            // 
            // carbsTextBox
            // 
            this.carbsTextBox.Location = new System.Drawing.Point(157, 161);
            this.carbsTextBox.Name = "carbsTextBox";
            this.carbsTextBox.Size = new System.Drawing.Size(100, 20);
            this.carbsTextBox.TabIndex = 2;
            this.carbsTextBox.TextChanged += new System.EventHandler(this.carbsTextBox_TextChanged);
            // 
            // pastItemsCombo
            // 
            this.pastItemsCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.pastItemsCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pastItemsCombo.FormattingEnabled = true;
            this.pastItemsCombo.Location = new System.Drawing.Point(16, 34);
            this.pastItemsCombo.Name = "pastItemsCombo";
            this.pastItemsCombo.Size = new System.Drawing.Size(260, 21);
            this.pastItemsCombo.TabIndex = 26;
            this.pastItemsCombo.SelectedIndexChanged += new System.EventHandler(this.pastItemsCombo_SelectedIndexChanged);
            // 
            // caloriesTextBox
            // 
            this.caloriesTextBox.Location = new System.Drawing.Point(17, 161);
            this.caloriesTextBox.Name = "caloriesTextBox";
            this.caloriesTextBox.Size = new System.Drawing.Size(100, 20);
            this.caloriesTextBox.TabIndex = 3;
            this.caloriesTextBox.TextChanged += new System.EventHandler(this.caloriesTextBox_TextChanged);
            // 
            // fatTextBox
            // 
            this.fatTextBox.Location = new System.Drawing.Point(17, 197);
            this.fatTextBox.Name = "fatTextBox";
            this.fatTextBox.Size = new System.Drawing.Size(100, 20);
            this.fatTextBox.TabIndex = 4;
            this.fatTextBox.TextChanged += new System.EventHandler(this.fatTextBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Name this item";
            // 
            // nameTextBox
            // 
            this.nameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.nameTextBox.Location = new System.Drawing.Point(16, 92);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(256, 20);
            this.nameTextBox.TabIndex = 21;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // proteinTextBox
            // 
            this.proteinTextBox.Location = new System.Drawing.Point(157, 197);
            this.proteinTextBox.Name = "proteinTextBox";
            this.proteinTextBox.Size = new System.Drawing.Size(100, 20);
            this.proteinTextBox.TabIndex = 9;
            this.proteinTextBox.TextChanged += new System.EventHandler(this.proteinTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Calories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Fat";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Protein";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Carbohydrates";
            // 
            // addFoodToolStripMenuItem
            // 
            this.addFoodToolStripMenuItem.Name = "addFoodToolStripMenuItem";
            this.addFoodToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.addFoodToolStripMenuItem.Text = "&Add Food";
            // 
            // recipeSearchToolStripMenuItem
            // 
            this.recipeSearchToolStripMenuItem.Name = "recipeSearchToolStripMenuItem";
            this.recipeSearchToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.recipeSearchToolStripMenuItem.Text = "&Recipe Search";
            // 
            // healthSummaryToolStripMenuItem
            // 
            this.healthSummaryToolStripMenuItem.Name = "healthSummaryToolStripMenuItem";
            this.healthSummaryToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.healthSummaryToolStripMenuItem.Text = "&Health Summary";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 721);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RecipeInfo);
            this.Controls.Add(this.RecipeName);
            this.Controls.Add(this.nutritionItemId);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Recipe Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label nutritionItemId;
        private System.Windows.Forms.TextBox RecipeName;
        private System.Windows.Forms.ListBox RecipeInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label totalProteinLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label totalCarbsLbl;
        private System.Windows.Forms.Label totalFatLbl;
        private System.Windows.Forms.Label totalCalLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button deleteItem;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button addNewItemButton;
        private System.Windows.Forms.TextBox carbsTextBox;
        private System.Windows.Forms.ComboBox pastItemsCombo;
        private System.Windows.Forms.TextBox caloriesTextBox;
        private System.Windows.Forms.TextBox fatTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox proteinTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem addFoodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recipeSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem healthSummaryToolStripMenuItem;
    }
}

