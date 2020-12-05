using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GreetingAppRL
{
    public class RegistrationRepository:IRegistrationRepository
    {
        private IConfiguration _configuration;
        private string _connectionString;
        private SqlConnection _conn;
        
        public RegistrationRepository(IConfiguration configuration)
        {

            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("GreetingAppDB");
            _conn = new SqlConnection(_connectionString);
            Console.WriteLine(_connectionString);
        }
        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public RegistrationModel addUser(RegistrationModel registrationModel)
        {
            SqlCommand command = new SqlCommand("insert into registrationTable(firstName,lastName,email,password) values(@firstName,@lastName,@email,@password)");
            command.Parameters.AddWithValue("@firstName", registrationModel.firstName);
            command.Parameters.AddWithValue("@lastName", registrationModel.lastName);
            command.Parameters.AddWithValue("@email", registrationModel.email);
            command.Parameters.AddWithValue("@password", EncodePasswordToBase64(registrationModel.password));
            _conn.Open();
            command.Connection = _conn;
            command.ExecuteNonQuery();
            _conn.Close();
            return registrationModel;
        }

        public List<RegistrationModel> getUsers()
        {
            List<RegistrationModel> list = new List<RegistrationModel>();
            using (_conn)
            {
                _conn.Open();
                SqlCommand command = new SqlCommand("Select id, firstName ,lastName , email, password from registrationTable", _conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RegistrationModel
                        {
                            id = Convert.ToInt32(reader["id"]),
                            firstName = reader.GetString(1),
                            lastName = reader.GetString(2),
                            email = reader.GetString(3),
                            password = reader.GetString(4),
                            
                        });
                    }
                }
                _conn.Close();
            }
            return list;
        }

        public RegistrationModel checkLoginUser(RegistrationModel registrationModel)
        {
            RegistrationModel registrationModel1;
            _conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM  registrationTable WHERE email=@email AND password=@password", _conn);
            command.Parameters.AddWithValue("@email", registrationModel.email);
            command.Parameters.AddWithValue("@password", EncodePasswordToBase64(registrationModel.password));
            command.Connection = _conn;
            var count = command.ExecuteScalar(); //and check the returned value
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
            registrationModel1 = new RegistrationModel
                    {
                        id = Convert.ToInt32(reader["id"]),
                       firstName = reader.GetString(1),
                        lastName = reader.GetString(2),
                        email = reader.GetString(3),
                        password = reader.GetString(4),
                    };
                }
            }
            _conn.Close();
            return registrationModel;
        }
    }
}


