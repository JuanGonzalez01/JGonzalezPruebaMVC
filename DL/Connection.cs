using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Connection
    {
        public static string GetConnectionString()
        {
            //return "Data Source=.;Initial Catalog=JGonzalezPruebaMVC;User ID=sa;Password=pass@word1";
            return ConfigurationManager.ConnectionStrings["JGonzalezPruebaMVC"].ConnectionString;
        }
    }
}
