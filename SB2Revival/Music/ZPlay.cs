// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =ZPlay.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Drawing;
using System.Runtime.InteropServices;
namespace SB2Revival.Music
{
    public class ZPlay
    {
        #region libZPlay.dll interface
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct TStreamInfo_Internal
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
            public IntPtr Description;
        }
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct TWaveOutInfo_Internal
        {
            [FieldOffset(0)]
            public uint ManufacturerID;
            [FieldOffset(4)]
            public uint ProductID;
            [FieldOffset(8)]
            public uint DriverVersion;
            [FieldOffset(12)]
            public uint Formats;
            [FieldOffset(16)]
            public uint Channels;
            [FieldOffset(20)]
            public uint Support;
            [FieldOffset(24)]
            public IntPtr ProductName;
        }
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct TWaveInInfo_Internal
        {
            [FieldOffset(0)]
            public uint ManufacturerID;
            [FieldOffset(4)]
            public uint ProductID;
            [FieldOffset(8)]
            public uint DriverVersion;
            [FieldOffset(12)]
            public uint Formats;
            [FieldOffset(16)]
            public uint Channels;
            [FieldOffset(20)]
            public IntPtr ProductName;
        }
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct TID3Info_Internal
        {
            [FieldOffset(0)]
            public IntPtr Title;
            [FieldOffset(4)]
            public IntPtr Artist;
            [FieldOffset(8)]
            public IntPtr Album;
            [FieldOffset(12)]
            public IntPtr Year;
            [FieldOffset(16)]
            public IntPtr Comment;
            [FieldOffset(20)]
            public IntPtr Track;
            [FieldOffset(24)]
            public IntPtr Genre;
        }
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct TID3InfoEx_Internal
        {
            [FieldOffset(0)]
            public IntPtr Title;
            [FieldOffset(4)]
            public IntPtr Artist;
            [FieldOffset(8)]
            public IntPtr Album;
            [FieldOffset(12)]
            public IntPtr Year;
            [FieldOffset(16)]
            public IntPtr Comment;
            [FieldOffset(20)]
            public IntPtr Track;
            [FieldOffset(24)]
            public IntPtr Genre;
            [FieldOffset(28)]
            public IntPtr AlbumArtist;
            [FieldOffset(32)]
            public IntPtr Composer;
            [FieldOffset(36)]
            public IntPtr OriginalArtist;
            [FieldOffset(40)]
            public IntPtr Copyright;
            [FieldOffset(44)]
            public IntPtr URL;
            [FieldOffset(48)]
            public IntPtr Encoder;
            [FieldOffset(52)]
            public IntPtr Publisher;
            [FieldOffset(56)]
            public int BPM;
            [FieldOffset(60)]
            public int PicturePresent;
            [FieldOffset(64)]
            public int CanDrawPicture;
            [FieldOffset(68)]
            public IntPtr MIMEType;
            [FieldOffset(72)]
            public int PictureType;
            [FieldOffset(76)]
            public IntPtr Description;
            [FieldOffset(80)]
            public IntPtr PictureData;
            [FieldOffset(84)]
            public int PictureDataSize;
            [FieldOffset(88)]
            public IntPtr hBitmap;
            [FieldOffset(92)]
            public int Width;
            [FieldOffset(96)]
            public int Height;
            [FieldOffset(356)]
            public IntPtr reserved;
        };
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_CreateZPlay", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static uint zplay_CreateZPlay();
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_DestroyZPlay", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_DestroyZPlay(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetSettings", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetSettings(uint objptr, int nSettingID, int value);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetSettings", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetSettings(uint objptr, int nSettingID);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetError", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static IntPtr zplay_GetError(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetErrorW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        private extern static IntPtr zplay_GetErrorW(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetVersion", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetVersion(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetFileFormat", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetFileFormat(uint objptr, [MarshalAs(UnmanagedType.LPStr)]
                                                      string pchFileName);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetFileFormatW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        private extern static int zplay_GetFileFormatW(uint objptr, [MarshalAs(UnmanagedType.LPWStr)]
                                                       string pchFileName);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_OpenFile", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_OpenFile(uint objptr, [MarshalAs(UnmanagedType.LPStr)]
                                                 string sFileName, int nFormat);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_AddFile", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_AddFile(uint objptr, [MarshalAs(UnmanagedType.LPStr)]
                                                string sFileName, int nFormat);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_OpenFileW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        private extern static int zplay_OpenFileW(uint objptr, [MarshalAs(UnmanagedType.LPWStr)]
                                                  string sFileName, int nFormat);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_AddFileW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        private extern static int zplay_AddFileW(uint objptr, [MarshalAs(UnmanagedType.LPWStr)]
                                                 string sFileName, int nFormat);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_OpenStream", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_OpenStream(uint objptr, int fBuffered, int fManaged, [In()]
                                                   byte[] sMemStream, uint nStreamSize, int nFormat);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_PushDataToStream", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_PushDataToStream(uint objptr, [In()]
                                                         byte[] sMemNewData, uint nNewDataize);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_Close", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_Close(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_Play", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_Play(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_Stop", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_Stop(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_Pause", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_Pause(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_Resume", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_Resume(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_IsStreamDataFree", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_IsStreamDataFree(uint objptr, [In()]
                                                         byte[] sMemNewData);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetDynamicStreamLoad", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static void zplay_GetDynamicStreamLoad(uint objptr, ref TStreamLoadInfo pStreamLoadInfo);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetPosition", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static void zplay_GetPosition(uint objptr, ref TStreamTime pTime);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_PlayLoop", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_PlayLoop(uint objptr, int fFormatStartTime, ref TStreamTime pStartTime, int fFormatEndTime, ref TStreamTime pEndTime, uint nNumOfCycles, uint fContinuePlaying);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_Seek", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_Seek(uint objptr, TTimeFormat fFormat, ref TStreamTime pTime, TSeekMethod nMoveMethod);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_ReverseMode", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_ReverseMode(uint objptr, int fEnable);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetMasterVolume", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetMasterVolume(uint objptr, int nLeftVolume, int nRightVolume);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetPlayerVolume", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetPlayerVolume(uint objptr, int nLeftVolume, int nRightVolume);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetMasterVolume", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static void zplay_GetMasterVolume(uint objptr, ref int nLeftVolume, ref int nRightVolume);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetPlayerVolume", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static void zplay_GetPlayerVolume(uint objptr, ref int nLeftVolume, ref int nRightVolume);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetBitrate", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetBitrate(uint objptr, int fAverage);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetStatus", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static void zplay_GetStatus(uint objptr, ref TStreamStatus pStatus);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_MixChannels", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_MixChannels(uint objptr, int fEnable, uint nLeftPercent, uint nRightPercent);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetVUData", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static void zplay_GetVUData(uint objptr, ref int pnLeftChannel, ref int pnRightChannel);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SlideVolume", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SlideVolume(uint objptr, TTimeFormat fFormatStart, ref TStreamTime pTimeStart, int nStartVolumeLeft, int nStartVolumeRight, TTimeFormat fFormatEnd, ref TStreamTime pTimeEnd, int nEndVolumeLeft, int nEndVolumeRight);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_EnableEqualizer", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_EnableEqualizer(uint objptr, int fEnable);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetEqualizerPoints", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetEqualizerPoints(uint objptr, [In()]
                                                           int[] pnFreqPoint, int nNumOfPoints);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetEqualizerPoints", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetEqualizerPoints(uint objptr, [In(), Out()]
                                                           int[] pnFreqPoint, int nNumOfPoints);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetEqualizerParam", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetEqualizerParam(uint objptr, int nPreAmpGain, [In()]
                                                          int[] pnBandGain, int nNumberOfBands);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetEqualizerParam", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetEqualizerParam(uint objptr, ref int nPreAmpGain, [In(), Out()]
                                                          int[] pnBandGain, int nNumberOfBands);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetEqualizerPreampGain", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetEqualizerPreampGain(uint objptr, int nGain);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetEqualizerPreampGain", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetEqualizerPreampGain(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetEqualizerBandGain", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetEqualizerBandGain(uint objptr, int nBandIndex, int nGain);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetEqualizerBandGain", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetEqualizerBandGain(uint objptr, int nBandIndex);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_EnableEcho", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_EnableEcho(uint objptr, int fEnable);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_StereoCut", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_StereoCut(uint objptr, int fEnable, int fOutputCenter, int fBassToSides);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetEchoParam", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetEchoParam(uint objptr, [In()]
                                                     TEchoEffect[] pEchoEffect, int nNumberOfEffects);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetEchoParam", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetEchoParam(uint objptr, [In(), Out()]
                                                     TEchoEffect[] pEchoEffect, int nNumberOfEffects);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetFFTData", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetFFTData(uint objptr, int nFFTPoints, int nFFTWindow, ref int pnHarmonicNumber, [In(), Out()]
                                                   int[] pnHarmonicFreq, [In(), Out()]
                                                   int[] pnLeftAmplitude, [In(), Out()]
                                                   int[] pnRightAmplitude, [In(), Out()]
                                                   int[] pnLeftPhase, [In(), Out()]
                                                   int[] pnRightPhase);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetRate", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetRate(uint objptr, int nRate);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetRate", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetRate(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetPitch", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetPitch(uint objptr, int nPitch);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetPitch", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetPitch(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetTempo", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetTempo(uint objptr, int nTempo);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetTempo", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetTempo(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_DrawFFTGraphOnHDC", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_DrawFFTGraphOnHDC(uint objptr, System.IntPtr hdc, int nX, int nY, int nWidth, int nHeight);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_DrawFFTGraphOnHWND", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_DrawFFTGraphOnHWND(uint objptr, System.IntPtr hwnd, int nX, int nY, int nWidth, int nHeight);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetFFTGraphParam", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetFFTGraphParam(uint objptr, int nParamID, int nParamValue);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetFFTGraphParam", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetFFTGraphParam(uint objptr, int nParamID);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_LoadID3W", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_LoadID3W(uint objptr, int nId3Version, ref TID3Info_Internal pId3Info);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_LoadID3ExW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_LoadID3ExW(uint objptr, ref TID3InfoEx_Internal pId3Info, int fDecodeEmbededPicture);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_LoadFileID3W", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        private extern static int zplay_LoadFileID3W(uint objptr, [MarshalAs(UnmanagedType.LPWStr)]
                                                     string pchFileName, int nFormat, int nId3Version, ref TID3Info_Internal pId3Info);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_LoadFileID3ExW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        private extern static int zplay_LoadFileID3ExW(uint objptr, [MarshalAs(UnmanagedType.LPWStr)]
                                                       string pchFileName, int nFormat, ref TID3InfoEx_Internal pId3Info, int fDecodeEmbededPicture);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_DetectBPM", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_DetectBPM(uint objptr, uint nMethod);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_DetectFileBPM", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_DetectFileBPM(uint objptr, [MarshalAs(UnmanagedType.LPStr)]
                                                      string sFileName, int nFormat, uint nMethod);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_DetectFileBPMW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        private extern static int zplay_DetectFileBPMW(uint objptr, [MarshalAs(UnmanagedType.LPWStr)]
                                                       string sFileName, int nFormat, uint nMethod);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetCallbackFunc", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetCallbackFunc(uint objptr, [MarshalAs(UnmanagedType.FunctionPtr)]
                                                        TCallbackFunc pCallbackFunc, TCallbackMessage nMessage, int user_data);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_EnumerateWaveOut", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_EnumerateWaveOut(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetWaveOutInfoW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetWaveOutInfoW(uint objptr, uint nIndex, ref TWaveOutInfo_Internal pWaveOutInfo);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetWaveOutDevice", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetWaveOutDevice(uint objptr, uint nIndex);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_EnumerateWaveIn", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_EnumerateWaveIn(uint objptr);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetWaveInInfoW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_GetWaveInInfoW(uint objptr, uint nIndex, ref TWaveInInfo_Internal pWaveOutInfo);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetWaveInDevice", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static int zplay_SetWaveInDevice(uint objptr, uint nIndex);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_GetStreamInfoW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private extern static void zplay_GetStreamInfoW(uint objptr, ref TStreamInfo_Internal pInfo);
        [System.Runtime.InteropServices.DllImport("libzplay.dll", EntryPoint = "zplay_SetWaveOutFileW", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        private extern static int zplay_SetWaveOutFileW(uint objptr, [MarshalAs(UnmanagedType.LPWStr)]
                                                        string sFileName, int nFormat, int fOutputToSoundcard);
        #endregion
        #region Helper functions
        private uint objptr;
        #endregion
        #region Constructor and destructor
        public ZPlay()
        {
            this.objptr = zplay_CreateZPlay();
            if (this.objptr == 0)
            {
                throw new Exception("Can't create libZPlay interface.");
            }
              
            if (this.GetVersion() < 190)
            {
                throw new Exception("Need libZPlay.dll version 1.90 and above.");
            }
        }
        ~ZPlay()
        {
            zplay_DestroyZPlay(this.objptr);
        }
        #endregion
        #region Version
        public int GetVersion()
        {
            return zplay_GetVersion(this.objptr);
        }
        #endregion
        #region Error handling
        public string GetError()
        {
            return Marshal.PtrToStringUni(zplay_GetErrorW(this.objptr));
        }
        #endregion
        #region Open and close stream
        public TStreamFormat GetFileFormat(string FileName)
        {
            return (TStreamFormat)(zplay_GetFileFormatW(this.objptr, FileName));
        }
        public bool OpenFile(string FileName, TStreamFormat Format)
        {
            return zplay_OpenFileW(this.objptr, FileName, System.Convert.ToInt32(Format)) == 1;
        }
        public bool SetWaveOutFile(string FileName, TStreamFormat Format, bool fOutputToSoundcard)
        {
            int s = 0;
            if (fOutputToSoundcard)
            {
                s = 1;
            }
              
            return zplay_SetWaveOutFileW(this.objptr, FileName, System.Convert.ToInt32(Format), s) == 1;
        }
        public bool AddFile(string FileName, TStreamFormat Format)
        {
            return zplay_AddFileW(this.objptr, FileName, System.Convert.ToInt32(Format)) == 1;
        }
        public bool OpenStream(bool Buffered, bool Dynamic, ref byte[] MemStream, uint StreamSize, TStreamFormat nFormat)
        {
            int b = 0;
            int m = 0;
            if (Buffered)
            {
                b = 1;
            }
            if (Dynamic)
            {
                m = 1;
            }
            return zplay_OpenStream(this.objptr, b, m, MemStream, StreamSize, System.Convert.ToInt32(nFormat)) == 1;
        }
        public bool PushDataToStream(ref byte[] MemNewData, uint NewDatSize)
        {
            return zplay_PushDataToStream(this.objptr, MemNewData, NewDatSize) == 1;
        }
        public bool IsStreamDataFree(ref byte[] MemNewData)
        {
            return zplay_IsStreamDataFree(this.objptr, MemNewData) == 1;
        }
        public bool Close()
        {
            return zplay_Close(this.objptr) == 1;
        }
        #endregion
        #region Position and Seek
        public void GetPosition(ref TStreamTime time)
        {
            zplay_GetPosition(this.objptr, ref time);
        }
        public bool Seek(TTimeFormat TimeFormat, ref TStreamTime Position, TSeekMethod MoveMethod)
        {
            return zplay_Seek(this.objptr, TimeFormat, ref Position, MoveMethod) == 1;
        }
        #endregion
        #region Play, Pause, Loop, Reverse
        public bool ReverseMode(bool Enable)
        {
            if (Enable)
            {
                return zplay_ReverseMode(this.objptr, 1) == 1;
            }
            else
            {
                return zplay_ReverseMode(this.objptr, 0) == 1;
            }
        }
        public bool PlayLoop(TTimeFormat TimeFormatStart, ref TStreamTime StartPosition, TTimeFormat TimeFormatEnd, ref TStreamTime EndPosition, uint NumberOfCycles, bool ContinuePlaying)
        {
            uint continueplay = 0;
            if (ContinuePlaying)
            {
                continueplay = 1;
            }
            else
            {
                continueplay = 0;
            }
              
            return zplay_PlayLoop(this.objptr, System.Convert.ToInt32((int)(TimeFormatStart)), ref StartPosition, System.Convert.ToInt32((int)(TimeFormatEnd)), ref EndPosition, NumberOfCycles, continueplay) == 1;
        }
        public bool StartPlayback()
        {
            return zplay_Play(this.objptr) == 1;
        }
        public bool StopPlayback()
        {
            return zplay_Stop(this.objptr) == 1;
        }
        public bool PausePlayback()
        {
            return zplay_Pause(this.objptr) == 1;
        }
        public bool ResumePlayback()
        {
            return zplay_Resume(this.objptr) == 1;
        }
        #endregion
        #region Equalizer
        public bool SetEqualizerParam(int PreAmpGain, ref int[] BandGain, int NumberOfBands)
        {
            return zplay_SetEqualizerParam(this.objptr, PreAmpGain, BandGain, NumberOfBands) == 1;
        }
        public int GetEqualizerParam(ref int PreAmpGain, ref int[] BandGain)
        {
            int tempnPreAmpGain1 = 0;
            int size = zplay_GetEqualizerParam(this.objptr, ref tempnPreAmpGain1, null, 0);
            Array.Resize(ref BandGain, size);
            return zplay_GetEqualizerParam(this.objptr, ref PreAmpGain, BandGain, size);
        }
        public bool EnableEqualizer(bool Enable)
        {
            if (Enable)
            {
                return zplay_EnableEqualizer(this.objptr, 1) == 1;
            }
            return zplay_EnableEqualizer(this.objptr, 0) == 1;
        }
        public bool SetEqualizerPreampGain(int Gain)
        {
            return zplay_SetEqualizerPreampGain(this.objptr, Gain) == 1;
        }
        public int GetEqualizerPreampGain()
        {
            return zplay_GetEqualizerPreampGain(this.objptr);
        }
        public bool SetEqualizerBandGain(int BandIndex, int Gain)
        {
            return zplay_SetEqualizerBandGain(this.objptr, BandIndex, Gain) == 1;
        }
        public int GetEqualizerBandGain(int BandIndex)
        {
            return zplay_GetEqualizerBandGain(this.objptr, BandIndex);
        }
        public bool SetEqualizerPoints(ref int[] FreqPointArray, int NumberOfPoints)
        {
            return zplay_SetEqualizerPoints(this.objptr, FreqPointArray, NumberOfPoints) == 1;
        }
        public int GetEqualizerPoints(ref int[] FreqPointArray)
        {
            int size = zplay_GetEqualizerPoints(this.objptr, null, 0);
            Array.Resize(ref FreqPointArray, size);
            return zplay_GetEqualizerPoints(this.objptr, FreqPointArray, size);
        }
        #endregion
        #region Echo
        public bool EnableEcho(bool Enable)
        {
            if (Enable)
            {
                return zplay_EnableEcho(this.objptr, 1) == 1;
            }
            return zplay_EnableEcho(this.objptr, 0) == 1;
        }
        public bool SetEchoParam(ref TEchoEffect[] EchoEffectArray, int NumberOfEffects)
        {
            return zplay_SetEchoParam(this.objptr, EchoEffectArray, NumberOfEffects) == 1;
        }
        public int GetEchoParam(ref TEchoEffect[] EchoEffectArray)
        {
            int size = zplay_GetEchoParam(this.objptr, null, 0);
            Array.Resize(ref EchoEffectArray, size);
            return zplay_GetEchoParam(this.objptr, EchoEffectArray, size);
        }
        #endregion
        #region Volume and Fade
        public bool SetMasterVolume(int LeftVolume, int RightVolume)
        {
            return zplay_SetMasterVolume(this.objptr, LeftVolume, RightVolume) == 1;
        }
        public bool SetPlayerVolume(int LeftVolume, int RightVolume)
        {
            return zplay_SetPlayerVolume(this.objptr, LeftVolume, RightVolume) == 1;
        }
        public void GetMasterVolume(ref int LeftVolume, ref int RightVolume)
        {
            zplay_GetMasterVolume(this.objptr, ref LeftVolume, ref RightVolume);
        }
        public void GetPlayerVolume(ref int LeftVolume, ref int RightVolume)
        {
            zplay_GetPlayerVolume(this.objptr, ref LeftVolume, ref RightVolume);
        }
        public bool SlideVolume(TTimeFormat TimeFormatStart, ref TStreamTime TimeStart, int StartVolumeLeft, int StartVolumeRight, TTimeFormat TimeFormatEnd, ref TStreamTime TimeEnd, int EndVolumeLeft, int EndVolumeRight)
        {
            return zplay_SlideVolume(this.objptr, TimeFormatStart, ref TimeStart, StartVolumeLeft, StartVolumeRight, TimeFormatEnd, ref TimeEnd, EndVolumeLeft, EndVolumeRight) == 1;
        }
        #endregion
        #region Pitch, tempo, rate
        public bool SetPitch(int Pitch)
        {
            return zplay_SetPitch(this.objptr, Pitch) == 1;
        }
        public int GetPitch()
        {
            return zplay_GetPitch(this.objptr);
        }
        public bool SetRate(int Rate)
        {
            return zplay_SetRate(this.objptr, Rate) == 1;
        }
        public int GetRate()
        {
            return zplay_GetRate(this.objptr);
        }
        public bool SetTempo(int Tempo)
        {
            return zplay_SetTempo(this.objptr, Tempo) == 1;
        }
        public int GetTempo()
        {
            return zplay_GetTempo(this.objptr);
        }
        #endregion
        #region Bitrate
        public int GetBitrate(bool Average)
        {
            if (Average)
            {
                return zplay_GetBitrate(this.objptr, 1);
            }
              
            return zplay_GetBitrate(this.objptr, 0);
        }
        #endregion
        #region ID3 Info
        public bool LoadID3(TID3Version Id3Version, ref TID3Info Info)
        {
            TID3Info_Internal tmp = new TID3Info_Internal();
            if (zplay_LoadID3W(this.objptr, System.Convert.ToInt32((int)(Id3Version)), ref tmp) == 1)
            {
                Info.Album = Marshal.PtrToStringUni(tmp.Album);
                Info.Artist = Marshal.PtrToStringUni(tmp.Artist);
                Info.Comment = Marshal.PtrToStringUni(tmp.Comment);
                Info.Genre = Marshal.PtrToStringUni(tmp.Genre);
                Info.Title = Marshal.PtrToStringUni(tmp.Title);
                Info.Track = Marshal.PtrToStringUni(tmp.Track);
                Info.Year = Marshal.PtrToStringUni(tmp.Year);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LoadID3Ex(ref TID3InfoEx Info, bool fDecodePicture)
        {
            TID3InfoEx_Internal tmp = new TID3InfoEx_Internal();
              
            if (zplay_LoadID3ExW(this.objptr, ref tmp, 0) == 1)
            {
                Info.Album = Marshal.PtrToStringUni(tmp.Album);
                Info.Artist = Marshal.PtrToStringUni(tmp.Artist);
                Info.Comment = Marshal.PtrToStringUni(tmp.Comment);
                Info.Genre = Marshal.PtrToStringUni(tmp.Genre);
                Info.Title = Marshal.PtrToStringUni(tmp.Title);
                Info.Track = Marshal.PtrToStringUni(tmp.Track);
                Info.Year = Marshal.PtrToStringUni(tmp.Year);
                  
                Info.AlbumArtist = Marshal.PtrToStringUni(tmp.AlbumArtist);
                Info.Composer = Marshal.PtrToStringUni(tmp.Composer);
                Info.OriginalArtist = Marshal.PtrToStringUni(tmp.OriginalArtist);
                Info.Copyright = Marshal.PtrToStringUni(tmp.Copyright);
                Info.Encoder = Marshal.PtrToStringUni(tmp.Encoder);
                Info.Publisher = Marshal.PtrToStringUni(tmp.Publisher);
                Info.BPM = tmp.BPM;
                  
                Info.Picture.PicturePresent = false;
                if (fDecodePicture)
                {
                    try
                    {
                        if (tmp.PicturePresent == 1)
                        {
                            byte[] stream_data = new byte[System.Convert.ToInt32(tmp.PictureDataSize) + 1];
                            Marshal.Copy(tmp.PictureData, stream_data, 0, tmp.PictureDataSize);
                            Info.Picture.BitStream = new System.IO.MemoryStream();
                            Info.Picture.BitStream.Write(stream_data, 0, tmp.PictureDataSize);
                            Info.Picture.Bitmap = new Bitmap(Info.Picture.BitStream);
                            Info.Picture.PictureType = tmp.PictureType;
                            Info.Picture.Description = Marshal.PtrToStringUni(tmp.Description);
                            Info.Picture.PicturePresent = true;
                        }
                        else
                        {
                            Info.Picture.Bitmap = new Bitmap(1, 1);
                        }
                        return true;
                    }
                    catch
                    {
                        Info.Picture.PicturePresent = false;
                    }
                }
            }
            else
            {
                return false;
            }
              
            return false;
        }
        public bool LoadFileID3(string FileName, TStreamFormat Format, TID3Version Id3Version, ref TID3Info Info)
        {
            TID3Info_Internal tmp = new TID3Info_Internal();
            if (zplay_LoadFileID3W(this.objptr, FileName, System.Convert.ToInt32(Format), System.Convert.ToInt32((int)(Id3Version)), ref tmp) == 1)
            {
                Info.Album = Marshal.PtrToStringUni(tmp.Album);
                Info.Artist = Marshal.PtrToStringUni(tmp.Artist);
                Info.Comment = Marshal.PtrToStringUni(tmp.Comment);
                Info.Genre = Marshal.PtrToStringUni(tmp.Genre);
                Info.Title = Marshal.PtrToStringUni(tmp.Title);
                Info.Track = Marshal.PtrToStringUni(tmp.Track);
                Info.Year = Marshal.PtrToStringUni(tmp.Year);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LoadFileID3Ex(string FileName, TStreamFormat Format, ref TID3InfoEx Info, bool fDecodePicture)
        {
            TID3InfoEx_Internal tmp = new TID3InfoEx_Internal();
              
            if (zplay_LoadFileID3ExW(this.objptr, FileName, System.Convert.ToInt32(Format), ref tmp, 0) == 1)
            {
                Info.Album = Marshal.PtrToStringUni(tmp.Album);
                Info.Artist = Marshal.PtrToStringUni(tmp.Artist);
                Info.Comment = Marshal.PtrToStringUni(tmp.Comment);
                Info.Genre = Marshal.PtrToStringUni(tmp.Genre);
                Info.Title = Marshal.PtrToStringUni(tmp.Title);
                Info.Track = Marshal.PtrToStringUni(tmp.Track);
                Info.Year = Marshal.PtrToStringUni(tmp.Year);
                  
                Info.AlbumArtist = Marshal.PtrToStringUni(tmp.AlbumArtist);
                Info.Composer = Marshal.PtrToStringUni(tmp.Composer);
                Info.OriginalArtist = Marshal.PtrToStringUni(tmp.OriginalArtist);
                Info.Copyright = Marshal.PtrToStringUni(tmp.Copyright);
                Info.Encoder = Marshal.PtrToStringUni(tmp.Encoder);
                Info.Publisher = Marshal.PtrToStringUni(tmp.Publisher);
                Info.BPM = tmp.BPM;
                  
                Info.Picture.PicturePresent = false;
                if (fDecodePicture)
                {
                    try
                    {
                        if (tmp.PicturePresent == 1)
                        {
                            byte[] stream_data = new byte[System.Convert.ToInt32(tmp.PictureDataSize) + 1];
                            Marshal.Copy(tmp.PictureData, stream_data, 0, tmp.PictureDataSize);
                            Info.Picture.BitStream = new System.IO.MemoryStream();
                            Info.Picture.BitStream.Write(stream_data, 0, tmp.PictureDataSize);
                            Info.Picture.Bitmap = new Bitmap(Info.Picture.BitStream);
                            Info.Picture.PictureType = tmp.PictureType;
                            Info.Picture.Description = Marshal.PtrToStringUni(tmp.Description);
                            Info.Picture.PicturePresent = true;
                        }
                        else
                        {
                            Info.Picture.Bitmap = new Bitmap(1, 1);
                        }
                        return true;
                    }
                    catch
                    {
                        Info.Picture.PicturePresent = false;
                    }
                }
            }
            else
            {
                return false;
            }
              
            return false;
        }
        #endregion
        #region Callback
        public bool SetCallbackFunc(TCallbackFunc CallbackFunc, TCallbackMessage Messages, int UserData)
        {
            return zplay_SetCallbackFunc(this.objptr, CallbackFunc, Messages, UserData) == 1;
        }
        #endregion
        #region Beat-Per-Minute
        public int DetectBPM(TBPMDetectionMethod Method)
        {
            return zplay_DetectBPM(this.objptr, System.Convert.ToUInt32(Method));
        }
        public int DetectFileBPM(string FileName, TStreamFormat Format, TBPMDetectionMethod Method)
        {
            return zplay_DetectFileBPMW(this.objptr, FileName, System.Convert.ToInt32(Format), System.Convert.ToUInt32(Method));
        }
        #endregion
        #region FFT Graph and FFT values
        public bool GetFFTData(int FFTPoints, TFFTWindow FFTWindow, ref int HarmonicNumber, ref int[] HarmonicFreq, ref int[] LeftAmplitude, ref int[] RightAmplitude, ref int[] LeftPhase, ref int[] RightPhase)
        {
            return zplay_GetFFTData(this.objptr, FFTPoints, System.Convert.ToInt32((int)(FFTWindow)), ref HarmonicNumber, HarmonicFreq, LeftAmplitude, RightAmplitude, LeftPhase, RightPhase) == 1;
        }
        public bool DrawFFTGraphOnHDC(System.IntPtr hdc, int X, int Y, int Width, int Height)
        {
            return zplay_DrawFFTGraphOnHDC(this.objptr, hdc, X, Y, Width, Height) == 1;
        }
        public bool DrawFFTGraphOnHWND(System.IntPtr hwnd, int X, int Y, int Width, int Height)
        {
            return zplay_DrawFFTGraphOnHWND(this.objptr, hwnd, X, Y, Width, Height) == 1;
        }
        public bool SetFFTGraphParam(TFFTGraphParamID ParamID, int ParamValue)
        {
            return zplay_SetFFTGraphParam(this.objptr, System.Convert.ToInt32((int)(ParamID)), ParamValue) == 1;
        }
        public int GetFFTGraphParam(TFFTGraphParamID ParamID)
        {
            return zplay_GetFFTGraphParam(this.objptr, System.Convert.ToInt32((int)(ParamID)));
        }
        #endregion
        #region Center and side cut
        public bool StereoCut(bool Enable, bool OutputCenter, bool BassToSides)
        {
            int fOutputCenter = 0;
            int fBassToSides = 0;
            int fEnable = 0;
            if (OutputCenter)
            {
                fOutputCenter = 1;
            }
            if (BassToSides)
            {
                fBassToSides = 1;
            }
            if (Enable)
            {
                fEnable = 1;
            }
            return zplay_StereoCut(this.objptr, fEnable, fOutputCenter, fBassToSides) == 1;
        }
        #endregion
        #region Channel mixing
        public bool MixChannels(bool Enable, uint LeftPercent, uint RightPercent)
        {
            if (Enable)
            {
                return zplay_MixChannels(this.objptr, 1, LeftPercent, RightPercent) == 1;
            }
            else
            {
                return zplay_MixChannels(this.objptr, 0, LeftPercent, RightPercent) == 1;
            }
        }
        #endregion
        #region VU Data
        public void GetVUData(ref int LeftChannel, ref int RightChannel)
        {
            zplay_GetVUData(this.objptr, ref LeftChannel, ref RightChannel);
        }
        #endregion
        #region Status and Info
        public void GetStreamInfo(ref TStreamInfo info)
        {
            TStreamInfo_Internal tmp = new TStreamInfo_Internal();
            zplay_GetStreamInfoW(this.objptr, ref tmp);
            info.Bitrate = tmp.Bitrate;
            info.ChannelNumber = tmp.ChannelNumber;
            info.SamplingRate = tmp.SamplingRate;
            info.VBR = tmp.VBR;
            info.Length = tmp.Length;
            info.Description = Marshal.PtrToStringUni(tmp.Description);
        }
        public void GetStatus(ref TStreamStatus status)
        {
            zplay_GetStatus(this.objptr, ref status);
        }
        public void GetDynamicStreamLoad(ref TStreamLoadInfo StreamLoadInfo)
        {
            zplay_GetDynamicStreamLoad(this.objptr, ref StreamLoadInfo);
        }
        #endregion
        #region Wave Out and Wave In Info
        public int EnumerateWaveOut()
        {
            return zplay_EnumerateWaveOut(this.objptr);
        }
        public bool GetWaveOutInfo(uint Index, ref TWaveOutInfo Info)
        {
            TWaveOutInfo_Internal tmp = new TWaveOutInfo_Internal();
            if (zplay_GetWaveOutInfoW(this.objptr, Index, ref tmp) == 0)
            {
                return false;
            }
            Info.Channels = tmp.Channels;
            Info.DriverVersion = tmp.DriverVersion;
            Info.Formats = tmp.Formats;
            Info.ManufacturerID = tmp.ManufacturerID;
            Info.ProductID = tmp.ProductID;
            Info.Support = tmp.Support;
            Info.ProductName = Marshal.PtrToStringUni(tmp.ProductName);
            return true;
        }
        public bool SetWaveOutDevice(uint Index)
        {
            return zplay_SetWaveOutDevice(this.objptr, Index) == 1;
        }
        public int EnumerateWaveIn()
        {
            return zplay_EnumerateWaveIn(this.objptr);
        }
        public bool GetWaveInInfo(uint Index, ref TWaveInInfo Info)
        {
            TWaveInInfo_Internal tmp = new TWaveInInfo_Internal();
            if (zplay_GetWaveInInfoW(this.objptr, Index, ref tmp) == 0)
            {
                return false;
            }
            Info.Channels = tmp.Channels;
            Info.DriverVersion = tmp.DriverVersion;
            Info.Formats = tmp.Formats;
            Info.ManufacturerID = tmp.ManufacturerID;
            Info.ProductID = tmp.ProductID;
            Info.ProductName = Marshal.PtrToStringUni(tmp.ProductName);
            return true;
        }
        public bool SetWaveInDevice(uint Index)
        {
            return zplay_SetWaveInDevice(this.objptr, Index) == 1;
        }
        #endregion
        #region Settings
        public int SetSettings(TSettingID SettingID, int Value)
        {
            return zplay_SetSettings(this.objptr, (int)SettingID, Value);
        }
        public int GetSettings(TSettingID SettingID)
        {
            return zplay_GetSettings(this.objptr, (int)SettingID);
        }
        #endregion
    }
}