using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

class TexturesAndFonts
{
    public Game1 game1;
    public Song bookendSong;
    public Song badApple;
    public Song blissBoutique;
    public SoundEffect clickSFX;
    public Texture2D bubbleBaseTexture;
    public Texture2D bubbleCircleTexture;
    public Texture2D mainMenuBG;
    public Texture2D songSelectBG;
    public Texture2D badAppleCover;
    public Texture2D bookendCover;
    public SoundEffect selectSFX;
    
    public bool isActive { get; private set; }

    public SpriteFont fightFont;
    public SpriteFont fightFontLarge;

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
        clickSFX = game1.Content.Load<SoundEffect>("MetalClick");
        blissBoutique = game1.Content.Load<Song>("BlissBoutique");
        mainMenuBG = game1.Content.Load<Texture2D>("Mine_MainMenu");
        songSelectBG = game1.Content.Load<Texture2D>("SongSelect_BG");
        bookendCover = game1.Content.Load<Texture2D>("bookendsongcover");
        badAppleCover = game1.Content.Load<Texture2D>("badappleSongCover");
        selectSFX = game1.Content.Load<SoundEffect>("Select");
    }
}