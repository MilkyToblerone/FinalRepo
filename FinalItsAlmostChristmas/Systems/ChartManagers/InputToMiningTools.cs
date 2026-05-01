using System;

class InputToMiningTools
{
    static InputToMiningTools instance;

    // SINGLETON LOGIC
    private InputToMiningTools()
    {
    }
    public static InputToMiningTools getInstance()
    {
        if (instance == null)
        {
            instance = new InputToMiningTools();
        }
        return instance;
    }
    // SINGLETON LOGIC ENDS

    // current tool for anim and visual purposes.
    ToolTypes currentTool;
    int currentBeat;

    public void InitializeLogic()
    {
        InputSystems.getInstance().RythmButtonPressed += ChangeCurrentTool;
    }
    
    public void ChangeCurrentTool(ToolTypes tool)
    {
        currentTool = tool;
    }
     
}