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
        List<string> writingList;
        private double _countdownTimer;
        private bool _isCountingDown;
        private double _fadeOutTimer;
        private bool _isFadingOut;
        private Chart chart;

        public SongState(Game1 game1, SpriteBatch spriteBatch) : base(game1, spriteBatch)
        {
        }

        public override void OnEnter()
        {
            _countdownTimer = 3.0;
            _isCountingDown = true;
            _isFadingOut = false;
            _fadeOutTimer = 0.0;
            startWriting = "3";
            writingList = new();
            writingList.Add(startWriting);
        }
        public override void OnExit()
        {
        }

        public override void LoadContent()
        {
            chart = new Chart();
            chart.Load();
            chart.AddRythmBubbles();
        }
        public override void Update(GameTime gameTime)
        {
            // Countdown first so the same frame "MINE!" starts the song, clock advances, then chart sees correct time.
            Countdown(gameTime);
            UpdateFadeIn(gameTime);
            ChartManager.getInstance().Update(gameTime);
            chart.Update(gameTime);
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
                    ChartManager.getInstance().StartingSong(TexturesAndFonts.getInstance().badApple,130);
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

            // elapsed time
            _spritebatch.DrawString(TexturesAndFonts.getInstance().fightFont,
            ChartManager.getInstance().songElapsedTime + " / " + ChartManager.getInstance().songTime
            , Vector2.Zero, Color.Black);

            // BPM
            _spritebatch.DrawString(TexturesAndFonts.getInstance().fightFont,
            "CurrentBeat = " + ChartManager.getInstance().currentBeat,
            new Vector2(0, 200), Color.BlueViolet);

            chart.Draw(_spritebatch);
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
