using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_
{
    public class Connection
    {
        SqlConnection connection = null;

        public Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            connection = new SqlConnection(connectionString);
        }
        public void Connect()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
            }
            catch(Exception ex)
            {
                throw(ex);
            }
        }
        public void Disconnect()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public IDbCommand CreateCommand()
        {            
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                return command;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
