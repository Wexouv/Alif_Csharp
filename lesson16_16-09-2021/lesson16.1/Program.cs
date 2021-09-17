﻿using System;
using System.Data.SqlClient;
//using System.Threading;

/* Input output helper */
static class IO {
    static private bool DEBUG = true;

    static public void Print(string what, ConsoleColor color = ConsoleColor.Black, bool newLine = true) {
        Console.ForegroundColor = color;
        Console.Write(what);

        if (newLine) Console.Write("\n");

        Console.ResetColor();
    }

    /* This function will not output to the terminal if DEBUG is not set */
    static public void Debug(string what, ConsoleColor color = ConsoleColor.DarkCyan, bool newLine = true) {
        if (!DEBUG) return;

        Print(what, color, newLine);
    }

    /* This method prompts WHAT and gets the input from Console*/
    static public string GetString(string what = "") {
        IO.Print(what, ConsoleColor.Yellow, false);
        var input = Console.ReadLine();
        return input;
    }
}

class Account {
    public int       Id          { get; set; }
    public string    Acc         { get; set; }
    public int       Is_Active   { get; set; }
    public DateTime  Created_At  { get; set; }
    public DateTime? Updated_At  { get; set; } // This can be null

    // Default constructor
    public Account() { }

    public Account(string acc, int is_active, DateTime created_at) {
        Acc = acc;
        Is_Active = is_active;
        Created_At = created_at;
        IO.Debug("Created new account instance.", ConsoleColor.Green);
    }

    class Transaction { 
        public int      Id           { get; set; }
        public int      Account_Id   { get; set; }
        public decimal  Amount       { get; set; }
        public DateTime Created_At   { get; set; }
    }

    class Program {
        /* NOTE: Why ref ? */
        static void CreateAccount(ref SqlConnection cnn) {
            var curAcc = new Account(IO.GetString("Input Account number in xxxxx format: "), 1, DateTime.Now);

            try {
                if (String.IsNullOrEmpty(curAcc.Acc)) throw new Exception("Account can not be empty !");
                /* If OK then, open the connection */
                cnn.Open();
                IO.Debug("Connection opened !");
                try {
                    var command = cnn.CreateCommand();
                    /* The command to execute */
                    command.CommandText = "INSERT INTO [dbo].[Account]([Account], [Is_Active], [Created_At]) VALUES (@Acc, @IsActive, @Created_At)";
                    command.Parameters.AddWithValue("@Acc", curAcc.Acc);
                    command.Parameters.AddWithValue("@IsActive", curAcc.Is_Active);
                    command.Parameters.AddWithValue("@Created_At", curAcc.Created_At);
                    var res = command.ExecuteNonQuery();
                    if (res <= 0) throw new Exception("The account was not created !");
                    /* If OK print this ...*/
                    IO.Print($"Account {curAcc.Acc} created successfully !", ConsoleColor.Green);
                } catch (Exception ex) {
                    IO.Print(ex.Message);
                    IO.Print("Account was not created !", ConsoleColor.Red);
                } finally {
                    /* Close the connection in every case */
                    IO.Debug("Connection closed !");
                    cnn.Close();
                }
            } catch (Exception ex) {
                IO.Print(ex.Message, ConsoleColor.Red);
            }
        }
        static void ShowAccounts() {

        }
        static void Transfer(string from, string to, decimal amount) {

        }

        static void Main() {
            /* Initializing SQL Connection */
            IO.Print("Starting SQL connection ...", ConsoleColor.Yellow);
            var builder = new SqlConnectionStringBuilder();

            /* Change these to your needs */
            builder.DataSource = "localhost";
            builder.UserID = "sa";
            builder.Password = "qwerty112!";
            builder.InitialCatalog = "DZ";

            var cnn = new SqlConnection(builder.ToString());

            /* Testing system */
            bool running = true;
            while (running) {
                IO.Print("Pess any key ...", ConsoleColor.Cyan, false);
                Console.ReadLine();
                Console.Clear();

                /* Get user choice */
                IO.Print("1. Create Account\t 2. Show Accounts\t 3. Transfer");
                var cmd = IO.GetString("->: ");

                switch (cmd) {
                    case "1":
                        CreateAccount(ref cnn);
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        IO.Print("Invalid command !", ConsoleColor.Red);
                        running = false;
                        break;
                }
            }
        }
    }
}
