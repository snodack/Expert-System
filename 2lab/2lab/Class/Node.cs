using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2lab
{
    public class Node: Button
    {
        public Node()
        {
            this.AutoSize = true;
            this.FlatStyle = FlatStyle.Flat;
            this.TabStop = false;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
        }
        //public String info = "";
        public Factor child = null; //text
        public List<Node> variants = new List<Node>(); //save
        public List<object> variants_tips = new List<object>(); //save
        public bool edited = false;
        public int height = 50;
        public void Node_MouseUp(object sender, MouseEventArgs e)
        {
            if (edited)
            {
                edited = false;
                BackColor = System.Drawing.Color.White;
            }
        }
        public void f_harness(Factor f = null)
        {
            if (f == null)
            {
                Text = "";
                variants_tips.Clear();
                child = null;
                Width = 75;
                return;
            }
            Text = f.Text;
            variants_tips = f.variants;
            child = f;
        }
        public void save(string filename)
        {
            string save = "Привет";
            System.IO.File.WriteAllText(filename, save);
            foreach (Node i  in variants)
            {
                i.save(filename);
            }
        }
        public int check_height()
        {
            int sum = 50;
            foreach (Node var in variants)
            {
                var.check_height();
                sum += var.height;
            }
            height = sum;
            return height;
        }
        }

    }

