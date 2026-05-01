using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Sprite
{
    public Texture2D spriteTexture;
    protected Vector2 texturePos;
    
    protected Rectangle sourceRect
    {
        get
        {
            return spriteTexture != null ? new Rectangle(0, 0, spriteTexture.Width, spriteTexture.Height) : Rectangle.Empty;
        }
    }

    public Sprite(Texture2D texture,Vector2 Pos)
    {
        spriteTexture = texture;
        texturePos = Pos;
    }
    public Sprite(Vector2 Pos)
    {
        texturePos = Pos;
    }
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        if (spriteTexture != null)
            spriteBatch.Draw(spriteTexture, texturePos, Color.White);
    }
}