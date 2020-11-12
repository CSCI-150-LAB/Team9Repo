namespace recipe
{
    partial class Form1
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
            this.label24 = new System.Windows.Forms.Label();
            this.totalSaltLbl = new System.Windows.Forms.Label();
            this.totalProteinLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.totalFibreLbl = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.totalSugarsLbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.totalCarbsLbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.totalSatFatLbl = new System.Windows.Forms.Label();
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
            this.saturatesTextBox = new System.Windows.Forms.TextBox();
            this.saltTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.sugarsTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.proteinTextBox = new System.Windows.Forms.TextBox();
            this.fibreTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
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
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.totalSaltLbl);
            this.panel1.Controls.Add(this.totalProteinLbl);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.totalFibreLbl);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.totalSugarsLbl);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.totalCarbsLbl);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.totalSatFatLbl);
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
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(193, 117);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(25, 13);
            this.label24.TabIndex = 35;
            this.label24.Text = "Salt";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalSaltLbl
            // 
            this.totalSaltLbl.AutoSize = true;
            this.totalSaltLbl.Location = new System.Drawing.Point(224, 117);
            this.totalSaltLbl.Name = "totalSaltLbl";
            this.totalSaltLbl.Size = new System.Drawing.Size(10, 13);
            this.totalSaltLbl.TabIndex = 36;
            this.totalSaltLbl.Text = "-";
            // 
            // totalProteinLbl
            // 
            this.totalProteinLbl.AutoSize = true;
            this.totalProteinLbl.Location = new System.Drawing.Point(224, 95);
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
            // totalFibreLbl
            // 
            this.totalFibreLbl.AutoSize = true;
            this.totalFibreLbl.Location = new System.Drawing.Point(224, 72);
            this.totalFibreLbl.Name = "totalFibreLbl";
            this.totalFibreLbl.Size = new System.Drawing.Size(10, 13);
            this.totalFibreLbl.TabIndex = 32;
            this.totalFibreLbl.Text = "-";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(178, 95);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 13);
            this.label22.TabIndex = 33;
            this.label22.Text = "Protein";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(188, 72);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(30, 13);
            this.label20.TabIndex = 31;
            this.label20.Text = "Fibre";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // totalSugarsLbl
            // 
            this.totalSugarsLbl.AutoSize = true;
            this.totalSugarsLbl.Location = new System.Drawing.Point(224, 50);
            this.totalSugarsLbl.Name = "totalSugarsLbl";
            this.totalSugarsLbl.Size = new System.Drawing.Size(10, 13);
            this.totalSugarsLbl.TabIndex = 30;
            this.totalSugarsLbl.Text = "-";
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Sat. Fat";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(178, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "Sugars";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalSatFatLbl
            // 
            this.totalSatFatLbl.AutoSize = true;
            this.totalSatFatLbl.Location = new System.Drawing.Point(57, 95);
            this.totalSatFatLbl.Name = "totalSatFatLbl";
            this.totalSatFatLbl.Size = new System.Drawing.Size(10, 13);
            this.totalSatFatLbl.TabIndex = 26;
            this.totalSatFatLbl.Text = "-";
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
            this.panel2.Controls.Add(this.saturatesTextBox);
            this.panel2.Controls.Add(this.saltTextBox);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.sugarsTextBox);
            this.panel2.Controls.Add(this.nameTextBox);
            this.panel2.Controls.Add(this.proteinTextBox);
            this.panel2.Controls.Add(this.fibreTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(15, 386);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(485, 281);
            this.panel2.TabIndex = 34;
            // 
            // deleteItem
            // 
            this.deleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteItem.Location = new System.Drawing.Point(302, 32);
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(95, 23);
            this.deleteItem.TabIndex = 31;
            this.deleteItem.Text = "Delete";
            this.deleteItem.UseVisualStyleBackColor = true;
            this.deleteItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(297, 237);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 36);
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
            this.addNewItemButton.Location = new System.Drawing.Point(300, 72);
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
            // saturatesTextBox
            // 
            this.saturatesTextBox.Location = new System.Drawing.Point(17, 237);
            this.saturatesTextBox.Name = "saturatesTextBox";
            this.saturatesTextBox.Size = new System.Drawing.Size(100, 20);
            this.saturatesTextBox.TabIndex = 5;
            this.saturatesTextBox.TextChanged += new System.EventHandler(this.saturatesTextBox_TextChanged);
            // 
            // saltTextBox
            // 
            this.saltTextBox.Location = new System.Drawing.Point(300, 197);
            this.saltTextBox.Name = "saltTextBox";
            this.saltTextBox.Size = new System.Drawing.Size(100, 20);
            this.saltTextBox.TabIndex = 6;
            this.saltTextBox.TextChanged += new System.EventHandler(this.saltTextBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Name this item";
            // 
            // sugarsTextBox
            // 
            this.sugarsTextBox.Location = new System.Drawing.Point(157, 197);
            this.sugarsTextBox.Name = "sugarsTextBox";
            this.sugarsTextBox.Size = new System.Drawing.Size(100, 20);
            this.sugarsTextBox.TabIndex = 8;
            this.sugarsTextBox.TextChanged += new System.EventHandler(this.sugarsTextBox_TextChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.nameTextBox.Location = new System.Drawing.Point(20, 93);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(256, 20);
            this.nameTextBox.TabIndex = 21;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // proteinTextBox
            // 
            this.proteinTextBox.Location = new System.Drawing.Point(300, 161);
            this.proteinTextBox.Name = "proteinTextBox";
            this.proteinTextBox.Size = new System.Drawing.Size(100, 20);
            this.proteinTextBox.TabIndex = 9;
            this.proteinTextBox.TextChanged += new System.EventHandler(this.proteinTextBox_TextChanged);
            // 
            // fibreTextBox
            // 
            this.fibreTextBox.Location = new System.Drawing.Point(157, 237);
            this.fibreTextBox.Name = "fibreTextBox";
            this.fibreTextBox.Size = new System.Drawing.Size(100, 20);
            this.fibreTextBox.TabIndex = 10;
            this.fibreTextBox.TextChanged += new System.EventHandler(this.fibreTextBox_TextChanged);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(297, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Salt";
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
            this.label7.Location = new System.Drawing.Point(297, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Protein";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Saturated Fat";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(154, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Fibre";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Sugars";
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
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label totalSaltLbl;
        private System.Windows.Forms.Label totalProteinLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label totalFibreLbl;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label totalSugarsLbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label totalCarbsLbl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label totalSatFatLbl;
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
        private System.Windows.Forms.TextBox saturatesTextBox;
        private System.Windows.Forms.TextBox saltTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox sugarsTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox proteinTextBox;
        private System.Windows.Forms.TextBox fibreTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

