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
                              "10. Load items from database \n" +
                              "0. Archive, save and exit \n");
        }

        public void NotImplementedYet() => Console.WriteLine("Not implemented yet");

        public void AskForIndex() => Console.WriteLine("Choose item by its number");

        public void AskForStatus() => Console.WriteLine("Choose one of the statuses ('IU', 'IN', 'NU', 'NN')");

        public void AskForTitle() => Console.WriteLine("Put in the title:");

        public void AskForDeadline() => Console.WriteLine("Put in the deadline (dd-MM)");

        public void AskForImportance() => Console.WriteLine("Is it important? (Y/N)");
        
    }
}