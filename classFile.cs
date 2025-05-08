namespace CookBook;

class FileManager
{
    private CookBook _cookBook;
    private MessageConsole _messageConsole;

    public const string Folder = @"C:\Users\Edoardo\RiderProjects\CookBook\CookBook\bin\Debug\net9.0\";
    public readonly string NameFile = "Ricette";
    public readonly string FilePath = @"C:\Users\Edoardo\RiderProjects\CookBook\CookBook\bin\Debug\net9.0\Ricette.";
    public const EstensioneFile FormatoFile = EstensioneFile.Txt;

    public FileManager(CookBook cookBook, MessageConsole messageConsole)
    {
        this._cookBook = cookBook;
        this._messageConsole = messageConsole;
    }
    public enum EstensioneFile
    {
        Json,
        Txt
    }
    
    public EstensioneFile GetFormatoFile()
    {
        return FormatoFile;
    }

    public string FilePathPlusExtension()
    {
        return  FilePath + FormatoFile.ToString().ToLower();
    }
    
    
    public void SaveFile()
    {
        if (GetFormatoFile() is EstensioneFile.Json)
        {
            var json = JsonSerializer.Serialize(_cookBook.ListaFinaleDellUtente());
            File.WriteAllText(FilePathPlusExtension(), json);
            
        }
        else
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(FilePathPlusExtension())))
            {
                foreach (var item in _cookBook.ListaFinaleDellUtente())
                    outputFile.WriteLine($"{item.Id}.{item.Nome}.{item.Informazioni}");
            }
        }
    }
    

    
    
    public void LoadFileIntoConsole(EstensioneFile estensioneFile)
    {
        string fullPath = FilePathPlusExtension();
        
        if (estensioneFile is EstensioneFile.Json)
        {
            var readFile = File.ReadAllText(FilePathPlusExtension());
            _messageConsole.Asterischi(CounterFile());
            Console.WriteLine(readFile);
            
        }
        else
        {
            var readFile = File.ReadAllLines(FilePathPlusExtension());
            _messageConsole.Asterischi(CounterFile());
            foreach (var item in readFile)
            {
                Console.WriteLine(item);
            }
            
            
            
        }
    }

    public int CounterFile()
    {
        var counter = 0;
        string[] filePresentiNellaCartella = Directory.GetFiles(Folder);
        foreach (var item in filePresentiNellaCartella)
        {
            if (item.Contains($"{NameFile}"))
            {
                counter++;
            }
        }

        return counter;
    }
    
}
