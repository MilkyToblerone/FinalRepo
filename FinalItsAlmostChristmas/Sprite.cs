using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Sprite
{
    public Texture2D spriteTexture;
    protected Vector2 texturePos;
    protected Rectangle rect
    {
        get
        {
            return new Rectangle
            ((int)texturePos.X,
            (int)texturePos.Y,
            spriteTexture.Width,
            spriteTexture.Height);
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
        spriteBatch.Draw(spriteTexture,rect,Color.White);
    }
}