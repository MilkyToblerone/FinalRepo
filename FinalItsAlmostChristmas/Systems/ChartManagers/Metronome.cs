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
        currentBeat = 0;
        songBPM = ChartManager.getInstance().songBPM;
        songTime = ChartManager.getInstance().songTime;
        beatTimeMS = songTime / (songBPM * (songTime / 60000));
        beatTimeThreshold = beatTimeMS;
    }

    public void UpdateLogic()
    {
        if (ChartManager.getInstance().isSongPlaying)
        {
            if (ChartManager.getInstance().songElapsedTime >= beatTimeThreshold)
            {
                currentBeat++;
                beatTimeThreshold += beatTimeMS;
                beatChanged.Invoke(currentBeat);
            }
        }
    }


    
}