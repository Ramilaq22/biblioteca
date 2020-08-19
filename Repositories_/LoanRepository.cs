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
    public class LoanRepository : ILoanRepository
    {
        private List<Loan> loanList = new List<Loan>();
        Connection connection = new Connection();
        private IBookRepository bookRepository = new BookRepository();
        private IPartnerRepository partnerRepository = new PartnerRepository();

        public LoanRepository() { }

        public Loan AddLoan(Loan loan)
        {
            try
            {
                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Loans_Add");
                command.CommandType = CommandType.StoredProcedure;

                var BookID = command.CreateParameter(); BookID.ParameterName = "@BookID"; BookID.DbType = DbType.Int32; BookID.Value = loan.Book.BookID; command.Parameters.Add(BookID);
                var PartnerID = command.CreateParameter(); PartnerID.ParameterName = "@PartnerID"; PartnerID.DbType = DbType.Int32; PartnerID.Value = loan.Partner.PartnerID; command.Parameters.Add(PartnerID);
                var LoanDate = command.CreateParameter(); LoanDate.ParameterName = "@LoanDate"; LoanDate.DbType = DbType.DateTime; LoanDate.Value = loan.LoanDate; command.Parameters.Add(LoanDate);
                var EstimatedDate = command.CreateParameter(); EstimatedDate.ParameterName = "@EstimatedDate"; EstimatedDate.DbType = DbType.DateTime; EstimatedDate.Value = loan.EstimatedDate; command.Parameters.Add(EstimatedDate);
                var DevolutionDate = command.CreateParameter(); DevolutionDate.ParameterName = "@DevolutionDate"; DevolutionDate.DbType = DbType.DateTime; DevolutionDate.Value = loan.DevolutionDate; command.Parameters.Add(DevolutionDate);

                var affectedRows = command.ExecuteNonQuery();
                if (affectedRows >= 1) return loan;

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
        
        public List<Loan> FilteredList()
        {
            try
            {
                List<Loan> returnList = new List<Loan>();

                foreach (Loan loan in GetAll())
                {
                    if (loan.DevolutionDate == default(DateTime))
                    {
                        returnList.Add(loan);
                    }
                }

                return returnList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Loan EditLoan(Loan loan)
        {
            try
            {
                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Loans_Edit");
                command.CommandType = CommandType.StoredProcedure;

                var LoanID = command.CreateParameter(); LoanID.ParameterName = "@LoanID"; LoanID.DbType = DbType.Int32; LoanID.Value = loan.LoanID; command.Parameters.Add(LoanID);
                var DevolutionDate = command.CreateParameter(); DevolutionDate.ParameterName = "@DevolutionDate"; DevolutionDate.DbType = DbType.DateTime; DevolutionDate.Value = loan.DevolutionDate; command.Parameters.Add(DevolutionDate);

                var affectedRows = command.ExecuteNonQuery();
                if (affectedRows >= 1) return loan;

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
        public List<Loan> GetAll()
        {
            try
            {
                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Books_GetAll");
                command.CommandType = CommandType.StoredProcedure;

                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    int loanID = dr.GetInt32(0);
                    Book book = bookRepository.GetByID(dr.GetInt32(1));
                    Partner partner = partnerRepository.GetByID(dr.GetInt32(2));
                    DateTime loanDate = dr.GetDateTime(3);
                    DateTime estimatedDate = dr.GetDateTime(4);
                    DateTime devolutionDate = dr.GetDateTime(5);

                    Loan loan = new Loan(loanID, book, partner, loanDate, estimatedDate, devolutionDate);
                    loanList.Add(loan);
                }

                dr.Close();
                return loanList;
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
