﻿namespace Goon_Log_Realtime_Sorting
{
    partial class setup_page
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.setupEnter = new System.Windows.Forms.Button();
            this.autoDetectCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ENTER LOG FILE LOCATION";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "C:\\Users\\USERNAME\\Documents\\EVE\\logs\\Gamelogs";
            // 
            // setupEnter
            // 
            this.setupEnter.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupEnter.Location = new System.Drawing.Point(269, 84);
            this.setupEnter.Name = "setupEnter";
            this.setupEnter.Size = new System.Drawing.Size(99, 37);
            this.setupEnter.TabIndex = 2;
            this.setupEnter.Text = "ENTER";
            this.setupEnter.UseVisualStyleBackColor = true;
            this.setupEnter.Click += new System.EventHandler(this.button1_Click);
            // 
            // autoDetectCheck
            // 
            this.autoDetectCheck.AutoSize = true;
            this.autoDetectCheck.Font = new System.Drawing.Font("Arial Narrow", 10.75F);
            this.autoDetectCheck.Location = new System.Drawing.Point(111, 91);
            this.autoDetectCheck.Name = "autoDetectCheck";
            this.autoDetectCheck.Size = new System.Drawing.Size(130, 24);
            this.autoDetectCheck.TabIndex = 3;
            this.autoDetectCheck.Text = "Auto Detect Toons";
            this.autoDetectCheck.UseVisualStyleBackColor = true;
            // 
            // setup_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 450);
            this.Controls.Add(this.autoDetectCheck);
            this.Controls.Add(this.setupEnter);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "setup_page";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button setupEnter;
        private System.Windows.Forms.CheckBox autoDetectCheck;
    }
}