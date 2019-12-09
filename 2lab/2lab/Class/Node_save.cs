using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    public class Node_save
    {
        public Node_save() { }
        public Node_save(Node node)
        {
            Text = node.Text;
            variants_tips = node.variants_tips;
            Location = node.Location;
            foreach (Node n in node.variants)
            {
                variants.Add(new Node_save(n));
            }
        }
        public string Text;
        public List<Node_save> variants = new List<Node_save>();
        public List<object> variants_tips = new List<object>();
        public Point Location;
    }
}
