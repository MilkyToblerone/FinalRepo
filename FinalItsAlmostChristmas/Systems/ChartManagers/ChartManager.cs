using System;
using System.Collections.Generic;
using FinalItsAlmostChristmas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

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
    public ChartMetronome chartMetronome;
    public MusicPlayer musicPlayer;
    public SongClock songClock;
    public Judge judge;
    public Action SongStart;
    public double songTime;
    public float songBPM;
    public double songElapsedTime;
    public int currentBeat;
    public bool isSongPlaying;
    public int score;
    public int perfectNumber;
    public int goodNumber;
    public int okayNumber;
    public int badNumber;
    public int missNumber;
    public Chart currentChart;
    public Chart bookendChart;
    public Chart badAppleChart;
    public Chart tutorialChart;
    public Chart poppipoChart;
    public Chart bakamitaiChart;
    public Chart loopingTheRoomsChart;
    public Chart irisOutChart;
    public double beatTimeThreshold;
    public List<ObstacleSprite> obstacles;

    public Action Perfect;
    public Action Good;
    public Action Okay;
    public Action Bad;
    public Action Miss;

    public ReactionStatus reactionStatus;
    public GameState resultScene;
    
    public void Init()
    {

    }
    public void Load()
    {
        judge = new();


        bookendChart = new BookendsongChart();
        badAppleChart = new BadAppleChart();
        tutorialChart = new TutorialChart();
        poppipoChart = new PoppipoChart();
        bakamitaiChart = new BakamitaiChart();
        loopingTheRoomsChart = new LoopingTheRoomsChart();
        irisOutChart = new irisOutChart();

        


        songClock = new();
        chartMetronome = new();
        musicPlayer = new(songClock);
        obstacles = new();
        MusicPlayer.SongEnd += SongEnd;

        Perfect += PerfectInvoked;
        Okay += OkayInvoked;
        Good += GoodInvoked;
        Bad += BadInvoked;
        Miss += MissInvoked;
    }

    /// Set a specific chart to play
    public void SetChart(Chart chart)
    {
        currentChart = chart;
        currentChart.Load();
    }

    /// Reset chart state for replay
    public void Reset()
    {
        // Reset all score counters
        score = 0;
        perfectNumber = 0;
        goodNumber = 0;
        okayNumber = 0;
        badNumber = 0;
        missNumber = 0;
        currentBeat = 0;

        // Reset timing
        songElapsedTime = 0;
        isSongPlaying = false;

        // Reset chart bubbles
        if (currentChart != null && currentChart.allOfTheRythmBubbles != null)
        {
            currentChart.allOfTheRythmBubbles.Clear();
            currentChart.Load();
        }

        // Reset music
        MediaPlayer.Stop();

        // Reset song clock
        if (songClock != null)
        {
            songClock.songsElapsedTime = 0;
        }

        // Reset obstacles
        obstacles = new();

        reactionStatus = ReactionStatus.Okay;
    }

    public void Update(GameTime gameTime)
    {
        musicPlayer.UpdateLogic(gameTime);
        chartMetronome.UpdateLogic();
        currentChart.Update(gameTime);
        judge.Update();
        foreach (var item in obstacles)
        {
            item.Update(gameTime);
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var item in obstacles)
        {
            item.Draw(spriteBatch);
        }
        currentChart.Draw(spriteBatch);
    }
    public void ChangeCurrentBeat(int beatToBe)
    {
        currentBeat = beatToBe;
    }
    public void StartingSong(Chart chart)
    {
        musicPlayer.selectedSong = chart.chartSong;
        songTime = chart.chartSong.Duration.TotalMilliseconds;
        songBPM = chart.chartBPM;
        SongStart.Invoke();
        foreach (var item in currentChart.allOfTheRythmBubbles)
        {
            obstacles.Add(new(item));
        }
        Charter.AssignBeats(currentChart);
    }
    void PerfectInvoked()
    {
        reactionStatus = ReactionStatus.Perfect;
    }
    void GoodInvoked()
    {
        reactionStatus = ReactionStatus.Good;
    }
    void OkayInvoked()
    {
        reactionStatus = ReactionStatus.Okay;
    }
    void BadInvoked()
    {
        reactionStatus = ReactionStatus.Bad;
    }
    void MissInvoked()
    {
        reactionStatus = ReactionStatus.Miss;
    }
    public void SongEnd()
    {
        StateManager.SwitchState(resultScene);
    }
}