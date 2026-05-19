using System;

class Judge
{
    NewRythmBubbles currentRythmBubble;
    double perfectOffset = 2000;
    double goodOffset = 100;
    double okayOffset = 150;
    double badOffset = 200;
    public Judge()
    {
        InputSystems.getInstance().RythmButtonPressed += CheckAccuracy;
    }
    public void Update()
    {
        
    }

    private void CheckAccuracy(ToolTypes toolType)
    {
        if (ChartManager.getInstance().currentChart.allOfTheRythmBubbles.Count == 0) return;
        currentRythmBubble = ChartManager.getInstance().currentChart.allOfTheRythmBubbles[0];
        double perfectTime = currentRythmBubble.chartTime + currentRythmBubble.timeToClose / 2;
        if (!currentRythmBubble.isActive || currentRythmBubble.IsExpired) return;
        double timeWhenButtonPressed = ChartManager.getInstance().songElapsedTime;
        int beatWhenButtonPressed = ChartManager.getInstance().currentBeat;


        if ((timeWhenButtonPressed < perfectTime - badOffset) && (toolType == currentRythmBubble.toolType) && (beatWhenButtonPressed == currentRythmBubble.beatItisOn))
        {
            ChartManager.getInstance().missNumber++;
            ChartManager.getInstance().currentChart.allOfTheRythmBubbles.Remove(currentRythmBubble);
            System.Console.WriteLine("ahmet");
        }


        else if ((timeWhenButtonPressed > perfectTime - perfectOffset || timeWhenButtonPressed < perfectTime + perfectOffset) && (toolType == currentRythmBubble.toolType) && (beatWhenButtonPressed == currentRythmBubble.beatItisOn))
        {
            ChartManager.getInstance().perfectNumber++;
            ChartManager.getInstance().currentChart.allOfTheRythmBubbles.Remove(currentRythmBubble);
        }


        else if ((timeWhenButtonPressed > perfectTime - goodOffset || timeWhenButtonPressed < perfectTime + goodOffset) && (toolType == currentRythmBubble.toolType) && (beatWhenButtonPressed == currentRythmBubble.beatItisOn))
        {
            ChartManager.getInstance().goodNumber++;
            ChartManager.getInstance().currentChart.allOfTheRythmBubbles.Remove(currentRythmBubble);
        }


        else if ((timeWhenButtonPressed > perfectTime - okayOffset || timeWhenButtonPressed < perfectTime + okayOffset) && (toolType == currentRythmBubble.toolType) && (beatWhenButtonPressed == currentRythmBubble.beatItisOn))
        {
            ChartManager.getInstance().okayNumber++;
            ChartManager.getInstance().currentChart.allOfTheRythmBubbles.Remove(currentRythmBubble);
        }


        else if ((timeWhenButtonPressed > perfectTime - badOffset || timeWhenButtonPressed < perfectTime + badOffset) && (toolType == currentRythmBubble.toolType) && (beatWhenButtonPressed == currentRythmBubble.beatItisOn))
        {
            ChartManager.getInstance().badNumber++;
            ChartManager.getInstance().currentChart.allOfTheRythmBubbles.Remove(currentRythmBubble);
        }
        else
        {
            ChartManager.getInstance().missNumber++;
            ChartManager.getInstance().currentChart.allOfTheRythmBubbles.Remove(currentRythmBubble); 
            System.Console.WriteLine("1111t");
        }
    }
}