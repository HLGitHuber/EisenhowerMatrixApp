using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper.Configuration.Attributes;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace EisenhowerMain
{
    public class TodoMatrix {
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
            bool isUrgent = deadline.AddDays(3) <= DateTime.Now;
            
            if (isImportant && isUrgent) TodoQuarters["IU"].AddItem(title, deadline);
            if (isImportant && !isUrgent) TodoQuarters["IN"].AddItem(title, deadline);
            if (!isImportant && isUrgent) TodoQuarters["NU"].AddItem(title, deadline);
            if (!isImportant && !isUrgent) TodoQuarters["NN"].AddItem(title, deadline);
        }
        //TODO working reading && writing csv files method
        public void AddItemsFromFile(string fileName)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };
            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var reader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(reader, configuration))
                {
                    var records = csv.GetRecords<CsvItem>();

                    foreach (var item in records)
                    {
                       //do something with it
                    }
                }
            }
        }
    }

    public class CsvItem
    {
        [Name("title")]
        public string Title { get; set; }
            
        [Name("day-month")]
        public string DayMonth { get; set; }
        
        [Name("is_important")]
        public string IsImportant { get; set; }
    }

}