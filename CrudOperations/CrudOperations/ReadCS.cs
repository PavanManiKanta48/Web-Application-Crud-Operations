using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudOperations
{
    public class ReadCS
    {
        public static string ASPDB
        {
            get { return ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString; }
        }
    }
}