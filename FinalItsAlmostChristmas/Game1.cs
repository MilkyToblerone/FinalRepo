using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace FinalItsAlmostChristmas;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private MikuState mikuState;
    private TetoState tetoState;
    private CreditsState creditsState;
    private ChartMaker chartMaker;
    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        IsMouseVisible = false;
        _graphics.IsFullScreen = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        
        TexturesAndFonts.getInstance().game1 = this;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        
        TexturesAndFonts.getInstance().Load();
        ChartManager.getInstance().Load();
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        creditsState = new CreditsState(this,_spriteBatch);
        tetoState = new TetoState(this,_spriteBatch);
        mikuState = new MikuState(this,_spriteBatch,tetoState,creditsState);
        mikuState.LoadContent();
        tetoState.LoadContent();
        creditsState.LoadContent(mikuState);
        tetoState.mainMenuScene = mikuState;
        StateManager.Initialize(mikuState);
        ResultState.mikuState = mikuState;
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here

        InputSystems.getInstance().CheckInputs();
        StateManager.GetCurrentState().Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(15, 9, 9));
        _spriteBatch.Begin(SpriteSortMode.FrontToBack);
        StateManager.GetCurrentState().Draw(gameTime);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
