using System;
using System.Collections.Generic;

namespace EisenhowerMain
{
    public class EisenhowerMain
    {  
        public static void Main(String[] args)
        {
            //TODO make exceptions for inputs
            
            var FILENAME = "list";
            var matrix = new TodoMatrix();
            var display = new Display();
            
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(matrix.ToString());
                display.ShowMenu();
                
                string menuInput = Console.ReadLine();
                TodoQuarter quarter;

                switch (menuInput)
                {
                    case "1":
                        exit = true;
                        break;
                    case "2":
                        display.NotImplementedYet();
                        break;
                    case "3":
                        var title = display.AskForTitle();
                        var deadline = display.AskForDeadline();
                        var isImportant = display.AskForImportance();
                        matrix.AddItem(title, deadline, isImportant);
                        break;
                    case "4":
                        quarter = matrix.GetQuarter(display.AskForStatus());
                        quarter.GetItem(display.AskForIndex()).Mark();
                        break;
                    case "5":
                        quarter = matrix.GetQuarter(display.AskForStatus());
                        quarter.GetItem(display.AskForIndex()).Unmark();
                        break;
                    case "6":
                        quarter = matrix.GetQuarter(display.AskForStatus());
                        quarter.RemoveItem(display.AskForIndex());
                        break;
                    case "7":
                        matrix.ArchiveItems();
                        break;
                    case "8":
                        matrix.SaveItemsToFile(FILENAME);
                        break;
                    case "9":
                        matrix.AddItemsFromFile(FILENAME);
                        break;
                    case "0":
                        exit = true;
                        matrix.ArchiveItems();
                        matrix.SaveItemsToFile(FILENAME);
                        break;
                }
            }
        }
    }
}
