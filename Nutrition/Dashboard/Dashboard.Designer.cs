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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.recipeSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.addFood = new System.Windows.Forms.ToolStripMenuItem();
            this.Graphs = new System.Windows.Forms.ToolStripMenuItem();
            this.weekly = new System.Windows.Forms.ToolStripMenuItem();
            this.monthly = new System.Windows.Forms.ToolStripMenuItem();
            this.yearly = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.dashboardUser = new System.Windows.Forms.ToolStripDropDownButton();
            this.logoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lastLoginLabel = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recipeSearch,
            this.addFood,
            this.Graphs});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // recipeSearch
            // 
            this.recipeSearch.Name = "recipeSearch";
            this.recipeSearch.Size = new System.Drawing.Size(92, 20);
            this.recipeSearch.Text = "Recipe Search";
            // 
            // addFood
            // 
            this.addFood.Name = "addFood";
            this.addFood.Size = new System.Drawing.Size(76, 20);
            this.addFood.Text = "Add Foods";
            // 
            // Graphs
            // 
            this.Graphs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weekly,
            this.monthly,
            this.yearly});
            this.Graphs.Name = "Graphs";
            this.Graphs.Size = new System.Drawing.Size(108, 20);
            this.Graphs.Text = "Health Summary";
            // 
            // weekly
            // 
            this.weekly.Name = "weekly";
            this.weekly.Size = new System.Drawing.Size(119, 22);
            this.weekly.Text = "Weekly";
            // 
            // monthly
            // 
            this.monthly.Name = "monthly";
            this.monthly.Size = new System.Drawing.Size(119, 22);
            this.monthly.Text = "Monthly";
            // 
            // yearly
            // 
            this.yearly.Name = "yearly";
            this.yearly.Size = new System.Drawing.Size(119, 22);
            this.yearly.Text = "Yearly";
            // 
            // statusBar
            // 
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardUser,
            this.dateLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 24);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(966, 36);
            this.statusBar.TabIndex = 2;
            // 
            // dashboardUser
            // 
            this.dashboardUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dashboardUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutMenuItem});
            this.dashboardUser.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dashboardUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dashboardUser.Name = "dashboardUser";
            this.dashboardUser.Size = new System.Drawing.Size(41, 34);
            this.dashboardUser.Text = "...";
            this.dashboardUser.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.logout_ItemClicked);
            // 
            // logoutMenuItem
            // 
            this.logoutMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logoutMenuItem.Name = "logoutMenuItem";
            this.logoutMenuItem.Size = new System.Drawing.Size(118, 22);
            this.logoutMenuItem.Text = "Logout";
            // 
            // dateLabel
            // 
            this.dateLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(910, 31);
            this.dateLabel.Spring = true;
            this.dateLabel.Text = "CurrentDate";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastLoginLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 615);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(966, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lastLoginLabel
            // 
            this.lastLoginLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lastLoginLabel.Name = "lastLoginLabel";
            this.lastLoginLabel.Size = new System.Drawing.Size(61, 22);
            this.lastLoginLabel.Text = "Last Login";
            this.lastLoginLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(5, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 246);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daily Progress Graph";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(471, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 246);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Weight Change Graph";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(5, 362);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(446, 240);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Promoted Recipe";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(470, 362);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(484, 240);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Quick View Foods";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 640);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.Text = "Nutrition Dashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Graphs;
        private System.Windows.Forms.ToolStripMenuItem weekly;
        private System.Windows.Forms.ToolStripMenuItem monthly;
        private System.Windows.Forms.ToolStripMenuItem yearly;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem recipeSearch;
        private System.Windows.Forms.ToolStripMenuItem addFood;
        private System.Windows.Forms.ToolStripDropDownButton dashboardUser;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel dateLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lastLoginLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}