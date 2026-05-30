using System;
using System.Collections;
using System.Collections.Generic;
using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FinalItsAlmostChristmas
{
    public class TutorialState : GameState
    {
        string startWriting;
        private double _countdownTimer;
        private bool _isCountingDown;
        private double _fadeOutTimer;
        private bool _isFadingOut;
        ScaleableSprite sideWallLeft;
        ScaleableSprite sideWallRight;
        ScaleableSprite reactionPic;
        Animation toolAnim;
        ScaleableSprite pickaxeIcon;
        ScaleableSprite axeIcon;
        ScaleableSprite shovelIcon;
        GameState resultState;
        bool pickaxeUnlocked;
        bool axeUnlocked;
        bool shovelUnlocked;

        SoundEffect Line1;
        SoundEffect Line2;
        SoundEffect Line3;
        SoundEffect Line4;
        SoundEffect Line5;
        SoundEffect Line6;
        bool voiceLine1Played;
        bool voiceLine2Played;
        bool voiceLine3Played;
        bool voiceLine4Played;
        bool voiceLine5Played;
        bool voiceLine6Played;
        float voicelineTimer;
        bool glintLock;


        public TutorialState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
            resultState = new ResultState(game1, spriteBatch);
            ChartManager.getInstance().resultScene = resultState;
            toolAnim = new(4, 0.05f);
            InputSystems.getInstance().RythmButtonPressed += toolAnim.PlayAnimation;
            Line1 = game1.Content.Load<SoundEffect>("Tutorial Voicelines/Line_1");
            Line2 = game1.Content.Load<SoundEffect>("Tutorial Voicelines/Line_2");
            Line3 = game1.Content.Load<SoundEffect>("Tutorial Voicelines/Line_3");
            Line4 = game1.Content.Load<SoundEffect>("Tutorial Voicelines/Line_4");
            Line5 = game1.Content.Load<SoundEffect>("Tutorial Voicelines/Line_5");
            Line6 = game1.Content.Load<SoundEffect>("Tutorial Voicelines/Line_6");
        }

        public override void OnEnter()
        {
            ChartManager.getInstance().Reset();
            MediaPlayer.IsRepeating = false;
            MediaPlayer.Stop();
            _countdownTimer = 3.0;
            _isCountingDown = true;
            _isFadingOut = false;
            _fadeOutTimer = 0.0;
            startWriting = "3";
            ResultState.rythmBubbleAmount = ChartManager.getInstance().currentChart.allOfTheRythmBubbles.Count;
            InputSystems.getInstance().inputsLocked = true;
            voicelineTimer = 0;
            voiceLine1Played = false;
            voiceLine2Played = false;
            voiceLine3Played = false;
            voiceLine4Played = false;
            voiceLine5Played = false;
            voiceLine6Played = false;
            pickaxeUnlocked = false;
            axeUnlocked = false;
            shovelUnlocked = false;
        }
        public override void OnExit()
        {
        }

        public override void LoadContent()
        {
            sideWallLeft = new(TexturesAndFonts.getInstance().sideWallTexture, new Vector2(1390, 540), 1f);
            sideWallRight = new(TexturesAndFonts.getInstance().sideWallTexture, new Vector2(530, 540), 1f);
            reactionPic = new(new Vector2(250, 250), 0.2f);

            pickaxeIcon = new(TexturesAndFonts.getInstance().pickaxeIcon, new Vector2(150, 930), 1f);
            axeIcon = new(TexturesAndFonts.getInstance().axeIcon, new Vector2(350, 930), 1f);
            shovelIcon = new(TexturesAndFonts.getInstance().shovelIcon, new Vector2(550, 930), 1f);
        }
        public override void Update(GameTime gameTime)
        {
            Countdown(gameTime);
            UpdateFadeIn(gameTime);
            ChartManager.getInstance().Update(gameTime);
            ManageReactionTexture();
            toolAnim.Update(gameTime);
            if (_isCountingDown == false) voicelineTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (voicelineTimer > 4 && !voiceLine1Played)
            {
                Line1.Play();
                voiceLine1Played = true;
            }
            else if (voicelineTimer > 22 && !voiceLine2Played)
            {
                Line2.Play();
                voiceLine2Played = true;
                InputSystems.getInstance().inputsLocked = false;
                pickaxeUnlocked = true;
            }
            else if (voicelineTimer > 51 && !voiceLine3Played)
            {
                InputSystems.getInstance().inputsLocked = true;
                Line3.Play();
                voiceLine3Played = true;

            }
            else if (voicelineTimer > 54 && !glintLock)
            {
                glintLock = true;
                InputSystems.getInstance().inputsLocked = false;
                ChartManager.getInstance().songClock.songClockPaused = true;
                MediaPlayer.Pause();
            }
            else if (voicelineTimer > 68 && !voiceLine4Played)
            {
                ChartManager.getInstance().songClock.songClockPaused = false;
                MediaPlayer.Resume();
                InputSystems.getInstance().inputsLocked = false;
                Line4.Play();
                voiceLine4Played = true;
                axeUnlocked = true;
            }
            else if (voicelineTimer > 87 && !voiceLine5Played)
            {
                Line5.Play();
                voiceLine5Played = true;
                shovelUnlocked = true;
            }
            else if (voicelineTimer > 105 && !voiceLine6Played)
            {
                Line6.Play();
                voiceLine6Played = true;
            }
            else if (voicelineTimer > 117)
            {
                MusicPlayer.SongEnd?.Invoke();
            }
            
            


        }

        private void ManageReactionTexture()
        {

            
            switch (ChartManager.getInstance().reactionStatus)
            {
                case ReactionStatus.Perfect:
                    reactionPic.spriteTexture = TexturesAndFonts.getInstance().perfectReactionTexture;
                    break;
                case ReactionStatus.Good:
                    reactionPic.spriteTexture = TexturesAndFonts.getInstance().goodReactionTexture;
                    break;
                case ReactionStatus.Okay:
                    reactionPic.spriteTexture = TexturesAndFonts.getInstance().okayReactionTexture;
                    break;
                case ReactionStatus.Bad:
                    reactionPic.spriteTexture = TexturesAndFonts.getInstance().badReactionTexture;
                    break;
                case ReactionStatus.Miss:
                    reactionPic.spriteTexture = TexturesAndFonts.getInstance().missReactionTexture;
                    break;
            }
        }

        private void Countdown(GameTime gameTime)
        {
            if (_isCountingDown)
            {
                _countdownTimer -= gameTime.ElapsedGameTime.TotalSeconds;

                if (_countdownTimer > 2.0)
                    startWriting = "3";
                else if (_countdownTimer > 1.0)
                    startWriting = "2";
                else if (_countdownTimer > 0.0)
                    startWriting = "1";

                if (_countdownTimer <= 0.0)
                {
                    _isCountingDown = false;
                    startWriting = "MINE!";
                    _isFadingOut = true;
                    _fadeOutTimer = 1;
                    ChartManager.getInstance().StartingSong(ChartManager.getInstance().currentChart);
                    // ChartManager.getInstance().chartMaker.StartRecording();
                }
            }
        }

        private void UpdateFadeIn(GameTime gameTime)
        {
            if (_isFadingOut)
            {
                _fadeOutTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                if (_fadeOutTimer <= 0)
                {
                    _isFadingOut = false;
                    _fadeOutTimer = 0;
                    startWriting = "";
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            DrawStartWriting();
            sideWallLeft.Draw(_spritebatch, 0.01f, 1.5f);
            sideWallRight.Draw(_spritebatch, 0.01f, 1.5f, SpriteEffects.FlipHorizontally);
            reactionPic.Draw(_spritebatch, 0.2f, 0.4f);
            ChartManager.getInstance().Draw(_spritebatch);
            toolAnim.Draw(_spritebatch);

            if (pickaxeUnlocked)
            {
                _spritebatch.DrawString(TexturesAndFonts.getInstance().fightFont, "G",
                new Vector2(140, 700), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
                pickaxeIcon.Draw(_spritebatch, 0.3f, 0.16f);
            }
            if (axeUnlocked)
            {   
                _spritebatch.DrawString(TexturesAndFonts.getInstance().fightFont, "H",
                new Vector2(340, 700), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
                axeIcon.Draw(_spritebatch, 0.3f, 0.16f);
            }

            if (shovelUnlocked)
            {
                _spritebatch.DrawString(TexturesAndFonts.getInstance().fightFont, "J",
                new Vector2(540, 700), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
                shovelIcon.Draw(_spritebatch, 0.3f, 0.16f);
            }

        }

        private void DrawStartWriting()
        {
            float alpha = _isFadingOut ? (float)_fadeOutTimer : 1;
            Color drawColor = Color.White * alpha;
            
            var font = TexturesAndFonts.getInstance().fightFont;
            Vector2 textSize = font.MeasureString(startWriting);
            Vector2 centerPosition = new Vector2(game1.Window.ClientBounds.Width, game1.Window.ClientBounds.Height) * 0.5f;
            Vector2 drawPosition = centerPosition - (textSize * 0.5f);
            
            _spritebatch.DrawString(font, startWriting, drawPosition, drawColor);
        }
    }
}
