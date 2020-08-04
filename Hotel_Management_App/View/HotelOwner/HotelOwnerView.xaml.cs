using Hotel_Management_App.ViewModel.HotelOwner;
using System.Windows;

namespace Hotel_Management_App.View.HotelOwner
{
    /// <summary>
    /// Interaction logic for HotelOwnerView.xaml
    /// </summary>
    public partial class HotelOwnerView : Window
    {
        public HotelOwnerView()
        {
            InitializeComponent();
            this.DataContext = new HotelOwnerViewModel(this);
        }
    }
}
