using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class MusicPlayer
{
    float maxSongTime;
    float songElapsedTime;
    public Song selectedSong;
    public static Action SongEnd;
    public void Load()
    {

    }
    public MusicPlayer()
    {
        ChartManager.getInstance().SongStart += StartSong;
    }
    public void Initilize()
    {
        
    }

    public void StartSong()
    {
        maxSongTime = ChartManager.getInstance().songTime;
        MediaPlayer.Play(selectedSong);
    }
    public void UpdateLogic()
    {
        songElapsedTime += (float)(MediaPlayer.PlayPosition.TotalMilliseconds);
        ChartManager.getInstance().songElapsedTime = songElapsedTime;
        
        if (songElapsedTime >= maxSongTime)
        {
            SongEnd.Invoke();
            MediaPlayer.Stop();
        }
    }
}