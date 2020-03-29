using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using WalkItLikeYouWagItConsole.Models;

namespace WalkItLikeYouWagItConsole.Data
{
    class WalkerRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=WalkItLikeYouWagIt; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Walker> GetAllWalkers()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT w.Id, w.WName, w.NeighborhoodId, n.Id, n.NName
                        FROM Walker w
                        LEFT JOIN Neighborhood n 
                        ON w.NeighborhoodId = n.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Walker> allWalkers = new List<Walker>();

                    while (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int walkerNameColumn = reader.GetOrdinal("WName");
                        string walkerNameValue = reader.GetString(walkerNameColumn);

                        int walkerNeighborhoodIdColumn = reader.GetOrdinal("NeighborhoodId");
                        int walkerNeighborhoodIdValue = reader.GetInt32(walkerNeighborhoodIdColumn);

                        int walkerNieghborhoodColumn = reader.GetOrdinal("NName");
                        string walkerNieghborhoodValue = reader.GetString(walkerNieghborhoodColumn);

                        var walker = new Walker()
                        {
                            Id = idValue,
                            Name = walkerNameValue,
                            NeighborhoodId = walkerNeighborhoodIdValue,
                            Neighborhood = new Neighborhood()
                            {
                                Id = walkerNeighborhoodIdValue,
                                Name = walkerNieghborhoodValue
                            }
                        };

                        allWalkers.Add(walker);
                    }

                    reader.Close();

                    return allWalkers;
                }
            }
        }

        public List<Walker> GetWalkerByNeighborhood(string neighborhoodName)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT w.Id, w.WName, w.NeighborhoodId, n.Id, n.NName
                        FROM Walker w
                        LEFT JOIN Neighborhood n 
                        ON w.NeighborhoodId = n.Id
                        WHERE n.NName = @neighname";

                    cmd.Parameters.Add(new SqlParameter("@neighname", neighborhoodName));

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Walker> neighborhoodWalkers = new List<Walker>();

                    while (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int walkerNameColumn = reader.GetOrdinal("WName");
                        string walkerNameValue = reader.GetString(walkerNameColumn);

                        int walkerNeighborhoodIdColumn = reader.GetOrdinal("NeighborhoodId");
                        int walkerNeighborhoodIdValue = reader.GetInt32(walkerNeighborhoodIdColumn);

                        int walkerNieghborhoodColumn = reader.GetOrdinal("NName");
                        string walkerNieghborhoodValue = reader.GetString(walkerNieghborhoodColumn);

                        var walker = new Walker()
                        {
                            Id = idValue,
                            Name = walkerNameValue,
                            NeighborhoodId = walkerNeighborhoodIdValue,
                            Neighborhood = new Neighborhood()
                            {
                                Id = walkerNeighborhoodIdValue,
                                Name = walkerNieghborhoodValue
                            }
                        };

                        neighborhoodWalkers.Add(walker);
                    }

                    reader.Close();

                    return neighborhoodWalkers;
                }
            }
        }

        public Walker CreateNewWalker(Walker walkerToAdd)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Walker (WName, NeighborhoodId)
                    OUTPUT INSERTED.Id
                    VALUES (@WName, @NeighborhoodId)";

                    cmd.Parameters.Add(new SqlParameter("@WName", walkerToAdd.Name));
                    cmd.Parameters.Add(new SqlParameter("@NeighborhoodId", walkerToAdd.NeighborhoodId));

                    int id = (int)cmd.ExecuteScalar();

                    walkerToAdd.Id = id;

                    return walkerToAdd;
                }
            }
        }

        public void UpdateWalker(int walkerId, Walker walker)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    UPDATE Walker
                    SET WName = @WName, NeighborhoodId = @NeighborhoodId
                    WHERE Id = @Id";

                    cmd.Parameters.Add(new SqlParameter("@WName", walker.Name));
                    cmd.Parameters.Add(new SqlParameter("@NeighborhoodId", walker.NeighborhoodId));
                    cmd.Parameters.Add(new SqlParameter("@Id", walkerId));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
