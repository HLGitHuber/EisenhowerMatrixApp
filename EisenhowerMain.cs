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
            manager.Connect();

            IItemDao itemDao = new MssqlItemDao(manager.ConnectionString);
            
            //TODO make exceptions for false inputs
            
            var FILENAME = "list";
            var matrix = new TodoMatrix();
            var display = new Display();
            var input = new Input();
            
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(matrix.ToString());
                display.ShowMenu();
                
                string menuInput = Console.ReadLine();
                TodoQuarter quarter;
                TodoItem item;
                
                switch (menuInput)
                {
                    case "1":
                        exit = true;
                        break;
                    case "2":
                        display.NotImplementedYet();
                        break;
                    case "3":
                        display.AskForTitle();
                        var title = input.GetString();
                        display.AskForDeadline();
                        var deadline = input.GetDeadline();
                        display.AskForImportance();
                        var isImportant = input.GetImportance();
                        item = new TodoItem(title, deadline, isImportant);
                        AddItemToDb(item, itemDao);
                        matrix.AddItem(item);
                        break;
                    case "4":
                        display.AskForStatus();
                        quarter = matrix.GetQuarter(input.GetStringUpper());
                        display.AskForIndex();
                        item = quarter.GetItem(input.GetInt()-1);
                        item.Mark();
                        SwitchMarkInDb(item, itemDao);
                        break;
                    case "5":
                        display.AskForStatus();
                        quarter = matrix.GetQuarter(input.GetStringUpper());
                        display.AskForIndex();
                        item = quarter.GetItem(input.GetInt()-1);
                        item.Unmark();
                        SwitchMarkInDb(item, itemDao);
                        break;
                    case "6":
                        display.AskForStatus();
                        quarter = matrix.GetQuarter(input.GetStringUpper());
                        display.AskForIndex();
                        var userInput = input.GetInt();
                        item = quarter.GetItem(userInput - 1);
                        DeleteItemFromDb(item, itemDao);
                        quarter.RemoveItem(userInput-1);
                        break;
                    case "7":
                        matrix.ArchiveItems(itemDao);
                        break;
                    case "8":
                        matrix.SaveItemsToFile(FILENAME);
                        break;
                    case "9":
                        matrix.AddItemsFromFile(FILENAME);
                        break;
                    case "10":
                        matrix.AddItemsFromDb(itemDao);
                        break;
                    case "0":
                        exit = true;
                        matrix.ArchiveItems(itemDao);
                        matrix.SaveItemsToFile(FILENAME);
                        break;
                }
            }
        }

        public static void AddItemToDb(TodoItem item, IItemDao dao)
        {
            dao.Add(item);
        }

        public static void DeleteItemFromDb(TodoItem item, IItemDao dao)
        {
            dao.Delete(item);
        }

        public static void SwitchMarkInDb(TodoItem item, IItemDao dao)
        {
            dao.MarkUpdate(item);
        }
    }
}
