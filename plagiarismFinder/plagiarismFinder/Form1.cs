using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDR;

namespace plagiarismFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = @"c:\\daa";
            fd.Filter = "Pdf Files|*.pdf";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fd.FileName;

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = textBox1.Text;
            MessageBox.Show(filename);
            if(filename !=null)
            {
                Main pdf = new Main();
                MessageBox.Show(pdf.ReadRawPdf(filename));
            }
        }
    }
}
