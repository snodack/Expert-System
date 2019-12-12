namespace _2lab
{
    partial class Project_form
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
            this.label2 = new System.Windows.Forms.Label();
            this.project_name_text = new System.Windows.Forms.TextBox();
            this.location_path = new System.Windows.Forms.TextBox();
            this.review_button = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ready_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Расположение:";
            // 
            // project_name_text
            // 
            this.project_name_text.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.project_name_text.Location = new System.Drawing.Point(98, 23);
            this.project_name_text.Name = "project_name_text";
            this.project_name_text.Size = new System.Drawing.Size(373, 23);
            this.project_name_text.TabIndex = 2;
            this.project_name_text.MouseClick += new System.Windows.Forms.MouseEventHandler(this.project_name_text_MouseClick);
            this.project_name_text.TextChanged += new System.EventHandler(this.project_name_text_TextChanged);
            // 
            // location_path
            // 
            this.location_path.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.location_path.Location = new System.Drawing.Point(131, 63);
            this.location_path.Name = "location_path";
            this.location_path.ReadOnly = true;
            this.location_path.Size = new System.Drawing.Size(340, 23);
            this.location_path.TabIndex = 3;
            // 
            // review_button
            // 
            this.review_button.Location = new System.Drawing.Point(477, 63);
            this.review_button.Name = "review_button";
            this.review_button.Size = new System.Drawing.Size(27, 21);
            this.review_button.TabIndex = 5;
            this.review_button.Text = "...";
            this.review_button.UseVisualStyleBackColor = true;
            this.review_button.Click += new System.EventHandler(this.review_button_Click);
            // 
            // ready_button
            // 
            this.ready_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ready_button.Location = new System.Drawing.Point(441, 99);
            this.ready_button.Name = "ready_button";
            this.ready_button.Size = new System.Drawing.Size(75, 26);
            this.ready_button.TabIndex = 6;
            this.ready_button.Text = "Создать";
            this.ready_button.UseVisualStyleBackColor = true;
            this.ready_button.Click += new System.EventHandler(this.ready_button_Click);
            // 
            // Project_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 137);
            this.Controls.Add(this.ready_button);
            this.Controls.Add(this.review_button);
            this.Controls.Add(this.location_path);
            this.Controls.Add(this.project_name_text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Project_form";
            this.Text = "Создание проекта";
            this.Load += new System.EventHandler(this.Project_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox project_name_text;
        private System.Windows.Forms.TextBox location_path;
        private System.Windows.Forms.Button review_button;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button ready_button;
    }
}