using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace EisenhowerMain.Manager;

public class TodoDbManager
{
    public string ConnectionString => ConfigurationManager.AppSettings["connectionString"];

    public void Connect()
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
    }
}