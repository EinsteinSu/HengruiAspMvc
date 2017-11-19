using System.Collections;
using System.Linq;
using System.Web;

namespace Hengrui.Models
{
    // DXCOMMENT: Configure a data model (In this sample, we do this in file NorthwindDataProvider.cs. You would better create your custom file for a data model.)
    public static class NorthwindDataProvider
    {
        private const string NorthwindContextKey = "DXNorthwindContext";

        public static NorthwindContext DB
        {
            get
            {
                if (HttpContext.Current.Items[NorthwindContextKey] == null)
                    HttpContext.Current.Items[NorthwindContextKey] = new NorthwindContext();
                return (NorthwindContext) HttpContext.Current.Items[NorthwindContextKey];
            }
        }

        public static IEnumerable GetCustomers()
        {
            return DB.Customers.ToList();
        }
    }
}