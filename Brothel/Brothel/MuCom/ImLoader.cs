// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =ImLoader.cs=
// = 10/17/2014 =
// =Brothel=
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SB2R;
using Color2 = Microsoft.Xna.Framework.Color;
namespace SB2R.MuCom
{
    public class ImLoader : GameComponent
    {
        #region values
        Game1 GameRef;
        Texture2D texture;
        int hight;
        int wid;
        #endregion
        #region class
        public ImLoader(Game game) : base(game)
        {
            this.GameRef = (Game1)game;
        }
        public Texture2D LoadImage(string image)
        {
            Bitmap temp2 = (Bitmap)Image.FromFile(image);
            temp2.MakeTransparent(System.Drawing.Color.White);
            this.hight = temp2.Height;
            this.wid = temp2.Width;
            this.texture = new Texture2D(this.GameRef.Gra.GraphicsDevice, this.wid, this.hight);
            Microsoft.Xna.Framework.Color[] r = new Microsoft.Xna.Framework.Color[this.wid * this.hight];
            int num = 0;
            for (int i = 0; i < this.hight; i++)
            {
                for (int j = 0; j < this.wid; j++)
                {
                    System.Drawing.Color pixel = temp2.GetPixel(j, i);
                    r[num].A = pixel.A;
                    r[num].R = pixel.R;
                    r[num].G = pixel.G;
                    r[num].B = pixel.B;
                    num++;
                }
            }
            this.texture.SetData<Microsoft.Xna.Framework.Color>(r);
            
            this.hight = 0;
            this.wid = 0;
            return this.texture;
        }
        public Texture2D Convert(Bitmap image)
        {
            this.hight = image.Height;
            this.wid = image.Width;
            this.texture = new Texture2D(this.GameRef.Gra.GraphicsDevice, this.wid, this.hight);
            Microsoft.Xna.Framework.Color[] r = new Microsoft.Xna.Framework.Color[this.wid * this.hight];
            int num = 0;
            for (int i = 0; i < this.hight; i++)
            {
                for (int j = 0; j < this.wid; j++)
                {
                    System.Drawing.Color pixel = image.GetPixel(j, i);
                    r[num].A = pixel.A;
                    r[num].R = pixel.R;
                    r[num].G = pixel.G;
                    r[num].B = pixel.B;
                    
                    num++;
                }
            }
            this.texture.SetData<Microsoft.Xna.Framework.Color>(r);

            this.hight = 0;
            this.wid = 0;
            return this.texture;
        }
        #endregion
    }
}