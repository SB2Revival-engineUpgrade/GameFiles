// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TileCo.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace SB2Revival.TileEngine
{
    public class TileCo
    {
        #region virtial
        bool bAllPass;
        bool bUpPass;
        bool bDownPass;
        bool bLeftPass;
        bool bRightPass;
        #endregion
        #region class
        /// <summary>
        /// this just creates a blank class
        /// </summary>
        public TileCo()
        {
        }
        /// <summary>
        /// used to set which direction collision is blocked
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="up"></param>
        /// <param name="down"></param>
        public TileCo(bool left, bool right, bool up, bool down)
        {
            this.bLeftPass = left;
            this.bRightPass = right;
            this.bUpPass = up;
            this.bDownPass = down;
            this.bAllPass = false;
        }
        #endregion
        #region gets/sets
        public bool BRightPass
        {
            get
            {
                if (this.bAllPass)
                {
                    return true;
                }
                else
                {
                    return this.bRightPass;
                }
            }
            private set
            {
                this.bRightPass = value;
            }
        }
        public bool BLeftPass
        {
            get
            {
                if (this.bAllPass)
                {
                    return true;
                }
                else
                {
                    return this.bLeftPass;
                }
            }
            private set
            {
                this.bLeftPass = value;
            }
        }
        public bool BDownPass
        {
            get
            {
                if (this.bAllPass)
                {
                    return true;
                }
                else
                {
                    return this.bDownPass;
                }
            }
            private set
            {
                this.bDownPass = value;
            }
        }
        public bool BUpPass
        {
            get
            {
                if (this.bAllPass)
                {
                    return true;
                }
                else
                {
                    return this.bUpPass;
                }
            }
            private set
            {
                this.bUpPass = value;
            }
        }
        public bool BAllPass
        {
            get
            {
                return this.bAllPass;
            }
            private set
            {
                this.bAllPass = value;
            }
        }
        #endregion
        #region logic
        #region set all blocked
        public void SetAllB()
        {
            this.bAllPass = true;
        }
        #endregion
        #region reader
        #endregion
        #region Writer
        #endregion
        #endregion
    }
}