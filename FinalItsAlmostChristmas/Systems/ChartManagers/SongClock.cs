using Microsoft.Xna.Framework;

class SongClock
{
    public double songsElapsedTime;
    double offset = 0;
    public  bool songClockPaused;
    public SongClock()
    {
    }
    public double SongClockUpdate(GameTime gameTime)
    {
        if (!songClockPaused)
        {
            songsElapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds + offset;
        }
        else
        {
            songsElapsedTime = 0;
        }
        
        return songsElapsedTime;
    }

}