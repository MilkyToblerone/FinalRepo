using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Animation
{
    Texture2D animTextureSheet;
    int frameNumber;
    int currentFrame;
    float timeBetweenFrames;
    bool isPlaying;
    float timer;
    float timeBetweenFramesThreshold;
    public Animation(Texture2D animTextureSheet,int frameNumber,float timeBetweenFrames)
    {
        this.animTextureSheet = animTextureSheet;
        this.frameNumber = frameNumber;
        this.timeBetweenFrames = timeBetweenFrames;
    } 
    public void PlayAnimation(ToolTypes toolType)
    {
        isPlaying = true;
        currentFrame = 0;
        timer = 0;
        timeBetweenFramesThreshold = timeBetweenFrames;  
    }
    public void Update(GameTime gameTime)
    {
        if (isPlaying)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > timeBetweenFramesThreshold)
            {
                currentFrame++;
                timeBetweenFramesThreshold += timeBetweenFrames;
                if (currentFrame == frameNumber)
                {
                    currentFrame = 0;
                    isPlaying = false;
                }
            }
        }
        else
        {
            currentFrame = 0;
            timer = 0;
            timeBetweenFramesThreshold = timeBetweenFrames;
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(animTextureSheet, new Rectangle(960, 448, 632, 632),
        new Rectangle(animTextureSheet.Width / frameNumber * currentFrame, 0, animTextureSheet.Width / frameNumber, animTextureSheet.Height),
        Color.White,0,Vector2.Zero,SpriteEffects.None,0.9f);
    }
}