using System;
using System.Collections.Generic;
using Hengrui.Business;
using Hengrui.DataAccess.Models.Organization;
using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.Commons
{
    public static class DataProvider
    {
        public static IEnumerable<Department> GetDepartments()
        {
            return new DepartmentMgr().GetItems();
        }

        public static Dictionary<int, string> GetReviewRoles()
        {
            var dic = new Dictionary<int, string>();
            foreach (var value in Enum.GetValues(typeof(ReviewRoleType)))
                dic.Add((int) value, value.ToString());
            return dic;
        }

        public static IEnumerable<City> GetCities()
        {
            return new CityMgr().GetItems();
        }

        public static IEnumerable<EnterpriseUser> GetEnterpriseUsers()
        {
            return new EnterpriseUserMgr().GetItems();
        }
    }
}