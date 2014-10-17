// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =MusicPlayer.cs=
// = 10/17/2014 =
// =Brothel=
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using Microsoft.Xna.Framework;
using SB2Revival.Music;
namespace SB2R.MuCom
{
    public class MusicPlayer : GameComponent
    {
        Game1 GameRef;
        ZPlay musicloads = new ZPlay();
        Timer hehe = new Timer(20);
        TStreamTime x = new TStreamTime();
        public MusicPlayer(Game game) : base(game)
        {
            this.GameRef = (Game1)game;
        }
        #region logic
        public void beGinMus(string file)
        {
            this.musicloads.OpenFile(file, TStreamFormat.sfAutodetect);
            this.musicloads.GetPosition(ref this.x);
            this.hehe.Elapsed += this.hehe_Elapsed;
            this.hehe.AutoReset = true;
            this.BeEnd(true);
            this.hehe.Enabled = true;
            this.hehe.Start();
        }
        void hehe_Elapsed(object sender, ElapsedEventArgs e)
        {
            TStreamStatus status = new TStreamStatus();
            this.musicloads.GetStatus(ref status);
            if (status.fPlay == false)
            {
                this.musicloads.StartPlayback();
            }
        }
        public void BeEnd(bool start)
        {
            if (start)
            {
                this.musicloads.StartPlayback();
            }
            else
            {
                this.musicloads.StopPlayback();
                this.hehe.Stop();
                this.musicloads.Close();
            }
        }
        public void SetVol(int Valume)
        {
            this.musicloads.SetPlayerVolume(Valume, Valume);
        }
        #endregion
    }
}