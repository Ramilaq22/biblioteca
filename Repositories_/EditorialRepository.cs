using Repositories_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Repositories
{
    public class EditorialRepository : IEditorialRepository
    {
        private List<Editorial> editorialList = new List<Editorial>();
        Connection connection = new Connection();

        public Editorial AddEditorial(Editorial editorial)
        {
            try
            {
                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Editorials_Add");
                command.CommandType = CommandType.StoredProcedure;

                var Name = command.CreateParameter(); Name.ParameterName = "@Name"; Name.DbType = DbType.String; Name.Size = 255; Name.Value = editorial.Name; command.Parameters.Add(Name);

                var affectedRows = command.ExecuteNonQuery();
                if (affectedRows >= 1) return editorial;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Disconnect();
            }
        }
        public Editorial GetByID(int ID)
        {
            try
            {
                Editorial editorial = null;

                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Editorials_GetByID");
                command.CommandType = CommandType.StoredProcedure;

                var EditorialIDParam = command.CreateParameter(); EditorialIDParam.ParameterName = "@EditorialIDParam"; EditorialIDParam.DbType = DbType.Int32; EditorialIDParam.Value = ID; command.Parameters.Add(EditorialIDParam);
                var dr = command.ExecuteReader();

                while (dr.Read())
                {
                    int editorialID = dr.GetInt32(0);
                    string name = dr.GetString(1);

                    editorial = new Editorial(editorialID, name);
                    editorialList.Add(editorial);
                }

                dr.Close();
                return editorial;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Disconnect();
            }
        }
        public List<Editorial> GetAll()
        {
            try
            {
                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Editorials_GetAll");
                command.CommandType = CommandType.StoredProcedure;

                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    int editorialID = dr.GetInt32(0);
                    string name = dr.GetString(1);

                    Editorial editorial = new Editorial(editorialID, name);
                    editorialList.Add(editorial);
                }

                dr.Close();
                return editorialList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Disconnect();
            }
        }
    }
}
