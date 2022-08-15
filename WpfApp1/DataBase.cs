using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace WpfApp1;

public class DataBase
{
    private const string STR = @"Data Source=D:\Programming\Temp\persons.db;";
    private SqliteConnection _db;

    public DataBase()
    {
        _db = new SqliteConnection(STR);
    }

    public IEnumerable<Person> GetAllPersons()
    {
        var persons = new List<Person>();
        
        _db.Open();

        var sql = "SELECT * FROM tab_persons";
        var command = new SqliteCommand(sql, _db);
        var result = command.ExecuteReader();
        while (result.Read())
        {
            persons.Add(new Person
            {
                Id = result.GetInt32("id"),
                FirstName = result.GetString("first_name"),
                LastName = result.GetString("last_name"),
                DateOfBirth = Convert.ToDateTime(result.GetString("date_of_birth"))
            });
        }
        
        _db.Close();

        return persons;
    }

    public void UpdatePerson(Person person)
    {
        _db.Open();

        var sql = $"UPDATE tab_persons SET first_name = '{person.FirstName}', last_name = '{person.LastName}', date_of_birth = '{person.DateOfBirth:g}' WHERE id = {person.Id}";
        var command = new SqliteCommand(sql, _db);
        command.ExecuteNonQuery();
        
        _db.Close();
    }

    public void UpdateAllPersons(IEnumerable<Person> persons)
    {
        foreach (var person in persons)
        {
            UpdatePerson(person);
        }
    }
}