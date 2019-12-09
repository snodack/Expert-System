using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace _2lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Main();
        }
        public List<Question> factors = new List<Question>();
        public List<Factor> targets = new List<Factor>();
        public Node current_node = null;
        private Node contextselected = null;
        private Node tree;
        string project_path = "";
        string perm = ".keks";
        WinNodes q_and_a;
        enum states { auto, handle };
        states state = states.auto;
        public void Main()
        {
            tree = new_node(new Point(50, 360));
            saveFileDialog1.Filter = "Kekduck | *.keks";
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        //Создание нового узла
        private Node new_node(Point pos)
        {
            Node node = new Node();
            pictureBox1.Controls.Add(node);
            //node.MouseClick += this.Place;
            node.MouseDown += this.Node_edit;
            node.MouseMove += pictureBox1_MouseMove;
            node.MouseUp += node.Node_MouseUp;
            node.ContextMenuStrip = contextMenu_Node;
            node.Location = pos;
            return node;
        }
        //вызывается при нажатии на кнопку
        public void Place(Node node) { 
            if (node.edited)
                return;
            current_node = node;
            open_q_and_a();
        }

        //При закрытии окна выбора
        public void Form1_WinNodeClosed(object sender, FormClosingEventArgs e)
        {
            Factor f = q_and_a.returner;
            if (f == null || current_node == null) return;
            if (f != null)
            {
                current_node.f_harness(f);
            }
            if (f.quest)
            {
                Question q = (Question)f;
                if (q.variants.Count == 0) return;
                node_del(current_node);
                if (state == states.handle)
                {
                    double angle = (Math.PI / 2 / (q.variants.Count - 1));
                    for (int i = 0; i < q.variants.Count; i++)
                    {
                        current_node.variants.Add(new_node(new Point(current_node.Location.X + current_node.Width / 2 - 75 / 2 + (int)((200) * Math.Cos(i * angle)), current_node.Location.Y + (int)((200) * Math.Sin(i * angle)))));
                    }
                }
                else if (state == states.auto)
                {
                    tree.check_height();
                    current_node.variants.Add(new_node(new Point(current_node.Location.X + current_node.Width / 2 - 75 / 2 + 200, current_node.Location.Y + 50)));
                    for (int i =1; i< q.variants.Count; i++)
                    {
                        current_node.variants.Add(new_node(new Point(current_node.Location.X + current_node.Width / 2 - 75 / 2 + 200, current_node.variants[i-1].Location.Y + current_node.variants[i-1].height)));
                    }
                }
                RDraw();
            }
        }
        public void node_del(Node n)
        {
            foreach (Node t in n.variants)
            {
                node_del(t);
                pictureBox1.Controls.Remove(t);
            }
            n.variants.Clear();
        }
        public void Node_edit(object node, MouseEventArgs e)
        {
            Node cch = (Node)node;
            if (e.Button == MouseButtons.Left)
            {
                current_node = cch;
                Place(current_node);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                cch.edited = !cch.edited;
                current_node = cch;
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextselected = cch;
                current_node = cch;
            }
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (current_node != null && current_node.edited)
            {

                current_node.Location =new Point(-pictureBox1.Location.X+Cursor.Position.X - Location.X - current_node.Size.Width/2,-pictureBox1.Location.Y + Cursor.Position.Y - Location.Y-30 - current_node.Size.Height / 2);
                RDraw();
            }
        }

        private void RDraw()
        {
            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 3);
            tree.check_height();
            Drawvar(tree, e.Graphics, pen);
        }
        private void Drawvar(Node node, Graphics k, Pen p)
        {
            Font f = new Font("Calibri", 10, FontStyle.Italic);
            if (state == states.auto) {
            
                if (node.variants.Count <= 0)
                {
                    return;
                }
                for (int i = 0; i < node.variants_tips.Count; i++)
                {
                    
                    if (i == 0) {node.variants[0].Location = new Point(node.Location.X + node.Width / 2 - 75 / 2 + 200, node.Location.Y + 50); }
                    else
                        node.variants[i].Location = new Point(node.Location.X + node.Width / 2 - 75 / 2 + 200, node.variants[i - 1].Location.Y + node.variants[i - 1].height);
                    k.DrawLine(p, node.Location + new Size(node.Width / 2, node.Height / 2), new PointF(node.Location.X + node.Width / 2, node.variants[i].Location.Y + node.Height / 2));
                    k.DrawLine(p, new PointF(node.Location.X + node.Width / 2, node.variants[i].Location.Y + node.Height / 2), new PointF(node.variants[i].Location.X + node.variants[i].Width / 2, node.variants[i].Location.Y + node.Height / 2));
                    k.DrawString(node.variants_tips[i].ToString(), f, Brushes.Black, new PointF((node.Location.X + node.variants[i].Location.X) / 2 + node.Width / 2,
                        node.variants[i].Location.Y - 10));
                    Drawvar(node.variants[i], k, p);
                }
            }
            else
            {
                for (int i = 0; i < node.variants.Count; i++)
                {
                    k.DrawLine(p, node.Location + new Size(node.Width / 2, node.Height / 2), node.variants[i].Location + new Size(node.variants[i].Width / 2,
                        node.variants[i].Height / 2));
                    k.DrawString(node.variants_tips[i].ToString(), f, Brushes.Black, new PointF((node.Location.X + node.variants[i].Location.X) / 2 + node.Width / 2,
                        (node.Location.Y + node.variants[i].Location.Y) / 2 - 5));
                    Drawvar(node.variants[i], k, p);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Test start = new Test();
            start.Show();
            start.Start(tree);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (project_path == "")
            {
                новыйПроектToolStripMenuItem_Click(sender, e);
            }
            string dircache = "//cache-" + DateTime.Now.Ticks;
            Directory.CreateDirectory(project_path + dircache);
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Question>));
            string filename = project_path + dircache;
            System.IO.FileStream file = System.IO.File.Create(filename + "//Questions.xml");
            writer.Serialize(file, factors);
            file.Close();

            writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Factor>));
            file = System.IO.File.Create(filename + "//Factors.xml");
            writer.Serialize(file, targets);
            file.Close();

            writer = new System.Xml.Serialization.XmlSerializer(typeof(Node_save));
            file = System.IO.File.Create(filename + "//Nodes.xml");
            writer.Serialize(file, new Node_save(tree));
            file.Close();

            if (File.Exists(project_path + "//" + "check" + perm))
                File.Delete(project_path + "//" + "check" + perm);
            ZipFile.CreateFromDirectory(project_path + dircache, project_path + "//" + "check" + perm, CompressionLevel.Fastest, false);
            Directory.Delete(project_path + dircache, true);
        }

        private void отрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                project_path = openFileDialog1.FileName;
            }
            string dircache = "//cache -" + DateTime.Now.Ticks;
            string project_folder_path = project_path + "/../";
            Directory.CreateDirectory(project_folder_path + dircache);
            ZipFile.ExtractToDirectory(project_path, project_folder_path + dircache);
            string filename = project_folder_path + dircache +"//Questions.xml";
            if (File.Exists(filename))
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Question>));
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                factors = (List<Question>)reader.Deserialize(file);
                file.Close();
            }
            filename = project_folder_path + dircache +"//Factors.xml";
            if (File.Exists(filename))
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Factor>));
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                targets = (List<Factor>)reader.Deserialize(file);
                file.Close();

            }
            filename = project_folder_path + dircache +"//Nodes.xml";
            if (File.Exists(filename))
            {
                Node_save tree_save;
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Node_save));
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                tree_save = (Node_save)reader.Deserialize(file);
                file.Close();
                tree = Init_node(tree_save, tree);
                RDraw();
            }
            Directory.Delete(project_folder_path + dircache, true);


        }
        public Node Init_node(Node_save node_save, Node tree)
        {
            Factor f = null;
            foreach (Question factor in factors)
            {
                if (factor.Text == node_save.Text)
                {
                    f = factor;
                }
            }
            if (f == null) {
                foreach (Factor target in targets)
                {
                    if (target.Text == node_save.Text)
                    {
                        f = target;
                    }
                } 
            }
            if (f != null)
            {
                tree.f_harness(f);
            }
            
            tree.Location = node_save.Location;
            tree.variants_tips = node_save.variants_tips;
            for (int i =0; i < node_save.variants.Count; i++)
            {
                Node cch = Init_node(node_save.variants[i], new_node(node_save.variants[i].Location));
                tree.variants.Add(cch);
            }
            return tree;
        }

        private void новыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                project_path = folderBrowserDialog1.SelectedPath;
            }
        }

        private void редакторУзловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_node = null;
            open_q_and_a();
        }

        private void open_q_and_a()
        {
            q_and_a = new WinNodes(factors, targets);
            q_and_a.StartPosition = FormStartPosition.CenterScreen;
            q_and_a.FormClosing += this.Form1_WinNodeClosed;
            q_and_a.Show();
            q_and_a.Refresh();
        }

        private void редакторФакторовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_q_and_a();
            q_and_a.addQuestion_Click(sender, e);
        }

        private void редакторЦелейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_q_and_a();
            q_and_a.addAnswer_Click(sender, e);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            node_del(current_node);
            current_node.child = null;
            current_node.Text = "";
            RDraw();
        }
        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_q_and_a();
            q_and_a.find_and_select(current_node);
            q_and_a.EditQuestion_Click(sender, e);
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(0 - hScrollBar1.Value * 10);
        }

        
    }
}

