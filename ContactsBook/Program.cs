using ContactsBook.Models;
using ContactsBook.Services;

var menu = new MenuManager();

menu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

while (menu.ConsoleAppRunning)
{
    Console.Clear();
    menu.StartingMenu();
}