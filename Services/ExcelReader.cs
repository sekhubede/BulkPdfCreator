using ClosedXML.Excel;

namespace BulkPdfCreator.Services;

public class ExcelReader(string filePath)
{
    public List<string> ReadColumn(string columnName)
    {
        var values = new List<string>();

        using var workbook = new XLWorkbook(filePath);
        var worksheet = workbook.Worksheets.First();
        var headerRow = worksheet.Row(1);

        int columnIndex = -1;

        foreach (var cell in headerRow.Cells())
        {
            if (cell.Value.ToString().Equals(columnName, StringComparison.OrdinalIgnoreCase))
            {
                columnIndex = cell.Address.ColumnNumber;
                break;
            }
        }

        if (columnIndex == -1)
            throw new Exception($"Column '{columnName}' not found.");

        foreach (var row in worksheet.RowsUsed().Skip(1))
        {
            var cellValue = row.Cell(columnIndex).GetValue<string>();
            if (!string.IsNullOrWhiteSpace(cellValue))
                values.Add(cellValue);
        }

        return values;
    }
}
