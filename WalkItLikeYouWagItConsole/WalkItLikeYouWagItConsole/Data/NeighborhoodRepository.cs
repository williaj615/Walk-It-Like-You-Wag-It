using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using WalkItLikeYouWagItConsole.Models;

namespace WalkItLikeYouWagItConsole.Data
{
    class NeighborhoodRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=WalkItLikeYouWagIt; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Neighborhood> GetAllNeighborhoods()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT n.Id, n.NName
                        FROM Neighborhood n";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Neighborhood> allNeighborhoods = new List<Neighborhood>();

                    while (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int neighNameColumn = reader.GetOrdinal("NName");
                        string neighNameValue = reader.GetString(neighNameColumn);

                        var neighborhood = new Neighborhood()
                        {
                            Id = idValue,
                            Name = neighNameValue
                        };

                        allNeighborhoods.Add(neighborhood);
                    }

                    reader.Close();

                    return allNeighborhoods;
                }
            }
        }
    }
}
