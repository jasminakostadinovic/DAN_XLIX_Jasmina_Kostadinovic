using Hotel_Management_App.Model;
using Hotel_Management_App.View.HotelOwner;

namespace Hotel_Management_App.ViewModel.HotelOwner
{
    class HotelOwnerViewModel
    {
        #region Fields
        private readonly HotelOwnerView hotelOwnerView;
        private readonly DataAccess db = new DataAccess();
        #endregion
        #region Constructors
        public HotelOwnerViewModel(HotelOwnerView hotelOwnerView)
        {
            this.hotelOwnerView = hotelOwnerView;
        }
        #endregion
    }
}
