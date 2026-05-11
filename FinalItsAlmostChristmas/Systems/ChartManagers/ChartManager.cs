using System;
using Microsoft.Xna.Framework;
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
    public SongClock songClock;
    public GameTime gameTime;
    public Action SongStart;
    public double songTime;
    public float songBPM;
    public double songElapsedTime;
    public string songName;
    public int currentBeat;
    public bool isSongPlaying;
    public void Init()
    {

    }
    public void Load()
    {
        songClock = new();
        chartMetronome = new();
        musicPlayer = new(songClock);
    }
    public void Update(GameTime gameTime)
    {
        musicPlayer.UpdateLogic(gameTime);
        chartMetronome.UpdateLogic();
    }
    public void ChangeCurrentBeat(int beatToBe)
    {
        currentBeat = beatToBe;
    }
    public void StartingSong(Song song, int BPM)
    {
        musicPlayer.selectedSong = song;
        songTime = song.Duration.TotalMilliseconds;
        songBPM = BPM;
        SongStart.Invoke();
    }

}