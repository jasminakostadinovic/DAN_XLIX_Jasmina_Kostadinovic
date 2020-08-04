using Hotel_Management_App.Command;
using Hotel_Management_App.Model;
using Hotel_Management_App.View;
using Hotel_Management_App.View.Employee;
using Hotel_Management_App.View.HotelOwner;
using Hotel_Management_App.View.Manager;
using System.Windows.Controls;
using System.Windows.Input;
using Validations;

namespace Hotel_Management_App.ViewModel
{
	class MainWindowViewModel : ViewModelBase
	{
		#region Fields
		private string userName;
		readonly MainWindow loginView;
		#endregion

		#region Constructor
		internal MainWindowViewModel(MainWindow view)
		{
			this.loginView = view;
		}
		#endregion

		#region Properties
		public string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}
		#endregion

		private ICommand submitCommand;
		public ICommand SubmitCommand
		{
			get
			{
				if (submitCommand == null)
				{
					submitCommand = new RelayCommand(Submit);
					return submitCommand;
				}
				return submitCommand;
			}
		}

		void Submit(object obj)
		{
			string password = (obj as PasswordBox).Password;
			if (UserName == LoginData.HotelOwnerUserName && SecurePasswordHasher.Verify(password, LoginData.HotelOwnerPasswordHashed))
			{
				HotelOwnerView hotelOwnerView = new HotelOwnerView();
				loginView.Close();
				hotelOwnerView.Show();
				return;
			}

			DataAccess dataAccess = new DataAccess();

			if (!dataAccess.IsCorrectUser(userName, password))
			{
				WarningView warning = new WarningView(loginView);
				warning.Show("User name or password are not correct!");
				return;
			}
			var typeOfUser = dataAccess.GetTypeOfUser(UserName);
			if(typeOfUser != null)
			{
				if(typeOfUser == "manager")
				{
					var manager = dataAccess.LoadManagerByUsername(UserName);
					ManagerView managerView = new ManagerView(manager);
					loginView.Close();
					managerView.Show();
					return;
				}
				if (typeOfUser == "employee")
				{
					var employee = dataAccess.LoadEmployeeByUsername(UserName);
					EmployeeView employeeView = new EmployeeView(employee);
					loginView.Close();
					employeeView.Show();
					return;
				}
			}
			
		}
	}
}
