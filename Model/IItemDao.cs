using System.Collections.Generic;

namespace EisenhowerMain.Model;

public interface IItemDao
{
    public void Add(TodoItem item);

    public void Update(TodoItem item);

    public TodoItem Get(int id);

    List<TodoItem> GetAll();
}