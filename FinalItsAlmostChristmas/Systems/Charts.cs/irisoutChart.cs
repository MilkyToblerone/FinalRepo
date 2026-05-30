using System.Numerics;

class irisOutChart : Chart
{
    public irisOutChart()
    {
        chartName = "irisOut";
        chartBPM = 130;
        chartSong = TexturesAndFonts.getInstance().irisOut;
    }
    protected override void AddRythmBubbles()
    {
        
    }
}