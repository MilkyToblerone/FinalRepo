using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Button
{
    public Vector2 Position;
    public string Text;
    public bool isHovered;

    public event Action OnPressed;

    private SpriteFont font;
    private Color textColor;
    private Color hoverColor;
    private float wobbleTimer;
    private float wobbleSpeed = 3f;
    private float wobbleAmount = 5f;
    private float wobbleOffset;
    private float hoverScale = 1.2f;
    public float currentScale { get; private set; }
    private static Random random = new Random();
    public bool isActive = true;
    bool isWobbly = true;

    public Button(Vector2 position, string text)
    {
        Position = position;
        Text = text;
        isHovered = false;
        font = TexturesAndFonts.getInstance().fightFont;
        textColor = Color.White;
        hoverColor = Color.Yellow;
        wobbleTimer = 0f;
        wobbleOffset = (float)random.NextDouble() * MathHelper.TwoPi;
        currentScale = 1f;
    }
    public Button(Vector2 position, string text, SpriteFont spriteFont)
    {
        Position = position;
        Text = text;
        isHovered = false;
        font = spriteFont;
        textColor = Color.White;
        hoverColor = Color.Yellow;
        wobbleTimer = 0f;
        wobbleOffset = (float)random.NextDouble() * MathHelper.TwoPi;
        currentScale = 1f;
    }
    public Button(Vector2 position, string text,SpriteFont spriteFont,bool isWobbly)
    {
        this.isWobbly = isWobbly;
        Position = position;
        Text = text;
        isHovered = false;
        font = spriteFont;
        textColor = Color.White;
        hoverColor = Color.Yellow;
        wobbleTimer = 0f;
        wobbleOffset = (float)random.NextDouble() * MathHelper.TwoPi;
        currentScale = 1f;
    }

    public void Update(GameTime gameTime)
    {
        wobbleTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        float targetScale = isHovered ? hoverScale : 1f;
        currentScale = MathHelper.Lerp(currentScale, targetScale, 0.1f);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Color drawColor = isHovered ? hoverColor : textColor;
        float wobbleX = (float)Math.Sin(wobbleTimer * wobbleSpeed + wobbleOffset) * wobbleAmount;
        float wobbleY = (float)Math.Cos(wobbleTimer * wobbleSpeed + wobbleOffset) * wobbleAmount;
        
        Vector2 drawPosition = isWobbly ? Position + new Vector2(wobbleX, wobbleY) : Position;
        Vector2 textSize = font.MeasureString(Text);
        Vector2 origin = textSize * 0.5f;
        
        spriteBatch.DrawString(font, Text, drawPosition + origin, drawColor, 0f, origin, currentScale, SpriteEffects.None, 1f);
    }

    public void Press()
    {
        if (!isActive) return;
        TexturesAndFonts.getInstance().selectSFX.Play();
        OnPressed?.Invoke();
    }
}