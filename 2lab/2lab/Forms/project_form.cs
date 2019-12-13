using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2lab
{
    public partial class Project_form : Form
    {
        public string default_path = "";
        public string project_name = "";
        public Project_form()
        {
            InitializeComponent();
            this.FormClosing += newproject_Closing;
            default_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TreeXp projects";
            if (!Directory.Exists(default_path))
            {
                Directory.CreateDirectory(default_path);
            }
            location_path.Text = default_path;
            project_name= define_name("untitled", default_path);
            project_name_text.Text = project_name;
        }
        string define_name(string name, string path)
        {
            bool flag = false;
            foreach (string str in Directory.GetFiles(default_path))
            {
                if (path + "\\" + name + ".keks" == str)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag) return name;
            for (int i = 1; i < 100; i++)
            {
                flag = false;
                foreach (string str in Directory.GetFiles(default_path))
                {
                    if (path + "\\" + name + i +".keks" == str)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag) return name + i;

            }
            return "";
        }

        private void Project_form_Load(object sender, EventArgs e)
        {

        }

        public void newproject_Closing(object sender, FormClosingEventArgs e)
        {
            if (project_name == "") project_name = define_name("untitled", default_path);
            if (default_path == "") default_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TreeXp projects";
        }
        private void review_button_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = default_path;
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                if (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TreeXp projects" != folderBrowserDialog1.SelectedPath)
                {
                    default_path = folderBrowserDialog1.SelectedPath + "\\TreeXp projects";
                    if (!Directory.Exists(default_path))
                    {
                        Directory.CreateDirectory(default_path);
                    }
                    location_path.Text = default_path;
                    project_name = define_name("untitled", default_path);
                    project_name_text.Text = project_name;
                }
            }
        }

        private void project_name_text_TextChanged(object sender, EventArgs e)
        {
            project_name = define_name(project_name_text.Text, default_path);
            project_name_text.Text = project_name;
        }

        private void project_name_text_MouseClick(object sender, MouseEventArgs e)
        {
            project_name_text.Text = "";
        }

        private void ready_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
