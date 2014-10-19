using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SB2Revival.SpriteCl
{
    public class DynamicSprite
    {
        #region virtial
        public Bitmap character;
        public List<Bitmap> items;
        public Bitmap CombinedImage;
        #endregion
        #region empty class
        public DynamicSprite() { }
        #endregion
        public Bitmap SetPics(string PathtoCharaSprite, List<string> pathtoitemsprites)
        {
            character = (Bitmap)Image.FromFile(PathtoCharaSprite);
            foreach (string x in pathtoitemsprites)
            {
                Bitmap temp = (Bitmap)Image.FromFile(x);
                temp.MakeTransparent(Color.White);
                items.Add(temp);
            }
            character.MakeTransparent(Color.White);
            Graphics hehe = Graphics.FromImage((Image)character);
            foreach (Bitmap x in items)
            {
                hehe.DrawImage((Image)x, 0, 0);
            }
            CombinedImage = character;
            return CombinedImage;
        }
        
        
    }
}
