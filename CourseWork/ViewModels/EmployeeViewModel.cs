using DataBaseAccess;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Utils;
using Model;
using System.Collections.ObjectModel;

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
    }
}
