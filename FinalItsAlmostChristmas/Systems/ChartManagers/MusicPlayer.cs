using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class MusicPlayer
{
    double maxSongTime;
    double songElapsedTime;
    public SongClock songClock;
    public Song selectedSong;
    public static Action SongEnd;
    
    public void Load()
    {

    }
    public MusicPlayer(SongClock songClock)
    {
        ChartManager.getInstance().SongStart += StartSong;
        this.songClock = songClock;
    }
    public void Initilize()
    {
        
    }

    public void StartSong()
    {
        maxSongTime = ChartManager.getInstance().songTime;
        songElapsedTime = 0;
        ChartManager.getInstance().songElapsedTime = 0;
        MediaPlayer.Play(selectedSong);
        ChartManager.getInstance().isSongPlaying = true;
    }
    public void UpdateLogic(GameTime gameTime)
    {
        if (ChartManager.getInstance().isSongPlaying)
        {
            songElapsedTime += songClock.SongClockUpdate(gameTime);
            ChartManager.getInstance().songElapsedTime = songElapsedTime;

            if (songElapsedTime >= maxSongTime)
            {
                ChartManager.getInstance().isSongPlaying = false;
                SongEnd?.Invoke();
                songElapsedTime = 0;
                ChartManager.getInstance().songElapsedTime = songElapsedTime;
                System.Console.WriteLine("ahmet");
            }
        }
        
    }
}