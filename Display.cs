using System;

namespace EisenhowerMain
{
    public class Display
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n1. Quit \n" +
                              "2. Choose status of shown TODO items \n" +
                              "3. Add item \n" +
                              "4. Mark item \n" +
                              "5. Unmark item \n" +
                              "6. Remove item \n" +
                              "7. Archive items (remove all done) \n" +
                              "8. Save items to file \n" +
                              "9. Load items from file \n" +
                              "0. Archive, save and exit \n");
        }

        public void NotImplementedYet() => Console.WriteLine("Not implemented yet");

        public int AskForIndex()
        {
            Console.WriteLine("Choose item by its number");
            var index = Console.ReadLine();
            return int.Parse(index);
        }

        public string AskForStatus()
        {
            Console.WriteLine("Choose one of the statuses ('IU', 'IN', 'NU', 'NN')");
            return Console.ReadLine();
        }

        public string AskForTitle()
        {
            Console.WriteLine("Put in the title:");
            return Console.ReadLine();
        }

        public DateTime AskForDeadline()
        {
            Console.WriteLine("Put in the deadline (dd-MM)");
            var parsedDate = DateTime.Parse(Console.ReadLine());
            return parsedDate;
        }

        public bool AskForImportance()
        {
            Console.WriteLine("Is it important? (Y/N)");
            var userInput = Console.ReadLine();
            return userInput == "Y";
        }
    }
}