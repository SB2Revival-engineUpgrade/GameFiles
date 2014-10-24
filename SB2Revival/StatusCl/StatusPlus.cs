using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SB2Revival.CharaClasses.Base;
namespace SB2Revival.StatusCl
{
    /// <summary>
    /// this gives the combatant Restrictions and determains what type of restrict;
    /// </summary>
    public enum Restrict { None, AttackEnemies, AttackAllies, CantMove, NoMagic, NoWeapAttack }
    public enum EftType { Positive, Negitive, Trait, NonCombat }
    public enum ReturnDam { None, Physical, Magic }
    public enum Release { Item, Timed, Turns }
    public enum DamExtend { None, Physical, Magic }
    #region mainStatus
    public class Status
    {
        #region virital
        protected string name;
        protected string disc;
        protected bool nonRes;
        protected bool hp0;
        protected bool exp0;
        protected bool damPM;
        protected bool comRel;
        List<int> elemDef = new List<int>();
        List<int> stateRel = new List<int>();
        Restrict restriction = Restrict.None;
        int aniId;
        Attrib attribReduct;
        #endregion
        #region get/set
        #endregion
        #region classes
        #endregion
        #region logic
        #region combatDamage
        public int DetDamage()
        {
            return 0;
        }
        #endregion
        #endregion
    }
    #endregion
    public class StatusPlus
    {
        #region virital
        private int stateID;
        #endregion
        #region get/set
        public int StateID
        { get { return this.stateID; } private set { this.stateID = value; } }
        #endregion
        #region classes
        public StatusPlus(int id){this.stateID=id;}
        public StatusPlus(){}
        #endregion
        #region logic
        #endregion
    }
    public class StatusNeg
    {
        #region virital
        private int stateID;
        #endregion
        #region get/set
        public int StateID
        { get { return this.stateID; } private set { this.stateID = value; } }
        #endregion
        #region classes
        public StatusNeg(int id)
        { this.stateID = id; }
        public StatusNeg(){}
        #endregion
        #region logic
        #endregion
    }
}
