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
        }
        public override void Update(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                StateManager.SwitchState(nextState);
            }
        }
        public override void Draw(GameTime gameTime)
        {
            _spritebatch.Draw(tetoTexture,new Rectangle(100,100,500,500),Color.White);
        }
    }
}