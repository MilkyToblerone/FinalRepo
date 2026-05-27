
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalItsAlmostChristmas
{
    public class ResultState : GameState
    {
        Sprite ResultsBG;
        ScaleableSprite rank;
        ButtonManager resultScreenButtonManager;
        Button backToMainMenuButton;
        Button retryButton;
        public static int rythmBubbleAmount;
        public static GameState songState;
        public static GameState mikuState;
        float timer;
        float complationPercent;
        bool sfxPlayed;
        bool mainmenuPressed = false;
        float menuTimer=0;
        public ResultState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
            ResultsBG = new(TexturesAndFonts.getInstance().resultScreen, Vector2.Zero);
            rank = new(new Vector2(1740, 180), 0.2f);
            resultScreenButtonManager = new(ButtonTypes.LeftToRight);

            backToMainMenuButton = new(new Vector2(1350, 820), "Main Menu",TexturesAndFonts.getInstance().fightFontSmall,false);
            retryButton = new(new Vector2(1650, 820), "Retry",TexturesAndFonts.getInstance().fightFontSmall,false);

            resultScreenButtonManager.buttons.Add(backToMainMenuButton);
            resultScreenButtonManager.buttons.Add(retryButton);
            resultScreenButtonManager.isBeingUsed = false;

            backToMainMenuButton.OnPressed += MainMenuPressed;
            retryButton.OnPressed += RetryPressed;
        }

        public override void OnEnter()
        {
            resultScreenButtonManager.isBeingUsed = true;
            timer = 0;
            complationPercent = 0;
            sfxPlayed = false;
            System.Console.WriteLine(rythmBubbleAmount);
            mainmenuPressed = false;
            menuTimer=0;
            
            if (rythmBubbleAmount > 0)
            {
                float perfectGiverAmount = 100f / (float)rythmBubbleAmount;
                float goodGiverAmount = perfectGiverAmount / 2f;
                float okayGiverAmount = goodGiverAmount / 2f;
                float badGiverAmount = okayGiverAmount / 2f;

                complationPercent += perfectGiverAmount * ChartManager.getInstance().perfectNumber;
                complationPercent += goodGiverAmount * ChartManager.getInstance().goodNumber;
                complationPercent += okayGiverAmount * ChartManager.getInstance().okayNumber;
                complationPercent += badGiverAmount * ChartManager.getInstance().badNumber;
                System.Console.WriteLine(perfectGiverAmount);
            }
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
            resultScreenButtonManager.Update(gameTime);
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (mainmenuPressed) menuTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (menuTimer > 0.2f) StateManager.SwitchState(mikuState);
        }
        public override void Draw(GameTime gameTime)
        {
            ResultsBG.Draw(_spritebatch);
            resultScreenButtonManager.Draw(_spritebatch);
            DrawResults();
            if (timer > 14 && !sfxPlayed)
            {
                TexturesAndFonts.getInstance().writingSFX.Play();
                sfxPlayed = true;
            }
        }

        private void DrawResults()
        {
            if (timer > 2)
            {
                _spritebatch.DrawString(TexturesAndFonts.getInstance().fightFont, "Miss: "
                + (int)MathHelper.Lerp(0, ChartManager.getInstance().missNumber, Math.Clamp(timer - 2, 0, 1)), new Vector2(1160, 640), Color.Red);
            }
            if (timer > 4)
            {
                _spritebatch.DrawString(TexturesAndFonts.getInstance().fightFont, "Bad: "
                + (int)MathHelper.Lerp(0, ChartManager.getInstance().badNumber, Math.Clamp(timer - 4, 0, 1)), new Vector2(1160, 550), Color.Orange);
            }
            if (timer > 6)
            {
                _spritebatch.DrawString(TexturesAndFonts.getInstance().fightFont, "Okay: "
                + (int)MathHelper.Lerp(0, ChartManager.getInstance().okayNumber, Math.Clamp(timer - 6, 0, 1)), new Vector2(1160, 460), Color.Yellow);
            }
            if (timer > 8)
            {
                _spritebatch.DrawString(TexturesAndFonts.getInstance().fightFont, "Good: "
                + (int)MathHelper.Lerp(0, ChartManager.getInstance().goodNumber, Math.Clamp(timer - 8, 0, 1)), new Vector2(1160, 370), Color.LimeGreen);
            }
            if (timer > 10)
            {
                _spritebatch.DrawString(TexturesAndFonts.getInstance().fightFont, "Perfect: "
                + (int)MathHelper.Lerp(0, ChartManager.getInstance().perfectNumber, Math.Clamp(timer - 10, 0, 1)), new Vector2(1160, 280), Color.Gold);
            }
            if (timer > 12)
            {
                _spritebatch.DrawString(TexturesAndFonts.getInstance().fightFont,
                +(int)MathHelper.Lerp(0, complationPercent, Math.Clamp(timer - 12, 0, 1)) + "%", new Vector2(1200, 180), Color.White);
            }
            if (timer > 14)
            {
                switch (complationPercent)
                {
                    case > 90:
                        rank.spriteTexture = TexturesAndFonts.getInstance().STier;
                        break;
                    case > 70:
                        rank.spriteTexture = TexturesAndFonts.getInstance().ATier;
                        break;
                    case > 55:
                        rank.spriteTexture = TexturesAndFonts.getInstance().BTier;
                        break;
                    case > 40:
                        rank.spriteTexture = TexturesAndFonts.getInstance().CTier;
                        break;
                    default:
                        rank.spriteTexture = TexturesAndFonts.getInstance().FTier;
                        break;
                }
                rank.Draw(_spritebatch, 0.1f, 0.2f);
            }
        }


        void RetryPressed()
        {
            StateManager.SwitchState(songState);
        }
        void MainMenuPressed()
        {
            mainmenuPressed = true;
        }
    }
    
}
