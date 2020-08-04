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


		internal bool IsUniqueUsername(string username)
		{
			using (var conn = new HotelManagementEntities())
			{
				return !conn.tblUserDatas.Any(x => x.Username == username);
			}
		}

		internal void AddNewUserData(tblUserData userData)
		{
			using (var conn = new HotelManagementEntities())
			{
				conn.tblUserDatas.Add(userData);
				conn.SaveChanges();
			}
		}

		internal int GetUserDataId(string username)
		{
			using (var conn = new HotelManagementEntities())
			{
				var user = conn.tblUserDatas.FirstOrDefault(x => x.Username == username);
				if (user != null)
					return user.UserDataID;
				return -1;
			}
		}

		internal void AddNewEmployee(tblEmployee employee)
		{
			using (var conn = new HotelManagementEntities())
			{
				conn.tblEmployees.Add(employee);
				conn.SaveChanges();
			}
		}

		internal void AddNewManager(tblManager manager)
		{
			using (var conn = new HotelManagementEntities())
			{
				conn.tblManagers.Add(manager);
				conn.SaveChanges();
			}
		}

		internal bool IsManagerOnTheFloor(string floorNumber)
		{
			using (var conn = new HotelManagementEntities())
			{
				return conn.tblManagers.Any(x => x.FloorNumber == floorNumber);
			}
		}
	}
}
