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
        Button tutorialButton;
        ScaleableSprite tutorialCover;

        Button bookendSongButton;
        ScaleableSprite bookendSongCover;

        SongState songState;
        TutorialState tutorialState;
        
        public TetoState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
            songState = new(game1, _spritebatch);
            tutorialState = new(game1, _spritebatch);
            songStateButtonManager = new(ButtonTypes.LeftToRight);
            songStateButtonManager.isBeingUsed = false;

            tutorialButton = new(new Vector2(175, 700), "Tutorial");
            tutorialCover = new(TexturesAndFonts.getInstance().tutorialCover, new Vector2(300, 400), 1f);

            bookendSongButton = new(new Vector2(700, 700), "Bookend Song");
            bookendSongCover = new(TexturesAndFonts.getInstance().bookendCover, new Vector2(925, 400), 1f);

            songStateButtonManager.buttons.Add(tutorialButton);
            songStateButtonManager.buttons.Add(bookendSongButton);

            tutorialButton.OnPressed += SwitchoverToTutorial;
            bookendSongButton.OnPressed += SwitchoverToBookendSong; 
            ResultState.songState = songState;
        }

        public override void OnEnter()
        {
            songStateButtonManager.isBeingUsed = true;
        }
        
        public override void OnExit()
        {
            songStateButtonManager.isBeingUsed = false;
        }

        public override void LoadContent()
        {
            songSelectBG = new(TexturesAndFonts.getInstance().songSelectBG,songSelectBGPos);
            songState.LoadContent();
            tutorialState.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            songStateButtonManager.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            songSelectBG.Draw(_spritebatch, songSelectBGPos);
            songStateButtonManager.Draw(_spritebatch);
            tutorialCover.Draw(_spritebatch, tutorialButton.currentScale);

            bookendSongCover.Draw(_spritebatch, bookendSongButton.currentScale);
        }
        void SwitchoverToTutorial()
        {
            ChartManager.getInstance().SetChart(ChartManager.getInstance().tutorialChart);
            StateManager.SwitchState(tutorialState);
        }
        void SwitchoverToBookendSong()
        {
            ChartManager.getInstance().SetChart(ChartManager.getInstance().bookendChart);
            StateManager.SwitchState(songState);
        }
        
    }
}