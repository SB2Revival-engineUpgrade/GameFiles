// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =GameState.cs=
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
    public class GameState : DrawableGameComponent
    {
        #region Fields and Properties
        List<GameComponent> childComponents;
        public List<GameComponent> Components
        {
            get
            {
                return this.childComponents;
            }
        }
        GameState tag;
        public GameState Tag
        {
            get
            {
                return this.tag;
            }
        }
        protected GameStateManager StateManager;
        #endregion
        #region Constructor Region
        public GameState(Game game, GameStateManager manager) : base(game)
        {
            this.StateManager = manager;
            this.childComponents = new List<GameComponent>();
            this.tag = this;
        }
        #endregion
        #region XNA Drawable Game Component Methods
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent component in this.childComponents)
            {
                if (component.Enabled)
                {
                    component.Update(gameTime);
                }
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent drawComponent;
            foreach (GameComponent component in this.childComponents)
            {
                if (component is DrawableGameComponent)
                {
                    drawComponent = component as DrawableGameComponent;
                    if (drawComponent.Visible)
                    {
                        drawComponent.Draw(gameTime);
                    }
                }
            }
            base.Draw(gameTime);
        }
        #endregion
        #region GameState Method Region
        internal protected virtual void StateChange(object sender, EventArgs e)
        {
            if (this.StateManager.CurrentState == this.Tag)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }
        protected virtual void Show()
        {
            this.Visible = true;
            this.Enabled = true;
            foreach (GameComponent component in this.childComponents)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = true;
                }
            }
        }
        protected virtual void Hide()
        {
            this.Visible = false;
            this.Enabled = false;
            foreach (GameComponent component in this.childComponents)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = false;
                }
            }
        }
        #endregion
    }
}