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

    public bool IsExpired { get; set; }

    double timer;
    double lastSongMS;
    readonly float _initialOuterScale;
    bool _ringStarted;
    public int beatItisOn;
    public int orderNumber;
    Random random;
    int randomXvalue;
    Vector2 pos = new();

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
    public NewRythmBubbles(double chartTime, double timeToClose, ToolTypes toolType,int orderNumber)
    {
        this.chartTime = chartTime;
        this.timeToClose = timeToClose;
        this.toolType = toolType;

        var game = TexturesAndFonts.getInstance().game1;
        var baseTex = game.Content.Load<Texture2D>("Bubble");
        var circleTex = game.Content.Load<Texture2D>("Circle");
        Vector2 pos = new();
        const float initialScale = 0.05f;
        bubbleTexture = new ScaleableSprite(baseTex, pos, initialScale);
        _initialOuterScale = initialScale * 2f;
        outerBubbleTexture = new ScaleableSprite(circleTex, pos, _initialOuterScale);
        random = new();
        randomXvalue = random.Next(100);
        this.orderNumber = orderNumber;
        switch (orderNumber)
        {
            case 0:
                this.pos = new Vector2(910 + randomXvalue, 250);
                break;
            case 1:
                this.pos = new Vector2(910 + randomXvalue, 550);
                break;
            case 2:
                this.pos = new Vector2(910 + randomXvalue, 850);
                break;
        }
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
        else
        {
            timer += songMs - lastSongMS;
        }

        float progress = MathHelper.Clamp((float)(timer / timeToClose), 0f, 1f);
        if(progress < 0.5f) outerBubbleTexture.scale = MathHelper.Lerp(_initialOuterScale, 0.05f, progress * 2);
        else outerBubbleTexture.scale = MathHelper.Lerp(_initialOuterScale, 0f, progress);
        if (outerBubbleTexture.scale <= 0f || progress >= 1f)
        {
            isActive = false;
            IsExpired = true;
            ChartManager.getInstance().missNumber++;
            ChartManager.getInstance().Miss?.Invoke();
        }
        lastSongMS = ChartManager.getInstance().songElapsedTime;
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        System.Console.WriteLine(orderNumber);
        if (!isActive)
            return;
        bubbleTexture.Draw(spriteBatch, Color.White,pos);
        outerBubbleTexture.Draw(spriteBatch, Color.White,pos);
    }
}