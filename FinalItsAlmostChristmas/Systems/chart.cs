using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Chart
{
    public string chartName;
    public List<NewRythmBubbles> allOfTheRythmBubbles;

    public void Load()
    {
        allOfTheRythmBubbles = new();
    }
    public void AddRythmBubbles()
    {
        allOfTheRythmBubbles.Add(new NewRythmBubbles(1, 1299, ToolTypes.Pickaxe));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(1600, 200, ToolTypes.Pickaxe));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(2000, 5000, ToolTypes.Pickaxe));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(2000, 5000, ToolTypes.Pickaxe));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(300, 5000, ToolTypes.Pickaxe));

    }

    public void Update(GameTime gameTime)
    {
        if (allOfTheRythmBubbles == null)
            return;
        foreach (var item in allOfTheRythmBubbles)
            item.Update(gameTime);
        allOfTheRythmBubbles.RemoveAll(static x => x.IsExpired);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        if (allOfTheRythmBubbles == null)
            return;
        foreach (var item in allOfTheRythmBubbles)
        {
            if (item.isActive)
                item.Draw(spriteBatch);
        }
    }
}