using System;
using System.Collections.Generic;
using System.Configuration;
using EisenhowerMain.Model;
using Microsoft.Data.SqlClient;

namespace EisenhowerMain.Manager;

public class TodoDbManager
{
    
    private readonly IItemDao _dao;
    
    public TodoDbManager()
    {
        this._dao = new MssqlItemDao(ConnectionString);
    }
    
    public string ConnectionString => ConfigurationManager.AppSettings["connectionString"];
    
    public void Connect()
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
    }
    
    public void AddItemToDb(TodoItem item) => _dao.Add(item);

    public void DeleteItemFromDb(TodoItem item) => _dao.Delete(item);

    public void SwitchMarkInDb(TodoItem item) => _dao.MarkUpdate(item);
    
    public List<TodoItem> GetAllItems() => _dao.GetAll();
}