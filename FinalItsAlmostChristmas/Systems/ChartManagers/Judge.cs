using System;

class Judge
{
    NewRythmBubbles currentRythmBubble;
    double perfectOffset = 70;
    double goodOffset = 80;
    double okayOffset = 90;
    double badOffset = 100;
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
            ChartManager.getInstance().Miss?.Invoke(); 
            currentRythmBubble.IsExpired = true;
        }


        else if (((timeWhenButtonPressed > perfectTime - perfectOffset) && (timeWhenButtonPressed < perfectTime + perfectOffset)) && (toolType == currentRythmBubble.toolType))
        {
            ChartManager.getInstance().perfectNumber++;
            ChartManager.getInstance().Perfect?.Invoke(); 
            currentRythmBubble.IsExpired = true;
        }


        else if ((timeWhenButtonPressed > perfectTime - goodOffset && timeWhenButtonPressed < perfectTime + goodOffset) && (toolType == currentRythmBubble.toolType) && (beatWhenButtonPressed == currentRythmBubble.beatItisOn))
        {
            ChartManager.getInstance().goodNumber++;
            ChartManager.getInstance().Good?.Invoke(); 
            currentRythmBubble.IsExpired = true;
        }


        else if ((timeWhenButtonPressed > perfectTime - okayOffset && timeWhenButtonPressed < perfectTime + okayOffset) && (toolType == currentRythmBubble.toolType) && (beatWhenButtonPressed == currentRythmBubble.beatItisOn))
        {
            ChartManager.getInstance().okayNumber++;
            ChartManager.getInstance().Okay?.Invoke(); 
            currentRythmBubble.IsExpired = true;
        }


        else if ((timeWhenButtonPressed > perfectTime - badOffset && timeWhenButtonPressed < perfectTime + badOffset) && (toolType == currentRythmBubble.toolType) && (beatWhenButtonPressed == currentRythmBubble.beatItisOn))
        {
            ChartManager.getInstance().badNumber++;
            ChartManager.getInstance().Bad?.Invoke(); 
            currentRythmBubble.IsExpired = true; 
        }
        else
        {
            ChartManager.getInstance().missNumber++;
            ChartManager.getInstance().Miss?.Invoke(); 
            currentRythmBubble.IsExpired = true;
        }
    }
}