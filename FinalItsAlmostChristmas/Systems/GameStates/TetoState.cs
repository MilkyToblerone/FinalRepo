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
        private Texture2D bubbleBaseTexture;
        private Texture2D bubbleCircleTexture;
        private SpriteFont comboFont;
        Random random = new();
        float timer =0;
        
        private List<RythmBubble> rhythmBubbles;
        private float bubbleTickDownSpeed = 0.0005f;
        private float bubbleInitialScale = 0.05f;

        
        public GameState nextState;
        
        public TetoState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
            rhythmBubbles = new List<RythmBubble>();
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