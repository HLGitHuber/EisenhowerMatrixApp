using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace EisenhowerMain
{
    public class TodoMatrix
    {
        private Dictionary<string, TodoQuarter> TodoQuarters { get; set; }

        public TodoMatrix()
        {
            TodoQuarters = new Dictionary<string, TodoQuarter>()
            {
                { "IU", new TodoQuarter() },
                { "IN", new TodoQuarter() },
                { "NU", new TodoQuarter() },
                { "NN", new TodoQuarter() }
            };
        }

        public Dictionary<string, TodoQuarter> GetQuarters()
        {
            return TodoQuarters;
        }

        public TodoQuarter GetQuarter(string status)
        {
            return TodoQuarters[status];
        }

        public void AddItem(string title, DateTime deadline, bool isImportant = false)
        {
            bool isUrgent = deadline <= DateTime.Now.AddDays(3);

            if (isImportant && isUrgent) TodoQuarters["IU"].AddItem(title, deadline);
            if (isImportant && !isUrgent) TodoQuarters["IN"].AddItem(title, deadline);
            if (!isImportant && isUrgent) TodoQuarters["NU"].AddItem(title, deadline);
            if (!isImportant && !isUrgent) TodoQuarters["NN"].AddItem(title, deadline);
        }

        public void AddItemsFromFile(string fileName)
        {

            var lines = ReadFile(fileName + ".csv");
            foreach (var line in lines)
            {
                string[] columns = line.Split(',');
                var title = columns[0];
                var deadline = ParseDateToDateTime(columns[1]);
                var isImportant = CheckIfIsImportant(columns[2]);
                AddItem(title, deadline, isImportant);
            }
        }

        public void SaveItemsToFile(string fileName)
        {
            using (var writer = new StreamWriter(fileName + ".csv", false, Encoding.UTF8))
            {
                foreach (var quarter in TodoQuarters)
                {
                    foreach (var item in quarter.Value.GetItems())
                    {
                        bool isImportant = quarter.Key == "IU" || quarter.Key == "IN";
                        var isImportantString = GetIsImportantString(isImportant);
                        writer.WriteLine("{0}|{1:dd-MM}|{2}", item.GetTitle(), item.GetDeadline(), isImportantString);
                    }
                }
            }
        }

        public void ArchiveItems()
        {
            foreach (var quarter in TodoQuarters.Values)
            {
                quarter.GetItems().RemoveAll(item => item.IsDone);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TODO:");
            sb.AppendLine("Important and Urgent:");
            sb.AppendLine(TodoQuarters["IU"].ToString());
            sb.AppendLine("Important but Not Urgent:");
            sb.AppendLine(TodoQuarters["IN"].ToString());
            sb.AppendLine("Urgent but Not Important:");
            sb.AppendLine(TodoQuarters["NU"].ToString());
            sb.AppendLine("Not Important and Not Urgent:");
            sb.AppendLine(TodoQuarters["NN"].ToString());
            return sb.ToString();
        }

        private string[] ReadFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            return lines;
        }

        private DateTime ParseDateToDateTime(string date)
        {
            var parsedDate = DateTime.Parse(date);
            return parsedDate;
        }

        private bool CheckIfIsImportant(string isImportant)
        {
            return isImportant != "" && isImportant != " ";
        }
        
        private string GetIsImportantString(bool isImportant)
        {
            return isImportant ? "1" : "";
        }
    }
}