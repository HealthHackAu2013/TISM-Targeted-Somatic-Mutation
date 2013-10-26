using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace HealthHack.TiSM.DAL
{
    public class Base
    {
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        }

        protected SqlCommand GetCommand()
        {
            SqlCommand aCommand = new SqlCommand();
            aCommand.Connection = GetConnection();
            aCommand.CommandTimeout = 300;
            aCommand.CommandType = CommandType.StoredProcedure ;
            aCommand.Connection.Open();
            return aCommand;
        }       
     
        protected SqlParameter GetParameter(string name, DbType type, object value)
        {
            SqlParameter aPara = new SqlParameter();
            aPara.ParameterName = name;
            aPara.DbType = type;
            aPara.Value = value;
            return aPara;
        }
    }
}
