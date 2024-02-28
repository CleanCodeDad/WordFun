using System.Drawing;
using System.Windows.Forms;

namespace EducationalSoftware
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelAlphabet = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAlphabet
            // 
            this.labelAlphabet.Font = new System.Drawing.Font("Consolas", 100F);
            this.labelAlphabet.Location = new System.Drawing.Point(33, -11);
            this.labelAlphabet.Name = "labelAlphabet";
            this.labelAlphabet.Size = new System.Drawing.Size(590, 234);
            this.labelAlphabet.TabIndex = 0;
            this.labelAlphabet.Text = "labelAlphabet";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 98);
            this.button1.TabIndex = 1;
            this.button1.Text = "Correct";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCorrect_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(356, 210);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 98);
            this.button2.TabIndex = 2;
            this.button2.Text = "Almost";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnIncorrect_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Consolas", 15F);
            this.labelTimer.Location = new System.Drawing.Point(389, 341);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(111, 36);
            this.labelTimer.TabIndex = 3;
            this.labelTimer.Text = "label1";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Consolas", 15F);
            this.labelScore.Location = new System.Drawing.Point(66, 341);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(287, 36);
            this.labelScore.TabIndex = 4;
            this.labelScore.Text = "Correct Answers: ";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(198, 34);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(249, 243);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go!";
            this.btnGo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(648, 383);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelAlphabet);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isGameActive)
            {
                LogData("Exited");
            }
        }

        #endregion

        private System.Windows.Forms.Label labelAlphabet;
        private System.Windows.Forms.Button btnCorrect;
        private System.Windows.Forms.Button btnIncorrect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelScore;
        private Button btnGo;
    }
}
