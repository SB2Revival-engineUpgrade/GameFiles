using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SB2REdit.Main;
using SB2Revival.ElemCl;
namespace SB2REdit.Elem
{
    public partial class ElemForm : Form
    {
        private Form1 FormRef;
        private Element x = new Element();
        int id;
        int name;
        public ElemForm(Form mainForm)
        {
            InitializeComponent();
            this.FormRef = (Form1)mainForm;
            this.FormRef.ElsEdited = ElemEdit.Editing;
        }

        private void ElemForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = new Element(textBox1.Text, FormRef.elems.Count + 1);
            FormRef.elems.Add(x);
            FormRef.UpList();
            FormRef.ElsEdited = ElemEdit.New;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
