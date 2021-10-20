﻿using QuickLook;
using System;
using System.IO;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(PdfSaveService))]

public class PdfSaveService : IPdfSave
{
    //Method to save document as a file and view the saved document
    public async Task SaveAndView(string filename, string contentType, MemoryStream stream) => await Task.Run(() =>
    {
        //Get the root path in iOS device.
        var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        var filePath = Path.Combine(path, filename);

        //Create a file and write the stream into it.
        var fileStream = File.Open(filePath, FileMode.Create);
        stream.Position = 0;
        stream.CopyTo(fileStream);
        fileStream.Flush();
        fileStream.Close();

        //Invoke the saved document for viewing
        MainThread.BeginInvokeOnMainThread(() =>
        {
            var currentController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (currentController.PresentedViewController != null)
                currentController = currentController.PresentedViewController;
            var currentView = currentController.View;

            var qlPreview = new QLPreviewController();
            QLPreviewItem item = new QLPreviewItemBundle(filename, filePath);
            qlPreview.DataSource = new PreviewControllerDS(item);

            currentController.PresentViewController(qlPreview, true, null);
        });

    }).ConfigureAwait(false);
}
