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
    bool rythButtonPressedBoolPick;
    bool rythButtonPressedBoolShovel;
    bool rythButtonPressedBoolAxe;
    public void CheckInputs()
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.W) | keyboardState.IsKeyDown(Keys.Up)) UpPressed?.Invoke();
        if (keyboardState.IsKeyDown(Keys.D) | keyboardState.IsKeyDown(Keys.Right)) RightPressed?.Invoke();
        if (keyboardState.IsKeyDown(Keys.A) | keyboardState.IsKeyDown(Keys.Left)) LeftPressed?.Invoke();
        if (keyboardState.IsKeyDown(Keys.S) | keyboardState.IsKeyDown(Keys.Down)) DownPressed?.Invoke();
        if (keyboardState.IsKeyDown(Keys.Enter)) Confirm?.Invoke();
        if (keyboardState.IsKeyDown(Keys.Escape)) Decline?.Invoke();


        // THIS MAKES SURE SO IT DOESNT FIRE OFF AT EVERY FUCKING FRAME
        if (keyboardState.IsKeyDown(Keys.G) && !rythButtonPressedBoolPick) { RythmButtonPressed?.Invoke(ToolTypes.Pickaxe); rythButtonPressedBoolPick = true; }
        if (keyboardState.IsKeyDown(Keys.H) && !rythButtonPressedBoolAxe) {RythmButtonPressed?.Invoke(ToolTypes.Axe); rythButtonPressedBoolAxe = true; }
        if (keyboardState.IsKeyDown(Keys.J) && !rythButtonPressedBoolShovel) { RythmButtonPressed?.Invoke(ToolTypes.Shovel); rythButtonPressedBoolShovel = true; }
        
        if (keyboardState.IsKeyUp(Keys.G)) rythButtonPressedBoolPick = false;
        if (keyboardState.IsKeyUp(Keys.H)) rythButtonPressedBoolAxe = false;
        if (keyboardState.IsKeyUp(Keys.J)) rythButtonPressedBoolShovel = false;

        
    }


}