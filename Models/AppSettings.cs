namespace BulkPdfCreator.Models;

public class AppSettings
{
    public string ExcelFilePath { get; set; }
    public string OutputDirectory { get; set; }
    public string TargetColumnName { get; set; }
    public string PdfContentTemplate { get; set; }
    public int ParallelDegreeOfConcurrency { get; set; } = Environment.ProcessorCount;
}
