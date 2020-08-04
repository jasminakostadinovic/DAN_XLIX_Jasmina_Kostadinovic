using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validations;

namespace Hotel_Management_App.Model
{
    class DataAccess
    {
		public bool IsCorrectUser(string userName, string password)
		{
			using (var conn = new HotelManagementEntities())
			{
				var user = conn.tblUserDatas.FirstOrDefault(x => x.Username == userName && x.Password == password);
				if (user != null)
					return true;
				return false;
			}

		}

		internal string GetTypeOfUser(string userName)
		{
			using (var conn = new HotelManagementEntities())
			{
				var user = conn.tblUserDatas.FirstOrDefault(x => x.Username == userName);
				if (user != null)
				{
					var manager = conn.tblManagers.FirstOrDefault(x => x.UserDataID == user.UserDataID);
					if(manager != null)
					{
						return "manager";
					}
					else
					{
						return "employee";
					}
				}
				return null;
			}
		}

		internal tblManager LoadManagerByUsername(string userName)
		{

			using (var conn = new HotelManagementEntities())
			{
				var user = conn.tblUserDatas.FirstOrDefault(x => x.Username == userName);
				if (user != null)
				{
					return conn.tblManagers.FirstOrDefault(x => x.UserDataID == user.UserDataID);
				}
				return null;
			}
		}

		internal tblEmployee LoadEmployeeByUsername(string userName)
		{

			using (var conn = new HotelManagementEntities())
			{
				var user = conn.tblUserDatas.FirstOrDefault(x => x.Username == userName);
				if (user != null)
				{
					return conn.tblEmployees.FirstOrDefault(x => x.UserDataID == user.UserDataID);
				}
				return null;
			}
		}
	}
}
