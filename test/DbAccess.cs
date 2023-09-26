using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public abstract class DbAccess
    {
        protected readonly string ConnectionString;
        public DbAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
