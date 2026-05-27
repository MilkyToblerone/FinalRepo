using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace FinalItsAlmostChristmas;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private MikuState mikuState;
    private TetoState tetoState;
    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        IsMouseVisible = false;
        _graphics.IsFullScreen = false;
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
        tetoState = new TetoState(this,_spriteBatch);
        mikuState = new MikuState(this,_spriteBatch,tetoState);
        mikuState.LoadContent();
        tetoState.LoadContent();
        tetoState.mainMenuScene = mikuState;
        StateManager.Initialize(mikuState);
        
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
        base.Draw(gameTime);
        _spriteBatch.End();
    }
}
