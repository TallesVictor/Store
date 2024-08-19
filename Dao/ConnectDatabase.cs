using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dao
{
    static class ConnectDatabase
    {
        private const string server = "localhost";
        private const string database = "store_c";
        private const string user = "root";
        private const string password = "";

        static public string connectDB = $"server={server};user={user};database={database};password={password}";




    }
}


