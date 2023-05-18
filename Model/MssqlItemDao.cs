using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

            string sql =
                @"
INSERT INTO items (title, deadline, important, done)
VALUES (@title, @deadline, @important, @done);

SELECT SCOPE_IDENTITY();
";

            command.CommandText = sql;
            command.Parameters.AddWithValue("@title", item.GetTitle());
            command.Parameters.AddWithValue("@deadline", item.GetDeadline());
            command.Parameters.AddWithValue("@important", item.GetImportance());
            command.Parameters.AddWithValue("@done", item.IsDone);
            
            int itemId = Convert.ToInt32(command.ExecuteScalar());
            item.SetId(itemId);
        }
        catch (SqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void MarkUpdate(TodoItem item)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            string sql =
                @"
UPDATE items 
SET done = @done
WHERE id = @id;
";

            command.CommandText = sql;
            command.Parameters.AddWithValue("@done", item.IsDone);
            command.Parameters.AddWithValue("@id", item.GetId());
            
            command.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Delete(TodoItem item)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            string sql =
                @"
DELETE FROM items 
WHERE id = @id;
";
            
            command.CommandText = sql;

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
        try
        {
            var todoItems = new List<TodoItem>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            string sql = @"
SELECT id, title, deadline, important, done
FROM items;
";
                command.CommandText = sql;

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = (int)reader["id"];
                string title = (string)reader["title"];
                DateTime deadline = Convert.ToDateTime(reader["deadline"]);
                bool important = (bool)reader["important"];
                bool done = (bool)reader["done"];

                var item = new TodoItem(title, deadline, important);
                item.SetId(id);
                item.IsDone = done;
                
                todoItems.Add(item);
            }

            Console.WriteLine(todoItems);
            return todoItems;

        }
        catch (SqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}