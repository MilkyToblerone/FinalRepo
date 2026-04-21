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
        spriteBatch.Draw(spriteTexture,texturePos,rect,Color.White,0,Vector2.Zero,scale,SpriteEffects.None,0);
    }
}