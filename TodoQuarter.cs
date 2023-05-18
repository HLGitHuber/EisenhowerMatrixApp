using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EisenhowerMain { 

    public class TodoQuarter {
        private List<TodoItem> TodoItems { get; set; }

        public TodoQuarter()
        {
            this.TodoItems = new List<TodoItem>();
        }

        public void AddItem(TodoItem item)
        {
            TodoItems.Add(item);
        }

        public void RemoveItem(int index)
        {
            TodoItems.RemoveAt(index);
        }
        
        public void ArchiveItems()
        {
            foreach (var todoItem in TodoItems.Where(todoItem => todoItem.IsDone))
            {
                TodoItems.Remove(todoItem);
            }
        }

        public TodoItem GetItem(int index)
        {
            return TodoItems[index];
        }

        public List<TodoItem> GetItems()
        {
            return TodoItems;
        }

        public override string ToString()
        {
            string stringList = "";
            foreach (var todoItem in TodoItems)
            {
                stringList += todoItem.ToString();
                stringList += Environment.NewLine;
            }

            return stringList;
        }
    }

}