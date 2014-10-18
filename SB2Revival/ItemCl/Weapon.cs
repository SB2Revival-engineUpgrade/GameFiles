// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =Weapon.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB2Revival.ItemCl
{
    public enum wepType { 
    Axe,
    Sword,
    Bow,
    Dagger,
    FireArm,
    Fist,
    GreatAxe,
    GreatSword,
    Hammer,
    Katana,
    Rapier,
    Scythe,
    Spear,
    Staff,
    Wand,
    Whip}
    /// <summary>
    /// currently under construction
    /// </summary>
    public class Weapon : BaseItem
    {
        #region Field Region
        Hands hands;
        ItType TyOfItem;
        ArmorLocation Loc;
        
        #endregion
        #region Property Region
        public ItType PTyOfItem
        {
            get
            {
                return this.TyOfItem;
            }
            set
            {
                this.TyOfItem = value;
            }
        }
        public ArmorLocation PLoc
        {
            get
            {
                return this.Loc;
            }
            private set { Loc = value; }
        }
        public Hands NumberHands
        {
            get
            {
                return this.hands;
            }
            protected set
            {
                this.hands = value;
            }
        }
        #endregion
        #region Constructor Region
        public Weapon(
            string weaponName,
            string disc,
            int id,
            int price,
            Hands hands,
            ArmorLocation loc,
            params string[] blockedClasses) : base(weaponName, price,id,disc, blockedClasses)
        {
            this.NumberHands = hands;
            this.PLoc = loc;
        }
        #endregion
        #region Abstract Method Region
        public override object Clone()
        {
            throw new NotImplementedException();
        }
        /*
        public override object Clone()
        {
        string[] allowedClasses = new string[blockedClasses.Count];
        for (int i = 0; i < blockedClasses.Count; i++)
        allowedClasses[i] = blockedClasses[i];
        /*Weapon weapon = new Weapon(
        Name,
        Price,
        NumberHands,
        blockedClasses);
        return weapon;
             
        }
        */
        public override string ToString()
        {
            string weaponString = string.Format("{0}, ", base.ToString());
            weaponString += string.Format("{0}, ", this.NumberHands.ToString());
            return base.ToString();
        }
        #endregion
    }
}