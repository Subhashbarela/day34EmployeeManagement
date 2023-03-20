using EmployeeManagement;
namespace EmployeeManagementTest
    
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSalaryDetails_AbleToUpdateSalaryDetails()
        {
            //Arrange

            Salary salary = new Salary();

            SalaryUpdateModel updateModel = new SalaryUpdateModel()
            {
                SalaryId = 2,
                Month = "Feb",
                EmployeeSalary = 14000,
                EmployeeID = 1
            };

            //Act
            int EmpSalary = salary.UpdateEmployeeSalary(updateModel);

            //Assert;

            Assert.AreEqual(EmpSalary, updateModel.EmployeeSalary);





        }
    }
}