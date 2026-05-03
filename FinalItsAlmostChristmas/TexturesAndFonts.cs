using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

class TexturesAndFonts
{
    public Game1 game1;
    public Song bookendSong;

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
        bookendSong = game1.Content.Load<Song>("BookendOpening");
        fightFont = game1.Content.Load<SpriteFont>("Fonts/FightFont");
    }
}