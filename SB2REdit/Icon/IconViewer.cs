using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SB2REdit.Main;
namespace SB2REdit.Icon
{
    public partial class IconViewer : Form
    {
        private Form1 FrmRef;
        public IconViewer(Form Editor)
        {
            InitializeComponent();
            FrmRef =(Form1)Editor;
            CheckForIllegalCrossThreadCalls = false;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            
        }

        private void IconViewer_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string fileLoc = Environment.CurrentDirectory + @"\Data\Graphics\Engine\Icons\";
            Bitmap Temp;
            foreach (string x in FrmRef.Iconnames)
            {
                Temp = (Bitmap)Image.FromFile(fileLoc+x);
                Temp.MakeTransparent(Color.White);
                dataGridView1.Rows.Add(x, fileLoc + x, Temp);
                
            }
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
