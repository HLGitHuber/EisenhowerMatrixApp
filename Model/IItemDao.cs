using System.Collections.Generic;

namespace EisenhowerMain.Model;

public interface IItemDao
{
    public void Add(TodoItem item);

    public void MarkUpdate(TodoItem item);

    public void Delete(List<int> itemIds);

    public TodoItem Get(int id);

    List<TodoItem> GetAll();
}