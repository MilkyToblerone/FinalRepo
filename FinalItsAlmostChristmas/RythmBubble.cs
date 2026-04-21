using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class RythmBubble
{
    ScaleableSprite bubbleBase;
    ScaleableSprite bubbleCircle;
    bool isInstantiated;
    float tickDownSpeed;
    public RythmBubble(ScaleableSprite bubbleBase, ScaleableSprite bubbleCircle,float tickDownSpeed)
    {
        this.bubbleBase = bubbleBase;
        this.bubbleCircle = bubbleCircle;
        this.tickDownSpeed = tickDownSpeed;
    }
    public void TickDownBubble()
    {
        if (bubbleCircle.scale > 0)
        {
            bubbleCircle.scale -= tickDownSpeed;
        }
        else
        {
            bubbleCircle.scale = 0;
        }
    }
    public void SpawnCircle(float baseScale,SpriteBatch spriteBatch)
    {
        if (!isInstantiated)
        {
            bubbleBase.scale = baseScale;
            bubbleCircle.scale = baseScale * 1.5f;
            isInstantiated = true;
        }
        DrawCircle(spriteBatch);
    }
    public void DrawCircle(SpriteBatch spriteBatch)
    {
        bubbleBase.Draw(spriteBatch);
        bubbleCircle.Draw(spriteBatch);
    }
}