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
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.dashboardUser = new System.Windows.Forms.ToolStripDropDownButton();
            this.logoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lastLoginLabel = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.weightFormsPlot = new ScottPlot.FormsPlot();
            this.barsFormsPlot = new ScottPlot.FormsPlot();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusBar.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardUser,
            this.dateLabel});
            this.statusBar.Location = new System.Drawing.Point(3, 3);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(952, 36);
            this.statusBar.TabIndex = 2;
            this.statusBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusBar_ItemClicked);
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
            this.dateLabel.Size = new System.Drawing.Size(896, 31);
            this.dateLabel.Spring = true;
            this.dateLabel.Text = "CurrentDate";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastLoginLabel});
            this.toolStrip1.Location = new System.Drawing.Point(3, 584);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(952, 25);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 3;
            this.tabControl1.Size = new System.Drawing.Size(966, 640);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.weightFormsPlot);
            this.tabPage1.Controls.Add(this.barsFormsPlot);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.statusBar);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(958, 612);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dashboard";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // weightFormsPlot
            // 
            this.weightFormsPlot.Location = new System.Drawing.Point(481, 42);
            this.weightFormsPlot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.weightFormsPlot.Name = "weightFormsPlot";
            this.weightFormsPlot.Size = new System.Drawing.Size(472, 232);
            this.weightFormsPlot.TabIndex = 5;
            this.weightFormsPlot.Load += new System.EventHandler(this.formsPlot1_Load);
            // 
            // barsFormsPlot
            // 
            this.barsFormsPlot.Location = new System.Drawing.Point(4, 42);
            this.barsFormsPlot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barsFormsPlot.Name = "barsFormsPlot";
            this.barsFormsPlot.Size = new System.Drawing.Size(472, 232);
            this.barsFormsPlot.TabIndex = 4;
            this.barsFormsPlot.Load += new System.EventHandler(this.barsFormsPlot_Load_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(958, 612);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Food";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(958, 612);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Recipe Search";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(958, 612);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Health Summary";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(484, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 288);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Food Quickview";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(8, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 288);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recipe?";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 640);
            this.Controls.Add(this.tabControl1);
            this.Name = "Dashboard";
            this.Text = "Nutrition Dashboard";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripDropDownButton dashboardUser;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel dateLabel;
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
    }
}