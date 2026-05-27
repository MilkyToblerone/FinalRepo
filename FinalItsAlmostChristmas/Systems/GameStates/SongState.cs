using System;
using System.Collections;
using System.Collections.Generic;
using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FinalItsAlmostChristmas
{
    public class SongState : GameState
    {
        string startWriting;
        private double _countdownTimer;
        private bool _isCountingDown;
        private double _fadeOutTimer;
        private bool _isFadingOut;
        ScaleableSprite sideWallLeft;
        ScaleableSprite sideWallRight;
        ScaleableSprite reactionPic;

        GameState resultState;

        public SongState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
            resultState = new ResultState(game1, spriteBatch);
            ChartManager.getInstance().resultScene = resultState;
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
        }
        public override void OnExit()
        {
        }

        public override void LoadContent()
        {
            sideWallLeft = new(TexturesAndFonts.getInstance().sideWallTexture, new Vector2(1390, 540), 1f);
            sideWallRight = new(TexturesAndFonts.getInstance().sideWallTexture, new Vector2(530, 540), 1f);
            reactionPic = new(new Vector2(250, 250), 0.2f);
        }
        public override void Update(GameTime gameTime)
        {
            Countdown(gameTime);
            UpdateFadeIn(gameTime);
            ChartManager.getInstance().Update(gameTime);
            ManageReactionTexture();
            if (Keyboard.GetState().IsKeyDown(Keys.Tab))
            {
                StateManager.SwitchState(resultState);
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
