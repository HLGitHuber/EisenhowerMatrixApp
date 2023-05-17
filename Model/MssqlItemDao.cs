using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace EisenhowerMain.Model;

public class MssqlItemDao : IItemDao
{
    // for select => command.ExecuteReader();
    // for no returns => command.ExecuteNonQuery();
    // for single select => command.ExecuteScalar();
    
    private readonly string _connectionString;
    
    public MssqlItemDao(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public void Add(TodoItem item)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            string insertItemSql =
                @"
INSERT INTO items (title, deadline, important)
VALUES (@title, @deadline, @important);

SELECT SCOPE_IDENTITY();
";

            command.CommandText = insertItemSql;
            command.Parameters.AddWithValue("@title", item.GetTitle());
            command.Parameters.AddWithValue("@deadline", item.GetDeadline());
            command.Parameters.AddWithValue("@important", item.GetImportance());
            
            int itemId = Convert.ToInt32(command.ExecuteScalar());
            item.SetId(itemId);
        }
        catch (SqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Update(TodoItem item)
    {
        throw new System.NotImplementedException();
    }

    public void Delete(TodoItem item)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            string insertItemSql =
                @"
DELETE FROM items 
WHERE id = @id;
";

            command.CommandText = insertItemSql;
            command.Parameters.AddWithValue("@id", item.GetId());

            command.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public TodoItem Get(int id)
    {
        throw new System.NotImplementedException();
    }

    public List<TodoItem> GetAll()
    {
        throw new System.NotImplementedException();
    }
}