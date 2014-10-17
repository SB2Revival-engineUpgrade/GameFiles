// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TID3Picture.cs=
// = 10/17/2014 =
// =SB2Revival=
using System.Drawing;
namespace SB2Revival.Music
{
    public struct TID3Picture
    {
        public bool PicturePresent;
        public int PictureType;
        public string Description;
        public Bitmap Bitmap;
        public System.IO.MemoryStream BitStream;
    }
}