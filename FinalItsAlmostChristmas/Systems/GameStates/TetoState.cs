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

        Button rulerOfMyHeartButton;
        ScaleableSprite rulerOfMyHeartCover;


        Button tarkanopButton;
        ScaleableSprite tarkanopCover;

        SongState songState;
        TutorialState tutorialState;

        private const float CoverSize = 225f;
        private const float TopRowY = 322.5f;
        private const float BottomRowY = 730f;
        
        public TetoState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
            songState = new(game1, _spritebatch);
            tutorialState = new(game1, _spritebatch);
            songStateButtonManager = new(ButtonTypes.LeftToRight);
            songStateButtonManager.isBeingUsed = false;

            float spacing = (1920f - (4f * CoverSize)) / 5f;
            float topRowLeftInset = (1920f - (4f * CoverSize + 3f * spacing)) / 2f;
            float bottomRowLeftInset = (1920f - (2f * CoverSize + spacing)) / 2f;

            Vector2[] topRowPositions = new Vector2[4];
            for (int i = 0; i < topRowPositions.Length; i++)
            {
                topRowPositions[i] = new Vector2(topRowLeftInset + (CoverSize / 2f) + i * (CoverSize + spacing), TopRowY);
            }

            Vector2[] bottomRowPositions = new Vector2[2];
            for (int i = 0; i < bottomRowPositions.Length; i++)
            {
                bottomRowPositions[i] = new Vector2(bottomRowLeftInset + (CoverSize / 2f) + i * (CoverSize + spacing), BottomRowY);
            }

            tutorialButton = new(topRowPositions[0] + new Vector2(-90 , + 140), "Tutorial", TexturesAndFonts.getInstance().fightFontSmall);
            tutorialCover = new(TexturesAndFonts.getInstance().tutorialCover, topRowPositions[0], 0.5f);

            bookendSongButton = new(topRowPositions[1]+ new Vector2(-130 , + 140), "Bookend Song", TexturesAndFonts.getInstance().fightFontSmall);
            bookendSongCover = new(TexturesAndFonts.getInstance().bookendCover, topRowPositions[1], 0.5f);

            bakamitaiButton = new(topRowPositions[2]+ new Vector2(-110 , + 140), "Bakamitai", TexturesAndFonts.getInstance().fightFontSmall);
            bakamitaiCover = new(TexturesAndFonts.getInstance().bakamitaiCover, topRowPositions[2], 0.5f);

            loopingTheRooms = new(topRowPositions[3]+ new Vector2(-130 , + 140), "Looping the \n    rooms", TexturesAndFonts.getInstance().fightFontSmall);
            loopingTheRoomsCover = new(TexturesAndFonts.getInstance().loopingTheRoomsCover, topRowPositions[3], 0.5f);

            rulerOfMyHeartButton = new(bottomRowPositions[0]+ new Vector2(-130 , + 140), "Ruler of My\n    Heart", TexturesAndFonts.getInstance().fightFontSmall);
            rulerOfMyHeartCover = new(TexturesAndFonts.getInstance().rulerOfMyHeartCover, bottomRowPositions[0], 0.5f);

            tarkanopButton = new(bottomRowPositions[1]+ new Vector2(-110 , + 140), "Secret Song", TexturesAndFonts.getInstance().fightFontSmall);
            tarkanopCover = new(TexturesAndFonts.getInstance().tarkanopCover, bottomRowPositions[1], 0.5f);

            songStateButtonManager.buttons.Add(tutorialButton);
            songStateButtonManager.buttons.Add(bookendSongButton);
            songStateButtonManager.buttons.Add(bakamitaiButton);
            songStateButtonManager.buttons.Add(loopingTheRooms);
            songStateButtonManager.buttons.Add(rulerOfMyHeartButton);
            songStateButtonManager.buttons.Add(tarkanopButton);

            tutorialButton.OnPressed += SwitchoverToTutorial;
            bookendSongButton.OnPressed += SwitchoverToBookendSong;
            bakamitaiButton.OnPressed += SwitchovertoBakamitai;
            loopingTheRooms.OnPressed += SwitchoverToLoopingTheRooms;
            rulerOfMyHeartButton.OnPressed += SwitchoverToRulerOfMyHeart;
            tarkanopButton.OnPressed += SwitchoverToTarkanop;
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
            rulerOfMyHeartCover.Draw(_spritebatch, rulerOfMyHeartButton.currentScale / 2);
            tarkanopCover.Draw(_spritebatch, tarkanopButton.currentScale / 2);

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

        private void SwitchoverToRulerOfMyHeart()
        {
            ChartManager.getInstance().SetChart(ChartManager.getInstance().rulerOfMyHeart);
            StateManager.SwitchState(songState);
        }


        private void SwitchoverToTarkanop()
        {
            ChartManager.getInstance().SetChart(ChartManager.getInstance().tarkanopChart);
            StateManager.SwitchState(songState);
        }
    }
}