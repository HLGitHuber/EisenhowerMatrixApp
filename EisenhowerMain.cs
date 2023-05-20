using System;
using System.Collections.Generic;
using EisenhowerMain.Manager;
using EisenhowerMain.Model;
using Microsoft.Data.SqlClient;

namespace EisenhowerMain
{
    public class EisenhowerMain
    {  
        public static void Main(String[] args)
        {
            TodoDbManager manager = new TodoDbManager();

            //TODO make exceptions for false inputs
            
            var FILENAME = "list";
            var matrix = new TodoMatrix();
            var display = new Display();
            var input = new Input();
            
            bool exit = false;
            while (!exit)
            {
                TodoQuarter quarter;
                TodoItem item;
                
                Console.Clear();
                Console.WriteLine(matrix.ToString());
                display.ShowMenu();
                string menuInput = Console.ReadLine();

                switch (menuInput)
                {
                    case "1":
                        exit = true;
                        break;
                    case "2":
                        item = GetNewItem(display, input);
                        manager.AddItemToDb(item);
                        matrix.AddItem(item);
                        break;
                    case "3":
                        display.AskForStatus();
                        quarter = matrix.GetQuarter(input.GetStringUpper());
                        display.AskForIndex();
                        item = quarter.GetItem(input.GetInt()-1);
                        item.Mark();
                        manager.SwitchMarkInDb(item);
                        break;
                    case "4":
                        display.AskForStatus();
                        quarter = matrix.GetQuarter(input.GetStringUpper());
                        display.AskForIndex();
                        item = quarter.GetItem(input.GetInt()-1);
                        item.Unmark();
                        manager.SwitchMarkInDb(item);
                        break;
                    case "5":
                        display.AskForStatus();
                        quarter = matrix.GetQuarter(input.GetStringUpper());
                        display.AskForIndex();
                        var userInput = input.GetInt();
                        item = quarter.GetItem(userInput - 1);
                        manager.DeleteItemFromDb(item);
                        quarter.RemoveItem(userInput-1);
                        break;
                    case "6":
                        matrix.ArchiveItems(manager);
                        break;
                    case "7":
                        matrix.SaveItemsToFile(FILENAME);
                        break;
                    case "8":
                        matrix.AddItemsFromFile(FILENAME);
                        break;
                    case "9":
                        matrix.AddItemsFromDb(manager);
                        break;
                    case "0":
                        exit = true;
                        matrix.ArchiveItems(manager);
                        matrix.SaveItemsToFile(FILENAME);
                        break;
                }
            }
        }

        public static TodoItem GetNewItem(Display display, Input input)
        {
            display.AskForTitle();
            var title = input.GetString();
            display.AskForDeadline();
            var deadline = input.GetDeadline();
            display.AskForImportance();
            var isImportant = input.GetImportance();
            var item = new TodoItem(title, deadline, isImportant);
            return item;
        }
    }
}
