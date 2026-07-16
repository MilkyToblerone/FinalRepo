using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


class ChartMaker
{
    static ChartMaker instance;
    private bool isInitialized;

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
    private int orderCounter = 0;

    public void Initialize()
    {
        if (isInitialized)
        {
            return;
        }

        InputSystems.getInstance().RythmButtonPressed += OnRythmButtonPressed;
        isInitialized = true;

        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }
    }

    private void OnRythmButtonPressed(ToolTypes toolType)
    {
        if (!IsRecording) return;

        double currentTime = ChartManager.getInstance().songElapsedTime;

        int displayOrder = orderCounter;
        orderCounter = (orderCounter + 1) % 3;

        recordedBubbles.Add(new BubbleRecord
        {
            chartTime = currentTime - DEFAULT_TIME_TO_CLOSE / 2,
            timeToClose = DEFAULT_TIME_TO_CLOSE,
            toolType = toolType.ToString(),
            order = displayOrder
        });

        System.Console.WriteLine($"[ChartMaker] Recorded: {toolType} at {currentTime:F0}ms (order={displayOrder})");
    }

    public void StartRecording()
    {
        IsRecording = true;
        recordedBubbles.Clear();
        orderCounter = 0;
        System.Console.WriteLine("[ChartMaker] Recording started");
    }

    public void StopAndExport(string chartName = "NewChart")
    {
        IsRecording = false;
        ExportToJson(chartName);
    }

    private void ExportToJson(string chartName)
    {
        try
        {
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
            code.AppendLine($"        allOfTheRythmBubbles.Add(new NewRythmBubbles({bubble.chartTime:F0}, {bubble.timeToClose:F0}, ToolTypes.{bubble.toolType}, {bubble.order}));");
        }

        code.AppendLine("    }");
        code.AppendLine("}");

        return code.ToString();
    }

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

    public int GetRecordedCount()
    {
        return recordedBubbles.Count;
    }

    public void Clear()
    {
        recordedBubbles.Clear();
        System.Console.WriteLine("[ChartMaker] Recorded data cleared");
    }
}


[Serializable]
class BubbleRecord
{
    public double chartTime { get; set; }
    public double timeToClose { get; set; }
    public string toolType { get; set; }
    public int order { get; set; }
}