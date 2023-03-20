using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection salaryConnection = ConnectionSetup();
            int salary = 0;

            try
            {
                using(salaryConnection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SqlCommand command = new SqlCommand("spUpdateemployeeSalary", salaryConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", salaryUpdateModel.SalaryId);
                    command.Parameters.AddWithValue("@month", salaryUpdateModel.Month);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@empId", salaryUpdateModel.EmployeeID);

                    salaryConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            displayModel.EmployeeId = dr.GetInt32(0);
                            displayModel.EmployeeName = dr.GetString(1);
                            displayModel.JobDescription = dr.GetString(2);
                            displayModel.EmployeeSalary = dr.GetInt32(3);
                            displayModel.Month = dr.GetString(4);
                            displayModel.SalaryId = dr.GetInt32(5);

                            Console.WriteLine("{0} {1}",displayModel.EmployeeId, displayModel.EmployeeName);
                            salary = displayModel.EmployeeSalary;

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found!");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { salaryConnection.Close(); }
            return salary;
        }
    }
}
