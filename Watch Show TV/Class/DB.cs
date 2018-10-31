using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_Show_TV.Class
{
    class DB
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=databaseSeries.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS tv_shows (Primary_Key INTEGER PRIMARY KEY, " +
                    "serie_id INTEGER NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddShowToFavorite(int inputText)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=databaseSeries.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO tv_shows VALUES (NULL, @Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", inputText);

                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        public static void RemoveShowToFavorite(int inputText)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=databaseSeries.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "DELETE FROM tv_shows WHERE serie_id = @Entry;";
                insertCommand.Parameters.AddWithValue("@Entry", inputText);

                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        public static bool isShowFavorite(int theShowId)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=databaseSeries.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT serie_id from tv_shows WHERE serie_id = @Entry;";
                selectCommand.Parameters.AddWithValue("@Entry", theShowId);
                SqliteDataReader query = selectCommand.ExecuteReader();

                if (query.HasRows)
                {
                    db.Close();
                    return true;
                }

                db.Close();
            }

            return false;
        }

        public static List<int> GetShowFavorites()
        {
            List<int> entries = new List<int>();

            using (SqliteConnection db =
                new SqliteConnection("Filename=databaseSeries.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT serie_id from tv_shows", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetInt32(0));
                }

                db.Close();
            }

            return entries;
        }
    }
}
