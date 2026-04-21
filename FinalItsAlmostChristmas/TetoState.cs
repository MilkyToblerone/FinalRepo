using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;

namespace FinalItsAlmostChristmas
{
    public class TetoState : GameState
    {
        Texture2D tetoTexture;
        ScaleableSprite bubbleImage;
        ScaleableSprite bubbleCircle;
        ScaleableSprite scaleableTeto;
        
        
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
            tetoTexture = game1.Content.Load<Texture2D>("fatass");
            bubbleImage.spriteTexture = game1.Content.Load<Texture2D>("Bubble");
            bubbleCircle.spriteTexture = game1.Content.Load<Texture2D>("Circle");
            bubbleImage = new ScaleableSprite(Vector2.Zero,1);
        }
        public override void Update(GameTime gameTime)
        {
            scaleableTeto.scale += 0.001f;
        }
        public override void Draw(GameTime gameTime)
        {
            scaleableTeto.Draw(_spritebatch);
        }
    }
}