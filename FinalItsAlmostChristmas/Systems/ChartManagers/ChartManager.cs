class ChartManager
{
    static ChartManager instance;

    // SINGLETON LOGIC
    private ChartManager()
    {
    }
    public static ChartManager getInstance()
    {
        if (instance == null)
        {
            instance = new ChartManager();
        }
        return instance;
    }
    //SINGLETON LOGIC ENDS
    public float songTime;
    public float songBPM;
    public string songName;
    
}