using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class MusicPlayer
{
    double maxSongTime;
    double songElapsedTime;
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
        ChartManager.getInstance().songElapsedTime = 0;
        MediaPlayer.Play(selectedSong);
    }
    public void UpdateLogic()
    {
        songElapsedTime = (double)(MediaPlayer.PlayPosition.TotalMilliseconds);
        ChartManager.getInstance().songElapsedTime = songElapsedTime;
        
    }
}