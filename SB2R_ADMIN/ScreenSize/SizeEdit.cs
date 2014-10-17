// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =SizeEdit.cs=
// = 10/17/2014 =
// =SB2R_ADMIN=
using System;
using System.Linq;
using System.Windows.Forms;
using SB2R_MU001.Screens.AllOptions;
namespace SB2R_ADMIN.ScreenSize
{
    public partial class SizeEdit : Form
    {
        private ScreenOpt temp = new ScreenOpt();
        public SizeEdit()
        {
            this.InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.temp.AddOp(Convert.ToInt32(this.numericUpDown1.Value), Convert.ToInt32(this.numericUpDown2.Value), this.checkBox1.Checked);
            this.set(Convert.ToInt32(this.numericUpDown1.Value), Convert.ToInt32(this.numericUpDown2.Value), this.checkBox1.Checked);
        }
        private void set(int x1, int x2, bool x3)
        {
            string temp = string.Format("{0}X{1} FullScreen: {2}", x1, x2, x3);
            this.listBox1.Items.Add(temp);
        }
        private void write()
        {
            this.temp.write();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.write();
        }
    }
}