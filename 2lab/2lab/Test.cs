using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2lab
{
    public partial class Test : Form
    {
        Node current_node;
        public Test()
        {
            InitializeComponent();
        }
        public void Start(Node node)
        {
            this.Controls.Clear();
            current_node = node;
            if (node.child == null)
                return;
            if (node.child.quest)
            {
                new_Question(node);
            }
            else
            {
                new_Factor(node);
            }
        }
        public void new_Question(Node node)
        {
            Label lb = new Label();
            lb.Location = new Point(268, 108);
            lb.Font = this.Font;
            lb.Text = node.child.Text;
            this.Controls.Add(lb);
            for (int i = 0; i < node.variants_tips.Count; i++)
            {
                Button btn = new_Button(i);
                this.Controls.Add(btn);
                btn.Text = node.variants_tips[i].ToString();
                
            }
        }
        public void new_Factor(Node node)
        {
            Label lb = new Label();
            lb.Location = new Point((this.Width - lb.Width)/2, 108);
            lb.Font = new Font(this.Font.FontFamily, 14,FontStyle.Bold);
            lb.Text = node.child.Text;
            this.Controls.Add(lb);
            RichTextBox text = new RichTextBox();
            text.Font = new Font(this.Font.FontFamily, 14, FontStyle.Regular);
            text.Text = node.child.info;
            text.Width = 572;
            text.Height = 32;
            text.Enabled = false;
            text.Location = new Point((this.Width - text.Width)/2, 200);
            text.BorderStyle = BorderStyle.None;
            text.BackColor = SystemColors.ScrollBar;
            
            this.Controls.Add(text);

        }
        ///переделать как-то
        public void choose_Factor(object sender, MouseEventArgs e)
        {
            for (int i =0; i< current_node.variants_tips.Count; i++)
            {
                if (current_node.variants_tips[i].ToString() == ((Button)sender).Text)
                {
                    Start(current_node.variants[i]);
                    break;
                }
            }
        }


        public Button new_Button(int i)
        {
            Button btn = new Button();
            btn.Font = this.Font;
            btn.Width = 572;
            btn.Height = 32;
            btn.Location = new Point(12, 160 + 40 * i);
            btn.MouseClick += this.choose_Factor;
            return btn;
        }
    }
}
