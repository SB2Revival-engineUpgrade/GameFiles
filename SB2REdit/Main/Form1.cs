using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SB2Revival.ElemCl;
using SB2REdit.Elem;
using System.IO;
using SB2REdit.Icon;
namespace SB2REdit.Main
{   
    #region Enums
    /// <summary>
    /// this is so you know what type of item to create
    /// </summary>
    public enum Selected { Element, Weapon, Armor }
    /// <summary>
    /// This is so you know when and if on exit it should save
    /// </summary>
    public enum ElemEdit { Editing, New, Saved }
    #endregion
    public partial class Form1 : Form
    {
        #region Values
        public Selected Choice;
        public ElemEdit ElsEdited;
        public List<Element> elems = new List<Element>();
        private ElemForm FormNewElem;
        public List<string> Iconnames = new List<string>();
        int itemsLoaded = 0;
        #endregion
        #region form events
        public Form1()
        {
            InitializeComponent();
            //keeps things from not working right, without this you get threading error
            CheckForIllegalCrossThreadCalls = false;
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Element x in this.elems)
            {
                x.Writer();
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ElemWorker.RunWorkerAsync();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            if (treeView1.SelectedNode.Index==0)
            {
                ColumnHeader IDCol = new ColumnHeader();
                IDCol.Text = "ID";
                listView1.Columns.Add(IDCol);
                ColumnHeader head = new ColumnHeader();
                head.Text = "Name";
                listView1.Columns.Add(head);
                Choice = Selected.Element;
            }
            else if (treeView1.SelectedNode.Index == 1)
            { Choice = Selected.Weapon; }
            else
            { Choice = Selected.Armor; }
            UpList();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Choice.ToString() == "Element")
            {
                this.FormNewElem = new ElemForm(this);
                ElemForm.CheckForIllegalCrossThreadCalls = false;
                this.FormNewElem.ShowDialog();
            }
        }
        #endregion
        #region custom functions
        public void UpList()
        {
            if (Choice.ToString() == "Element")
            {
                listView1.Items.Clear();
                foreach (Element x in this.elems)
                {
                    List<string> hem=new List<string>();
                    hem.Add(x.Id.ToString());
                    hem.Add(x.Name.ToString());
                    ListViewItem te = new ListViewItem(hem.ToArray());
                    listView1.Items.Add(te);
                    
                }
            }
            
            
        }
        #endregion
        #region loaders/loaderevents
        private void ElemWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] temp = Directory.GetFiles(Environment.CurrentDirectory + @"\Data\Game\Elements", "*.EM");
            int i = temp.Count();
            int p = 0;
            if (i == 0)
                i = 1;
            this.toolStripProgressBar1.Maximum = i;
            this.toolStripStatusLabel3.Text = "Loading Elements";
            foreach (string la in temp)
            {
                
                Element he = new Element();
                he.loader(la);
                this.elems.Add(he);
                p++;
                itemsLoaded++;
                ElemWorker.ReportProgress(p);
            }
            UpList();
        }

        private void ElemWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.toolStripProgressBar1.Value = e.ProgressPercentage;
            this.toolStripStatusLabel5.Text = itemsLoaded.ToString();
        }

        private void ElemWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //toolStripStatusLabel3.Text = "Loading Complete";
            toolStripProgressBar1.Value = 0;
            Iconworker1.RunWorkerAsync();
        }
        private void Iconworker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] temp = Directory.GetFiles(Environment.CurrentDirectory + @"\Data\Graphics\Engine\Icons", "*.png");
            string[] temp2 = Directory.GetFiles(Environment.CurrentDirectory + @"\Data\Graphics\Engine\Icons", "*.jpg");
            List<string> tes = temp.ToList();
            foreach (string x in temp2)
                tes.Add(x);
            temp = tes.ToArray();
            temp2 = new string[0];
            int i = temp.Count();
            int p = 0;
            if (i == 0)
                i = 1;
            this.toolStripProgressBar1.Maximum = i;
            this.toolStripStatusLabel3.Text = "Loading Icon Files";
            foreach (string la in temp)
            {
                string x = Path.GetFileName(la);
                this.Iconnames.Add(x);
                p++;
                itemsLoaded++;
                Iconworker1.ReportProgress(p);
            }
            
        }

        private void Iconworker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.toolStripProgressBar1.Value = e.ProgressPercentage;
            this.toolStripStatusLabel5.Text = itemsLoaded.ToString();
        }

        private void Iconworker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel3.Text = "Loading Complete";
            toolStripProgressBar1.Value = 0;
        }
        #endregion

        private void viewIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IconViewer lala = new IconViewer(this);
            lala.ShowDialog();
            IconViewer.CheckForIllegalCrossThreadCalls = false;
        }

        

    }
}
