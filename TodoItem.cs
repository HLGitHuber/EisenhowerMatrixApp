using System;

namespace EisenhowerMain 
{
    public class TodoItem
    {
        private string Title { get; set; }
        private DateTime Deadline { get; set; }
        
        private bool Important { get; set; }
        public bool IsDone { get; set; }

        public TodoItem(string title, DateTime deadline, bool important = false)
        {
            this.Title = title;
            this.Deadline = deadline;
            this.IsDone = false;
            this.Important = important;
        }

        public string GetTitle() => Title;

        public DateTime GetDeadline() => Deadline;

        public bool GetImportance() => Important;

        public void Mark() => IsDone = true;

        public void Unmark() => IsDone = false;

        public override string ToString()
        {
            int day = Deadline.Day;
            int month = Deadline.Month;
            char mark = ' ';
            
            if (IsDone) mark = 'x';

            return $"[{mark}] {day}-{month} {Title}";
        }
    }

}