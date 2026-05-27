using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Records rhythm bubbles during gameplay and exports them as JSON.
/// Enable by setting ChartMaker.getInstance().IsRecording = true;
/// </summary>
class ChartMaker
{
    static ChartMaker instance;

    // SINGLETON LOGIC
    private ChartMaker()
    {
        recordedBubbles = new();
        IsRecording = false;
    }

    public static ChartMaker getInstance()
    {
        if (instance == null)
        {
            instance = new ChartMaker();
        }
        return instance;
    }
    // SINGLETON LOGIC ENDS

    public bool IsRecording { get; set; }
    private List<BubbleRecord> recordedBubbles;
    private const double DEFAULT_TIME_TO_CLOSE = 1000.0;
    private string outputPath = "ChartData";

    public void Initialize()
    {
        // Subscribe to input events when recording is enabled
        InputSystems.getInstance().RythmButtonPressed += OnRythmButtonPressed;

        // Create output directory if it doesn't exist
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }
    }

    private void OnRythmButtonPressed(ToolTypes toolType)
    {
        if (!IsRecording) return;

        double currentTime = ChartManager.getInstance().songElapsedTime;
        recordedBubbles.Add(new BubbleRecord
        {
            chartTime = currentTime - DEFAULT_TIME_TO_CLOSE / 2,
            timeToClose = DEFAULT_TIME_TO_CLOSE,
            toolType = toolType.ToString()
        });

        System.Console.WriteLine($"[ChartMaker] Recorded: {toolType} at {currentTime:F0}ms");
    }

    /// <summary>
    /// Start recording chart data
    /// </summary>
    public void StartRecording()
    {
        IsRecording = true;
        recordedBubbles.Clear();
        System.Console.WriteLine("[ChartMaker] Recording started");
    }

    /// <summary>
    /// Stop recording and export to JSON
    /// </summary>
    public void StopAndExport(string chartName = "NewChart")
    {
        IsRecording = false;
        ExportToJson(chartName);
    }

    /// <summary>
    /// Export recorded bubbles to JSON file and print to console
    /// </summary>
    private void ExportToJson(string chartName)
    {
        try
        {
            // Create chart class code
            string chartCode = GenerateChartCode(chartName);

            // Save to file
            string fileName = Path.Combine(outputPath, $"{chartName}_Chart.cs");
            File.WriteAllText(fileName, chartCode);

            System.Console.WriteLine($"\n[ChartMaker] Exported to: {fileName}");
            System.Console.WriteLine($"\n[ChartMaker] Copy this code into your Charts folder:\n");
            System.Console.WriteLine(chartCode);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"[ChartMaker] Error exporting: {ex.Message}");
        }
    }

    /// <summary>
    /// Generate C# chart class code from recorded bubbles
    /// </summary>
    private string GenerateChartCode(string chartName)
    {
        string className = ToPascalCase(chartName) + "Chart";
        
        var code = new System.Text.StringBuilder();
        code.AppendLine($"class {className} : Chart");
        code.AppendLine("{");
        code.AppendLine($"    public {className}()");
        code.AppendLine("    {");
        code.AppendLine($"        chartName = \"{chartName}\";");
        code.AppendLine("    }");
        code.AppendLine();
        code.AppendLine("    protected override void AddRythmBubbles()");
        code.AppendLine("    {");

        foreach (var bubble in recordedBubbles)
        {
            code.AppendLine($"        allOfTheRythmBubbles.Add(new NewRythmBubbles({bubble.chartTime:F0}, {bubble.timeToClose:F0}, ToolTypes.{bubble.toolType}));");
        }

        code.AppendLine("    }");
        code.AppendLine("}");

        return code.ToString();
    }

    /// <summary>
    /// Convert string to PascalCase
    /// </summary>
    private string ToPascalCase(string str)
    {
        if (string.IsNullOrEmpty(str)) return str;
        
        var words = str.Split(new[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
        var result = new System.Text.StringBuilder();

        foreach (var word in words)
        {
            if (word.Length > 0)
            {
                result.Append(char.ToUpper(word[0]));
                if (word.Length > 1)
                    result.Append(word.Substring(1).ToLower());
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// Get the count of recorded bubbles
    /// </summary>
    public int GetRecordedCount()
    {
        return recordedBubbles.Count;
    }

    /// <summary>
    /// Clear all recorded data
    /// </summary>
    public void Clear()
    {
        recordedBubbles.Clear();
        System.Console.WriteLine("[ChartMaker] Recorded data cleared");
    }
}

/// <summary>
/// Represents a single recorded rhythm bubble
/// </summary>
[Serializable]
class BubbleRecord
{
    public double chartTime { get; set; }
    public double timeToClose { get; set; }
    public string toolType { get; set; }
}
