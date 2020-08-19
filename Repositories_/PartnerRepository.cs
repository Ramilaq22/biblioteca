using EJ01.Repositories;
using Repositories_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    public class PartnerRepository : IPartnerRepository
    {
        private List<Partner> partnerList = new List<Partner>();
        Connection connection = new Connection();
        public PartnerRepository() { }

        public Partner AddPartner(Partner partner)
        {
            try
            {
                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Partners_Add");
                command.CommandType = CommandType.StoredProcedure;

                var LastName = command.CreateParameter(); LastName.ParameterName = "@LastName"; LastName.DbType = DbType.String; LastName.Size = 255; LastName.Value = partner.LastName; command.Parameters.Add(LastName);
                var FirstName = command.CreateParameter(); FirstName.ParameterName = "@FirstName"; FirstName.DbType = DbType.String; FirstName.Size = 255; FirstName.Value = partner.FirstName; command.Parameters.Add(FirstName);
                var DNI = command.CreateParameter(); DNI.ParameterName = "@DNI"; DNI.DbType = DbType.String; DNI.Size = 8; DNI.Value = partner.DNI; command.Parameters.Add(DNI);
                var Address = command.CreateParameter(); Address.ParameterName = "@Address"; Address.DbType = DbType.String; Address.Size = 255; Address.Value = partner.Address; command.Parameters.Add(Address);
                var Phone = command.CreateParameter(); Phone.ParameterName = "@Phone"; Phone.DbType = DbType.String; Phone.Size = 255; Phone.Value = partner.Phone; command.Parameters.Add(Phone);

                var affectedRows = command.ExecuteNonQuery();
                if (affectedRows >= 1) return partner;

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
        public Partner GetByID(int ID)
        {
            try
            {
                Partner partner = null;

                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Partners_GetByID");
                command.CommandType = CommandType.StoredProcedure;

                var IDParam = command.CreateParameter(); IDParam.ParameterName = "@IDParam"; IDParam.DbType = DbType.Int32; IDParam.Value = ID; command.Parameters.Add(IDParam);
                var dr = command.ExecuteReader();

                while (dr.Read())
                {
                    int partnerID = dr.GetInt32(0);
                    string lastName = dr.GetString(1);
                    string firstName = dr.GetString(2);
                    string DNI = dr.GetString(3);
                    string address = dr.GetString(4);
                    string phone = dr.GetString(5);

                    partner = new Partner(partnerID, lastName, firstName, DNI, address, phone);
                    partnerList.Add(partner);
                }

                dr.Close();
                return partner;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Disconnect();
            }
        }
        public Partner CheckPartner(string DNIValue)
        {
            try
            {
                Partner partner = null;

                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Partners_Check");
                command.CommandType = CommandType.StoredProcedure;

                var DNIParam = command.CreateParameter(); DNIParam.ParameterName = "@DNIParam"; DNIParam.DbType = DbType.String; DNIParam.Size = 8; DNIParam.Value = DNIValue; command.Parameters.Add(DNIParam);
                var dr = command.ExecuteReader();

                while (dr.Read())
                {
                    int partnerID = dr.GetInt32(0);
                    string lastName = dr.GetString(1);
                    string firstName = dr.GetString(2);
                    string DNI = dr.GetString(3);
                    string address = dr.GetString(4);
                    string phone = dr.GetString(5);

                    partner = new Partner(partnerID, lastName, firstName, DNI, address, phone);
                    partnerList.Add(partner);
                }

                dr.Close();
                return partner;
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
        public List<Partner> GetAll()
        {
            try
            {
                Partner partner = null;

                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Partners_GetAll");
                command.CommandType = CommandType.StoredProcedure;

                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    int partnerID = dr.GetInt32(0);
                    string lastName = dr.GetString(1);
                    string firstName = dr.GetString(2);
                    string DNI = dr.GetString(3);
                    string address = dr.GetString(4);
                    string phone = dr.GetString(5);

                    partner = new Partner(partnerID, lastName, firstName, DNI, address, phone);
                    partnerList.Add(partner);
                }

                dr.Close();
                return partnerList;
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
