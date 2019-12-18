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
        Node tree;
        List<object> removed = new List<object>();
        Stack<Node> actions = new Stack<Node>(); 
        public Test(Node _tree)
        {
            tree = _tree;
            InitializeComponent();
            Start(tree);
        }
        public void Start(Node node)
        {
            actions.Push(node);
            foreach (Control k in removed)
            {
                this.Controls.Remove(k);
            }
            removed.Clear();
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
            lb.Font = this.Font;
            lb.Text = node.child.Text;
            lb.Location = new Point(0, 108);
            lb.Width = this.Width;
            lb.TextAlign = ContentAlignment.MiddleCenter;
            lb.AutoSize = false;
            this.Controls.Add(lb);
            removed.Add(lb);
            for (int i = 0; i < node.variants_tips.Count; i++)
            {
                Button btn = new_Button(i);
                this.Controls.Add(btn);
                removed.Add(btn);
                btn.Text = node.variants_tips[i].ToString();
                
            }
        }
        public void new_Factor(Node node)
        {
            Label lb = new Label();
            lb.Location = new Point(0, 108);
            lb.Width = this.Width;
            lb.TextAlign = ContentAlignment.MiddleCenter;
            lb.AutoSize = false;
            lb.Font = new Font(this.Font.FontFamily, 12,FontStyle.Bold);
            lb.Text = node.child.Text;
            this.Controls.Add(lb);
            removed.Add(lb);
            RichTextBox text = new RichTextBox();
            text.Font = new Font(this.Font.FontFamily, 12, FontStyle.Regular);
            text.Text = node.child.info;
            text.Width = 580;
            text.Height = 200;
            text.Enabled = false;
            text.Location = new Point((this.Width - text.Width)/2, 200);
            text.BorderStyle = BorderStyle.None;
            text.BackColor = SystemColors.ScrollBar;
            
            this.Controls.Add(text);
            removed.Add(text);

        }
        ///переделать как-то
        public void choose_Factor(object sender, MouseEventArgs e)
        {
            for (int i =0; i< current_node.variants_tips.Count; i++)
            {
                if (current_node.variants_tips[i].ToString() == ((Button)sender).Text)
                {
                    actions.Push(current_node);
                    Start(current_node.variants[i]);
                    break;
                }
            }
        }


        public Button new_Button(int i)
        {
            Button btn = new Button();
            btn.Font = this.Font;
            btn.Width = 580;
            btn.Height = 32;
            btn.Location = new Point(12, 160 + 40 * i);
            btn.MouseClick += this.choose_Factor;
            return btn;
        }

        private void restart_button_Click(object sender, EventArgs e)
        {
            Start(tree);
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            if (actions.Count == 0)
            {
                return;
            }
            Start(actions.Pop());
        }
    }
}
