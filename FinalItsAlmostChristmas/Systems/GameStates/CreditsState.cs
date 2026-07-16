using System;
using System.Diagnostics;
using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FinalItsAlmostChristmas
{
    public class CreditsState : GameState
    {
        GameState mainMenu;
        Sprite songSelectBG;
        ScaleableSprite credits;
        Button doguhanCredits;
        Button EsinCredits;
        Button kerimButton;

        Button backButton;
        bool mainmenuPressed = false;
        float menuTimer;

        ScaleableSprite chibiCredits;
        ScaleableSprite kerimCredits;
        ButtonManager buttonManagerCredits;
        public CreditsState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
            buttonManagerCredits = new ButtonManager(ButtonTypes.LeftToRight);
        }

        public override void OnEnter()
        {
            buttonManagerCredits.isBeingUsed = true;
            foreach (var item in buttonManagerCredits.buttons)
            {
                item.isActive = true;
            }
            menuTimer = 0;
            mainmenuPressed = false;
        }
        public override void OnExit()
        {
            buttonManagerCredits.isBeingUsed = false;
            foreach (var item in buttonManagerCredits.buttons)
            {
                item.isActive = false;
            }
            
        }

        public void LoadContent(GameState gameState)
        {
            mainMenu = gameState;
            songSelectBG = new(TexturesAndFonts.getInstance().songSelectBG, Vector2.Zero);
            chibiCredits = new(TexturesAndFonts.getInstance().chibiCredits, new Vector2(460, 550), 0.36f);
            kerimCredits = new(TexturesAndFonts.getInstance().kerimCredits, new Vector2(1100, 550), 0.65f);
            credits = new(TexturesAndFonts.getInstance().CREDITS, new Vector2(1500, 550), 1f);

            doguhanCredits = new(new Vector2(30, 890), "Doguhan's Social",TexturesAndFonts.getInstance().fightFontSmall,true);
            buttonManagerCredits.buttons.Add(doguhanCredits);
            EsinCredits = new(new Vector2(510, 890), "esin's Social",TexturesAndFonts.getInstance().fightFontSmall,true);
            buttonManagerCredits.buttons.Add(EsinCredits);
            kerimButton = new(new Vector2(900, 890), "Kerim(va)'s Social",TexturesAndFonts.getInstance().fightFontSmall,true);
            buttonManagerCredits.buttons.Add(kerimButton);
            backButton = new(new Vector2(1650, 890), "Go back",TexturesAndFonts.getInstance().fightFontSmall,true);
            buttonManagerCredits.buttons.Add(backButton);

            doguhanCredits.OnPressed += doguhanTwitch;
            EsinCredits.OnPressed += esinTiktok;
            backButton.OnPressed += backToMainMenu;
            kerimButton.OnPressed += kerimTwitter;

        }

        private void kerimTwitter()
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "https://x.com/DevAeix";
            process.Start();
        }

        private void backToMainMenu()
        {
            mainmenuPressed = true;
        }

        private void esinTiktok()
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "https://www.tiktok.com/@esinspiration1";
            process.Start();
        }

        private void doguhanTwitch()
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "https://www.twitch.tv/lumeniacdev";
            process.Start();
        }

        public override void Update(GameTime gameTime)
        {
            if (mainmenuPressed) menuTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (menuTimer > 0.2f) StateManager.SwitchState(mainMenu);
            buttonManagerCredits.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            credits.Draw(_spritebatch,Color.White,new Vector2(1600, 450));
            songSelectBG.Draw(_spritebatch);
            chibiCredits.Draw(_spritebatch);
            kerimCredits.Draw(_spritebatch);
            buttonManagerCredits.Draw(_spritebatch);
        }
    }
}