using BulkPdfCreator.Utilities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace BulkPdfCreator.Services;

public class PdfGenerator(string outputDirectory, string template)
{
   public void CreatePdf(string rawFileName)
   {
        var safeFileName = FileHelper.SanitizeFileName(rawFileName);
        var filePath = Path.Combine(outputDirectory, $"{safeFileName}.pdf");

        var content = template.Replace("filename", safeFileName);

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(50);
                page.Size(PageSizes.A4);
                page.Content().Padding(50).Column(col =>
                {
                    col.Item().Text("Bulk PDF Generator")
                    .FontSize(20).Bold().FontColor(Colors.Blue.Medium);

                    col.Item().Text(content).FontSize(14);
                });
            });
        }).GeneratePdf(filePath);
   }
}
