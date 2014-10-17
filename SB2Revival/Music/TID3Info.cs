// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TID3Info.cs=
// = 10/17/2014 =
// =SB2Revival=
using System.Runtime.InteropServices;
namespace SB2Revival.Music
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct TID3Info
    {
        [FieldOffset(0)]
        public string Title;
        [FieldOffset(4)]
        public string Artist;
        [FieldOffset(8)]
        public string Album;
        [FieldOffset(12)]
        public string Year;
        [FieldOffset(16)]
        public string Comment;
        [FieldOffset(20)]
        public string Track;
        [FieldOffset(24)]
        public string Genre;
    }
}