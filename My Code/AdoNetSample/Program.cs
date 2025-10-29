using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace AdoNetSample
{
    internal class Program
    {
        string connectionString = "Server=localhost;Database=AdoNetSample;User Id=sa;Password=bitspa.1;TrustServerCertificate=true";
        static void Main(string[] args)
        {
            Program p = new Program();
            Person personToAdd = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 1, 1),
                Description = "A sample person"
            };
            //p.CreatePerson(personToAdd);
            List<Person> people = p.GetAllPeople();
            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Id} - {person.FirstName} - {person.LastName} - {person.BirthDate} - {person.Description}");
            }
        }
        void CreatePerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Person (FirstName, LastName, BirthDate, [Custom Description]) VALUES (@firstName, @lastName, @birthDate, @description)";
                cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                cmd.Parameters.AddWithValue("@lastName", person.LastName);
                cmd.Parameters.AddWithValue("@birthDate", person.BirthDate);
                cmd.Parameters.AddWithValue("@description", person.Description);

                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }
        void ReadPerson(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Person WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["FirstName"]} - {dr["LastName"]} - {dr["BirthDate"]}");
                }
            }
        }
        void UpdatePerson(int id, string firstName, string lastName, DateTime birthDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Person SET FirstName = @firstName, LastName = @lastName, BirthDate = @birthDate WHERE Id = @id";
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@birthDate", birthDate);
                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        void DeletePerson(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM Person WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        List<Person> GetAllPeople()
        {
            List<Person> people = new List<Person>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //var sp = "GetAllPeople"; // Stored Procedure
                SqlCommand cmd = connection.CreateCommand(); // SqlCommand cmd = new(sp, connection) { CommandType = CommandType.StoredProcedure };
                cmd.CommandText = "SELECT Id, FirstName, LastName, BirthDate, [Custom Description] AS Description FROM Person";
                connection.Open();

                using SqlDataReader dr = cmd.ExecuteReader();
                int ordId = dr.GetOrdinal("Id");
                int ordFirst = dr.GetOrdinal("FirstName");
                int ordLast = dr.GetOrdinal("LastName");
                int ordBirth = dr.GetOrdinal("BirthDate");
                int ordDesc = dr.GetOrdinal("Description");

                while (dr.Read())
                {
                    Person p = new Person
                    {
                        Id = dr.GetInt32(ordId),
                        FirstName = dr.GetString(ordFirst),
                        LastName = dr.GetString(ordLast),
                        BirthDate = dr.GetDateTime(ordBirth),
                        // If the DB allows NULLs, avoid casting DBNull to string
                        Description = dr.IsDBNull(ordDesc) ? string.Empty : dr.GetString(ordDesc)
                    };
                    people.Add(p);
                }
            }
            return people;
        }
    }
}
