using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetSample
{
    internal class Program
    {
        private static readonly string _connectionString = "Server=localhost;Database=AdoNetSample;User Id=sa;Password=bitspa.1;TrustServerCertificate=true";

        static void Main(string[] args)
        {
            try
            {
                //RetrievePersons(_connectionString);
                //UpdatePerson(_connectionString, 1);

                //Console.WriteLine("[1] Insert a record");
                //Console.WriteLine("[2] Delete a record");

                //var option = Convert.ToInt32(Console.ReadLine());

                //if (option == 1)
                //{
                //    InsertPerson();
                //}
                //else
                //{
                //    GetPersons();
                //    DeletePerson();
                //}

                //GetPersons();

                Console.WriteLine(RetrievePerson(_connectionString));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void GetPersons()
        {
            var persons = RetrievePersonListSP(_connectionString);

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }

        static void DeletePerson()
        {
            Console.Write("Enter an id: ");
            var id = Convert.ToInt32(Console.ReadLine());
            DeletePerson(id);
        }

        static void InsertPerson()
        {
            Console.WriteLine("Add new person");
            Console.Write("FirsName:");
            var firstName = Console.ReadLine();

            Console.Write("LastName:");
            var lastName = Console.ReadLine();

            Console.Write("BirthDate:");
            var birthDate = Console.ReadLine();

            Console.Write("Description:");
            var description = Console.ReadLine();

            var p = new Person()
            {
                FirstName = firstName!,
                LastName = lastName!,
                BirthDate = Convert.ToDateTime(birthDate),
                Description = description
            };

            AddPerson(p);
        }

        static void UpdatePerson(string connectionString, int id)
        {
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                var query = "UPDATE Persons SET [BirthDate]=@newDate WHERE id=@id";
                SqlCommand cmd = new(query, connection);
                cmd.Parameters.Add(DbHelpers.CreateParameter("@id", id, DbType.Int32));
                cmd.Parameters.Add(DbHelpers.CreateParameter("@newDate", new DateTime(1980, 12, 12), DbType.DateTime2));
                var rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Updated successfully executed! Rows affected: {rowsAffected}");
            }
        }

        static void RetrievePersons(string connectionString)
        {
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                var query = "SELECT [Id],[FirstName],[LastName],[BirthDate] FROM [Persons] WHERE id=@id";
                SqlCommand cmd = new(query, connection);
                //SqlCommand command = connection.CreateCommand();
                //command.CommandText = query;
                cmd.Parameters.Add(DbHelpers.CreateParameter("@id", 1, DbType.Int32));

                //var param = new SqlParameter("@id", 1);
                //param.DbType = DbType.Int32;
                //command.Parameters.Add(param);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //for (int i = 0; i < dr.FieldCount; i++)
                        //{
                        //    Console.Write(dr[i] + "-");
                        //}

                        //Console.WriteLine();
                        Console.WriteLine($"{dr.GetString("FirstName")}-{dr.GetString("LastName")}-{dr.GetInt32("Id")}");
                        //Console.WriteLine($"{dr[0]}-{dr[1]}-{dr[2]}");
                    }
                }
            }
        }

        static Person? RetrievePerson(string connectionString)
        {
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                var query = "SELECT [Id],[FirstName],[LastName],[BirthDate] FROM [Persons] WHERE id=@id";
                SqlCommand cmd = new(query, connection);
                cmd.Parameters.Add(DbHelpers.CreateParameter("@id", 1, DbType.Int32));

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Person()
                        {
                            Id = dr.GetInt32("Id"),
                            FirstName = dr.GetString("FirstName"),
                            LastName = dr.GetString("LastName"),
                            BirthDate = dr.GetDateTime("BirthDate")
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        static List<Person> RetrievePersonList(string connectionString)
        {
            var persons = new List<Person>();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                var query = "SELECT [Id],[FirstName],[LastName],[BirthDate],[Custom Description] AS Description FROM [Persons]";
                SqlCommand cmd = new(query, connection);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var person = new Person()
                        {
                            Id = dr.GetInt32(nameof(Person.Id)),
                            FirstName = dr.GetString("FirstName"),
                            LastName = dr.GetString("LastName"),
                            BirthDate = dr.GetDateTime("BirthDate"),
                            Description = dr.GetString("Description")
                        };

                        persons.Add(person);
                    }
                }
            }

            return persons;
        }

        static List<Person> RetrievePersonListSP(string connectionString)
        {
            var persons = new List<Person>();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                var sp = "sp_GetPersons";
                SqlCommand cmd = new(sp, connection) { CommandType = CommandType.StoredProcedure };

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var person = new Person()
                        {
                            Id = dr.GetInt32(nameof(Person.Id)),
                            FirstName = dr.GetString("FirstName"),
                            LastName = dr.GetString("LastName"),
                            BirthDate = dr.GetDateTime("BirthDate"),
                            Description = dr.GetString("Description")
                        };

                        persons.Add(person);
                    }
                }
            }

            return persons;
        }

        static void AddPerson(Person person)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            var query = "INSERT INTO Persons(FirstName, LastName, BirthDate, [Custom Description]) VALUES(@firstName, @lastName, @birthDate, @description)";
            SqlCommand cmd = new(query, connection);
            cmd.Parameters.AddRange([
                DbHelpers.CreateParameter("@firstName", person.FirstName, DbType.String),
                DbHelpers.CreateParameter("@lastName", person.LastName, DbType.String),
                DbHelpers.CreateParameter("@birthDate", person.BirthDate, DbType.DateTime2),
                DbHelpers.CreateParameter("@description", person.Description, DbType.String)
            ]);
            cmd.ExecuteNonQuery();
        }

        static void DeletePerson(int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            var query = "DELETE FROM Persons WHERE Id=@id";
            SqlCommand cmd = new(query, connection);
            cmd.Parameters.Add(DbHelpers.CreateParameter("@id", id, DbType.Int32));
            cmd.ExecuteNonQuery();
        }
    }
}
