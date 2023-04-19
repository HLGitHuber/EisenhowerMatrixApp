using System;

namespace EisenhowerMain 
{
    public class TodoItem
    {
        private string Title { get; set; }
        private DateTime Deadline { get; set; }
        private bool IsDone { get; set; }

        public TodoItem(string title, DateTime deadline)
        {
            this.Title = title;
            this.Deadline = deadline;
            this.IsDone = false;
        }

        public string GetTitle()
        {
            return Title;
        }

        public DateTime GetDeadline()
        {
            return Deadline;
        }

        private void Mark()
        {
            IsDone = true;
        }

        private void Unmark()
        {
            IsDone = false;
        }

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