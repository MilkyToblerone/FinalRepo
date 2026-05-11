using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

class TexturesAndFonts
{
    public Game1 game1;
    public Song bookendSong;
    public Song badApple;
    public Texture2D bubbleBaseTexture;
    public Texture2D bubbleCircleTexture;
    private float tickDownSpeed;
    public bool isActive { get; private set; }

    public SpriteFont fightFont;

    static TexturesAndFonts instance;

    // SINGLETON LOGIC
    private TexturesAndFonts()
    {
    }
    public static TexturesAndFonts getInstance()
    {
        if (instance == null)
        {
            instance = new TexturesAndFonts();
        }
        return instance;
    }
    public void Load()
    {
        bubbleBaseTexture = game1.Content.Load<Texture2D>("Bubble");
        bubbleCircleTexture = game1.Content.Load<Texture2D>("Circle");
        badApple = game1.Content.Load<Song>("BadApple");
        bookendSong = game1.Content.Load<Song>("BookendOpening");
        fightFont = game1.Content.Load<SpriteFont>("Fonts/FightFont");
    }
}