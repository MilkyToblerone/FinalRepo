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
        Sprite songSelectBG;
        Vector2 songSelectBGPos = new Vector2(0, 0);
        public GameState nextState;
        public GameState mainMenuScene;
        ButtonManager songStateButtonManager;
        Button badAppleButon;
        ScaleableSprite badAppleCover;

        Button bookendSongButton;
        ScaleableSprite bookendSongCover;

        SongState songState;
        
        public TetoState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
            songState = new(game1, _spritebatch);
            songStateButtonManager = new(ButtonTypes.LeftToRight);
            songStateButtonManager.isBeingUsed = false;

            badAppleButon = new(new Vector2(175, 700), "Bad Apple");
            badAppleCover = new(TexturesAndFonts.getInstance().badAppleCover, new Vector2(300, 400), 1f);

            bookendSongButton = new(new Vector2(700, 700), "Bookend Song");
            bookendSongCover = new(TexturesAndFonts.getInstance().bookendCover, new Vector2(925, 400), 1f);

            songStateButtonManager.buttons.Add(badAppleButon);
            songStateButtonManager.buttons.Add(bookendSongButton);

            badAppleButon.OnPressed += SwitchoverToBadApple; 
        }

        public override void OnEnter()
        {
            songStateButtonManager.isBeingUsed = true;
        }
        
        public override void OnExit()
        {
        }

        public override void LoadContent()
        {
            songSelectBG = new(TexturesAndFonts.getInstance().songSelectBG,songSelectBGPos);
            nextState = new SongState(game1, _spritebatch);
            nextState.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            songStateButtonManager.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            songSelectBG.Draw(_spritebatch, songSelectBGPos);
            songStateButtonManager.Draw(_spritebatch);
            badAppleCover.Draw(_spritebatch, badAppleButon.currentScale);

            bookendSongCover.Draw(_spritebatch, bookendSongButton.currentScale);
        }
        void SwitchoverToBadApple()
        {
            StateManager.SwitchState(songState);
        }
        
    }
}