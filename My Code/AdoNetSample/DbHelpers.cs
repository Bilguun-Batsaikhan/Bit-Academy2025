using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetSample
{
    internal static class DbHelpers
    {
        public static SqlParameter CreateParameter(string paramName, object value, DbType dbType)
        {
            return new SqlParameter(paramName, value)
            {
                DbType = dbType,
            };
        }
    }
}
