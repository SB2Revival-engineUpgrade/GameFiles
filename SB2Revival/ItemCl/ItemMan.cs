// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =ItemMan.cs=
// = 10/20/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SB2Revival.ItemCl
{
    class ItemMan
    {
        #region Fields Region
        Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();
        //Dictionary<string, Armor> armors = new Dictionary<string, Armor>();
        //Dictionary<string, Shield> shields = new Dictionary<string, Shield>();
        #endregion
        #region Keys Property Region
        public Dictionary<string, Weapon>.KeyCollection WeaponKeys
        {
            get
            {
                return this.weapons.Keys;
            }
        }
        //public Dictionary<string, Armor>.KeyCollection ArmorKeys
        //{
            //get
            //{
             //   return this.armors.Keys;
           // }
       // }
        /*
        public Dictionary<string, Shield>.KeyCollection ShieldKeys
        {
            get
            {
                return this.shields.Keys;
            }
        }
        #endregion
         */
        #region Constructor Region
        public ItemMan()
        {
        }
        #endregion
        #region Weapon Methods
        public void AddWeapon(Weapon weapon)
        {
            if (!this.weapons.ContainsKey(weapon.Name))
            {
                this.weapons.Add(weapon.Name, weapon);
            }
        }
        public Weapon GetWeapon(string name)
        {
            if (this.weapons.ContainsKey(name))
            {
                return (Weapon)this.weapons[name].Clone();
            }
            return null;
        }
        public bool ContainsWeapon(string name)
        {
            return this.weapons.ContainsKey(name);
        }
        #endregion
        /*
        #region Armor Methods
        public void AddArmor(Armor armor)
        {
            if (!this.armors.ContainsKey(armor.Name))
            {
                this.armors.Add(armor.Name, armor);
            }
        }
        public Armor GetArmor(string name)
        {
            if (this.armors.ContainsKey(name))
            {
                return (Armor)this.armors[name].Clone();
            }
            return null;
        }
        public bool ContainsArmor(string name)
        {
            return this.armors.ContainsKey(name);
        }
        #endregion
        #region Shield Methods
        public void AddShield(Shield shield)
        {
            if (!this.shields.ContainsKey(shield.Name))
            {
                this.shields.Add(shield.Name, shield);
            }
        }
        public Shield GetShield(string name)
        {
            if (this.shields.ContainsKey(name))
            {
                return (Shield)this.shields[name].Clone();
            }
            return null;
        }
        public bool ContainsShield(string name)
        {
            return this.shields.ContainsKey(name);
        }
        #endregion
         */
#endregion
    }
}