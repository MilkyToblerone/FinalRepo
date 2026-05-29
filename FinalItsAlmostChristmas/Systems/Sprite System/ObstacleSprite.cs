using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

class ObstacleSprite 
{
    Vector2 pos = new();
    Color color = Color.White;
    NewRythmBubbles assigendRythmBubble;
    Texture2D spriteTexture;
    float scale = 0.43f;
    bool inFront;
    float layerNumber;
    float yPos = 180;
    Random random;

    SoundEffectInstance breakSFX;
    bool sfxPlayed = false;


    Rectangle sourceRect
    {
        get
        {
            return spriteTexture != null ? new Rectangle(0, 0, spriteTexture.Width, spriteTexture.Height) : Rectangle.Empty;
        }
    }

    public ObstacleSprite(NewRythmBubbles rythmBubble)
    {
        assigendRythmBubble = rythmBubble;
        random = new();

        // switch for setting up the pos.
        switch (assigendRythmBubble.orderNumber)
        {
            case 0:
                pos = new Vector2(960, yPos);
                break;
            case 1:
                pos = new Vector2(960, yPos + 340);
                break;
            case 2:
                pos = new Vector2(960, yPos + 680);
                break;
        }

        // switch for setting the texture and the break sound
        switch (assigendRythmBubble.toolType)
        {
            case ToolTypes.Pickaxe:
                spriteTexture = TexturesAndFonts.getInstance().stoneTexture;
                breakSFX = TexturesAndFonts.getInstance().RockBreakSFX.CreateInstance();
                breakSFX.Pitch = random.Next(-10, 10) / 10;
                breakSFX.Volume = 0.03f;
                break;
            case ToolTypes.Axe:
                spriteTexture = TexturesAndFonts.getInstance().woodTexture;
                breakSFX = TexturesAndFonts.getInstance().WoodBreakSFX.CreateInstance();
                breakSFX.Volume = 0.1f;
                break;
            case ToolTypes.Shovel:
                breakSFX = TexturesAndFonts.getInstance().DirtBreakSFX.CreateInstance();
                breakSFX.Pitch = random.Next(-10, 10) / 10;
                breakSFX.Volume = 0.1f;
                spriteTexture = TexturesAndFonts.getInstance().dirtTexture;
                break;
        }
    }
    
    public void Update(GameTime gameTime)
    {

        if (ChartManager.getInstance().currentChart.allOfTheRythmBubbles.IndexOf(assigendRythmBubble) > 2 && !(assigendRythmBubble.orderNumber == 0 && ChartManager.getInstance().currentChart.allOfTheRythmBubbles.IndexOf(assigendRythmBubble) == 3))
        {
            color = Color.Black;
            inFront = false;
            layerNumber = 0.1f;

        }
        else if (ChartManager.getInstance().currentChart.allOfTheRythmBubbles.IndexOf(assigendRythmBubble) != assigendRythmBubble.orderNumber && !inFront)
        {
            color = new Color(50, 50, 50);
            inFront = false;
            layerNumber = 0.2f;
        }
        else
        {
            color = Color.White;
            inFront = true;
            if (assigendRythmBubble.orderNumber == 0)
            {
                layerNumber = 0.3f;
            }
            else if (assigendRythmBubble.orderNumber == 1)
            {
                layerNumber = 0.31f;
            }
            else if (assigendRythmBubble.orderNumber == 2)
            {
                layerNumber = 0.32f;
            }
        }
        if (assigendRythmBubble.IsExpired && !sfxPlayed && breakSFX !=null) { breakSFX.Play(); sfxPlayed = true; }
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        if (spriteTexture == null) return;
        if (assigendRythmBubble.IsExpired) return;
        if (ChartManager.getInstance().currentChart.allOfTheRythmBubbles.IndexOf(assigendRythmBubble) > 5) return;
        Vector2 origin = new Vector2(spriteTexture.Width / 2f, spriteTexture.Height / 2f);
        spriteBatch.Draw(spriteTexture, pos, sourceRect, color, 0, origin, scale, SpriteEffects.None, layerNumber);
    }

}