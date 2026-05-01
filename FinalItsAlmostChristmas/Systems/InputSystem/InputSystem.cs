using System;
using Microsoft.Xna.Framework.Input;

sealed class InputSystems
{
    static InputSystems instance;

    // SINGLETON LOGIC
    private InputSystems()
    {
    }
    public static InputSystems getInstance()
    {
        if (instance == null)
        {
            instance = new InputSystems();
        }
        return instance;
    }

    // SINGLETON LOGIC END 
    public delegate void RythmEvents(ToolTypes toolType);
    public RythmEvents RythmButtonPressed;
    Action UpPressed;
    Action RightPressed;
    Action LeftPressed;
    Action DownPressed;
    Action Confirm;
    Action Decline;
    public void CheckInputs()
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.W) | keyboardState.IsKeyDown(Keys.Up)) UpPressed?.Invoke();
        if (keyboardState.IsKeyDown(Keys.D) | keyboardState.IsKeyDown(Keys.Right)) RightPressed?.Invoke();
        if (keyboardState.IsKeyDown(Keys.A) | keyboardState.IsKeyDown(Keys.Left)) LeftPressed?.Invoke();
        if (keyboardState.IsKeyDown(Keys.S) | keyboardState.IsKeyDown(Keys.Down)) DownPressed?.Invoke();
        if (keyboardState.IsKeyDown(Keys.G)) RythmButtonPressed?.Invoke(ToolTypes.Pickaxe);
        if (keyboardState.IsKeyDown(Keys.H)) RythmButtonPressed?.Invoke(ToolTypes.Axe);
        if (keyboardState.IsKeyDown(Keys.J)) RythmButtonPressed?.Invoke(ToolTypes.Shovel);
        if (keyboardState.IsKeyDown(Keys.Enter)) Confirm?.Invoke();
        if (keyboardState.IsKeyDown(Keys.Escape)) Decline?.Invoke();
    }


}