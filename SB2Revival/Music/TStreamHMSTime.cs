// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TStreamHMSTime.cs=
// = 10/17/2014 =
// =SB2Revival=
using System.Runtime.InteropServices;
namespace SB2Revival.Music
{
    [StructLayout(LayoutKind.Explicit)]
    public struct TStreamHMSTime
    {
        [FieldOffset(0)]
        public uint hour;
        [FieldOffset(4)]
        public uint minute;
        [FieldOffset(8)]
        public uint second;
        [FieldOffset(12)]
        public uint millisecond;
    }
}