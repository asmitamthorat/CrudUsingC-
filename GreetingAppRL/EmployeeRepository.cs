using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace GreetingAppRL
{
    public class EmployeeRepository: IEmployeeRepository
    {
         private IConfiguration _configuration;
         private string _connectionString;
         private SqlConnection _conn;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("GreetingAppDB");
            _conn = new SqlConnection(_connectionString);
            Console.WriteLine(_connectionString);
        }

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            using (_conn)
            {
                _conn.Open();
                SqlCommand command = new SqlCommand("Select id, name ,address , email, password, phoneno from EmployeeTable", _conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new EmployeeModel
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Name = reader.GetString(1),
                            Email = reader.GetString(3),
                            Password = reader.GetString(4),
                            Address = reader.GetString(2),
                            PhoneNumber = reader.GetInt32(5),
                        });
                    }
                }
                _conn.Close();
            }
            return employees;
        }

        public EmployeeModel GetEmployee(int id)
        {
            EmployeeModel employee = null;
            using (_conn) {
                _conn.Open();
                SqlCommand command = new SqlCommand("Select id,name,address,email,password,phoneno from EmployeeTable where id=@id", _conn);
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        employee = new EmployeeModel
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Name = reader.GetString(1),
                            Email = reader.GetString(3),
                            Password = reader.GetString(4),
                            Address = reader.GetString(2),
                            PhoneNumber = reader.GetInt32(5)
                        };
                    }
                }
                _conn.Close();
            }
            return employee;
        }

        public EmployeeModel AddEmployee(EmployeeModel employeeData)
        {
            SqlCommand command = new SqlCommand("insert into EmployeeTable(name,password,address,email,phoneno) values(@name,@password,@address,@email,@phoneno)");
            command.Parameters.AddWithValue("@name", employeeData.Name);
            command.Parameters.AddWithValue("@password", employeeData.Password);
            command.Parameters.AddWithValue("@address", employeeData.Address);
            command.Parameters.AddWithValue("@email", employeeData.Email);
            command.Parameters.AddWithValue("@phoneno", employeeData.PhoneNumber);
            _conn.Open();
            command.Connection = _conn;
            command.ExecuteNonQuery();
            _conn.Close();
            return employeeData;
        }

        public int RemoveEmployee(int id)
        {
            _conn.Open();
            SqlCommand command = new SqlCommand("Delete from EmployeeTable where id=@id", _conn);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            _conn.Close();
            return id;
        }

        public EmployeeModel UpdateEmployee(int id, EmployeeModel employee)
        {
                SqlCommand command = new SqlCommand("update EmployeeTable set name=@name, address=@address, phoneno=@phoneno where id = @id");
                command.Parameters.AddWithValue("@name", employee.Name);
                command.Parameters.AddWithValue("@address", employee.Address);
                command.Parameters.AddWithValue("@phoneno", employee.PhoneNumber);
                command.Parameters.AddWithValue("@id", id);
                _conn.Open();
                command.Connection = _conn;
                command.ExecuteNonQuery();
                _conn.Close();
                return employee;
        }
    }
}
