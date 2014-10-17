// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =GameStateManager.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace SB2Revival
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameStateManager : Microsoft.Xna.Framework.GameComponent
    {
        #region Event Region
        public event EventHandler OnStateChange;
        #endregion
        #region Fields and Properties Region
        Stack<GameState> gameStates = new Stack<GameState>();
        const int startDrawOrder = 5000;
        const int drawOrderInc = 100;
        int drawOrder;
        public GameState CurrentState
        {
            get
            {
                return this.gameStates.Peek();
            }
        }
        #endregion
        #region Constructor Region
        public GameStateManager(Game game) : base(game)
        {
            this.drawOrder = startDrawOrder;
        }
        #endregion
        #region XNA Method Region
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        #endregion
        #region Methods Region
        public void PopState()
        {
            if (this.gameStates.Count > 0)
            {
                this.RemoveState();
                this.drawOrder -= drawOrderInc;
                if (this.OnStateChange != null)
                {
                    this.OnStateChange(this, null);
                }
            }
        }
        private void RemoveState()
        {
            GameState State = this.gameStates.Peek();
            this.OnStateChange -= State.StateChange;
            this.Game.Components.Remove(State);
            this.gameStates.Pop();
        }
        public void PushState(GameState newState)
        {
            this.drawOrder += drawOrderInc;
            newState.DrawOrder = this.drawOrder;
            this.AddState(newState);
            if (this.OnStateChange != null)
            {
                this.OnStateChange(this, null);
            }
        }
        private void AddState(GameState newState)
        {
            this.gameStates.Push(newState);
            this.Game.Components.Add(newState);
            this.OnStateChange += newState.StateChange;
        }
        public void ChangeState(GameState newState)
        {
            while (this.gameStates.Count > 0)
            {
                this.RemoveState();
            }
            newState.DrawOrder = startDrawOrder;
            this.drawOrder = startDrawOrder;
            this.AddState(newState);
            if (this.OnStateChange != null)
            {
                this.OnStateChange(this, null);
            }
        }
        #endregion
    }
}