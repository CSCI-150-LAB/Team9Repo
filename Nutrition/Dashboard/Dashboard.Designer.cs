namespace Nutrition
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.userDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.helpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lastLoginLabel = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.consumedBox = new System.Windows.Forms.CheckedListBox();
            this.weightFormsPlot = new ScottPlot.FormsPlot();
            this.barsFormsPlot = new ScottPlot.FormsPlot();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.foodBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.calorieBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fatBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.carbBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.proteinBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.targetLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.foodItems = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bmrLabel = new System.Windows.Forms.Label();
            this.saveFoodButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.goalChangeBox = new System.Windows.Forms.ComboBox();
            this.goalChangeLabel = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.HSweightLabel = new System.Windows.Forms.Label();
            this.HSheightLabel = new System.Windows.Forms.Label();
            this.bmrHSlabel = new System.Windows.Forms.Label();
            this.HSbmiLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.healthWelcome = new System.Windows.Forms.StatusStrip();
            this.healthUserWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.calRemainLabel = new System.Windows.Forms.Label();
            this.calEatenLabel = new System.Windows.Forms.Label();
            this.calGoalLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.exitButton = new System.Windows.Forms.Button();
            this.statusBar.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.healthWelcome.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userDropDown,
            this.dateLabel});
            this.statusBar.Location = new System.Drawing.Point(6, 6);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(2, 0, 26, 0);
            this.statusBar.Size = new System.Drawing.Size(1766, 62);
            this.statusBar.TabIndex = 2;
            // 
            // userDropDown
            // 
            this.userDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.userDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpItem,
            this.logoutItem});
            this.userDropDown.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userDropDown.Image = ((System.Drawing.Image)(resources.GetObject("userDropDown.Image")));
            this.userDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.userDropDown.Name = "userDropDown";
            this.userDropDown.Size = new System.Drawing.Size(72, 58);
            this.userDropDown.Text = "...";
            this.userDropDown.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.dropDownItem_Click);
            // 
            // helpItem
            // 
            this.helpItem.Name = "helpItem";
            this.helpItem.Size = new System.Drawing.Size(291, 62);
            this.helpItem.Text = "Help";
            // 
            // logoutItem
            // 
            this.logoutItem.Name = "logoutItem";
            this.logoutItem.Size = new System.Drawing.Size(291, 62);
            this.logoutItem.Text = "Logout";
            // 
            // dateLabel
            // 
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(1666, 52);
            this.dateLabel.Spring = true;
            this.dateLabel.Text = "dateLabel";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastLoginLabel});
            this.toolStrip1.Location = new System.Drawing.Point(6, 1267);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1766, 38);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lastLoginLabel
            // 
            this.lastLoginLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lastLoginLabel.Name = "lastLoginLabel";
            this.lastLoginLabel.Size = new System.Drawing.Size(121, 32);
            this.lastLoginLabel.Text = "Last Login";
            this.lastLoginLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 3;
            this.tabControl1.Size = new System.Drawing.Size(1794, 1365);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.weightFormsPlot);
            this.tabPage1.Controls.Add(this.barsFormsPlot);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.statusBar);
            this.tabPage1.Location = new System.Drawing.Point(8, 46);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Size = new System.Drawing.Size(1778, 1311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dashboard";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(15, 614);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(869, 614);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recipe?";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.consumedBox);
            this.groupBox1.Location = new System.Drawing.Point(899, 614);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(869, 614);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Food Quickview";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(505, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Last 10 Meals";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(124, 41);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 32);
            this.label14.TabIndex = 5;
            this.label14.Text = "Lunch";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(210, 41);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 32);
            this.label13.TabIndex = 4;
            this.label13.Text = "Dinner";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 41);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 32);
            this.label12.TabIndex = 3;
            this.label12.Text = "Breakfast";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 553);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(353, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "Delete Selected";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.deleteMeal_Click);
            // 
            // consumedBox
            // 
            this.consumedBox.FormattingEnabled = true;
            this.consumedBox.Location = new System.Drawing.Point(505, 85);
            this.consumedBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.consumedBox.Name = "consumedBox";
            this.consumedBox.Size = new System.Drawing.Size(349, 400);
            this.consumedBox.TabIndex = 1;
            // 
            // weightFormsPlot
            // 
            this.weightFormsPlot.Location = new System.Drawing.Point(893, 90);
            this.weightFormsPlot.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.weightFormsPlot.Name = "weightFormsPlot";
            this.weightFormsPlot.Size = new System.Drawing.Size(877, 495);
            this.weightFormsPlot.TabIndex = 5;
            this.weightFormsPlot.Load += new System.EventHandler(this.formsPlot1_Load);
            // 
            // barsFormsPlot
            // 
            this.barsFormsPlot.Location = new System.Drawing.Point(7, 90);
            this.barsFormsPlot.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.barsFormsPlot.Name = "barsFormsPlot";
            this.barsFormsPlot.Size = new System.Drawing.Size(877, 495);
            this.barsFormsPlot.TabIndex = 4;
            this.barsFormsPlot.Load += new System.EventHandler(this.barsFormsPlot_Load_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.saveFoodButton);
            this.tabPage2.Location = new System.Drawing.Point(8, 46);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Size = new System.Drawing.Size(1778, 1311);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Food";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.foodBox1);
            this.groupBox7.Location = new System.Drawing.Point(15, 6);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox7.Size = new System.Drawing.Size(316, 122);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Find Food";
            // 
            // foodBox1
            // 
            this.foodBox1.FormattingEnabled = true;
            this.foodBox1.Location = new System.Drawing.Point(11, 47);
            this.foodBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.foodBox1.Name = "foodBox1";
            this.foodBox1.Size = new System.Drawing.Size(290, 40);
            this.foodBox1.TabIndex = 0;
            this.foodBox1.SelectedIndexChanged += new System.EventHandler(this.foodBox1_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.flowLayoutPanel2);
            this.groupBox6.Controls.Add(this.flowLayoutPanel1);
            this.groupBox6.Location = new System.Drawing.Point(15, 141);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox6.Size = new System.Drawing.Size(316, 429);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Nutrition Entry";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.nameBox);
            this.flowLayoutPanel2.Controls.Add(this.calorieBox);
            this.flowLayoutPanel2.Controls.Add(this.label7);
            this.flowLayoutPanel2.Controls.Add(this.fatBox);
            this.flowLayoutPanel2.Controls.Add(this.label8);
            this.flowLayoutPanel2.Controls.Add(this.carbBox);
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.proteinBox);
            this.flowLayoutPanel2.Controls.Add(this.label10);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(11, 47);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(282, 365);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(9, 11);
            this.nameBox.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.nameBox.Name = "nameBox";
            this.nameBox.PlaceholderText = "Name";
            this.nameBox.Size = new System.Drawing.Size(156, 39);
            this.nameBox.TabIndex = 0;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // calorieBox
            // 
            this.calorieBox.Location = new System.Drawing.Point(9, 72);
            this.calorieBox.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.calorieBox.Name = "calorieBox";
            this.calorieBox.PlaceholderText = "Calories";
            this.calorieBox.Size = new System.Drawing.Size(156, 39);
            this.calorieBox.TabIndex = 1;
            this.calorieBox.TextChanged += new System.EventHandler(this.calorieBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 80);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 19, 9, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 32);
            this.label7.TabIndex = 2;
            this.label7.Text = "kcals";
            // 
            // fatBox
            // 
            this.fatBox.Location = new System.Drawing.Point(6, 129);
            this.fatBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.fatBox.Name = "fatBox";
            this.fatBox.PlaceholderText = "Fat";
            this.fatBox.Size = new System.Drawing.Size(160, 39);
            this.fatBox.TabIndex = 6;
            this.fatBox.TextChanged += new System.EventHandler(this.fatBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 138);
            this.label8.Margin = new System.Windows.Forms.Padding(0, 15, 9, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 32);
            this.label8.TabIndex = 3;
            this.label8.Text = "g";
            // 
            // carbBox
            // 
            this.carbBox.Location = new System.Drawing.Point(6, 187);
            this.carbBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.carbBox.Name = "carbBox";
            this.carbBox.PlaceholderText = "Carbs";
            this.carbBox.Size = new System.Drawing.Size(160, 39);
            this.carbBox.TabIndex = 7;
            this.carbBox.TextChanged += new System.EventHandler(this.carbBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 196);
            this.label9.Margin = new System.Windows.Forms.Padding(0, 15, 9, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 32);
            this.label9.TabIndex = 4;
            this.label9.Text = "g";
            // 
            // proteinBox
            // 
            this.proteinBox.Location = new System.Drawing.Point(6, 245);
            this.proteinBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.proteinBox.Name = "proteinBox";
            this.proteinBox.PlaceholderText = "Protein";
            this.proteinBox.Size = new System.Drawing.Size(160, 39);
            this.proteinBox.TabIndex = 8;
            this.proteinBox.TextChanged += new System.EventHandler(this.proteinBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(172, 254);
            this.label10.Margin = new System.Windows.Forms.Padding(0, 15, 9, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 32);
            this.label10.TabIndex = 5;
            this.label10.Text = "g";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 47);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(282, 365);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.targetLabel);
            this.groupBox5.Location = new System.Drawing.Point(342, 6);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox5.Size = new System.Drawing.Size(188, 122);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Total Calories";
            // 
            // targetLabel
            // 
            this.targetLabel.AutoSize = true;
            this.targetLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetLabel.Location = new System.Drawing.Point(45, 41);
            this.targetLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(95, 54);
            this.targetLabel.TabIndex = 0;
            this.targetLabel.Text = "N/A";
            this.targetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.removeButton);
            this.groupBox4.Controls.Add(this.clearAllButton);
            this.groupBox4.Controls.Add(this.foodItems);
            this.groupBox4.Location = new System.Drawing.Point(342, 141);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox4.Size = new System.Drawing.Size(368, 578);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Items";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(202, 516);
            this.removeButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(139, 49);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // clearAllButton
            // 
            this.clearAllButton.Location = new System.Drawing.Point(11, 516);
            this.clearAllButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(139, 49);
            this.clearAllButton.TabIndex = 1;
            this.clearAllButton.Text = "Clear All";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // foodItems
            // 
            this.foodItems.FormattingEnabled = true;
            this.foodItems.ItemHeight = 32;
            this.foodItems.Location = new System.Drawing.Point(11, 47);
            this.foodItems.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.foodItems.Name = "foodItems";
            this.foodItems.Size = new System.Drawing.Size(327, 452);
            this.foodItems.TabIndex = 0;
            this.foodItems.SelectedIndexChanged += new System.EventHandler(this.foodItems_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bmrLabel);
            this.groupBox3.Location = new System.Drawing.Point(548, 6);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Size = new System.Drawing.Size(162, 122);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BMR";
            // 
            // bmrLabel
            // 
            this.bmrLabel.AutoSize = true;
            this.bmrLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bmrLabel.Location = new System.Drawing.Point(30, 41);
            this.bmrLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.bmrLabel.Name = "bmrLabel";
            this.bmrLabel.Size = new System.Drawing.Size(95, 54);
            this.bmrLabel.TabIndex = 0;
            this.bmrLabel.Text = "N/A";
            // 
            // saveFoodButton
            // 
            this.saveFoodButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveFoodButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveFoodButton.Location = new System.Drawing.Point(544, 768);
            this.saveFoodButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.saveFoodButton.Name = "saveFoodButton";
            this.saveFoodButton.Size = new System.Drawing.Size(162, 77);
            this.saveFoodButton.TabIndex = 4;
            this.saveFoodButton.Text = "Save";
            this.saveFoodButton.UseVisualStyleBackColor = false;
            this.saveFoodButton.Click += new System.EventHandler(this.saveFoodButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(8, 46);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage3.Size = new System.Drawing.Size(1778, 1311);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Recipe Search";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.goalChangeBox);
            this.tabPage4.Controls.Add(this.goalChangeLabel);
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.healthWelcome);
            this.tabPage4.Controls.Add(this.groupBox9);
            this.tabPage4.Location = new System.Drawing.Point(8, 46);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage4.Size = new System.Drawing.Size(1778, 1311);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Health Summary";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // goalChangeBox
            // 
            this.goalChangeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.goalChangeBox.FormattingEnabled = true;
            this.goalChangeBox.Location = new System.Drawing.Point(1098, 427);
            this.goalChangeBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.goalChangeBox.Name = "goalChangeBox";
            this.goalChangeBox.Size = new System.Drawing.Size(221, 40);
            this.goalChangeBox.TabIndex = 3;
            // 
            // goalChangeLabel
            // 
            this.goalChangeLabel.AutoSize = true;
            this.goalChangeLabel.Location = new System.Drawing.Point(914, 427);
            this.goalChangeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.goalChangeLabel.Name = "goalChangeLabel";
            this.goalChangeLabel.Size = new System.Drawing.Size(156, 32);
            this.goalChangeLabel.TabIndex = 2;
            this.goalChangeLabel.Text = "Change Goal:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.HSweightLabel);
            this.groupBox8.Controls.Add(this.HSheightLabel);
            this.groupBox8.Controls.Add(this.bmrHSlabel);
            this.groupBox8.Controls.Add(this.HSbmiLabel);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Location = new System.Drawing.Point(56, 386);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox8.Size = new System.Drawing.Size(592, 476);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Your Info";
            // 
            // HSweightLabel
            // 
            this.HSweightLabel.AutoSize = true;
            this.HSweightLabel.Location = new System.Drawing.Point(30, 384);
            this.HSweightLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.HSweightLabel.Name = "HSweightLabel";
            this.HSweightLabel.Size = new System.Drawing.Size(102, 32);
            this.HSweightLabel.TabIndex = 4;
            this.HSweightLabel.Text = "Weight: ";
            // 
            // HSheightLabel
            // 
            this.HSheightLabel.AutoSize = true;
            this.HSheightLabel.Location = new System.Drawing.Point(30, 307);
            this.HSheightLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.HSheightLabel.Name = "HSheightLabel";
            this.HSheightLabel.Size = new System.Drawing.Size(98, 32);
            this.HSheightLabel.TabIndex = 3;
            this.HSheightLabel.Text = "Height: ";
            // 
            // bmrHSlabel
            // 
            this.bmrHSlabel.AutoSize = true;
            this.bmrHSlabel.Location = new System.Drawing.Point(30, 237);
            this.bmrHSlabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.bmrHSlabel.Name = "bmrHSlabel";
            this.bmrHSlabel.Size = new System.Drawing.Size(76, 32);
            this.bmrHSlabel.TabIndex = 2;
            this.bmrHSlabel.Text = "BMR: ";
            // 
            // HSbmiLabel
            // 
            this.HSbmiLabel.AutoSize = true;
            this.HSbmiLabel.Location = new System.Drawing.Point(30, 164);
            this.HSbmiLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.HSbmiLabel.Name = "HSbmiLabel";
            this.HSbmiLabel.Size = new System.Drawing.Size(61, 32);
            this.HSbmiLabel.TabIndex = 1;
            this.HSbmiLabel.Text = "BMI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Goal:";
            // 
            // healthWelcome
            // 
            this.healthWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.healthWelcome.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.healthWelcome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.healthUserWelcome});
            this.healthWelcome.Location = new System.Drawing.Point(6, 6);
            this.healthWelcome.Name = "healthWelcome";
            this.healthWelcome.Padding = new System.Windows.Forms.Padding(2, 0, 26, 0);
            this.healthWelcome.Size = new System.Drawing.Size(1766, 67);
            this.healthWelcome.TabIndex = 0;
            this.healthWelcome.Text = "statusStrip1";
            // 
            // healthUserWelcome
            // 
            this.healthUserWelcome.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.healthUserWelcome.Name = "healthUserWelcome";
            this.healthUserWelcome.Size = new System.Drawing.Size(657, 57);
            this.healthUserWelcome.Text = "\"User\"\'s Personal Health Summary";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox9.Controls.Add(this.calRemainLabel);
            this.groupBox9.Controls.Add(this.calEatenLabel);
            this.groupBox9.Controls.Add(this.calGoalLabel);
            this.groupBox9.Location = new System.Drawing.Point(243, 122);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox9.Size = new System.Drawing.Size(1250, 190);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            // 
            // calRemainLabel
            // 
            this.calRemainLabel.AutoSize = true;
            this.calRemainLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.calRemainLabel.Location = new System.Drawing.Point(977, 41);
            this.calRemainLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.calRemainLabel.Name = "calRemainLabel";
            this.calRemainLabel.Size = new System.Drawing.Size(177, 45);
            this.calRemainLabel.TabIndex = 6;
            this.calRemainLabel.Text = "Remaining:";
            this.calRemainLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // calEatenLabel
            // 
            this.calEatenLabel.AutoSize = true;
            this.calEatenLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.calEatenLabel.Location = new System.Drawing.Point(514, 41);
            this.calEatenLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.calEatenLabel.Name = "calEatenLabel";
            this.calEatenLabel.Size = new System.Drawing.Size(227, 45);
            this.calEatenLabel.TabIndex = 5;
            this.calEatenLabel.Text = "Calories Eaten:";
            this.calEatenLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // calGoalLabel
            // 
            this.calGoalLabel.AutoSize = true;
            this.calGoalLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.calGoalLabel.Location = new System.Drawing.Point(69, 41);
            this.calGoalLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.calGoalLabel.Name = "calGoalLabel";
            this.calGoalLabel.Size = new System.Drawing.Size(278, 45);
            this.calGoalLabel.TabIndex = 4;
            this.calGoalLabel.Text = "Daily Calorie Goal:";
            this.calGoalLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Name";
            this.textBox1.Size = new System.Drawing.Size(86, 39);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(5, 38);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Calories";
            this.textBox2.Size = new System.Drawing.Size(86, 39);
            this.textBox2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 9, 5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "kcals";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(3, 69);
            this.textBox3.Name = "textBox3";
            this.textBox3.PlaceholderText = "Fat";
            this.textBox3.Size = new System.Drawing.Size(88, 39);
            this.textBox3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 7, 5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "g";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(3, 98);
            this.textBox4.Name = "textBox4";
            this.textBox4.PlaceholderText = "Carbs";
            this.textBox4.Size = new System.Drawing.Size(88, 39);
            this.textBox4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 102);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 7, 5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "g";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(3, 127);
            this.textBox5.Name = "textBox5";
            this.textBox5.PlaceholderText = "Protein";
            this.textBox5.Size = new System.Drawing.Size(88, 39);
            this.textBox5.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 131);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 7, 5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "g";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(1412, 1367);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(374, 46);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1794, 1424);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Dashboard";
            this.Text = "Nutrition Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.healthWelcome.ResumeLayout(false);
            this.healthWelcome.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lastLoginLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private ScottPlot.FormsPlot barsFormsPlot;
        private ScottPlot.FormsPlot weightFormsPlot;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox foodBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.ListBox foodItems;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label bmrLabel;
        private System.Windows.Forms.Button saveFoodButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox calorieBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox fatBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox carbBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox proteinBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox consumedBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip healthWelcome;
        private System.Windows.Forms.ToolStripStatusLabel healthUserWelcome;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox goalChangeBox;
        private System.Windows.Forms.Label goalChangeLabel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label HSheightLabel;
        private System.Windows.Forms.Label bmrHSlabel;
        private System.Windows.Forms.Label HSbmiLabel;
        private System.Windows.Forms.Label HSweightLabel;
        private System.Windows.Forms.ToolStripDropDownButton userDropDown;
        private System.Windows.Forms.ToolStripStatusLabel dateLabel;
        private System.Windows.Forms.ToolStripMenuItem helpItem;
        private System.Windows.Forms.ToolStripMenuItem logoutItem;
        private System.Windows.Forms.Label calGoalLabel;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label calEatenLabel;
        private System.Windows.Forms.Label calRemainLabel;
        private System.Windows.Forms.Button exitButton;
    }
}