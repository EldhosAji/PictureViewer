using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture_Viewer
{
    public partial class Form1 : Form
    {
        public string[] data = null;
        public int initIndex,initStart=0;
        
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string initImage = openFileDialog1.FileName;
                button1.Enabled = true;
                string arr = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                data = System.IO.Directory.GetFiles(arr + "/", "*.jpg");
                
                pictureBox1.Load(openFileDialog1.FileName);
                int i=0;
                for (i = 0; i < data.Length; i++)
                {
                    if(System.IO.Path.GetFileName(initImage) == System.IO.Path.GetFileName(data[i]))
                    {
                        initIndex = i;
                    }
                }
                if (initIndex > 0)
                {
                    string d = data[initIndex];
                    data[initIndex] = data[0];
                    data[0] = d;
                    initIndex = 0;
                }

            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            data = null;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        public void changeImage(int ch)
        {
            switch (ch)
            {
                case 1:
                {
                        if (initIndex < data.Length)
                        {
                            initIndex = initIndex + ch;
                            pictureBox1.Load(data[initIndex]);
                            button2.Enabled = true;
                            if (initIndex == data.Length-1)
                            {
                                button1.Enabled = false;
                            }
                        }
                       
                        break;
                }
                case -1:
                {
                        
                        if (initIndex < data.Length && initIndex>0)
                        {
                            initIndex = initIndex + ch;
                            button1.Enabled = true;
                            pictureBox1.Load(data[initIndex]);
                            if (initIndex == initStart)
                            {
                                button2.Enabled = false;
                            }

                        }
                        break;
                }
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
                try
                {
                    changeImage(1);
                }
                catch (Exception err)
                {
                    changeImage(1);
                }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                try
                {
                    changeImage(-1);
                }
                catch (Exception err)
                {
                    changeImage(-1);
                }
            
        }
    }
}
