using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace EisenhowerMain
{
    public class EisenhowerMain
    {  
        public static void Main(String[] args)
        {
            var _connectionString =
                @"Server=localhost\MSSQLSERVER2019;Database=Eisenhower;Trusted_Connection=True;TrustServerCertificate=True;";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            Console.WriteLine(connection.ServerVersion);
            // //TODO make exceptions for inputs
            //
            // var FILENAME = "list";
            // var matrix = new TodoMatrix();
            // var display = new Display();
            // var input = new Input();
            //
            // bool exit = false;
            // while (!exit)
            // {
            //     Console.Clear();
            //     Console.WriteLine(matrix.ToString());
            //     display.ShowMenu();
            //     
            //     string menuInput = Console.ReadLine();
            //     TodoQuarter quarter;
            //
            //     switch (menuInput)
            //     {
            //         case "1":
            //             exit = true;
            //             break;
            //         case "2":
            //             display.NotImplementedYet();
            //             break;
            //         case "3":
            //             display.AskForTitle();
            //             var title = input.GetString();
            //             display.AskForDeadline();
            //             var deadline = input.GetDeadline();
            //             display.AskForImportance();
            //             var isImportant = input.GetImportance();
            //             matrix.AddItem(title, deadline, isImportant);
            //             break;
            //         case "4":
            //             display.AskForStatus();
            //             quarter = matrix.GetQuarter(input.GetStringUpper());
            //             display.AskForIndex();
            //             quarter.GetItem(input.GetInt()-1).Mark();
            //             break;
            //         case "5":
            //             display.AskForStatus();
            //             quarter = matrix.GetQuarter(input.GetStringUpper());
            //             display.AskForIndex();
            //             quarter.GetItem(input.GetInt()-1).Unmark();
            //             break;
            //         case "6":
            //             display.AskForStatus();
            //             quarter = matrix.GetQuarter(input.GetStringUpper());
            //             display.AskForIndex();
            //             quarter.RemoveItem(input.GetInt()-1);
            //             break;
            //         case "7":
            //             matrix.ArchiveItems();
            //             break;
            //         case "8":
            //             matrix.SaveItemsToFile(FILENAME);
            //             break;
            //         case "9":
            //             matrix.AddItemsFromFile(FILENAME);
            //             break;
            //         case "0":
            //             exit = true;
            //             matrix.ArchiveItems();
            //             matrix.SaveItemsToFile(FILENAME);
            //             break;
            //     }
            // }
        }
    }
}
