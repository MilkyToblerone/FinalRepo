using System;
using Microsoft.Xna.Framework.Media;

class ChartManager
{
    static ChartManager instance;

    // SINGLETON LOGIC
    private ChartManager()
    {
    }
    public static ChartManager getInstance()
    {
        if (instance == null)
        {
            instance = new ChartManager();
        }
        return instance;
    }
    //SINGLETON LOGIC ENDS
    public ChartMetronome chartMetronome;
    public MusicPlayer musicPlayer;
    public Action SongStart;
    public double songTime;
    public double songBPM;
    public double songElapsedTime;
    public string songName;
    public int currentBeat;
    public void Init()
    {

    }
    public void Load()
    {
        chartMetronome = new();
        musicPlayer = new();
    }
    public void Update()
    {
        musicPlayer.UpdateLogic();
        chartMetronome.UpdateLogic();
    }
    public void ChangeCurrentBeat(int beatToBe)
    {
        currentBeat = beatToBe;
    }
    public void StartingSong(Song song, int BPM)
    {
        musicPlayer.selectedSong = song;
        songTime = (double)(song.Duration.TotalMilliseconds);
        songBPM = BPM;
        SongStart.Invoke();
    }

}