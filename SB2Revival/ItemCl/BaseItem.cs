﻿// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =BaseItem.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SB2Revival.ItemCl
{
    /// <summary>
    /// This contains the number of hands needed
    /// </summary>
    public enum Hands
    {
        One,
        Two
    }
    /// <summary>
    /// this contains the item locations
    /// <para>Inventory is just ment for items that are not equipment</para>
    /// </summary>
    public enum ArmorLocation
    {
        Weapon,
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
        Wings,
        Inventory
    }
    /// <summary>
    /// this desides if the item is equipment or what the item is
    /// </summary>
    public enum ItType
    {
        Equipment,
        Quest,
        Useable,
        Permanant,
        Alchemy
    }
    /// <summary>
    /// currently under development
    /// </summary>
    public abstract class BaseItem
    {
        #region Field Region
        /// <summary>
        /// list of classes that cannot use the item
        /// </summary>
        protected List<String> blockedClasses = new List<String>();
        /// <summary>
        /// The Name of the object
        /// </summary>
        string name;
        /// <summary>
        /// The discription of the item
        /// </summary>
        string description;
        /// <summary>
        /// the price of the object
        /// </summary>
        int price;
        /// <summary>
        /// this is to tell if the item is equiped
        /// </summary>
        bool equipped;
        /// <summary>
        /// the item id
        /// </summary>
        int id;
        #endregion
        #region Property Region
        public List<string> BlockedClasses
        {
            get
            {
                return this.blockedClasses;
            }
            protected set
            {
                this.blockedClasses = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                this.name = value;
            }
        }
        public int Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                this.price = value;
            }
        }
        public bool IsEquiped
        {
            get
            {
                return this.equipped;
            }
            protected set
            {
                this.equipped = value;
            }
        }
        #endregion
        #region Constructor Region
        public BaseItem(string name, int price,int ID,string discription, params String[] blockedClasses)
        {
            List<string> temp = new List<string>();
            foreach (string t in blockedClasses)
            {
                temp.Add(t);
            }
            this.blockedClasses = temp;
            this.Name = name;
            this.description = discription;
            this.Price = price;
            this.id = ID;
            this.IsEquiped = false;
        }
        #endregion
        #region Abstract Method Region
        public abstract object Clone();
        public virtual bool CanEquip(string characterType)
        {
            return this.blockedClasses.Contains(characterType);
        }
        public override string ToString()
        {
            string itemString = "";
            itemString += string.Format("{0}, ", this.Name);
            return itemString;
        }
        #endregion
    }
}