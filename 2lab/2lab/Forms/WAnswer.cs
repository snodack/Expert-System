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
    public partial class WAnswer : Form
    {
        Factor target;
        public WAnswer(Factor _target)
        {
            target = _target;
            InitializeComponent();
            InfoTextBox.Text = target.info;
            textBoxInfo.Text = target.Text;
            Refresh();
        }

        private void Readybutton_Click(object sender, EventArgs e)
        {
            target.Text = textBoxInfo.Text;
            target.info = InfoTextBox.Text;
            Close();
        }
    }
}
