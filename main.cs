using System.Runtime.Intrinsics.Arm;

namespace CookBook;

class Program
{
    static void Main(string[] args)
    {
        MessageConsole msgConsole = new MessageConsole();
        CookBook cookBook = new CookBook();
        FileManager fileManager = new FileManager(cookBook,msgConsole);
        QuitProgramm quitProgramm = new QuitProgramm(msgConsole,cookBook,fileManager);
        SceltaIngredienti sceltaIngredienti = new SceltaIngredienti(cookBook,msgConsole,quitProgramm);
        MainMenu mainMenu = new MainMenu(cookBook, msgConsole,sceltaIngredienti,fileManager);
        
        
        mainMenu.PrintMainMenu();
        

    }
}
