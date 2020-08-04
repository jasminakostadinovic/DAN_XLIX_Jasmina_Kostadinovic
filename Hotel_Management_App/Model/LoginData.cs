using System.IO;
using Validations;

namespace Hotel_Management_App.Model
{
    class LoginData
    {
        private static readonly string ownerAccessPath = @"..\OwnerAccess";

        static LoginData()
        {
            if (!File.Exists(ownerAccessPath))
            {
                File.WriteAllLines(ownerAccessPath, new string[]
                {
                    "Vlasnik",
                    "Vlasnik123"
                });
            }
            HotelOwnerUserName = File.ReadAllLines(ownerAccessPath)[0];
            HotelOwnerPasswordHashed = SecurePasswordHasher.Hash(File.ReadAllLines(ownerAccessPath)[1]);
        }

        public static string HotelOwnerUserName { get; private set; }
        public static string HotelOwnerPasswordHashed { get; private set; }
    }
}
