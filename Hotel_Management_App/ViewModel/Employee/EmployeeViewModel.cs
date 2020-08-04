using Hotel_Management_App.Model;
using Hotel_Management_App.View.Employee;

namespace Hotel_Management_App.ViewModel.Employee
{
    class EmployeeViewModel : ViewModelBase
    {
        #region Fields
        private readonly EmployeeView employeeView;
        private readonly DataAccess db = new DataAccess();
        #endregion
        #region Constructors
        public EmployeeViewModel(EmployeeView employeeView, tblEmployee employee)
        {
            this.employeeView = employeeView;
        }
        #endregion
    }
}
