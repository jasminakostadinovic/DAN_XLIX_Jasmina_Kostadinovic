using Hotel_Management_App.Command;
using Hotel_Management_App.Model;
using Hotel_Management_App.View.HotelOwner;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using Validations;

namespace Hotel_Management_App.ViewModel.HotelOwner
{
    class AddNewManagerViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields
        private readonly AddNewManagerView addNewManagerView;
        private tblManager manager;
        private tblUserData userData;

        private string surname;
        private string givenName;
        private string dateOfBirth;
        private string email;
        private string username;
        private string password;

        private string professionalQualificationsLevel;
        private string floorNumber;
        private string workExperience;

        private DateTime dateValue;
        private int workExperienceValue;

        private string[] professionalQualificationsLevels = new string[] { "I", "II", "III", "IV", "V", "VI", "VII" };


        #endregion
        #region Properties
        public bool IsAddedNewManager { get; internal set; }
        public bool CanSave { get; set; }
        public int EmployeeAge { get; private set; }


        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (surname == value) return;
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string GivenName
        {
            get
            {
                return givenName;
            }
            set
            {
                if (givenName == value) return;
                givenName = value;
                OnPropertyChanged(nameof(GivenName));
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password == value) return;
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (username == value) return;
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email == value) return;
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                if (dateOfBirth == value) return;
                dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        //
        public string ProfessionalQualificationsLevel
        {
            get
            {
                return professionalQualificationsLevel;
            }
            set
            {
                if (professionalQualificationsLevel == value) return;
                professionalQualificationsLevel = value;
                OnPropertyChanged(nameof(ProfessionalQualificationsLevel));
            }
        }
        public string FloorNumber
        {
            get
            {
                return floorNumber;
            }
            set
            {
                if (floorNumber == value) return;
                floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        public string WorkExperience
        {
            get
            {
                return workExperience;
            }
            set
            {
                if (workExperience == value) return;
                workExperience = value;
                OnPropertyChanged(nameof(WorkExperience));
            }
        }

      

        public string[] ProfessionalQualificationsLevels
        {
            get
            {
                return professionalQualificationsLevels;
            }
            set
            {
                if (professionalQualificationsLevels == value) return;
                professionalQualificationsLevels = value;
                OnPropertyChanged(nameof(ProfessionalQualificationsLevels));
            }
        }

        #endregion
        #region Constructors
        public AddNewManagerViewModel(AddNewManagerView addNewManagerView)
        {
            this.addNewManagerView = addNewManagerView;

            GivenName = string.Empty;
            Surname = string.Empty;
            DateOfBirth = string.Empty;
            Email = string.Empty;
            Username = string.Empty;
            Password = string.Empty;

            ProfessionalQualificationsLevel = ProfessionalQualificationsLevels[0];
            FloorNumber = string.Empty;
            WorkExperience = string.Empty;

            manager = new tblManager();
            userData = new tblUserData();

            CanSave = true;
        }

        #endregion

        #region IDataErrorInfoImplementation
        //validations

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                CanSave = true;
                var db = new DataAccess();
                string validationMessage = string.Empty;
                var validate = new Validation();
                var culture = CultureInfo.InvariantCulture;
                var styles = DateTimeStyles.None;


                if (name == "Username")
                {
                    if (!db.IsUniqueUsername(Username))
                    {
                        validationMessage = "Username number must be unique!";
                        CanSave = false;
                    }
                }
                else if (name == "Email")
                {
                    if (!validate.IsValidEmail(Email))
                    {
                        validationMessage = "Invalid email format!";
                        CanSave = false;
                    }

                }
                if (name == "DateOfBirth")
                {
                    if (!DateTime.TryParse(DateOfBirth, culture, styles, out dateValue))
                    {
                        validationMessage = "Invalid date format! use: [4/10/2008]";
                        CanSave = false;
                    }
                    //to avoid SqlDateTime overflow exception
                    if (dateValue == default(DateTime) || dateValue.Year < 1900)
                    {
                        validationMessage = "Invalid date of birth!";
                        CanSave = false;
                    }
                }
                else if (name == "WorkExperience")
                {
                    if (!int.TryParse(WorkExperience, out workExperienceValue))
                    {
                        validationMessage = "Invalid format!";
                        CanSave = false;
                    }
                    if(workExperienceValue < 0)
                    {
                        validationMessage = "Invalid format!";
                        CanSave = false;
                    }

                }

                if (string.IsNullOrEmpty(validationMessage))
                    CanSave = true;

                return validationMessage;
            }
        }
        #endregion

        #region Commands
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private bool CanSaveExecute()
        {
            if (
                string.IsNullOrWhiteSpace(GivenName)
                || string.IsNullOrWhiteSpace(Surname)
                || string.IsNullOrWhiteSpace(Email)
                || string.IsNullOrWhiteSpace(DateOfBirth)
                || string.IsNullOrWhiteSpace(Username)
                || string.IsNullOrWhiteSpace(Password)
                || string.IsNullOrWhiteSpace(FloorNumber)
                || string.IsNullOrWhiteSpace(WorkExperience)
                || CanSave == false)
                return false;
            return true;
        }
        private void SaveExecute()
        {
            try
            {
                var db = new DataAccess();
                userData.GivenName = GivenName;
                userData.Surname = Surname;
                userData.Email = Email;
                userData.Username = Username;
                userData.Password = Password;
                userData.DateOfBirth = dateValue;



                //adding new employee to database 
                db.AddNewUserData(userData);
                manager.UserDataID = db.GetUserDataId(username);
                if (manager.UserDataID == -1)
                {
                    MessageBox.Show("Something went wrong.");
                    addNewManagerView.Close();
                    return;
                }
                manager.ProfessionalQualificationsLevel = ProfessionalQualificationsLevel;
                manager.FloorNumber = FloorNumber;
                manager.WorkExperience = workExperienceValue;
                db.AddNewManager(manager);
                IsAddedNewManager = true;

                addNewManagerView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //Escaping action
        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return exit;
            }
        }


        private bool CanExitExecute()
        {
            return true;
        }

        private void ExitExecute()
        {
            IsAddedNewManager = false;
            addNewManagerView.Close();
        }
        #endregion
    }
}
