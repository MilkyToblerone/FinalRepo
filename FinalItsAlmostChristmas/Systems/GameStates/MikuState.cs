using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using System;

namespace FinalItsAlmostChristmas
{
    public class MikuState : GameState
    {
        GameState nextState;
        GameState credits;
        Button startGameButton;
        Button exitButton;
        Button creditsButton;
        ButtonManager mainMenuButtonManager;
        Sprite menuBG;
        Sprite songSelectBG;
        float switchTimer;
        float maxTimer = 0.5f;
        bool gameStartPressed;

        Vector2 menuBGPos = new(0, 0);
        Vector2 songSelectPos = new(0, 1080);
        public MikuState(Game1 game1, SpriteBatch spriteBatch,GameState tetoState,GameState credits) : base(game1, spriteBatch)
        {
            nextState = tetoState;
            this.credits = credits;
        }

        public override void OnEnter()
        {
            mainMenuButtonManager.isBeingUsed = true;
            MediaPlayer.Play(TexturesAndFonts.getInstance().blissBoutique);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.3f;
            switchTimer = 0f;
            gameStartPressed = false;

            foreach (var item in mainMenuButtonManager.buttons)
            {
                item.isActive = true;
            }
            songSelectPos = new(0, 1080);
            menuBGPos = new(0, 0);
        }
        public override void OnExit()
        {

        }

        public override void LoadContent()
        {
            menuBG = new(TexturesAndFonts.getInstance().mainMenuBG, Vector2.Zero);
            songSelectBG = new(TexturesAndFonts.getInstance().songSelectBG, new Vector2(0, 1920));
            mainMenuButtonManager = new(ButtonTypes.TopToBottom);

            startGameButton = new Button(new Vector2(1300, 600), "Start Game", TexturesAndFonts.getInstance().fightFont, true);
            creditsButton = new(new Vector2(1300, 760), "credits", TexturesAndFonts.getInstance().fightFont, true);
            exitButton = new(new Vector2(1300, 900), "exit", TexturesAndFonts.getInstance().fightFont, true);

            mainMenuButtonManager.buttons.Add(startGameButton);
            mainMenuButtonManager.buttons.Add(creditsButton);
            mainMenuButtonManager.buttons.Add(exitButton);
            mainMenuButtonManager.buttons[0].isHovered = true;

            startGameButton.OnPressed += StartGame;
            creditsButton.OnPressed += Credits;
            exitButton.OnPressed += ExitGame;
        }

        private void Credits()
        {
            mainMenuButtonManager.isBeingUsed = false;
            foreach (var item in mainMenuButtonManager.buttons)
            {
                item.isActive = false;
            }
            StateManager.SwitchState(credits);
        }

        private void ExitGame()
        {
            game1.Exit();
        }

        private void StartGame()
        {
            gameStartPressed = true;
            mainMenuButtonManager.isBeingUsed = false;
            foreach (var item in mainMenuButtonManager.buttons)
            {
                item.isActive = false;
            }
        }

        public override void Update(GameTime gameTime)
        {
            mainMenuButtonManager.Update(gameTime);
            if (gameStartPressed) SwitchStart(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            songSelectBG.Draw(_spritebatch,songSelectPos);
            menuBG.Draw(_spritebatch,menuBGPos);
            if (mainMenuButtonManager.isBeingUsed) mainMenuButtonManager.Draw(_spritebatch);
        }
        void SwitchStart(GameTime gameTime)
        {
            switchTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            float t = switchTimer / maxTimer;
            float eased = 1 - (1 - t) * (1 - t);
            songSelectPos.Y = MathHelper.Lerp(1080, 0, eased);
            menuBGPos.Y =  MathHelper.Lerp(0, -1080, eased);

            if (switchTimer >= maxTimer)
            {
                StateManager.SwitchState(nextState);
            }
        }
    }
}
