using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System;

public class Student
{
    public Student() { }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    /* Adds new student to the table */
    static async Task Add(Student student)
    {
        using (IDbConnection db = new SqlConnection(cnnString)) {
            string insertQuery = "INSERT INTO [dbo].[Students] ([Name], [Age]) VALUES (@name, @age)";
            await db.QueryAsync(insertQuery, new { student.Name, student.Age });
        }
    }
    /* This method prints the students table */
    static async Task Print()
    {
        using (IDbConnection db = new SqlConnection(cnnString)) {
            string printQuery = "SELECT * FROM Students";
            List<Student> list = (await db.QueryAsync<Student>(printQuery)).ToList();

            foreach (var student in list)
                Console.WriteLine($"Id: {student.Id}\tName: {student.Name}\tAge: {student.Age}");
        }
    }
    public const string cnnString = "Server=localhost; Initial catalog=DZ; User=sa; password=qwerty112!";
    static async Task Main()
    {

    }
}
