using Microsoft.Xna.Framework;

class ChartMetronome
{
    public delegate void BeatChanged(int currentBeat);
    static BeatChanged beatChanged;
    double songBPM;
    double songTime;
    public double beatTimeMS;
    public int currentBeat;
    double beatTimeThreshold;

    public ChartMetronome()
    {
        ChartManager.getInstance().SongStart += StartSong;
        beatChanged += ChartManager.getInstance().ChangeCurrentBeat; 
    }
    
    public void Initilize()
    {

    }
    public void StartSong()
    {
        // Calculate beat duration in milliseconds: 60000ms / BPM = ms per beat
        currentBeat = 0;
        songBPM = ChartManager.getInstance().songBPM;
        beatTimeMS = 60000.0 / songBPM;
        beatTimeThreshold = beatTimeMS;
    }

    public void UpdateLogic()
    {
        if (ChartManager.getInstance().songElapsedTime >= beatTimeThreshold)
        {
            currentBeat++;
            beatTimeThreshold += beatTimeMS;
            beatChanged.Invoke(currentBeat);
        }
    }


    
}