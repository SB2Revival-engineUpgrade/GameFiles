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
using System.IO;
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
        wepType typeWep;
        #endregion
        #region Property Region
        public wepType TypeWep
        {
            get
            {
                return this.typeWep;
            }
            private set
            {
                this.typeWep = value;
            }
        }
        public List<int> SkillIds
        {
            get
            {
                return this.skillIds;
            }
            private set
            {
                this.skillIds = value;
            }
        }
        public List<StatusNeg> NegEffects
        {
            get
            {
                return this.negEffects;
            }
            private set
            {
                this.negEffects = value;
            }
        }
        public List<StatusPlus> PlusEffects
        {
            get
            {
                return this.plusEffects;
            }
            private set
            {
                this.plusEffects = value;
            }
        }
        public List<ElemAtk> ElemAttacks
        {
            get
            {
                return this.elemAttacks;
            }
            private set
            {
                this.elemAttacks = value;
            }
        }
        public bool ReqFem
        {
            get
            {
                return this.reqFem;
            }
            private set
            {
                this.reqFem = value;
            }
        }
        public int AniId2
        {
            get
            {
                return this.aniId2;
            }
            private set
            {
                this.aniId2 = value;
            }
        }
        public int AniId1
        {
            get
            {
                return this.aniId1;
            }
            private set
            {
                this.aniId1 = value;
            }
        }
        public int PhyDef
        {
            get
            {
                return this.phyDef;
            }
            private set
            {
                this.phyDef = value;
            }
        }
        public int MagDef
        {
            get
            {
                return this.magDef;
            }
            private set
            {
                this.magDef = value;
            }
        }
        public int WeapAtk
        {
            get
            {
                return this.weapAtk;
            }
            private set
            {
                this.weapAtk = value;
            }
        }
        public ItType PTyOfItem
        {
            get
            {
                return this.TyOfItem;
            }
            private set
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
            }
            private set
            {
                this.wepStats = value;
            }
        }
        public Attrib ReqStats
        { get { return this.reqStats; } private set { this.reqStats = value; } }

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
        #region Reader/Writer
        public void Read(string Loc)
        { }
        public void Write()
        {
            string x = Environment.CurrentDirectory + @"\Data\Game\Weapons\";
            Directory.CreateDirectory(x);
            using (BinaryWriter Wr = new BinaryWriter(File.Open(x + this.Name+".Wea", FileMode.Create)))
            {
                #region strings
                Wr.Write(this.Name);
                Wr.Write(this.Description);
                Wr.Write(this.ICon);
                #endregion
                #region ints
                Wr.Write(this.aniId1);
                Wr.Write(this.aniId2);
                Wr.Write(this.ID);
                Wr.Write(this.Price);
                Wr.Write(this.phyDef);
                Wr.Write(this.magDef);
                Wr.Write(this.weapAtk);
                #endregion
                #region bools
                Wr.Write(this.reqFem);
                #endregion
                #region Lists
                #region intlists
                Wr.Write(skillIds.Count);
                foreach (int tp in this.skillIds)
                {
                    Wr.Write(tp);
                }
                #endregion
                #region String lists
                Wr.Write(this.blockedClasses.Count);
                foreach (string tes in this.blockedClasses)
                {
                    Wr.Write(tes);
                }
                #endregion
                Wr.Write(this.negEffects.Count);
                //todo write the negeffects
                Wr.Write(this.plusEffects.Count);
                //todo write plus effects
                #region elem attack
                Wr.Write(this.elemAttacks.Count);
                foreach (ElemAtk ea in elemAttacks)
                {
                    Wr.Write(ea.ElemID);
                }
                #endregion
                #endregion
                #region write enums
                Wr.Write(this.hands.ToString());
                Wr.Write(typeWep.ToString());
                Wr.Write(this.Loc.ToString());
                Wr.Write(this.TyOfItem.ToString());
                #endregion
                #region write attrib
                Wr.Write(wepStats.Agility);
                Wr.Write(wepStats.Beauty);
                Wr.Write(wepStats.Charisma);
                Wr.Write(wepStats.Constitution);
                Wr.Write(wepStats.Intelligence);
                Wr.Write(wepStats.Obedience);
                Wr.Write(wepStats.Sex);
                Wr.Write(wepStats.Strength);
                Wr.Write(reqStats.Agility);
                Wr.Write(reqStats.Beauty);
                Wr.Write(reqStats.Charisma);
                Wr.Write(reqStats.Constitution);
                Wr.Write(reqStats.Intelligence);
                Wr.Write(reqStats.Obedience);
                Wr.Write(reqStats.Sex);
                Wr.Write(reqStats.Strength);
                #endregion
            }

        }
        #endregion 
    }
}