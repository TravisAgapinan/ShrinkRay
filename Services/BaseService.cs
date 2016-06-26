using Agap.Data.Providers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace URLShortener.Services
{

    public abstract class BaseService // connect to the SQL 
    {
        protected static IDao DataProvider
        {

            get { return Agap.Data.DataProvider.Instance; }
        }

        protected static SqlConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);


        }
    }

}