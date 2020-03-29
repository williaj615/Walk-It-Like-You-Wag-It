using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using WalkItLikeYouWagItConsole.Models;

namespace WalkItLikeYouWagItConsole.Data
{
    class DogRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=WalkItLikeYouWagIt; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Dog> GetAllDogs()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT d.Id, d.DName, d.OwnerId, d.Breed, d.Notes, o.Id, o.OName
                        FROM Dog d
                        LEFT JOIN Owner o
                        ON d.OwnerId = o.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Dog> allDogs = new List<Dog>();

                    while (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int dogNameColumn = reader.GetOrdinal("DName");
                        string dogNameValue = reader.GetString(dogNameColumn);

                        int dogOwnerIdColumn = reader.GetOrdinal("OwnerId");
                        int dogOwnerIdValue = reader.GetInt32(dogOwnerIdColumn);

                        int dogBreedColumn = reader.GetOrdinal("Breed");
                        string dogBreedValue = reader.GetString(dogBreedColumn);

                        int dogNotesColumn = reader.GetOrdinal("Notes");
                        string dogNotesValue = reader.GetString(dogNotesColumn);

                        int dogOwnerNameColumn = reader.GetOrdinal("OName");
                        string dogOwnerNameValue = reader.GetString(dogOwnerNameColumn);

                        var dog = new Dog()
                        {
                            Id = idValue,
                            Name = dogNameValue,
                            OwnerId = dogOwnerIdValue,
                            Breed = dogBreedValue,
                            Notes = dogNotesValue,
                            Owner = new Owner()
                            {
                                Id = dogOwnerIdValue,
                                Name = dogOwnerNameValue,

                            }
                        };

                        allDogs.Add(dog);
                    }

                    reader.Close();

                    return allDogs;
                }
            }
        }
    }
}
