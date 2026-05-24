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

    public void Draw(SpriteBatch spriteBatch,float scale)
    {
        if (spriteTexture != null)
        {
            Vector2 origin = new Vector2(spriteTexture.Width / 2f, spriteTexture.Height / 2f);
            spriteBatch.Draw(spriteTexture, texturePos, sourceRect, Color.White, 0, origin, scale, SpriteEffects.None, 0);
        }
    }
}