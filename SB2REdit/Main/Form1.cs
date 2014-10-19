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
namespace SB2REdit.Main
{
    public enum Selected { Element, Weapon, Armor }
    public enum ElemEdit { Editing, New, Saved }
    public partial class Form1 : Form
    {
        private int childFormNumber = 0;
        
        public Selected Choice;
        public ElemEdit ElsEdited;
        public List<Element> elems = new List<Element>();
        private ElemForm FormNewElem;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
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

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
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
                ElemWorker.ReportProgress(p);
            }
            UpList();
        }

        private void ElemWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void ElemWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel3.Text = "Loading Complete";
            toolStripProgressBar1.Value = 0;
        }
        
    }
}
