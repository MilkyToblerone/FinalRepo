using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

class ButtonManager
{
    ButtonTypes buttonType;
    public List<Button> buttons;
    public bool isBeingUsed;
    int hoveredButtonIndex;
    public ButtonManager(ButtonTypes buttonType)
    {
        this.buttonType = buttonType;
        buttons = new();
        if (buttonType == ButtonTypes.TopToBottom)
        {
            InputSystems.getInstance().UpPressed += ChangeButtonMinus;
            InputSystems.getInstance().DownPressed += ChangeButtonPlus;
        }
        else
        {
            InputSystems.getInstance().RightPressed += ChangeButtonPlus;
            InputSystems.getInstance().LeftPressed += ChangeButtonMinus;
        }
        InputSystems.getInstance().Confirm += PressButton;
        hoveredButtonIndex = 0;
    }

    private void PressButton()
    {
        buttons[hoveredButtonIndex].Press();
    }

    private void ChangeButtonMinus()
    {
        if (!isBeingUsed) return;
        if (hoveredButtonIndex == 0) return;
        buttons[hoveredButtonIndex].isHovered = false;

        TexturesAndFonts.getInstance().clickSFX.Play();

        hoveredButtonIndex--;
        buttons[hoveredButtonIndex].isHovered = true;
    }

    private void ChangeButtonPlus()
    {
        if (!isBeingUsed) return;
        if (hoveredButtonIndex == buttons.Count - 1) return;
        buttons[hoveredButtonIndex].isHovered = false;

        TexturesAndFonts.getInstance().clickSFX.Play();

        hoveredButtonIndex++;
        buttons[hoveredButtonIndex].isHovered = true;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var item in buttons)
        {
            item.Draw(spriteBatch);
        }
    }
    public void Update(GameTime gameTime)
    {
        foreach (var item in buttons)
        {
            item.Update(gameTime);
        }
    }
}