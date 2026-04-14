using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;

namespace FinalItsAlmostChristmas
{
    public class MikuState : GameState
    {
        Texture2D mikuTexture;
        GameState nextState;
        public MikuState(Game1 game1, SpriteBatch spriteBatch,GameState tetoState) : base(game1, spriteBatch)
        {
            nextState = tetoState;
        }

        public override void OnEnter()
        {
        }
        public override void OnExit()
        {
        }

        public override void LoadContent()
        {
            mikuTexture = game1.Content.Load<Texture2D>("BR_Miku");
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
            _spritebatch.Draw(mikuTexture,new Rectangle(100,100,500,500),Color.White);
        }
    }
}
