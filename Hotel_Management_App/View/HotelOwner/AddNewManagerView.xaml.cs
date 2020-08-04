using Hotel_Management_App.ViewModel.HotelOwner;
using System.Windows;

namespace Hotel_Management_App.View.HotelOwner
{
    /// <summary>
    /// Interaction logic for AddNewManagerView.xaml
    /// </summary>
    public partial class AddNewManagerView : Window
    {
        public AddNewManagerView()
        {
            InitializeComponent();
            this.DataContext = new AddNewManagerViewModel(this);
        }
    }
}
