using DataBaseAccess;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CourseWork.ViewModels
{
    public class DataViewModel : ViewModelBase
    {
        BDLabsDbContext dbContext;

        public ObservableCollection<Employee> Employees
        {
            get => GetValue<ObservableCollection<Employee>>();
            private set => SetValue(value);
        }

        public ObservableCollection<Client> Clients
        {
            get => GetValue<ObservableCollection<Client>>();
            private set => SetValue(value);
        }

        public ObservableCollection<Book> Books
        {
            get => GetValue<ObservableCollection<Book>>();
            private set => SetValue(value);
        }

        public ObservableCollection<Order> Orders
        {
            get => GetValue<ObservableCollection<Order>>();
            private set => SetValue(value);
        }


        public DataViewModel()
        {
            dbContext = new();

            dbContext.Employees.Load();
            dbContext.Clients.Load();
            dbContext.Books.Load();
            dbContext.Orders
            .Include(x => x.OrderedBooks)
            .Include(x => x.Emploee)
            .Include(x => x.Client)
            .Load();

            Employees = dbContext.Employees.Local.ToObservableCollection();
            Clients = dbContext.Clients.Local.ToObservableCollection();
            Books = dbContext.Books.Local.ToObservableCollection();
            Orders = dbContext.Orders.Local.ToObservableCollection();
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
            var item = (Client)args.Items.Single();
            dbContext.Clients.Remove(item);
            dbContext.SaveChanges();
        }


        [Command]
        public void ValidateClientRow(RowValidationArgs args)
        {
            var item = (Client)args.Item;
            args.Result = GetClientValidationErrorInfo(item);
            if (args.Result == null)
            {
                if (args.IsNewItem)
                    dbContext.Clients.Add(item);
                dbContext.SaveChanges();
            }
        }

        private static ValidationErrorInfo GetClientValidationErrorInfo(Client client)
        {
            if (string.IsNullOrEmpty(client.Name))
                return new ValidationErrorInfo("Please fill Name");
            if (string.IsNullOrEmpty(client.Surname))
                return new ValidationErrorInfo("Please fill Name");
            if (string.IsNullOrEmpty(client.PhoneNumber))
                return new ValidationErrorInfo("Please fill Phone Number");
            if (client.BirthDate > DateTime.Now)
                return new ValidationErrorInfo("Invalid Birth Date");
            return null;
        }

        [Command]
        public void ValidateClientRowDeletion(ValidateRowDeletionArgs args)
        {
            var item = (Client)args.Items.Single();
            dbContext.Clients.Remove(item);
            dbContext.SaveChanges();
        }


        [Command]
        public void ValidateBookRow(RowValidationArgs args)
        {
            var item = (Book)args.Item;
            args.Result = GetBookValidationErrorInfo(item);
            if (args.Result == null)
            {
                if (args.IsNewItem)
                    dbContext.Books.Add(item);
                dbContext.SaveChanges();
            }
        }

        private static ValidationErrorInfo GetBookValidationErrorInfo(Book book)
        {
            if (string.IsNullOrEmpty(book.Name))
                return new ValidationErrorInfo("Please fill Name");
            if (string.IsNullOrEmpty(book.Author))
                return new ValidationErrorInfo("Please fill Name");
            if (book.StockCount <= 0)
                return new ValidationErrorInfo("Invalid Stock Count");
            return null;
        }

        [Command]
        public void ValidateBookRowDeletion(ValidateRowDeletionArgs args)
        {
            var item = (Book)args.Items.Single();
            dbContext.Books.Remove(item);
            dbContext.SaveChanges();
        }


        [Command]
        public void ValidateOrderRow(RowValidationArgs args)
        {

            var item = (Order)args.Item;
            args.Result = GetOrderValidationErrorInfo(item, args);
            if (args.Result == null)
            {
                if (args.IsNewItem)
                    dbContext.Orders.Add(item);
                dbContext.SaveChanges();
            }
        }

        private static ValidationErrorInfo GetOrderValidationErrorInfo(Order order, RowValidationArgs args)
        {
            if (order.OrderStatus != OrderStatus.Draft && args.IsNewItem)
                return new ValidationErrorInfo("Please fill Name");
            //if (string.IsNullOrEmpty(order))
            //    return new ValidationErrorInfo("Please fill Name");
            //if (Order.StockCount <= 0)
            //    return new ValidationErrorInfo("Invalid Stock Count");
            return null;
        }

        [Command]
        public void ValidateOrderRowDeletion(ValidateRowDeletionArgs args)
        {
            var item = (Order)args.Items.Single();
            dbContext.Orders.Remove(item);
            dbContext.SaveChanges();
        }
    }
}
