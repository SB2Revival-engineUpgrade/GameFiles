using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB2Revival.ItemCl
{
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
        }
        public Hands NumberHands
        {
            get { return hands; }
            protected set { hands = value; }
        }
        #endregion
        #region Constructor Region
        public Weapon(
        string weaponName,
        string weaponType,
        int price,
        float weight,
        Hands hands,
        int attackValue,
        int attackModifier,
        int damageValue,
        int damageModifier,
        params string[] blockedClasses)
            : base(weaponName, weaponType, price, weight, blockedClasses)
        {
            NumberHands = hands;
        }
        #endregion
        #region Abstract Method Region
        public override object Clone()
        {
            string[] allowedClasses = new string[blockedClasses.Count];
            for (int i = 0; i < blockedClasses.Count; i++)
                allowedClasses[i] = blockedClasses[i];
            Weapon weapon = new Weapon(
            Name,
            Price,
            NumberHands,
            blockedClasses);
            return weapon;
        }
        public override string ToString()
        {
            string weaponString = base.ToString() + ", ";
            weaponString += NumberHands.ToString() + ", ";
            return base.ToString();
        }
        #endregion
    }
}
