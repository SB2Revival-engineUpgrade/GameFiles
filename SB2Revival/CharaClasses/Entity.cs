using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SB2Revival.CharaClasses.Base;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
namespace SB2Revival.CharaClasses
{
    public enum EntityType { Player, Soldier, Slave, Monster }
    public enum Gender{Male,Female,Shemale,Futa,Unknown}
    public enum BodyType { Big, Small, Med, SJ, SJLoli }
    public enum SkinType { White, Black, Tan, Darktan, Monster }
    public class Entity
    {
        #region Virtial
        private Attrib atributes;
        private string name;
        private List<string> classIds = new List<string>();
        private Gender entityGender;
        private Attrib atribMods;
        private Attrib atribExp;
        private BodyType mainBody;
        private SkinType skin;
        private EntityType type;
        private Texture2D mainbody;
        private Texture2D hair;
        #endregion
        #region gets/sets
        public EntityType Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type = value;
            }
        }
        public SkinType Skin
        {
            get
            {
                return this.skin;
            }
            private set
            {
                this.skin = value;
            }
        }
        public Texture2D Hair
        {
            get
            {
                return this.hair;
            }
            private set
            {
                this.hair = value;
            }
        }
        public Texture2D Mainbody
        {
            get
            {
                return this.mainbody;
            }
            private set
            {
                this.mainbody = value;
            }
        }
        public Gender EntityGender
        {
            get
            {
                return this.entityGender;
            }
            private set
            {
                this.entityGender = value;
            }
        }
        public List<string> ClassIds
        {
            get
            {
                return this.classIds;
            }
            private set
            {
                this.classIds = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }
        #endregion
        #region gets/sets attibutes
        public Attrib Atributes
        {
            get
            {
                return combined();
            }
            private set
            {
                this.atributes = value;
            }
        }
        #endregion
        #region logic
        public Attrib combined()
        {
            Attrib x = new Attrib();
            x.Agility = atributes.Agility + atribMods.Agility;
            x.Beauty = atributes.Beauty + atribMods.Beauty;
            x.Charisma = atributes.Charisma + atribMods.Charisma;
            x.Constitution = atributes.Constitution + atribMods.Constitution;
            x.Intelligence = atributes.Intelligence + atribMods.Intelligence;
            x.Obedience = atributes.Obedience + atribMods.Obedience;
            x.Sex = atributes.Sex + atribMods.Sex;
            x.Strength = atributes.Strength + atribMods.Strength;
            return x;
        }
        #endregion
        #region pairs
        private AttributePair health;
        private AttributePair skillPoints;
        private AttributePair vigor;
        private AttributePair moral;
        public AttributePair Health
        { get { return this.health; } }
        public AttributePair SP
        { get { return this.skillPoints; } }
        public AttributePair Vigor
        { get { return this.vigor; } }
        public AttributePair Moral
        { get { return this.moral; } }
        #endregion
        #region caculated
        private byte hitPer;
        private int atk;
        private int phyDef;
        private int magDef;
        private int speed;
        #endregion
        #region logic
        public Texture2D loadmainbody(GraphicsDevice device)
        {
            using (FileStream fileStream = new FileStream(Environment.CurrentDirectory + @"\Data\Graphics\Bodies\" + this.Skin.ToString() +@"\"+this.mainBody.ToString() + ".png", FileMode.Open))
            {
                Texture2D text = Texture2D.FromStream(device, fileStream);
                return text;
            }
        }
        public Texture2D loadHair(GraphicsDevice device)
        {
            using (FileStream fileStream = new FileStream(Environment.CurrentDirectory + @"\Data\Graphics\Hair\" + this.name + ".png", FileMode.Open))
            {
                Texture2D text = Texture2D.FromStream(device, fileStream);
                return text;
            }
        }
        #endregion
        #region LevelupLogic
        public Attrib CheckAtribLevelup()
        {
            Attrib levelups = new Attrib();
            #region agil check
            for (int i = 0; atributes.Agility > 100; i++)
            {
                if (atribExp.Agility > 100)
                {
                    atribExp.Agility -= 100;
                    atributes.Agility += 1;
                    levelups.Agility +=1;
                }
            }
            #endregion
            #region beauty
            for(int i=0;atribExp.Beauty>100;i++)
            {
                if (atribExp.Beauty>100)
                {
                    atribExp.Beauty-=100;
                    atributes.Beauty+=1;
                    levelups.Beauty+=1;
                }
            }
            #endregion
            return levelups;
        }
        #endregion
    }
}
