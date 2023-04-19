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
            var item = new TodoItem(title, deadline);
            TodoItems.Add(item);
        }

        public void RemoveItem(int index)
        {
            TodoItems.RemoveAt(index);
        }
        
        public void ArchiveItems()
        {
            foreach (var todoItem in TodoItems)
            {
                if (todoItem.IsDone) TodoItems.Remove(todoItem);
            }
        }
    }

}