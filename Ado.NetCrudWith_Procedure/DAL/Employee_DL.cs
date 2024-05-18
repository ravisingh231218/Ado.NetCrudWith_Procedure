using Ado.NetCrudWith_Procedure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace Ado.NetCrudWith_Procedure.DAL
{
    public class Employee_DL
    {
        private readonly string _connectionString;

        public Employee_DL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void InsertEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("InsertEmployee", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@JoinDate", employee.JoinDate);
                command.Parameters.AddWithValue("@City", employee.City);
                command.Parameters.AddWithValue("@Country", employee.Country);
                command.Parameters.AddWithValue("@State", employee.State);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("UpdateEmployee", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@JoinDate", employee.JoinDate);
                command.Parameters.AddWithValue("@City", employee.City);
                command.Parameters.AddWithValue("@Country", employee.Country);
                command.Parameters.AddWithValue("@State", employee.State);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int employeeID)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("DeleteEmployee", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT * FROM Employee", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new Employee
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Department = reader["Department"].ToString(),
                            Salary = Convert.ToDecimal(reader["Salary"]),
                            JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                            City = reader["City"].ToString(),
                            Country = reader["Country"].ToString(),
                            State = reader["State"].ToString()
                        };
                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }
        public Employee GetEmployeeById(int employeeID)
        {
            Employee employee = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Employee WHERE EmployeeID = @EmployeeID", connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Department = reader["Department"].ToString(),
                            Salary = Convert.ToDecimal(reader["Salary"]),
                            JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                            City = reader["City"].ToString(),
                            Country = reader["Country"].ToString(),
                            State = reader["State"].ToString()
                        };
                    }
                }
            }

            return employee;
        }
    }
}
using Ado.NetCrudWith_Procedure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace Ado.NetCrudWith_Procedure.DAL
{
    public class Employee_DL
    {
        private readonly string _connectionString;

        public Employee_DL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void InsertEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("INSERT INTO Employee (FirstName, LastName, Department, Salary, JoinDate, City, Country, State) VALUES (@FirstName, @LastName, @Department, @Salary, @JoinDate, @City, @Country, @State)", connection))
            {
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@JoinDate", employee.JoinDate);
                command.Parameters.AddWithValue("@City", employee.City);
                command.Parameters.AddWithValue("@Country", employee.Country);
                command.Parameters.AddWithValue("@State", employee.State);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, Department = @Department, Salary = @Salary, JoinDate = @JoinDate, City = @City, Country = @Country, State = @State WHERE EmployeeID = @EmployeeID", connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@JoinDate", employee.JoinDate);
                command.Parameters.AddWithValue("@City", employee.City);
                command.Parameters.AddWithValue("@Country", employee.Country);
                command.Parameters.AddWithValue("@State", employee.State);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int employeeID)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("DELETE FROM Employee WHERE EmployeeID = @EmployeeID", connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT * FROM Employee", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new Employee
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Department = reader["Department"].ToString(),
                            Salary = Convert.ToDecimal(reader["Salary"]),
                            JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                            City = reader["City"].ToString(),
                            Country = reader["Country"].ToString(),
                            State = reader["State"].ToString()
                        };
                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        public Employee GetEmployeeById(int employeeID)
        {
            Employee employee = null;

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT * FROM Employee WHERE EmployeeID = @EmployeeID", connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    employee = new Employee
                    {
                        EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Department = reader["Department"].ToString(),
                        Salary = Convert.ToDecimal(reader["Salary"]),
                        JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                        City = reader["City"].ToString(),
                        Country = reader["Country"].ToString(),
                        State = reader["State"].ToString()
                    };
                }
            }

            return employee;
        }
    }
}

