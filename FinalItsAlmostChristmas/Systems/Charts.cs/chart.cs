using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

abstract class Chart
{
    public string chartName;
    public Song chartSong;
    public int chartBPM;
    public List<NewRythmBubbles> allOfTheRythmBubbles;

    public void Load()
    {
        allOfTheRythmBubbles = new();
        AddRythmBubbles();
    }

    protected abstract void AddRythmBubbles();

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
