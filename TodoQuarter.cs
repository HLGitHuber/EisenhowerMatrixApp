using System;
using System.Collections.Generic;
using System.Text;

namespace EisenhowerMain { 

    public class TodoQuarter {
        private List<TodoItem> TodoItems { get; set; }

        public TodoQuarter()
        {
            this.TodoItems = new List<TodoItem>();
        }

        public void AddItem(string title, DateTime deadline)
        {
            TodoItem Item = new TodoItem(title, deadline);
            TodoItems.Add(Item);
        }
    }

}