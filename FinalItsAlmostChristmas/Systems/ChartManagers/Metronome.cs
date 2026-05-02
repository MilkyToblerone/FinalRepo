using Microsoft.Xna.Framework;

class ChartMetronome
{
    public delegate void BeatChanged(int currentBeat);
    static BeatChanged beatChanged;
    float songBPM;
    float songTime;
    public float beatTimeMS;
    public int currentBeat;
    float beatTimeThreshold;

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
        // 1000 is there for the miliseconds.
        currentBeat = 0;
        beatTimeMS = songTime / songBPM * 1000;
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