class ChartMetronome
{
    float songBPM;
    float songTime;
    public float beatTimeMS;
    public float currentBeat;
    public float elapsedTime;
    ChartMetronome currentChartMetronome;
    ChartMetronome(float songBPM,float songTime)
    {
        songBPM = this.songBPM;
        songTime = this.songTime;
    }
    public void StartSong()
    {
        if (currentChartMetronome != null) currentChartMetronome = null;
        currentChartMetronome = new(ChartManager.getInstance().songBPM, ChartManager.getInstance().songTime);
        // 1000 is there for the miliseconds.
        currentChartMetronome.beatTimeMS = currentChartMetronome.songTime / currentChartMetronome.songBPM * 1000;
        currentChartMetronome.elapsedTime = 0f;
    }


    
}