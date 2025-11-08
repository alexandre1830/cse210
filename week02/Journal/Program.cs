using System;
public class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        
        string _choice = "";
        do
        {
            Console.WriteLine("\nNavigation Menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option from the menu: ");
            _choice = Console.ReadLine() ?? "";

            switch (_choice.Trim().ToLower())
            {
                case "1":
                case "write":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Entry entry = new Entry();
                    entry._date = DateTime.Now.ToShortDateString();
                    entry._promptText = prompt;
                    entry._entryText = response;

                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added.");
                    break;

                case "2":
                case "display":
                    Console.WriteLine("Journal entries:");
                    journal.DisplayAll();
                    break;

                case "3":
                case "load":
                    Console.Write("Enter filename to load: ");
                    string loadName = Console.ReadLine();
                    journal.LoadFromFile(loadName);
                    Console.WriteLine("Journal loaded (if file existed).");
                    break;

                case "4":
                case "save":
                    Console.Write("Enter filename to save to: ");
                    string saveName = Console.ReadLine();
                    journal.SaveToFile(saveName);
                    Console.WriteLine($"Journal saved to {saveName}");
                    break;

                case "5":
                case "quit":
                    Console.WriteLine("Exiting the journal application. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option, please choose 1-5 or a word like 'Write'.");
                    break;
            }
        } while (_choice != "5");        
    }
}