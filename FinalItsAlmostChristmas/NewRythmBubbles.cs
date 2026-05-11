using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class NewRythmBubbles
{
    ScaleableSprite bubbleTexture;
    ScaleableSprite outerBubbleTexture;
    double chartTime;
    double timeToClose;
    ToolTypes toolType;
    Random random; //DELETE THIS THIS IS A TEST

    public bool isActive { get; private set; }

    public bool IsExpired { get; private set; }

    double timer;
    readonly float _initialOuterScale;
    bool _ringStarted;

    public NewRythmBubbles(double chartTime, double timeToClose, ToolTypes toolType)
    {
        this.chartTime = chartTime;
        this.timeToClose = timeToClose;
        this.toolType = toolType;
        random = new(); //DELETE THIS THIS IS A TEST

        var game = TexturesAndFonts.getInstance().game1;
        var baseTex = game.Content.Load<Texture2D>("Bubble");
        var circleTex = game.Content.Load<Texture2D>("Circle");
        var pos = new Vector2(random.Next(200, 500), 300);
        
        const float initialScale = 0.05f;
        bubbleTexture = new ScaleableSprite(baseTex, pos, initialScale);
        _initialOuterScale = initialScale * 1.5f; 
        outerBubbleTexture = new ScaleableSprite(circleTex, pos, _initialOuterScale);
    }
    public void Update(GameTime gameTime)
    {
        if (IsExpired)
            return;

        double songMs = ChartManager.getInstance().songElapsedTime;

        if (!_ringStarted)
        {
            if (songMs < chartTime)
                return;
            _ringStarted = true;
            isActive = true;
            timer = 0;
        }

        timer += gameTime.ElapsedGameTime.TotalMilliseconds;
        float progress = MathHelper.Clamp((float)(timer / timeToClose), 0f, 1f);
        outerBubbleTexture.scale = MathHelper.Lerp(_initialOuterScale, 0f, progress);
        if (outerBubbleTexture.scale <= 0f || progress >= 1f)
        {
            isActive = false;
            IsExpired = true;
        }
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        if (!isActive)
            return;
        bubbleTexture.Draw(spriteBatch);
        outerBubbleTexture.Draw(spriteBatch);
    }
}