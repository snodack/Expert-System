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
    public partial class WQuestion : Form
    {
        Question que;
        public WQuestion(Question _que)
        {
            que = _que;
            InitializeComponent();
            richTextBox1.Text = que.Text;
            if (que.variants.Count > 0) listBox1.Items.Clear();
            foreach (object i in que.variants)
            {
                listBox1.Items.Add(i);
            }
            que.variants.Clear();
            Refresh();
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            ready_save();
            Close();
        }
        private void ready_save()
        {
            que.Text = richTextBox1.Text;
            que.variants.Clear();
            foreach (object i in listBox1.Items)
            {
                que.variants.Add(i);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAdd.Text!= "")
            {
                listBox1.Items.Add(textBoxAdd.Text);
                textBoxAdd.Text = "";
            }
        }

        private void WQuestion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                delete_button_Click(sender, (EventArgs)e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                buttonReady_Click(sender, (EventArgs)e);
            }

        }
        private void textBoxAdd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAdd_Click(sender, (EventArgs)e);
            }
        }

        private void up_button_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex != 0)
            {
                object Item = listBox1.SelectedItem;
                int ItemIndex = listBox1.SelectedIndex;

                listBox1.Items.Remove(Item);
                listBox1.Items.Insert(ItemIndex - 1, Item);
                listBox1.SelectedIndex = ItemIndex - 1;
            }

        }

        private void down_button_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex != listBox1.Items.Count - 1)
            {
                object Item = listBox1.SelectedItem;
                int ItemIndex = listBox1.SelectedIndex;

                listBox1.Items.Remove(Item);
                listBox1.Items.Insert(ItemIndex + 1, Item);
                listBox1.SelectedIndex = ItemIndex + 1;
            }

        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            int ItemIndex = listBox1.SelectedIndex;
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                if (ItemIndex != 0)
                {
                    listBox1.SelectedIndex = ItemIndex - 1;
                }
                else if (listBox1.Items.Count != 0)
                {
                    listBox1.SelectedIndex = 0;
                }
                
            }
        }

        private void WQuestion_FormClosed(object sender, FormClosedEventArgs e)
        {
            ready_save();
        }
    }
}
