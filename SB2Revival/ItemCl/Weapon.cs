// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =Weapon.cs=
// = 10/18/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SB2Revival.CharaClasses.Base;
using SB2Revival.ElemCl;
using SB2Revival.StatusCl;
namespace SB2Revival.ItemCl
{
    public enum wepType
    { 
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
        Whip
    }
    /// <summary>
    /// currently under construction
    /// </summary>
    public class Weapon : BaseItem
    {
        #region Field Region
        Hands hands;
        ItType TyOfItem;
        ArmorLocation Loc;
        Attrib wepStats;
        int weapAtk;
        int magDef;
        int phyDef;
        int aniId1;
        int aniId2;
        bool reqFem;
        Attrib reqStats;
        List<ElemAtk> elemAttacks = new List<ElemAtk>();
        List<StatusPlus> plusEffects = new List<StatusPlus>();
        List<StatusNeg> negEffects = new List<StatusNeg>();
        List<int> skillIds = new List<int>();
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
            private set
            {
                this.Loc = value;
            }
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
        public Attrib WepStats
        {
            get
            {
                return this.wepStats;
            }private set
            {
                this.wepStats = value;
            }
        }
        #endregion
        #region Constructor Region
        public Weapon(
            string name,
            string discription,
            int price,
            int iD,
            int wepatk,
            int magdef,
            int phydef,
            int aniId1,
            int aniId2,
            Attrib wepstat,
            Attrib reqstat,
            Hands hands,
            ItType type,
            bool FemReq,
            ArmorLocation location,
            params string[] blockedClasses) : base(name, price, iD, discription,type, blockedClasses)
        {
            this.hands = hands; this.weapAtk = wepatk;this.magDef = magdef;this.phyDef = phydef;
            this.aniId1 = aniId1;this.aniId2 = aniId2;this.wepStats = wepstat;this.reqStats = reqstat;
            
            this.reqFem = FemReq;this.Loc = location;
        }
        #endregion
        #region extraLogic
        public void AddReqSkills(List<int> reqSkills)
        {
            this.skillIds = reqSkills;
        }
        public void AddPosEffects(List<StatusPlus> posEffect)
        { this.plusEffects = posEffect; }
        public void AddNegEffects(List<StatusNeg> negEffect)
        { this.negEffects = negEffect; }
        public void AddElemAttacks(List<ElemAtk> Attacks)
        { this.elemAttacks = Attacks; }
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