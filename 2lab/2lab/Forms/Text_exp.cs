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
    public partial class Text_exp : Form
    {
        public Text_exp(Node tree)
        {
            InitializeComponent();
            textBox1.Text = export_text(tree, 0);

        }

        String export_text(Node node, int level)
        {
            String exp = "";
            exp += (node.child.Text + Environment.NewLine);
            String tab = "";
            for (int i = 0; i < level; i++) tab += "\t";
            if (node.child.quest)
            {
                for (int i = 0; i < node.variants.Count; i++)
                {
                    exp += tab + "ЕСЛИ " + node.variants_tips[i] + " ТО " + export_text(node.variants[i], level + 1);
                    //export_text(node.variants[i], level + 1);
                }
            }
            return exp;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
