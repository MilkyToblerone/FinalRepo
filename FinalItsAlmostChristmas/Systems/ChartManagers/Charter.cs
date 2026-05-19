class Charter
{
    public static void AssignBeats(Chart chart)
    {
        foreach (var item in chart.allOfTheRythmBubbles)
        {
            double perfectTime = item.chartTime + item.timeToClose / 2;
            double beatTreasholdThing = 0; // USE THIS TO ADD BEAT TRESHOLD!
            int beatToAssign=0;
            while (perfectTime > beatTreasholdThing)
            {
                beatTreasholdThing += ChartManager.getInstance().beatTimeThreshold;
                beatToAssign++;
            }
            item.beatItisOn = beatToAssign;
        }
    }
}