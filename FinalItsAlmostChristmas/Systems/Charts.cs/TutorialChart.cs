using System.Numerics;

class TutorialChart : Chart
{
    public TutorialChart()
    {
        chartName = "TutorialChart";
        chartBPM = 90;
        chartSong = TexturesAndFonts.getInstance().tutorialSong;
    }
    protected override void AddRythmBubbles()
    {
        allOfTheRythmBubbles.Add(new NewRythmBubbles(40000, 3000, ToolTypes.Pickaxe, 0));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(43000, 3000, ToolTypes.Pickaxe, 1));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(46000, 3000, ToolTypes.Pickaxe, 2));

        allOfTheRythmBubbles.Add(new NewRythmBubbles(51000, 6000, ToolTypes.Pickaxe, 0));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(51000, 6000, ToolTypes.Pickaxe, 1));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(51000, 6000, ToolTypes.Pickaxe, 2));

        allOfTheRythmBubbles.Add(new NewRythmBubbles(63000, 4000, ToolTypes.Axe, 0));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(67000, 4000, ToolTypes.Axe, 1));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(71000, 4000, ToolTypes.Axe, 2));

        allOfTheRythmBubbles.Add(new NewRythmBubbles(85000, 2000, ToolTypes.Shovel, 0));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(87000, 2000, ToolTypes.Shovel, 1));
        allOfTheRythmBubbles.Add(new NewRythmBubbles(89000, 2000, ToolTypes.Shovel, 2));

    }
}