using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB2Revival.ItemCl
{
    public enum Hands { One, Two }
    public enum ArmorLocation { Weapon,
        Shield,
        Head,
        Glasses,
        Neck,
        Undershirt,
        Shirt,
        Skirt,
        Tail,
        Socks,
        Shoes,
    Cape,
    Arms,
    Gloves,
    Accessory,
    Belt,
    NeckTie,
    Wings}
    public enum ItType {Equipment, Quest, Useable, Permanant }
    public abstract class BaseItem
    {
        #region Field Region
        protected List<String> blockedClasses = new List<String>();
        string name;
        int price;
        bool equipped;
        #endregion
        #region Property Region
        public List<string> BlockedClasses
        {
            get { return blockedClasses; }
            protected set { blockedClasses = value; }
        }
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        public int Price
        {
            get { return price; }
            protected set { price = value; }
        }
        public bool IsEquiped
        {
            get { return equipped; }
            protected set { equipped = value; }
        }
        #endregion
        #region Constructor Region
        public BaseItem(string name, int price, params String[] blockedClasses)
        {
            List<string> temp = new List<string>();
            foreach (string t in blockedClasses)
                temp.Add(t);
            this.blockedClasses = temp;
            Name = name;
            Price = price;
            IsEquiped = false;
        }
        #endregion
        #region Abstract Method Region
        public abstract object Clone();
        public virtual bool CanEquip(string characterType)
        {
            return blockedClasses.Contains(characterType);
        }
        public override string ToString()
        {
            string itemString = "";
            itemString += Name + ", ";
            itemString += Price.ToString();
            return itemString;
        }
        #endregion
    }
}
