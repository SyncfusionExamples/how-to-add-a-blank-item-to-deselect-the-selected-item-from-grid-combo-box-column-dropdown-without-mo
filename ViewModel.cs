using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGrid_MVVM
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.Employees = this.GetEmployees();
            this.Countries = new ObservableCollection<string>();
            this.Countries.Add("India");
            this.Countries.Add("UK");
            this.Countries.Add("US");
            this.Countries.Add("Germany");
            this.Countries.Add("Australia");
        }

        public ObservableCollection<string> Countries { get; set; }

        private ObservableCollection<EmployeeInfo> _employees;

        public ObservableCollection<EmployeeInfo> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        private ObservableCollection<EmployeeInfo> GetEmployees()
        {
            ObservableCollection<EmployeeInfo> employeeDetails = new ObservableCollection<EmployeeInfo>();
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ferando", LastName = "Joseph", Title = "Management", Salary = 0, Country = "Australia", ID = 2 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "John", LastName = "Adams", Title = "Accounts", Salary = 10000, Country = "US", ID = 3 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Thomas", LastName = "Jefferson", Title = "Sales", Salary = 300000, Country = "UK", ID = 4 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "Madison", Title = "Marketing", Salary = 0, Country = "Germany", ID = 5 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ulysses", LastName = "Pierce", Title = "HumanResource", Salary = 20000, Country = "India", ID = 6 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Jimmy", LastName = "Harrison", Title = "Purchasing", Salary = 40000, Country = "Germany", ID = 7 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ronald", LastName = "Fillmore", Title = "Production", Salary = 25000, Country = "UK", ID = 8 });
           
            return employeeDetails;
        }
    }
}
