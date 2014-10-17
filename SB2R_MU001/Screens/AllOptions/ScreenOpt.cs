// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =ScreenOpt.cs=
// = 10/17/2014 =
// =SB2R_MU001=
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SB2R_MU001.Screens.Active;
namespace SB2R_MU001.Screens.AllOptions
{
    public class ScreenOpt
    {
        #region Values
        readonly Dictionary<int, ScreenSze> sizop = new Dictionary<int, ScreenSze>();
        #endregion
        #region Logic
        #region add size
        public void AddOp(int hight, int width, bool full)
        {
            ScreenSze temp = new ScreenSze();
            temp.hi = hight;
            temp.wi = width;
            temp.fu = full;
            this.sizop.Add(this.sizop.Count + 1, temp);
        }
        public List<AcScreen> geSc()
        {
            List<AcScreen> temp = new List<AcScreen>();
            foreach (int x in this.sizop.Keys)
            {
                ScreenSze temp2 = this.sizop[x];
                AcScreen temp3 = new AcScreen();
                temp3.Width = temp2.hi;
                temp3.Height = temp2.wi;
                temp3.Full = temp2.fu;
                temp.Add(temp3);
            }
            return temp;
        }
        #endregion
        #region read/write
        public void read()
        {
            using (BinaryReader temp = new BinaryReader(File.Open(string.Format("{0}{1}", Environment.CurrentDirectory, @"/Data/Options/Screen/SOF.MU2"), FileMode.Open)))
            {
                int x = temp.ReadInt32();
                for (int i = 0; i < x; i++)
                {
                    ScreenSze temp2 = new ScreenSze();
                    temp2.wi = temp.ReadInt32();
                    temp2.hi = temp.ReadInt32();
                    temp2.fu = temp.ReadBoolean();
                    this.sizop.Add(i, temp2);
                }
            }
        }
        public void write()
        {
            using (BinaryWriter temp = new BinaryWriter(File.Open(string.Format("{0}{1}", Environment.CurrentDirectory, @"/Data/Options/Screen/SOF.MU2"), FileMode.Create)))
            {
                temp.Write(this.sizop.Count);
                foreach (int x in this.sizop.Keys)
                {
                    ScreenSze temp2 = new ScreenSze();
                    temp2 = this.sizop[x];
                    temp.Write(temp2.wi);
                    temp.Write(temp2.hi);
                    temp.Write(temp2.fu);
                }
            }
        }
        #endregion
        #endregion
    }
}