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
        #region values for storage later
        private Form1 FormRef;
        private Element x = new Element();
        int id;
        int name;
        #endregion
        /// <summary>
        /// loads everything
        /// </summary>
        public ElemForm(Form mainForm)
        {
            InitializeComponent();
            //sets the formref to call later
            this.FormRef = (Form1)mainForm;
            //this sets setting to editing
            this.FormRef.ElsEdited = ElemEdit.Editing;
        }
        /// <summary>
        /// this isnt used currently
        /// </summary>
        private void ElemForm_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// used to save the new element to the collection
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            //the below option takes the text and then autogens the id
            x = new Element(textBox1.Text, FormRef.elems.Count + 1);
            //adds element to the collection
            FormRef.elems.Add(x);
            //adds element to the listview on main form
            FormRef.UpList();
            //sets the els edited tag, basicly it is like it is making the program know that thier are new items
            FormRef.ElsEdited = ElemEdit.New;

        }
        /// <summary>
        /// simply closes the elem adder
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
