using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class ScaleableSprite : Sprite
{
    public float scale;
    public ScaleableSprite(Texture2D texture, Vector2 Pos,float scale) : base(texture, Pos)
    {
        this.scale = scale;
    }
    public ScaleableSprite(Vector2 Pos,float scale) : base(Pos)
    {
        this.scale = scale;
    }


    public override void Draw(SpriteBatch spriteBatch)
    {
        if (spriteTexture != null)
        {
            Vector2 origin = new Vector2(spriteTexture.Width / 2f, spriteTexture.Height / 2f);
            spriteBatch.Draw(spriteTexture, texturePos, sourceRect, Color.White, 0, origin, scale, SpriteEffects.None, 0);
        }
    }

    public void Draw(SpriteBatch spriteBatch, float layerNumber, float scale)
    {
        if (spriteTexture != null)
        {
            Vector2 origin = new Vector2(spriteTexture.Width / 2f, spriteTexture.Height / 2f);
            spriteBatch.Draw(spriteTexture, texturePos, sourceRect, Color.White, 0, origin, scale, SpriteEffects.None, layerNumber);
        }
    }
    public void Draw(SpriteBatch spriteBatch,float layerNumber,float scale,SpriteEffects spriteEffect)
    {
        if (spriteTexture != null)
        {
            Vector2 origin = new Vector2(spriteTexture.Width / 2f, spriteTexture.Height / 2f);
            spriteBatch.Draw(spriteTexture, texturePos, sourceRect, Color.White, 0, origin, scale, spriteEffect, layerNumber);
        }
    }

    public void Draw(SpriteBatch spriteBatch, float scale)
    {
        if (spriteTexture != null)
        {
            Vector2 origin = new Vector2(spriteTexture.Width / 2f, spriteTexture.Height / 2f);
            spriteBatch.Draw(spriteTexture, texturePos, sourceRect, Color.White, 0, origin, scale, SpriteEffects.None, 0);
        }
    }

    public virtual void Draw(SpriteBatch spriteBatch, Color color)
    {
        if (spriteTexture != null)
        {
            Vector2 origin = new Vector2(spriteTexture.Width / 2f, spriteTexture.Height / 2f);
            spriteBatch.Draw(spriteTexture, texturePos, sourceRect, color, 0, origin, scale, SpriteEffects.None, 0);
        }
    }
    public virtual void Draw(SpriteBatch spriteBatch, Color color, Vector2 pos)  // DO NOT TOUCH ONLY RYTHMBUBBLE
    {
        if (spriteTexture != null)
        {
            Vector2 origin = new Vector2(spriteTexture.Width / 2f, spriteTexture.Height / 2f);
            spriteBatch.Draw(spriteTexture, pos, sourceRect, color, 0, origin, scale, SpriteEffects.None, 0.9f); // ONLY APPEARS IN FRONT!!!!!
        }
    }
    public void Draw(SpriteBatch spriteBatch, float layerNumber, float scale,Vector2 pos)
    {
        if (spriteTexture != null)
        {
            Vector2 origin = new Vector2(spriteTexture.Width / 2f, spriteTexture.Height / 2f);
            spriteBatch.Draw(spriteTexture, pos, sourceRect, Color.White, 0, origin, scale, SpriteEffects.None, layerNumber);
        }
    }

}