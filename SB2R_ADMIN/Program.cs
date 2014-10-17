// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =Program.cs=
// = 10/17/2014 =
// =SB2R_ADMIN=
using System;
using System.Linq;
using System.Windows.Forms;
using SB2R_ADMIN.ScreenSize;
namespace SB2R_ADMIN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SizeEdit());
        }
    }
}