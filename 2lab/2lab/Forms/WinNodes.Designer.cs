namespace _2lab
{
    partial class WinNodes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinNodes));
            this.listBoxQuestion = new System.Windows.Forms.ListBox();
            this.addQuestion = new System.Windows.Forms.Button();
            this.addAnswer = new System.Windows.Forms.Button();
            this.listBoxAnswer = new System.Windows.Forms.ListBox();
            this.EditQuestion = new System.Windows.Forms.Button();
            this.EditAnswer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxQuestion
            // 
            this.listBoxQuestion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.listBoxQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxQuestion.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxQuestion.FormattingEnabled = true;
            this.listBoxQuestion.ItemHeight = 15;
            this.listBoxQuestion.Location = new System.Drawing.Point(15, 27);
            this.listBoxQuestion.Name = "listBoxQuestion";
            this.listBoxQuestion.Size = new System.Drawing.Size(252, 227);
            this.listBoxQuestion.TabIndex = 0;
            this.listBoxQuestion.DoubleClick += new System.EventHandler(this.listBoxQuestion_DoubleClick);
            // 
            // addQuestion
            // 
            this.addQuestion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addQuestion.Location = new System.Drawing.Point(275, 39);
            this.addQuestion.Name = "addQuestion";
            this.addQuestion.Size = new System.Drawing.Size(35, 35);
            this.addQuestion.TabIndex = 1;
            this.addQuestion.Text = "+";
            this.addQuestion.UseVisualStyleBackColor = true;
            this.addQuestion.Click += new System.EventHandler(this.addQuestion_Click);
            // 
            // addAnswer
            // 
            this.addAnswer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addAnswer.Location = new System.Drawing.Point(274, 287);
            this.addAnswer.Name = "addAnswer";
            this.addAnswer.Size = new System.Drawing.Size(36, 35);
            this.addAnswer.TabIndex = 3;
            this.addAnswer.Text = "+";
            this.addAnswer.UseVisualStyleBackColor = true;
            this.addAnswer.Click += new System.EventHandler(this.addAnswer_Click);
            // 
            // listBoxAnswer
            // 
            this.listBoxAnswer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.listBoxAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxAnswer.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAnswer.FormattingEnabled = true;
            this.listBoxAnswer.ItemHeight = 15;
            this.listBoxAnswer.Location = new System.Drawing.Point(14, 276);
            this.listBoxAnswer.Name = "listBoxAnswer";
            this.listBoxAnswer.Size = new System.Drawing.Size(252, 227);
            this.listBoxAnswer.TabIndex = 2;
            this.listBoxAnswer.DoubleClick += new System.EventHandler(this.listBoxAnswer_DoubleClick);
            // 
            // EditQuestion
            // 
            this.EditQuestion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EditQuestion.Location = new System.Drawing.Point(274, 80);
            this.EditQuestion.Name = "EditQuestion";
            this.EditQuestion.Size = new System.Drawing.Size(36, 35);
            this.EditQuestion.TabIndex = 4;
            this.EditQuestion.Text = "✎";
            this.EditQuestion.UseVisualStyleBackColor = true;
            this.EditQuestion.Click += new System.EventHandler(this.EditQuestion_Click);
            // 
            // EditAnswer
            // 
            this.EditAnswer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EditAnswer.Location = new System.Drawing.Point(275, 329);
            this.EditAnswer.Name = "EditAnswer";
            this.EditAnswer.Size = new System.Drawing.Size(35, 35);
            this.EditAnswer.TabIndex = 5;
            this.EditAnswer.Text = "✎";
            this.EditAnswer.UseVisualStyleBackColor = true;
            this.EditAnswer.Click += new System.EventHandler(this.EditAnswer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Факторы:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Цели:";
            // 
            // WinNodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 519);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditAnswer);
            this.Controls.Add(this.EditQuestion);
            this.Controls.Add(this.addAnswer);
            this.Controls.Add(this.listBoxAnswer);
            this.Controls.Add(this.addQuestion);
            this.Controls.Add(this.listBoxQuestion);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WinNodes";
            this.Text = "Редактор узлов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxQuestion;
        private System.Windows.Forms.Button addQuestion;
        private System.Windows.Forms.Button addAnswer;
        private System.Windows.Forms.ListBox listBoxAnswer;
        private System.Windows.Forms.Button EditQuestion;
        private System.Windows.Forms.Button EditAnswer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}