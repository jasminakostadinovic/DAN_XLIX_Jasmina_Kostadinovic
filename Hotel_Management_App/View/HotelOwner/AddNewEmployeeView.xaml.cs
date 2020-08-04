using Hotel_Management_App.ViewModel.HotelOwner;
using System.Windows;

namespace Hotel_Management_App.View.HotelOwner
{
    /// <summary>
    /// Interaction logic for AddNewEmployeeView.xaml
    /// </summary>
    public partial class AddNewEmployeeView : Window
    {
        public AddNewEmployeeView()
        {
            InitializeComponent();
            this.DataContext = new AddNewEmployeeViewModel(this);
        }
    }
}
