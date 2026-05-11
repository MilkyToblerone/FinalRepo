using Microsoft.Xna.Framework;

class SongClock
{
    public double songsElapsedTime;
    double offset = 0;
    public SongClock()
    {
    }
    public double SongClockUpdate(GameTime gameTime)
    {
        songsElapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds + offset;
        return songsElapsedTime;
    }

}