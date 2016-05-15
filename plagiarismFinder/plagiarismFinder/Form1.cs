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
                pdf.CreatePdf(userfileName, uf);

                string[] users = pdf.ReadProcessPdf(userfileName);

                string[] f1 = pdf.ReadProcessPdf(sfiles + "1s.pdf");
                string[] f2 = pdf.ReadProcessPdf(sfiles + "2s.pdf");
                string[] f3 = pdf.ReadProcessPdf(sfiles + "3s.pdf");
                string[] f4 = pdf.ReadProcessPdf(sfiles + "4s.pdf");
                string[] f5 = pdf.ReadProcessPdf(sfiles + "5s.pdf");
                string[] ffinal = pdf.ReadProcessPdf(sfiles + "ufinals.pdf");

                int[,] jaccardmatrix = new int[ffinal.Length, 6];



                
                


                pdf.createMatrix(f2, ffinal, jaccardmatrix, 0, ffinal.Length);
                pdf.createMatrix(f1, ffinal, jaccardmatrix, 0, ffinal.Length);
                pdf.createMatrix(f3, ffinal, jaccardmatrix, 2, ffinal.Length);
                pdf.createMatrix(f4, ffinal, jaccardmatrix, 3, ffinal.Length);
                pdf.createMatrix(f5, ffinal, jaccardmatrix, 4, ffinal.Length);
                pdf.createMatrix(users, ffinal, jaccardmatrix, 5, ffinal.Length);

                int numOfPer =Convert.ToInt32(textBox3.Text);
                int[,] pa = new int[ffinal.Length,numOfPer];
                pdf.generatePermentations(pa, ffinal.Length, numOfPer);
                int[,] resultMaxtix =  new int[numOfPer, 6];
                pdf.finalMatrix(jaccardmatrix, pa, resultMaxtix, ffinal.Length, 6, numOfPer);

                double tmp0=pdf.similarity(resultMaxtix,0,numOfPer);
                double tmp1 = pdf.similarity(resultMaxtix, 1, numOfPer);
                double tmp2 = pdf.similarity(resultMaxtix, 2, numOfPer);
                double tmp3 = pdf.similarity(resultMaxtix, 3, numOfPer);
                double tmp4 = pdf.similarity(resultMaxtix, 4, numOfPer);




                Console.WriteLine(tmp0);
                Console.WriteLine(tmp1);
                Console.WriteLine(tmp2);
                Console.WriteLine(tmp3);
                Console.WriteLine(tmp4);
                double max = pdf.getMax(tmp0, tmp1, tmp2, tmp3, tmp4);
                label16.Text = (max+1) + ".pdf";


                label10.Text = tmp0.ToString()+"%";
                 progressBar1.Value = Convert.ToInt32(tmp0);



                label11.Text = tmp1.ToString() + "%";
                progressBar2.Value = Convert.ToInt32(tmp1) ;



                label12.Text = tmp2.ToString() + "%";
                progressBar3.Value = Convert.ToInt32(tmp2);


                label13.Text = tmp3.ToString() + "%";
                progressBar4.Value = Convert.ToInt32(tmp3) ;



                label14.Text = tmp4.ToString() + "%";
                progressBar5.Value =Convert.ToInt32(tmp4) ;


                

















            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
