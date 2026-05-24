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
    public Action UpPressed;
    public Action RightPressed;
    public Action LeftPressed;
    public Action DownPressed;
    public Action Confirm;
    public Action Decline;
    bool directionUpPressed;
    bool directionRightPressed;
    bool directionLeftPressed;
    bool directionDownPressed;
    bool rythButtonPressedBoolPick;
    bool rythButtonPressedBoolShovel;
    bool rythButtonPressedBoolAxe;
    bool confirmPressed;
    bool declinePressed;
    public void CheckInputs()
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up)) { if (!directionUpPressed) { UpPressed?.Invoke(); directionUpPressed = true; } }
        if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right)) { if (!directionRightPressed) { RightPressed?.Invoke(); directionRightPressed = true; } }
        if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left)) { if (!directionLeftPressed) { LeftPressed?.Invoke(); directionLeftPressed = true; } }
        if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down)) { if (!directionDownPressed) { DownPressed?.Invoke(); directionDownPressed = true; } }
        if (keyboardState.IsKeyDown(Keys.Enter)) { if (!confirmPressed) { Confirm?.Invoke(); confirmPressed = true; } }
        if (keyboardState.IsKeyDown(Keys.Escape)) Decline?.Invoke();

        // THIS MAKES SURE SO IT DOESNT FIRE OFF AT EVERY FRAME
        if (keyboardState.IsKeyUp(Keys.W) && keyboardState.IsKeyUp(Keys.Up)) directionUpPressed = false;
        if (keyboardState.IsKeyUp(Keys.D) && keyboardState.IsKeyUp(Keys.Right)) directionRightPressed = false;
        if (keyboardState.IsKeyUp(Keys.A) && keyboardState.IsKeyUp(Keys.Left)) directionLeftPressed = false;
        if (keyboardState.IsKeyUp(Keys.S) && keyboardState.IsKeyUp(Keys.Down)) directionDownPressed = false;
        if (keyboardState.IsKeyUp(Keys.Enter)) confirmPressed = false;

        // THIS MAKES SURE SO IT DOESNT FIRE OFF AT EVERY FRAME
        if (keyboardState.IsKeyDown(Keys.G) && !rythButtonPressedBoolPick) { RythmButtonPressed?.Invoke(ToolTypes.Pickaxe); rythButtonPressedBoolPick = true; }
        if (keyboardState.IsKeyDown(Keys.H) && !rythButtonPressedBoolAxe) {RythmButtonPressed?.Invoke(ToolTypes.Axe); rythButtonPressedBoolAxe = true; }
        if (keyboardState.IsKeyDown(Keys.J) && !rythButtonPressedBoolShovel) { RythmButtonPressed?.Invoke(ToolTypes.Shovel); rythButtonPressedBoolShovel = true; }
        
        if (keyboardState.IsKeyUp(Keys.G)) rythButtonPressedBoolPick = false;
        if (keyboardState.IsKeyUp(Keys.H)) rythButtonPressedBoolAxe = false;
        if (keyboardState.IsKeyUp(Keys.J)) rythButtonPressedBoolShovel = false;
    }


}