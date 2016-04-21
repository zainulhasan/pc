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
            double one = 0.0;
            double two = 0.0;
            double three = 0.0;
            double four = 0.0;
            double five = 0.0;
            double final = 0.0;

            string path = @"c:\daa\";
            string userfileName= @"c:\daa\sFiles\users.pdf";

            string userfile = textBox1.Text;
            
            int ws = Convert.ToInt32(textBox2.Text);
            if(userfile !=null && ws > 0)
            {
                Main pdf = new Main();

                pdf.ProcessPdfFiles(path,ws);
                string data=pdf.ReadRawPdf(userfile);
                if (pdf.CreatePdf(userfileName, pdf.ProcessPdf(data, ws)))
                {
                    string[] arr = pdf.ReadProcessPdf(userfileName);

                    MessageBox.Show("Done");

                    
                }
                
                

            }
        }
    }
}
