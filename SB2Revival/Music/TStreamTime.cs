// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TStreamTime.cs=
// = 10/17/2014 =
// =SB2Revival=
using System.Runtime.InteropServices;
namespace SB2Revival.Music
{
    [StructLayout(LayoutKind.Explicit)]
    public struct TStreamTime
    {
        [FieldOffset(0)]
        public uint sec;
        [FieldOffset(4)]
        public uint ms;
        [FieldOffset(8)]
        public uint samples;
        [FieldOffset(12)]
        public TStreamHMSTime hms;
    }
}