using BulkPdfCreator.Models;
using BulkPdfCreator.Services;
using Microsoft.Extensions.Configuration;
using QuestPDF.Infrastructure;
using System.Collections.Concurrent;

QuestPDF.Settings.License = LicenseType.Community;

// Load settings
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = config.Get<AppSettings>();

// Initialize services
var reader = new ExcelReader(settings.ExcelFilePath, settings.TargetColumnName);
var generator = new PdfGenerator(settings.OutputDirectory, settings.PdfContentTemplate);


// Read data
Console.WriteLine("Reading Excel...\n");
var values = reader.ExtractColumnValues();
Console.WriteLine($"Found {values.Count} records.");

// Track failures
var failedItems = new ConcurrentBag<string>();

// Parallel file generation
Console.WriteLine("Generating PDFs in parallel...");

Parallel.ForEach(values, new ParallelOptions { MaxDegreeOfParallelism = settings.ParallelDegreeOfConcurrency }, value =>
{
    try
    {
        generator.CreatePdf(value);
    }
    catch (Exception ex)
    {
        failedItems.Add($"{value}: {ex.Message}");
    }
});

Console.WriteLine("PDF generation completed.");

if (failedItems.Count > 0)
{
    Console.WriteLine($"Some files failed to generate ({failedItems.Count})");

    foreach (var fail in failedItems)
        Console.WriteLine($" - {fail}");
}

Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("\n(press any <key> to exit...");
Console.ResetColor();
Console.ReadKey();
