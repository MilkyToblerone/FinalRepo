using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class NewRythmBubbles
{
    ScaleableSprite bubbleTexture;
    ScaleableSprite outerBubbleTexture;
    public double chartTime { get; private set; }
    public double timeToClose { get; private set; }
    public ToolTypes toolType;

    public bool isActive { get; private set; }

    public bool IsExpired { get; private set; }

    double timer;
    readonly float _initialOuterScale;
    bool _ringStarted;
    public int beatItisOn;

    public NewRythmBubbles(double chartTime, double timeToClose, ToolTypes toolType, Vector2 pos)
    {
        this.chartTime = chartTime;
        this.timeToClose = timeToClose;
        this.toolType = toolType;

        var game = TexturesAndFonts.getInstance().game1;
        var baseTex = game.Content.Load<Texture2D>("Bubble");
        var circleTex = game.Content.Load<Texture2D>("Circle");

        const float initialScale = 0.05f;
        bubbleTexture = new ScaleableSprite(baseTex, pos, initialScale);
        _initialOuterScale = initialScale * 2f;
        outerBubbleTexture = new ScaleableSprite(circleTex, pos, _initialOuterScale);
    }
    public NewRythmBubbles(double chartTime, double timeToClose, ToolTypes toolType)
    {
        this.chartTime = chartTime;
        this.timeToClose = timeToClose;
        this.toolType = toolType;

        var game = TexturesAndFonts.getInstance().game1;
        var baseTex = game.Content.Load<Texture2D>("Bubble");
        var circleTex = game.Content.Load<Texture2D>("Circle");
        var pos = new Vector2(200, 300);
        
        const float initialScale = 0.05f;
        bubbleTexture = new ScaleableSprite(baseTex, pos, initialScale);
        _initialOuterScale = initialScale * 2f; 
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
            timer = songMs - chartTime;  // Account for any overshoot
        }
        else
        {
            timer += gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        float progress = MathHelper.Clamp((float)(timer / timeToClose), 0f, 1f);
        outerBubbleTexture.scale = MathHelper.Lerp(_initialOuterScale, 0f, progress);
        if (outerBubbleTexture.scale <= 0f || progress >= 1f)
        {
            isActive = false;
            IsExpired = true;
            ChartManager.getInstance().missNumber++;
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