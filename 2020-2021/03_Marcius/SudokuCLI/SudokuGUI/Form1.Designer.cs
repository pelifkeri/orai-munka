
namespace SudokuGUI
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSzam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKezdo = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lblHossz = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Új feladvány mérete:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.minuszClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(216, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.pluszClick);
            // 
            // txtSzam
            // 
            this.txtSzam.Enabled = false;
            this.txtSzam.Location = new System.Drawing.Point(183, 14);
            this.txtSzam.Name = "txtSzam";
            this.txtSzam.Size = new System.Drawing.Size(27, 23);
            this.txtSzam.TabIndex = 2;
            this.txtSzam.Text = "4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kezdőállapot:";
            // 
            // txtKezdo
            // 
            this.txtKezdo.Location = new System.Drawing.Point(13, 94);
            this.txtKezdo.Name = "txtKezdo";
            this.txtKezdo.Size = new System.Drawing.Size(499, 23);
            this.txtKezdo.TabIndex = 4;
            this.txtKezdo.TextChanged += new System.EventHandler(this.Kezdo_Changed);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(422, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Ellenőrzés";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Ellenorzes);
            // 
            // lblHossz
            // 
            this.lblHossz.AutoSize = true;
            this.lblHossz.Location = new System.Drawing.Point(13, 135);
            this.lblHossz.Name = "lblHossz";
            this.lblHossz.Size = new System.Drawing.Size(50, 15);
            this.lblHossz.TabIndex = 6;
            this.lblHossz.Text = "Hossz: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 171);
            this.Controls.Add(this.lblHossz);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtKezdo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSzam);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Sudoku-ellenőrző";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSzam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKezdo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblHossz;
    }
}

