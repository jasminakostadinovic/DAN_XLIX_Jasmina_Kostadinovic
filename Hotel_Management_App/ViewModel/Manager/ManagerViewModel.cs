using Hotel_Management_App.Model;
using Hotel_Management_App.View.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_App.ViewModel.Manager
{
    class ManagerViewModel : ViewModelBase
    {
        #region Fields
        private readonly ManagerView managerView;
        private readonly DataAccess db = new DataAccess();
        #endregion
        #region Constructors
        public ManagerViewModel(ManagerView managerView, tblManager manager)
        {
            this.managerView = managerView;
        }
        #endregion
    }
}
