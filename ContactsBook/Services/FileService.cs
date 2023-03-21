namespace ContactsBook.Services;

internal class FileService
{
    public void Save(string filePath, string content)
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine(content);
    }

    public string Read(string filePath)
    {
        try
        {
            using var sw = new StreamReader(filePath);
            return sw.ReadToEnd();
        }
        catch 
        {
            return null!;
        }
    }
}
