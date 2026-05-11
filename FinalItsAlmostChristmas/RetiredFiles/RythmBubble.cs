using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class RythmBubble
{
    private ScaleableSprite bubbleBase;
    private ScaleableSprite bubbleCircle;
    private float tickDownSpeed;
    public bool isActive { get; private set; }

    public RythmBubble(Texture2D baseTexture, Texture2D circleTexture, Vector2 position, float initialScale, float tickDownSpeed)
    {
        this.tickDownSpeed = tickDownSpeed;
        bubbleBase = new ScaleableSprite(baseTexture, position, initialScale);
        bubbleCircle = new ScaleableSprite(circleTexture, position, initialScale * 1.5f);
        isActive = true;
    }

    //  ########## RYTHMBUBBLE LOGIC #######################
    public void Update()
    {
        if (bubbleCircle.scale > 0)
        {
            bubbleCircle.scale -= tickDownSpeed;
        }
        else
        {
            bubbleCircle.scale = 0;
            isActive = false;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (isActive)
        {
            bubbleBase.Draw(spriteBatch);
            bubbleCircle.Draw(spriteBatch);
        }
    }
}