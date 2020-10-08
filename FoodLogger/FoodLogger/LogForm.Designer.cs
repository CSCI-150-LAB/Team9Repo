namespace FoodLogger
{
    partial class LogForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.foodBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.calorieBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fatBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.carbBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.proteinBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.targetLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.foodItems = new System.Windows.Forms.ListBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bmrLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.foodBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find Food";
            // 
            // foodBox
            // 
            this.foodBox.FormattingEnabled = true;
            this.foodBox.Location = new System.Drawing.Point(6, 22);
            this.foodBox.Name = "foodBox";
            this.foodBox.Size = new System.Drawing.Size(158, 23);
            this.foodBox.TabIndex = 0;
            this.foodBox.SelectedIndexChanged += new System.EventHandler(this.foodBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 201);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nutrition Entry";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.nameBox);
            this.flowLayoutPanel1.Controls.Add(this.calorieBox);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.fatBox);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.carbBox);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.proteinBox);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(152, 171);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(5, 5);
            this.nameBox.Margin = new System.Windows.Forms.Padding(5);
            this.nameBox.Name = "nameBox";
            this.nameBox.PlaceholderText = "Name";
            this.nameBox.Size = new System.Drawing.Size(86, 23);
            this.nameBox.TabIndex = 0;
            // 
            // calorieBox
            // 
            this.calorieBox.Location = new System.Drawing.Point(5, 38);
            this.calorieBox.Margin = new System.Windows.Forms.Padding(5);
            this.calorieBox.Name = "calorieBox";
            this.calorieBox.PlaceholderText = "Calories";
            this.calorieBox.Size = new System.Drawing.Size(86, 23);
            this.calorieBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 9, 5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "kcals";
            // 
            // fatBox
            // 
            this.fatBox.Location = new System.Drawing.Point(3, 69);
            this.fatBox.Name = "fatBox";
            this.fatBox.PlaceholderText = "Fat";
            this.fatBox.Size = new System.Drawing.Size(88, 23);
            this.fatBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 7, 5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "g";
            // 
            // carbBox
            // 
            this.carbBox.Location = new System.Drawing.Point(3, 98);
            this.carbBox.Name = "carbBox";
            this.carbBox.PlaceholderText = "Carbs";
            this.carbBox.Size = new System.Drawing.Size(88, 23);
            this.carbBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 7, 5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "g";
            // 
            // proteinBox
            // 
            this.proteinBox.Location = new System.Drawing.Point(3, 127);
            this.proteinBox.Name = "proteinBox";
            this.proteinBox.PlaceholderText = "Protein";
            this.proteinBox.Size = new System.Drawing.Size(88, 23);
            this.proteinBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 7, 5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "g";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.targetLabel);
            this.groupBox3.Location = new System.Drawing.Point(202, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(101, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total Calories";
            // 
            // targetLabel
            // 
            this.targetLabel.AutoSize = true;
            this.targetLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetLabel.Location = new System.Drawing.Point(24, 19);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(48, 28);
            this.targetLabel.TabIndex = 0;
            this.targetLabel.Text = "N/A";
            this.targetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.removeButton);
            this.groupBox4.Controls.Add(this.clearButton);
            this.groupBox4.Controls.Add(this.foodItems);
            this.groupBox4.Location = new System.Drawing.Point(202, 75);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(198, 271);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Items";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(109, 242);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(6, 242);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear All";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // foodItems
            // 
            this.foodItems.FormattingEnabled = true;
            this.foodItems.ItemHeight = 15;
            this.foodItems.Location = new System.Drawing.Point(6, 22);
            this.foodItems.Name = "foodItems";
            this.foodItems.Size = new System.Drawing.Size(178, 214);
            this.foodItems.TabIndex = 0;
            this.foodItems.SelectedIndexChanged += new System.EventHandler(this.foodItems_SelectedIndexChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(313, 372);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 36);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bmrLabel);
            this.groupBox5.Location = new System.Drawing.Point(313, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(87, 57);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "BMR";
            // 
            // bmrLabel
            // 
            this.bmrLabel.AutoSize = true;
            this.bmrLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bmrLabel.Location = new System.Drawing.Point(25, 19);
            this.bmrLabel.Name = "bmrLabel";
            this.bmrLabel.Size = new System.Drawing.Size(48, 28);
            this.bmrLabel.TabIndex = 0;
            this.bmrLabel.Text = "N/A";
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 420);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Log";
            this.Text = "Nutrition Log";
            this.Load += new System.EventHandler(this.Log_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox foodBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox foodItems;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox calorieBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fatBox;
        private System.Windows.Forms.TextBox carbBox;
        private System.Windows.Forms.TextBox proteinBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label bmrLabel;
    }
}

