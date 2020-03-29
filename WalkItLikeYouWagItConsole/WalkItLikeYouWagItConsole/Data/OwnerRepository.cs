using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using WalkItLikeYouWagItConsole.Models;

namespace WalkItLikeYouWagItConsole.Data
{
    class OwnerRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=WalkItLikeYouWagIt; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Owner> GetAllOwners()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT o.Id, o.OName, o.Address, o.NeighborhoodId, o.Phone, n.Id, n.NName
                        FROM Owner o
                        LEFT JOIN Neighborhood n
                        ON o.NeighborhoodId = n.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Owner> allOwners = new List<Owner>();

                    while (reader.Read())
                    {
                        int idColumn = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumn);

                        int ownerNameColumn = reader.GetOrdinal("OName");
                        string ownerNamerValue = reader.GetString(ownerNameColumn);

                        int ownerAddressColumn = reader.GetOrdinal("Address");
                        string ownerAddressValue = reader.GetString(ownerAddressColumn);

                        int ownerNeighIdColumn = reader.GetOrdinal("NeighborhoodId");
                        int ownerNeighIdValue = reader.GetInt32(ownerNeighIdColumn);

                        int ownerPhoneColumn = reader.GetOrdinal("Phone");
                        string ownerPhoneValue = reader.GetString(ownerPhoneColumn);

                        int ownerNeighborhoodColumn = reader.GetOrdinal("NName");
                        string ownerNeighborhoodValue = reader.GetString(ownerNeighborhoodColumn);

                        var owner = new Owner()
                        {
                            Id = idValue,
                            Name = ownerNamerValue,
                            Address = ownerAddressValue,
                            NeighborhoodId = ownerNeighIdValue,
                            Phone = ownerPhoneValue,
                            Neighborhood = new Neighborhood()
                            {
                                Id = ownerNeighIdValue,
                                Name = ownerNeighborhoodValue
                            }
                        };

                        allOwners.Add(owner);
                    }

                    reader.Close();

                    return allOwners;
                }
            }
        }

        public Owner CreateNewOwner(Owner ownerToAdd)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Owner (OName, NeighborhoodId, Phone, Address)
                    OUTPUT INSERTED.Id
                    VALUES (@OName, @NeighborhoodId, @Phone, @Address)";

                    cmd.Parameters.Add(new SqlParameter("@OName", ownerToAdd.Name));
                    cmd.Parameters.Add(new SqlParameter("@NeighborhoodId", ownerToAdd.NeighborhoodId));
                    cmd.Parameters.Add(new SqlParameter("@Phone", ownerToAdd.Phone));
                    cmd.Parameters.Add(new SqlParameter("@Address", ownerToAdd.Address));

                    int id = (int)cmd.ExecuteScalar();

                    ownerToAdd.Id = id;

                    return ownerToAdd;
                }
            }
        }
    }
}
