using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Lab6.Data.DB
{
    class UserSourceModel : IUserSourceModel
    {

        public List<UserDataModel> GetUsers()
        {
            var connection = DatabaseConnection.GetConnection();

            var query = "SELECT * FROM Users";
            var command = new SqlCommand(query, connection);

            connection.Open();

            var result = command.ExecuteReader();

            List<UserDataModel> users = new List<UserDataModel>();
            while (result.Read())
            {
                var user = new UserDataModel
                {
                    Id = result.GetInt32(0),
                    Name = result.GetString(1),
                    Surname = result.GetString(2),
                    Email = result.GetString(3),
                    Type = result.GetString(4)
                };
                users.Add(user);
            }

            connection.Close();

            return users;
        }

        public int AddUser(UserDataModel user)
        {
            var connection = DatabaseConnection.GetConnection();

            var query = $"INSERT INTO Users (name, surname, email, type) VALUES (@name, @surname, @email, @type) SELECT SCOPE_IDENTITY()";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("name", user.Name);
            command.Parameters.AddWithValue("surname", user.Surname);
            command.Parameters.AddWithValue("email", user.Email);
            command.Parameters.AddWithValue("type", user.Type);

            connection.Open();
            var result = (decimal) command.ExecuteScalar();
            connection.Close();

            return Convert.ToInt32(result);
        }

        public void DeleteUser(int id)
        {
            var connection = DatabaseConnection.GetConnection();

            var query = $"DELETE FROM Users WHERE id = {id}";
            var command = new SqlCommand(query, connection);

            ConnectionExecute(command);
        }

        public void EditUser(UserDataModel user)
        {
            var connection = DatabaseConnection.GetConnection();

            var query = $"UPDATE Users SET name = @name, surname = @surname, email = @email, type = @type WHERE id = {user.Id}";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("name", user.Name);
            command.Parameters.AddWithValue("surname", user.Surname);
            command.Parameters.AddWithValue("email", user.Email);
            command.Parameters.AddWithValue("type", user.Type);

            ConnectionExecute(command);
        }

        private void ConnectionExecute(SqlCommand command)
        {
            var connection = command.Connection;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
