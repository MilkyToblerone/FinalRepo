

class Charter
{
    
    public static void AssignBeats(Chart chart)
    {
        int orderNumber = 0;
        foreach (var item in chart.allOfTheRythmBubbles)
        {
            double perfectTime = item.chartTime + item.timeToClose / 2;
            double beatTreasholdThing = 0;
            int beatToAssign=-1;
            while (perfectTime > beatTreasholdThing)
            {
                beatTreasholdThing += ChartManager.getInstance().beatTimeThreshold;
                beatToAssign++;
            }
            item.beatItisOn = beatToAssign;
            item.orderNumber = orderNumber;
            orderNumber += 1;
            if (orderNumber == 3)
            {
                orderNumber = 0;
            }
        }
    }
} 