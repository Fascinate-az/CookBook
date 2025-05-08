using System.Net.Mail;

namespace CookBook;

using System.Globalization;
using System.Text.Json;
using System.IO;
class CookBook
{
    private MessageConsole msgConsole = new MessageConsole();
    public readonly List<Ingredienti> ingredientiSceltiUtente = new List<Ingredienti>();

    List<Ingredienti> listaIngredienti = new List<Ingredienti>()
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder(),

    };

    

    public List<Ingredienti> SelezioneDegliIngredienti()
    {
        return listaIngredienti;
    }

    public void RecipeAdd(int input)
    {
        var index = SelezioneDegliIngredienti()[input - 1];
        ingredientiSceltiUtente.Add(index);
        
    }

    public List<Ingredienti> ListaFinaleDellUtente()
    {
        return ingredientiSceltiUtente;
    }
    
}

class MainMenu
{
    private CookBook cookBook;
    private MessageConsole msgConsole;
    private SceltaIngredienti sceltaIngredienti;
    private FileManager _fileManager;
    
    
    public MainMenu(CookBook cookBook, MessageConsole msgConsole, SceltaIngredienti sceltaIngredienti, FileManager fileManager)
    {
       this.cookBook = cookBook;
       this.msgConsole = msgConsole;
       this.sceltaIngredienti = sceltaIngredienti;
       this._fileManager = fileManager;
       
    }
    public void PrintMainMenu()
    {
        if (File.Exists(_fileManager.FilePathPlusExtension()))
        {
            msgConsole.CaricaRecipe();
            _fileManager.LoadFileIntoConsole(_fileManager.GetFormatoFile());
            msgConsole.IntroMessage();
            cookBook.SelezioneDegliIngredienti().ForEach(item => Console.WriteLine(item));
            sceltaIngredienti.SceltaDegliIngredienti();
        }
        
        
        else
        {
            msgConsole.IntroMessage();
            cookBook.SelezioneDegliIngredienti().ForEach(item => Console.WriteLine(item));
            sceltaIngredienti.SceltaDegliIngredienti();
        }
        
    }
    
   
    
}

class SceltaIngredienti
{
    private CookBook cookBook;
    private MessageConsole msgConsole;
    private QuitProgramm quit;
    public SceltaIngredienti(CookBook cookBook, MessageConsole msgConsole,QuitProgramm quit)
    {
        this.cookBook = cookBook;
        this.msgConsole = msgConsole;
        this.quit = quit;
    }
    public int SceltaDegliIngredienti()
    {
        bool loop = true;
        int input = 0;
        while (loop)
        {
            msgConsole.SceltaIngredienti();
            bool isValid = int.TryParse(Console.ReadLine(), out input);
            if (input >=1 && input <= cookBook.SelezioneDegliIngredienti().Count && isValid)
            {
                
                cookBook.RecipeAdd(input);
                msgConsole.ConfermaIngredienteAggiunto();
            }

            else
            {
                    quit.Quit();
                    loop = false;
               
                
            }
        }
        return input;
    }
}


class QuitProgramm
{
    private MessageConsole msgConsole;
    private CookBook cookBook;
    private FileManager fileManager;
    public QuitProgramm(MessageConsole msgConsole, CookBook cookBook,FileManager fileManager)
    {
        this.msgConsole = msgConsole;
        this.cookBook = cookBook;
        this.fileManager = fileManager;
    }
    
    public void Quit()
    {
        if (cookBook.ListaFinaleDellUtente().Count > 0)
        {
            msgConsole.RecipeAdded();
            cookBook.ListaFinaleDellUtente().ForEach(item => Console.WriteLine($"{item}. {item.Informazioni}"));
            fileManager.SaveFile();
            msgConsole.Exit();
            Console.ReadKey();
            Environment.Exit(0); 
        }
        else
        {
            Environment.Exit(0);
        }
    }
}

