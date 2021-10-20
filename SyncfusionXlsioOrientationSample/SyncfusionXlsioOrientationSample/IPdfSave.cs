using System.IO;

public interface IPdfSave
{
    /// <summary>
    /// Method to save document as a file and view the saved document
    /// </summary>
    Task SaveAndView(string filename, string contentType, MemoryStream stream);
}

