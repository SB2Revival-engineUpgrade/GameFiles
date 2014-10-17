// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =AcScreen.cs=
// = 10/17/2014 =
// =SB2R_MU001=
using System;
using System.IO;
using System.Linq;
namespace SB2R_MU001.Screens.Active
{
    /// <summary>
    /// Used so that it can automaticly change to your perfect screen size
    /// <para>Enjoy</para>
    /// </summary>
    public class AcScreen
    {
        #region Size
        public Int32 Height = 768;
        public Int32 Width = 1024;
        public bool Full = false;
        #endregion
        #region Reader
        public void reader()
        {
            using (BinaryReader temp = new BinaryReader(File.Open(string.Format("{0}{1}", Environment.CurrentDirectory, @"/ActiveScreen.Mu1"), FileMode.Open)))
            {
                this.Height = temp.ReadInt32();
                this.Width = temp.ReadInt32();
                this.Full = temp.ReadBoolean();
            }
        }
        public void Writer()
        {
            using (BinaryWriter temp = new BinaryWriter(File.Open(string.Format("{0}{1}", Environment.CurrentDirectory, @"/ActiveScreen.Mu1"), FileMode.Create)))
            {
                temp.Write(this.Height);
                temp.Write(this.Width);
                temp.Write(this.Full);
            }
        }
        public void Checker()
        {
            try
            {
                this.reader();
            }
            catch
            {
                this.Writer();
            }
        }
        #endregion
    }
}