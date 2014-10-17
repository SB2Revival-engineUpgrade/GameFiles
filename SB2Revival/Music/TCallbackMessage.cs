// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TCallbackMessage.cs=
// = 10/17/2014 =
// =SB2Revival=
namespace SB2Revival.Music
{
    public enum TCallbackMessage : int
    {
        MsgStopAsync = 1,
        MsgPlayAsync = 2,
        MsgEnterLoopAsync = 4,
        MsgExitLoopAsync = 8,
        MsgEnterVolumeSlideAsync = 16,
        MsgExitVolumeSlideAsync = 32,
        MsgStreamBufferDoneAsync = 64,
        MsgStreamNeedMoreDataAsync = 128,
        MsgNextSongAsync = 256,
        MsgStop = 65536,
        MsgPlay = 131072,
        MsgEnterLoop = 262144,
        MsgExitLoop = 524288,
        MsgEnterVolumeSlide = 1048576,
        MsgExitVolumeSlide = 2097152,
        MsgStreamBufferDone = 4194304,
        MsgStreamNeedMoreData = 8388608,
        MsgNextSong = 16777216,
        MsgWaveBuffer = 33554432
    }
}