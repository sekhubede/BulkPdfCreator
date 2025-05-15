# BulkPdfCreator

BulkPdfCreator is a C# Console application that reads an Excel file with thousands of records and generates dummy PDF files using values from a specified column. It's ideal for generating mock document sets for testing or archiving scenarios.

---

## 🚀 Features

- 🔍 Reads Excel files using `ClosedXML`
- 🧾 Generates PDF files using `QuestPDF`
- 📁 Extracts a specific column to use as the filename
- 🧵 Supports parallel file generation with configurable concurrency
- 🛠 Sanitizes file names to avoid OS-level conflicts
- 📦 Fully open-source and non-commercial library usage

---

## 🛠 Technologies Used

| Technology     | Purpose                     | License Type       |
|----------------|-----------------------------|--------------------|
| [ClosedXML](https://github.com/ClosedXML/ClosedXML) | Excel file reading         | MIT (Open-source)    |
| [QuestPDF](https://www.questpdf.com/license/)     | PDF generation              | Community License (Free for < $1M revenue) |

---

## ⚙️ Configuration (`appsettings.json`)

```json
{
  "ExcelFilePath": "C:\\Path\\To\\Your\\records.xlsx",
  "OutputDirectory": "C:\\Path\\To\\Output\\Directory",
  "TargetColumnName": "Name or title",
  "PdfContentTemplate": "This is a dummy PDF for {filename}.",
  "ParallelDegreeOfConcurrency": 4
}
```

- `ExcelFilePath`: Path to the source Excel file
- `OutputDirectory`: Where generated PDFs will be stored
- `TargetColumnName`: Header name of the column to extract values from
- `PdfContentTemplate`: Template used as content in the generated PDFs. Use `{filename}` as a placeholder.
- `ParallelDegreeOfConcurrency`: Number of parallel PDF generations (default: 4 or based on CPU count)

---

## 📦 Project Structure

```
BulkPdfCreator/
├── Services/
│   ├── ExcelReader.cs       # Extracts values from Excel
│   └── PdfGenerator.cs      # Handles PDF file creation
├── Utilities/
│   └── FileHelper.cs        # Sanitizes file names
├── Startup/
│   └── Program.cs           # Main entry point
├── appsettings.json         # Config file
└── README.md
```

---

## 🔄 Roadmap

- [x] Excel column extraction
- [x] Dummy PDF generation
- [x] File name sanitization
- [x] Parallel file generation
- [ ] Logging and error handling
- [ ] Progress bar or metrics
- [ ] CLI input support

---

## 🤝 License

This tool uses open-source libraries under MIT and permissive community licenses. Please check each linked project for compliance in your environment.

---

## 🙌 Acknowledgements

Thanks to the creators and maintainers of [ClosedXML](https://github.com/ClosedXML/ClosedXML) and [QuestPDF](https://www.questpdf.com) for their powerful, developer-friendly libraries.

---
