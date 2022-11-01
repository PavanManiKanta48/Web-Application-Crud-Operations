using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Webform_Crud_Operations
{
    public class ReadCS
    {
        public static string ASPDB
        {
            get { return ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString; }
        }
    }
}