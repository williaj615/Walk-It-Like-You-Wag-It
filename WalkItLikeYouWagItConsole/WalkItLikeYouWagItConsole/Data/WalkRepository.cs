using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using WalkItLikeYouWagItConsole.Models;

namespace WalkItLikeYouWagItConsole.Data
{
    class WalkRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=WalkItLikeYouWagIt; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Walk> GetAllWalks()
        {
            // 1. Open a connection to the database
            // 2. Create a SQL SELECT  statement as a C# string
            // 3. Execute that SQL statement against the database
            // 4. From the database, we get "raw data" back. We need to parse this as a C# object
            // 5. Close the connection to the database
            // 6. Return the Walk object

            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT w.Id, w.Date, w.Duration, w.WalkerId, w.DogId, wr.Id, wr.WName, d.Id, d.DName
                        FROM Walk w
                        LEFT JOIN Walker wr
                        ON w.WalkerId = wr.Id
                        LEFT JOIN Dog d
                        ON w.DogId = d.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Walk> allWalks = new List<Walk>();

                    while (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int dateColumn = reader.GetOrdinal("Date");
                        DateTime dateValue = reader.GetDateTime(dateColumn);

                        int durationColumn = reader.GetOrdinal("Duration");
                        int durationValue = reader.GetInt32(durationColumn);

                        int walkerIdColumn = reader.GetOrdinal("WalkerId");
                        int walkerIdValue = reader.GetInt32(walkerIdColumn);

                        int dogIdColumn = reader.GetOrdinal("DogId");
                        int dogIdValue = reader.GetInt32(dogIdColumn);

                        int walkerNameColumn = reader.GetOrdinal("WName");
                        string walkerNameValue = reader.GetString(walkerNameColumn);

                        int dogNameColumn = reader.GetOrdinal("DName");
                        string dogNameValue = reader.GetString(dogNameColumn);

                        var walk = new Walk()
                        {
                            Id = idValue,
                            Date = dateValue,
                            Duration = durationValue,
                            WalkerId = walkerIdValue,
                            DogId = dogIdValue,
                            Dog = new Dog()
                            {
                                Id = dogIdValue,
                                Name = dogNameValue
                            },
                            Walker = new Walker()
                            {
                                Id = walkerIdValue,
                                Name = walkerNameValue
                            }
                        };

                        allWalks.Add(walk);
                    }

                    reader.Close();

                    return allWalks;
                }
            }
        }
    }
}
