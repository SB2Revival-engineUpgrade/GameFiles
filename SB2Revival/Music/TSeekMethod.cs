// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TSeekMethod.cs=
// = 10/17/2014 =
// =SB2Revival=
namespace SB2Revival.Music
{
    public enum TSeekMethod : int
    {
        smFromBeginning = 1,
        smFromEnd = 2,
        smFromCurrentForward = 4,
        smFromCurrentBackward = 8
    }
}