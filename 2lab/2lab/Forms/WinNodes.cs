
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
    public partial class WinNodes : Form
    {
        public List<Question> factors;
        public List<Factor> targets;
        public Factor returner = null;
        public WinNodes(List<Question> _factors, List<Factor> _targets)
        {
            factors = _factors;
            targets = _targets;
            InitializeComponent();
            Draw();
        }
        

        public void addQuestion_Click(object sender, EventArgs e)
        {
            Question answer = new Question();
            answer.Text = "Фактор" + (factors.Count+1);
            factors.Add(answer);
            WQuestion win = new WQuestion(answer);
            win.StartPosition = FormStartPosition.CenterScreen;
            win.FormClosed += this.ReDraw;
            win.Show();
        }

        
        public void ReDraw(object sender, FormClosedEventArgs e)
        {
            Draw();
        }
        public void Draw()
        {
            listBoxQuestion.Items.Clear();
            listBoxAnswer.Items.Clear();
            foreach (Question i in factors)
            {
                listBoxQuestion.Items.Add(i.Text);
            }
            foreach (Factor i in targets)
            {
                listBoxAnswer.Items.Add(i.Text);
            }

            Refresh();
        }

        public void addAnswer_Click(object sender, EventArgs e)
        {
            Factor target = new Factor();
            target.Text = "Цель" + (targets.Count + 1);
            targets.Add(target);
            WAnswer win = new WAnswer(target);
            win.StartPosition = FormStartPosition.CenterScreen;
            win.FormClosed += this.ReDraw;
            win.Show();
        }
        private void listBoxQuestion_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxQuestion.SelectedIndex != -1) {
                returner = factors[listBoxQuestion.SelectedIndex];
            Close();
            }
        }
        private void listBoxAnswer_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxAnswer.SelectedIndex != -1)
            {
                returner = targets[listBoxAnswer.SelectedIndex];
                Close();
            }
        }

        private void EditAnswer_Click(object sender, EventArgs e)
        {
            if (listBoxAnswer.SelectedIndex != -1)
            {
                WAnswer win = new WAnswer(targets[listBoxAnswer.SelectedIndex]);
                win.StartPosition = FormStartPosition.CenterScreen;
                win.FormClosed += this.ReDraw;
                win.Show();
            }
        }

        public void EditQuestion_Click(object sender, EventArgs e)
        {
            if (listBoxQuestion.SelectedIndex != -1)
            {
                WQuestion win = new WQuestion(factors[listBoxQuestion.SelectedIndex]);
                win.StartPosition = FormStartPosition.CenterScreen;
                win.FormClosed += this.ReDraw;
                win.Show();
            }
        }

        public void find_and_select(Node current_node)
        {
            if (current_node.child != null && current_node.child.quest)
            {
                int k = this.listBoxQuestion.FindString(current_node.Text);
                if ( k != -1)
                {
                    this.listBoxQuestion.SelectedIndex = k;
                }
            }
        }
    }
}
