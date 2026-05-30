using System.Numerics;

class BadAppleChart : Chart
{
    public BadAppleChart()
    {
        chartName = "BadApple";
        chartBPM = 130;
        chartSong = TexturesAndFonts.getInstance().badApple;
    }
    protected override void AddRythmBubbles()
    {
        allOfTheRythmBubbles.Add(new NewRythmBubbles(1, 1300, ToolTypes.Pickaxe, 1));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(1300, 5000, ToolTypes.Pickaxe, 1));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(1,500000,ToolTypes.Pickaxe,1));
    }
}