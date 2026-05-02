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
        private ScaleableSprite scaleableTeto;
        Random random = new();
        float timer =0;
        
        private List<RythmBubble> rhythmBubbles;
        private float bubbleTickDownSpeed = 0.0005f;
        private float bubbleInitialScale = 0.05f;
        Song bookendSong;
        
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
            bookendSong = game1.Content.Load<Song>("BookendOpening");
            bubbleBaseTexture = game1.Content.Load<Texture2D>("Bubble");
            bubbleCircleTexture = game1.Content.Load<Texture2D>("Circle");
            scaleableTeto = new ScaleableSprite(game1.Content.Load<Texture2D>("fatass"), Vector2.Zero, 0.5f);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Tab))
            {
                if (MediaPlayer.State == MediaState.Playing) return;
                ChartManager.getInstance().StartingSong(bookendSong, 123);
                
            }
            timer += 0.1f;
            
            for (int i = rhythmBubbles.Count - 1; i >= 0; i--)
            {
                
                rhythmBubbles[i].Update();
                if (!rhythmBubbles[i].isActive)
                {
                    rhythmBubbles.RemoveAt(i);
                }
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && timer > 2)
            {
                timer = 0;
                SpawnRythmBubble(new Vector2(random.Next(0,600), random.Next(0,600)));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            
            foreach (var bubble in rhythmBubbles)
            {
                bubble.Draw(_spritebatch);
            }
        }
        
        public void SpawnRythmBubble(Vector2 position)
        {
            RythmBubble newBubble = new RythmBubble(
                bubbleBaseTexture,
                bubbleCircleTexture,
                position,
                bubbleInitialScale,
                bubbleTickDownSpeed
            );
            rhythmBubbles.Add(newBubble);
        }
    }
}