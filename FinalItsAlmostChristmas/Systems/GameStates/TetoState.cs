using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace FinalItsAlmostChristmas
{
    public class TetoState : GameState
    {
        
        public GameState nextState;
        
        public TetoState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
        }

        public override void OnEnter()
        {
        }
        
        public override void OnExit()
        {
        }

        public override void LoadContent()
        {
            nextState = new SongState(game1, _spritebatch);
            nextState.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Tab))
            {
                StateManager.SwitchState(nextState);
                
            }
            
        }

        public override void Draw(GameTime gameTime)
        {
        }
        
    }
}