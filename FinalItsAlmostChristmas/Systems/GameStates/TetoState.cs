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

        Button bakamitaiButton;
        ScaleableSprite bakamitaiCover;

        Button loopingTheRooms;
        ScaleableSprite loopingTheRoomsCover;

        SongState songState;
        TutorialState tutorialState;
        
        public TetoState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
            songState = new(game1, _spritebatch);
            tutorialState = new(game1, _spritebatch);
            songStateButtonManager = new(ButtonTypes.LeftToRight);
            songStateButtonManager.isBeingUsed = false;

            tutorialButton = new(new Vector2(60, 330), "Tutorial",TexturesAndFonts.getInstance().fightFontSmall);
            tutorialCover = new(TexturesAndFonts.getInstance().tutorialCover, new Vector2(150, 200), 0.5f);

            bookendSongButton = new(new Vector2(410, 330), "Bookend Song",TexturesAndFonts.getInstance().fightFontSmall);
            bookendSongCover = new(TexturesAndFonts.getInstance().bookendCover, new Vector2(550, 200), 0.5f);

            bakamitaiButton = new(new Vector2(820, 330), "Bakamitai",TexturesAndFonts.getInstance().fightFontSmall);
            bakamitaiCover = new(TexturesAndFonts.getInstance().bakamitaiCover, new Vector2(950, 200), 0.5f);

            loopingTheRooms = new(new Vector2(1220, 330), "Looping the \n    rooms", TexturesAndFonts.getInstance().fightFontSmall);
            loopingTheRoomsCover = new(TexturesAndFonts.getInstance().loopingTheRoomsCover, new Vector2(1350, 200), 0.5f);


            songStateButtonManager.buttons.Add(tutorialButton);
            songStateButtonManager.buttons.Add(bookendSongButton);
            songStateButtonManager.buttons.Add(bakamitaiButton);
            songStateButtonManager.buttons.Add(loopingTheRooms);


            tutorialButton.OnPressed += SwitchoverToTutorial;
            bookendSongButton.OnPressed += SwitchoverToBookendSong;
            bakamitaiButton.OnPressed += SwitchovertoBakamitai;
            loopingTheRooms.OnPressed += SwitchoverToLoopingTheRooms;
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
            tutorialCover.Draw(_spritebatch, tutorialButton.currentScale / 2 );
            bakamitaiCover.Draw(_spritebatch, bakamitaiButton.currentScale / 2);
            loopingTheRoomsCover.Draw(_spritebatch, loopingTheRooms.currentScale/2);

            bookendSongCover.Draw(_spritebatch, bookendSongButton.currentScale/2);
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
        private void SwitchovertoBakamitai()
        {
            ChartManager.getInstance().SetChart(ChartManager.getInstance().bakamitaiChart);
            StateManager.SwitchState(songState);
        }
        
        private void SwitchoverToLoopingTheRooms()
        {
            ChartManager.getInstance().SetChart(ChartManager.getInstance().loopingTheRoomsChart);
            StateManager.SwitchState(songState);
        }
    }
}