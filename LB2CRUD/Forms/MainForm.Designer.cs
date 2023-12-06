namespace LB2CRUD.Forms
{
    partial class MainForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.fullName = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tireShopList = new System.Windows.Forms.ListView();
            this.addTireShop = new System.Windows.Forms.Button();
            this.searchField = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(77)))), ((int)(((byte)(37)))));
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.fullName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(776, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(24, 29);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "x";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // fullName
            // 
            this.fullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fullName.Font = new System.Drawing.Font("Comic Sans MS", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.fullName.Location = new System.Drawing.Point(0, 0);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(800, 100);
            this.fullName.TabIndex = 0;
            this.fullName.Text = "Main";
            this.fullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(94)))), ((int)(((byte)(92)))));
            this.mainPanel.Controls.Add(this.searchField);
            this.mainPanel.Controls.Add(this.tireShopList);
            this.mainPanel.Controls.Add(this.addTireShop);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            // 
            // tireShopList
            // 
            this.tireShopList.BackColor = System.Drawing.Color.IndianRed;
            this.tireShopList.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tireShopList.HideSelection = false;
            this.tireShopList.Location = new System.Drawing.Point(31, 170);
            this.tireShopList.Name = "tireShopList";
            this.tireShopList.Size = new System.Drawing.Size(740, 268);
            this.tireShopList.TabIndex = 4;
            this.tireShopList.UseCompatibleStateImageBehavior = false;
            this.tireShopList.View = System.Windows.Forms.View.List;
            this.tireShopList.ItemActivate += new System.EventHandler(this.tireShopsList_ItemActivate);
            // 
            // addTireShop
            // 
            this.addTireShop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(151)))), ((int)(((byte)(185)))));
            this.addTireShop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addTireShop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(151)))), ((int)(((byte)(185)))));
            this.addTireShop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen;
            this.addTireShop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOliveGreen;
            this.addTireShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTireShop.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTireShop.Location = new System.Drawing.Point(31, 127);
            this.addTireShop.Name = "addTireShop";
            this.addTireShop.Size = new System.Drawing.Size(108, 37);
            this.addTireShop.TabIndex = 3;
            this.addTireShop.Text = "Add";
            this.addTireShop.UseVisualStyleBackColor = false;
            this.addTireShop.Click += new System.EventHandler(this.addTireShop_Click);
            // 
            // searchField
            // 
            this.searchField.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchField.Location = new System.Drawing.Point(480, 127);
            this.searchField.Multiline = true;
            this.searchField.Name = "searchField";
            this.searchField.Size = new System.Drawing.Size(291, 37);
            this.searchField.TabIndex = 7;
            this.searchField.TextChanged += new System.EventHandler(this.searchField_TextChanged);
            this.searchField.Enter += new System.EventHandler(this.searchField_Enter);
            this.searchField.Leave += new System.EventHandler(this.searchField_Leave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label fullName;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button addTireShop;
        private System.Windows.Forms.ListView tireShopList;
        private System.Windows.Forms.TextBox searchField;
    }
}