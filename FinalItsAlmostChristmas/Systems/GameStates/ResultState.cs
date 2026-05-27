
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalItsAlmostChristmas
{
    public class ResultState : GameState
    {
        Sprite ResultsBG;
        ButtonManager resultScreenButtonManager;
        Button backToMainMenuButton;
        Button retryButton;
        public ResultState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
            resultScreenButtonManager.isBeingUsed = false;
            ResultsBG = new(TexturesAndFonts.getInstance().resultScreen, Vector2.Zero);
            resultScreenButtonManager = new(ButtonTypes.LeftToRight);

            backToMainMenuButton = new(new Vector2(1400, 860), "Main Menu");
            retryButton = new(new Vector2(1700, 860), "Retry");

            resultScreenButtonManager.buttons.Add(backToMainMenuButton);
            resultScreenButtonManager.buttons.Add(retryButton);
        }

        public override void OnEnter()
        {
            resultScreenButtonManager.isBeingUsed = true;
        }
        public override void OnExit()
        {
            resultScreenButtonManager.isBeingUsed = false;
        }

        public override void LoadContent()
        {
        }
        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(GameTime gameTime)
        {
            ResultsBG.Draw(_spritebatch); 
        }
    }
    
}
