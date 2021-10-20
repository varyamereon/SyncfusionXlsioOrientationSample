using MvvmHelpers;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncfusionXlsioOrientationSample;

public class MainPageViewModel : BaseViewModel
{
    public MainPageViewModel()
    {

    }

    private Command generateCommand;
    public ICommand GenerateCommand => generateCommand ??= new Command(Generate);

    private void Generate()
    {
        var renderer = new XlsIORenderer();
        using var engine = new ExcelEngine();
        var application = engine.Excel;

        var workbook = application.Workbooks.Create(1);
        var worksheet = workbook.Worksheets.First();
        worksheet.SetText(1, 1, "Hello world");

        worksheet.PageSetup.Orientation = ExcelPageOrientation.Landscape; // Landscape set on Excel worksheet.

        var document = renderer.ConvertToPDF(worksheet);
        document.PageSettings.Orientation = Syncfusion.Pdf.PdfPageOrientation.Landscape; // Landscape set on PDF document.
        var pdfService = DependencyService.Get<IPdfSave>();

        var stream = new MemoryStream();
        document.Save(stream);
        pdfService.SaveAndView($"Test.pdf", "application/pdf", stream);
    }
}

