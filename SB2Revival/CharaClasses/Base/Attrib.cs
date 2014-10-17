// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =Attrib.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SB2Revival.CharaClasses.Base
{
    public class Attrib
    {
        #region Virtial
        #region private
        private int constitution;
        private int sex;
        private int beauty;
        private int obedience;
        private int strength;
        private int charisma;
        private int agility;
        private int intelligence;
        #endregion
        #region gets/sets
        public int Intelligence
        {
            get
            {
                return this.intelligence;
            }
            set
            {
                this.intelligence = value;
            }
        }
        public int Agility
        {
            get
            {
                return this.agility;
            }
            set
            {
                this.agility = value;
            }
        }
        public int Charisma
        {
            get
            {
                return this.charisma;
            }
            set
            {
                this.charisma = value;
            }
        }
        public int Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                this.strength = value;
            }
        }
        public int Obedience
        {
            get
            {
                return this.obedience;
            }
            set
            {
                this.obedience = value;
            }
        }
        public int Beauty
        {
            get
            {
                return this.beauty;
            }
            set
            {
                this.beauty = value;
            }
        }
        public int Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }
        public int Constitution
        {
            get
            {
                return this.constitution;
            }
            set
            {
                this.constitution = value;
            }
        }
        #endregion
        #endregion
    }
}