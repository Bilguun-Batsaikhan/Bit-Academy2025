using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetSample
{
    public class DbHelpers
    {
        public static SqlParameter CreateParameter(string paramName, object? value, DbType dbType)
        {
            return new SqlParameter(paramName, value)
            {
                DbType = dbType
            };
        }
    }
}
