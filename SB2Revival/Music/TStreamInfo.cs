// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TStreamInfo.cs=
// = 10/17/2014 =
// =SB2Revival=
using System.Runtime.InteropServices;
namespace SB2Revival.Music
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct TStreamInfo
    {
        [FieldOffset(0)]
        public int SamplingRate;
        [FieldOffset(4)]
        public int ChannelNumber;
        [FieldOffset(8)]
        public bool VBR;
        [FieldOffset(12)]
        public int Bitrate;
        [FieldOffset(16)]
        public TStreamTime Length;
        [FieldOffset(44)]
        public string Description;
    }
}