using DataBaseAccess;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Utils;
using DevExpress.Mvvm.Xpf;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CourseWork.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        BDLabsDbContext dbContext;

        public ObservableCollection<Employee> Employees
        {
            get => GetValue<ObservableCollection<Employee>>();
            private set => SetValue(value);
        }

        public EmployeeViewModel()
        {
            dbContext = new();


            dbContext.Employees.Load();
            Employees = dbContext.Employees.Local.ToObservableCollection();
        }

        [Command]
        public void ValidateEmployeeRow(RowValidationArgs args)
        {
            var item = (Employee)args.Item;
            args.Result = GetEmployeeValidationErrorInfo(item);
            if (args.Result == null)
            {
                if (args.IsNewItem)
                    dbContext.Employees.Add(item);
                dbContext.SaveChanges();
            }
        }

        private static ValidationErrorInfo GetEmployeeValidationErrorInfo(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
                return new ValidationErrorInfo("Please fill Name");
            if (string.IsNullOrEmpty(employee.Surname))
                return new ValidationErrorInfo("Please fill Name");
            if (string.IsNullOrEmpty(employee.PhoneNumber))
                return new ValidationErrorInfo("Please fill Phone Number");
            if (employee.Salary <= 0)
                return new ValidationErrorInfo("Incorrect Salary");
            if (employee.BirthDate > DateTime.Now)
                return new ValidationErrorInfo("Invalid Birth Date");
            return null;
        }

        [Command]
        public void ValidateEmployeeRowDeletion(ValidateRowDeletionArgs args)
        {
            var item = (Employee)args.Items.Single();
            dbContext.Employees.Remove(item);
            dbContext.SaveChanges();
        }

        [Command]
        public void DataSourceRefresh(DataSourceRefreshArgs args)
        {

        }
    }
}
