// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TEchoEffect.cs=
// = 10/17/2014 =
// =SB2Revival=
using System.Runtime.InteropServices;
namespace SB2Revival.Music
{
    [StructLayout(LayoutKind.Explicit)]
    public struct TEchoEffect
    {
        [FieldOffset(0)]
        public int nLeftDelay;
        [FieldOffset(4)]
        public int nLeftSrcVolume;
        [FieldOffset(8)]
        public int nLeftEchoVolume;
        [FieldOffset(12)]
        public int nRightDelay;
        [FieldOffset(16)]
        public int nRightSrcVolume;
        [FieldOffset(20)]
        public int nRightEchoVolume;
    }
}