using BulkPdfCreator.Services;
using Microsoft.Extensions.Configuration;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var excelFilePath = configuration["ExcelFilePath"];
var outputDirectory = configuration["OutputDirectory"];
var targetColumnName = configuration["TargetColumnName"];
var pdfContentTemplate = configuration["PdfContentTemplate"];

if (!File.Exists(excelFilePath))
{
    Console.WriteLine($"Excel file not found at path: {excelFilePath}");
    return;
}

if (!Directory.Exists(outputDirectory))
{
    Directory.CreateDirectory(outputDirectory);
}

var reader = new ExcelReader(excelFilePath);
var fileNames = reader.ReadColumn(targetColumnName);

var generator = new PdfGenerator(outputDirectory, pdfContentTemplate);

foreach (var fileName in fileNames)
{
    generator.CreatePdf(fileName);
    Console.WriteLine($"Generated: {fileName}.pdf");
}

Console.ForegroundColor = ConsoleColor.Gray;

Console.WriteLine("\nAll PDFs generated.");
Console.WriteLine("\n(press any <key> to exit...");

Console.ResetColor();

Console.ReadKey();
