using Hotel_Management_App.Model;
using Hotel_Management_App.ViewModel.Employee;
using System.Windows;

namespace Hotel_Management_App.View.Employee
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        public EmployeeView(tblEmployee employee)
        {
            InitializeComponent();
            this.DataContext = new EmployeeViewModel(this, employee);
        }
    }
}
