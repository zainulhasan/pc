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
            string sfiles = @"c:\daa\sFiles\";
            string userfileName = @"c:\daa\sFiles\users.pdf";

            string userfile = textBox1.Text;

            int ws = Convert.ToInt32(textBox2.Text);
            if (userfile != null && ws > 0)
            {
                Main pdf = new Main();
                string data = pdf.ReadRawPdf(userfile);
                pdf.ProcessPdfFiles(path, ws);
                string tmp = pdf.ReadRawPdf(sfiles + "finals.pdf");
                string dr = pdf.removeDuplicatePdf(tmp);
                pdf.CreatePdf(sfiles + "ufinals.pdf", dr);

                string uf = pdf.ProcessPdf(data, ws);
                pdf.CreatePdf(userfileName,uf);

                string[] users = pdf.ReadProcessPdf(userfileName);

                string[] f1 = pdf.ReadProcessPdf(sfiles + "1s.pdf");
                string[] f2 = pdf.ReadProcessPdf(sfiles + "2s.pdf");
                string[] f3 = pdf.ReadProcessPdf(sfiles + "3s.pdf");
                string[] f4 = pdf.ReadProcessPdf(sfiles + "4s.pdf");
                string[] f5 = pdf.ReadProcessPdf(sfiles + "5s.pdf");
                string[] ffinal = pdf.ReadProcessPdf(sfiles + "ufinals.pdf");


                one = pdf.compareFiles(users, f1);
                two = pdf.compareFiles(users, f2);
                three = pdf.compareFiles(users, f3);
                four = pdf.compareFiles(users, f4);
                five = pdf.compareFiles(users, f5);
                final = pdf.compareFiles(users, ffinal);



                


                double max = pdf.findMax(one, two, three, four, five);
                if (one > 0)
                {
                    label10.Text = one.ToString("#.#####") + "%";
                }
                else
                {
                    label10.Text = "0 %";
                }




                if (two > 0)
                {
                    label11.Text = two.ToString("#.#####") + "%";
                }
                else
                {
                    label11.Text = "0 %";
                }

                if (three > 0)
                {
                    label12.Text = three.ToString("#.#####") + "%";
                }
                else
                {
                    label12.Text = "0 %";
                }




                if (four > 0)
                {
                    label13.Text = four.ToString("#.#####") + "%";
                }
                else
                {
                    label13.Text = "0 %";
                }


                if (five > 0)
                {
                    label14.Text = five.ToString("#.#####") + "%";
                }
                else
                {
                    label14.Text = "0 %";
                }


                if (max > 0)
                {
                    label16.Text = max.ToString("#.#####") + "%";
                }
                else
                {
                    label16.Text = "0 %";
                }


                if (final > 0)
                {
                    label17.Text = final.ToString("#.#####") + "%";
                }
                else
                {
                    label17.Text = "0 %";
                }










            }
        }
    }
}
