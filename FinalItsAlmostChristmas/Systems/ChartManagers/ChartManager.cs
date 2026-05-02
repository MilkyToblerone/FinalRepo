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
    public float songTime;
    public float songBPM;
    public float songElapsedTime;
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
        chartMetronome.UpdateLogic();
        musicPlayer.UpdateLogic();
    }
    public void ChangeCurrentBeat(int beatToBe)
    {
        currentBeat = beatToBe;
    }
    public void StartingSong(Song song, int BPM)
    {
        musicPlayer.selectedSong = song;
        songTime = (float)(song.Duration.TotalMilliseconds);
        songBPM = BPM;
        SongStart.Invoke();
    }

}