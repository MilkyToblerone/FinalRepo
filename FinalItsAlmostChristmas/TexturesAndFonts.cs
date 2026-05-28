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
    public Texture2D dirtTexture;
    public Texture2D woodTexture;
    public Texture2D stoneTexture;

    public Texture2D brokenTexture;
    public Texture2D sideWallTexture;
    public Texture2D perfectReactionTexture;
    public Texture2D goodReactionTexture;
    public Texture2D okayReactionTexture;
    public Texture2D badReactionTexture;
    public Texture2D missReactionTexture;
    public Texture2D resultScreen;

    public SpriteFont fightFont;
    public SpriteFont fightFontSmall;

    public Texture2D ATier;
    public Texture2D BTier;
    public Texture2D CTier;
    public Texture2D STier;
    public Texture2D FTier;
    public SoundEffect writingSFX;
    public Texture2D axeAnimSheet;

    public SoundEffect RockBreakSFX;
    public SpriteFont gloriaFont;
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
        fightFontSmall = game1.Content.Load<SpriteFont>("Fonts/FightFontSmall");
        clickSFX = game1.Content.Load<SoundEffect>("MetalClick");
        blissBoutique = game1.Content.Load<Song>("BlissBoutique");
        mainMenuBG = game1.Content.Load<Texture2D>("Mine_MainMenu");
        songSelectBG = game1.Content.Load<Texture2D>("SongSelect_BG");
        bookendCover = game1.Content.Load<Texture2D>("bookendsongcover");
        badAppleCover = game1.Content.Load<Texture2D>("badappleSongCover");
        selectSFX = game1.Content.Load<SoundEffect>("Select");
        dirtTexture = game1.Content.Load<Texture2D>("DirtObs");
        stoneTexture = game1.Content.Load<Texture2D>("RockObs");
        woodTexture = game1.Content.Load<Texture2D>("WoodObs");
        brokenTexture = game1.Content.Load<Texture2D>("brokenObsPlaceholder");
        sideWallTexture = game1.Content.Load<Texture2D>("Side_Wall");

        perfectReactionTexture = game1.Content.Load<Texture2D>("Reactions/Perfect_Face");
        goodReactionTexture = game1.Content.Load<Texture2D>("Reactions/Good_Face");
        okayReactionTexture = game1.Content.Load<Texture2D>("Reactions/Okay_Face");
        badReactionTexture = game1.Content.Load<Texture2D>("Reactions/Bad_Face");
        missReactionTexture = game1.Content.Load<Texture2D>("Reactions/Miss_Face");
        resultScreen = game1.Content.Load<Texture2D>("ResultScreen");
        ATier = game1.Content.Load<Texture2D>("Tiers/Tier_A");
        BTier = game1.Content.Load<Texture2D>("Tiers/Tier_B");
        CTier = game1.Content.Load<Texture2D>("Tiers/Tier_C");
        FTier = game1.Content.Load<Texture2D>("Tiers/Tier_F");
        STier = game1.Content.Load<Texture2D>("Tiers/Tier_S");
        writingSFX = game1.Content.Load<SoundEffect>("Tiers/PenWriting");
        axeAnimSheet = game1.Content.Load<Texture2D>("AxeAnimSprite");
        RockBreakSFX = game1.Content.Load<SoundEffect>("BreakingSFX/RockDestroy");
        gloriaFont = game1.Content.Load<SpriteFont>("Gloria");
    }
}