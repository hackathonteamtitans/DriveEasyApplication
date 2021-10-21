namespace DriveEasyApplication.Web.Mvc.Services
{
    using Microsoft.Data.Sqlite;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;

    /// <summary>
    /// This class will be used during the SQLite Db connection and DB creation with the required the test data.
    /// </summary>
    public class Sqlite
    {
        private SqliteConnection connection;

        protected string DbName;
        public Sqlite(string dbName)
        {
            DbName = dbName;
            string dbPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + $"\\resources\\Database\\{dbName}.sqlite";
            if (!File.Exists(dbPath))
            {
                throw new FileNotFoundException($"Unable to find  : -> {dbPath}");
            }
            connection = new SqliteConnection($"Data Source={dbPath}");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns">you can pass values like "Col1 VARCHAR(20)", "Col2 INT" for columns</param>
        public static int CreateTable(string dbName, string tableName, params string[] columns)
        {
            string combinedColumn = string.Empty;
            foreach (string column in columns)
            {
                combinedColumn = combinedColumn + column + ',';
            }

            if (combinedColumn != string.Empty)
            {
                combinedColumn = combinedColumn.TrimEnd(',');
            }

            return ExecuteNonQuerry(dbName, $"CREATE TABLE {tableName} ({combinedColumn})");
        }

        public static int ExecuteNonQuerry(string dbName, string query)
        {
            string dbPath = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.Parent.FullName + $"\\resources\\Database\\{dbName}.sqlite";
            if (!File.Exists(dbPath))
            {
                throw new FileNotFoundException($"Unable to find  : -> {dbPath}");
            }

            var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.Open();
            SqliteCommand sqlite_cmd = connection.CreateCommand();
            sqlite_cmd.CommandText = query;
            int result = sqlite_cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        public static long ExecuteScalar(string dbName, string query)
        {
            string dbPath = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.Parent.FullName + $"\\resources\\Database\\{dbName}.sqlite";
            if (!File.Exists(dbPath))
            {
                throw new FileNotFoundException($"Unable to find  : -> {dbPath}");
            }

            var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.Open();
            SqliteCommand sqlite_cmd = connection.CreateCommand();
            sqlite_cmd.CommandText = query;
            connection.Open();
            object obj = sqlite_cmd.ExecuteScalar();
            long id = (long)obj;
            connection.Close();
            return id;
        }

        public static long InsertData(string dbName, string tableName, Dictionary<string, object> columNamesValues)
        {
            string query = string.Empty;
            string columns = string.Empty;
            string values = string.Empty;

            foreach (KeyValuePair<string, object> columnNameValue in columNamesValues)
            {
                columns += $"{ columnNameValue.Key},";
                if (tableName == "Candidate" && columnNameValue.Key.Contains("FK_"))
                {
                    values += $"{ columnNameValue.Value},";
                }
                else
                    values += $"'{ columnNameValue.Value}',";
            }


            return ExecuteScalar(dbName, $"INSERT INTO {tableName} ({columns.TrimEnd(',')}) VALUES({values.TrimEnd(',')}); SELECT last_insert_rowid();");
        }

        public DataTable ReadTable(string tableName)
        {
            return ExecuteQuerry($"SELECT * FROM {tableName}");
        }

        public DataTable ExecuteQuerry(string query)
        {
            SqliteDataReader sqlite_datareader;
            SqliteCommand sqlite_cmd = connection.CreateCommand();

            sqlite_cmd.CommandText = query;
            connection.Open();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlite_datareader);
            connection.Close();
            return dataTable;
        }

        public static void CreateDbFile(string dbName)
        {
            string dBFilePath = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.Parent.FullName + $"\\resources\\Database\\{dbName}.sqlite";
            try
            {
                if (!File.Exists(dBFilePath))
                {
                    File.Create(dBFilePath);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception occured while Creating Database file: " + e.StackTrace);
            }
        }
    }
}