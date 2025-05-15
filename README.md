
# 🗂️ BulkPdfCreator

**BulkPdfCreator** is a .NET Console application that reads 50,000+ records from an Excel file and generates dummy PDFs named after a specific column (e.g., invoice numbers). It's designed for batch processing and leverages fully open-source, permissively licensed libraries.

---

## 🚀 Features

- Read large Excel `.xlsx` files
- Extract a specific column for file naming
- Generate individual PDF files for each record
- Configurable input/output paths and content template
- Uses only MIT-licensed or non-commercial-friendly libraries

---

## 📁 Project Structure

```
BulkPdfCreator/
│
├── appsettings.json           # Configuration file
├── Program.cs                 # Main application bootstrap
├── Services/
│   ├── ExcelReader.cs         # Reads Excel and extracts values
│   └── PdfGenerator.cs        # Generates PDFs
│
└── Utilities/
    └── FileHelper.cs          # Sanitizes filenames
```

---

## ⚙️ Configuration

Edit the `appsettings.json`:

```json
{
  "ExcelFilePath": "C:\\Data\\records.xlsx",
  "OutputDirectory": "C:\\Data\\GeneratedPdfs",
  "TargetColumnName": "InvoiceNumber",
  "PdfContentTemplate": "This is a dummy PDF for {filename}."
}
```

---

## 🧪 Getting Started

1. Clone the repository
2. Run `dotnet restore` to install dependencies
3. Update `appsettings.json` with your paths
4. Run the project

---

## 🧾 Libraries Used

| Library      | Purpose               | License |
|--------------|------------------------|---------|
| [ClosedXML](https://github.com/ClosedXML/ClosedXML) | Read `.xlsx` Excel files | MIT |
| [QuestPDF](https://github.com/QuestPDF/QuestPDF)     | Generate PDFs | Community (Free for < $1M orgs), otherwise Commercial |

> ℹ️ This project uses the **Community license** of QuestPDF. Please review their [license page](https://www.questpdf.com/license/) to ensure compliance for your use case.

---

## ✅ TODO / Next Steps

- [ ] Add parallel file generation
- [ ] Add CLI overrides for config values
- [ ] Log success/failure per PDF
- [ ] Performance monitoring

---

## 📜 License

This project is open-source under the **MIT License**.
