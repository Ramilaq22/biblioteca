using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EJ01.Controllers;

namespace EJ01
{
    public partial class Form1 : Form
    {
        public int partnerID = 0, bookID = 0, editorialID = 0, loanID = 0, ISBN = 0, year = 0, editionYear = 0, authorID = 0, edition = 0, i = 0;
        public string DNI = "", lastName = "", firstName = "", address = "", phone = "", error = "", title = "", deterioration = "", editorialName = "", authorName = "";
        public DateTime loanDate, estimatedDate, devolutionDate;
        public Book book;
        public Loan loan;
        public Partner partner;
        public Author author;
        public Editorial editorial;
        public PartnerController partnerController = new PartnerController();
        public BookController bookController = new BookController();
        public LoanController loanController = new LoanController();
        public AuthorController authorController = new AuthorController();
        public EditorialController editorialController = new EditorialController();

        public Form1()
        {
            updateAll();
        }
        private void updateAll()
        {
            try
            {
                this.Controls.Clear();
                InitializeComponent();

                dgvPartner.AutoGenerateColumns = false;
                dgvPartner.DataSource = null;

                foreach (Partner auxPartner in partnerController.GetAll())
                {
                    dgvPartner.Rows.Add(auxPartner.LastName, auxPartner.FirstName, auxPartner.DNI, auxPartner.Address, auxPartner.Phone);
                }

                dgvBook.AutoGenerateColumns = false;
                dgvBook.DataSource = null;

                foreach (Book auxBook in bookController.GetAll())
                {
                    dgvBook.Rows.Add(auxBook.ISBN, auxBook.Title, auxBook.Author.Name, auxBook.Editorial.Name, auxBook.Year, auxBook.Edition, auxBook.EditionYear, auxBook.Deterioration);
                }

                dgvLoan.AutoGenerateColumns = false;
                dgvLoan.DataSource = null;

                foreach (Loan auxLoan in loanController.GetAll())
                {
                    dgvLoan.Rows.Add(auxLoan.LoanID, (auxLoan.Partner.LastName + " " + auxLoan.Partner.FirstName), auxLoan.Book.Title, auxLoan.LoanDate, auxLoan.EstimatedDate, auxLoan.DevolutionDate);
                }

                dgvAuthor.AutoGenerateColumns = false;
                dgvAuthor.DataSource = null;

                foreach (Author auxAuthor in authorController.GetAll())
                {
                    dgvAuthor.Rows.Add(auxAuthor.AuthorID, auxAuthor.Name);
                }

                dgvEditorial.AutoGenerateColumns = false;
                dgvEditorial.DataSource = null;

                foreach (Editorial auxEditorial in editorialController.GetAll())
                {
                    dgvEditorial.Rows.Add(auxEditorial.EditorialID, auxEditorial.Name);
                }

                cmbBookAuthor.DataSource = null;
                cmbBookAuthor.DataSource = authorController.GetAll();

                cmbBookEditorial.DataSource = null;
                cmbBookEditorial.DataSource = editorialController.GetAll();
                cmbBookEditorial.ValueMember = "editorialID";
                cmbBookEditorial.DisplayMember = "name";

                cmbLoan.DataSource = loanController.FilteredList();
                cmbLoan.ValueMember = "loanID";
                cmbLoan.DisplayMember = "loanFull";

                cmbLoanPartner.DataSource = partnerController.GetAll();
                cmbLoanPartner.ValueMember = "partnerID";
                cmbLoanPartner.DisplayMember = "DNI";

                cmbLoanBook.DataSource = bookController.GetNoLoaned(loanController.GetAll());
                cmbLoanBook.ValueMember = "bookID";
                cmbLoanBook.DisplayMember = "title";

                foreach (DataGridViewRow row in dgvLoan.Rows)
                {
                    if (default(DateTime) == (DateTime)row.Cells[5].Value)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(error);
            }
        }
        private void btnClientAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (partnerController.CheckPartner(txbPartnerDNI.Text) == null)
                {
                    Partner partner = new Partner(partnerID, lastName, firstName, DNI, address, phone);
                    partner.LastName = txbPartnerLastName.Text;
                    partner.FirstName = txbPartnerFirstName.Text;
                    partner.DNI = txbPartnerDNI.Text;
                    partner.Address = txbClientAddress.Text;
                    partner.Phone = txbClientPhone.Text;

                    if (partnerController.AddPartner(partner) != null) MessageBox.Show("Se agregó un cliente con éxito.");
                }
                else
                {
                    MessageBox.Show("Ya existe una persona con ese DNI.");
                }

                updateAll();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(error);
            }
        }
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bookController.CheckBook((int)nudBookISBN.Value)) == null)
                {
                    Editorial editorial = new Editorial(editorialID, editorialName);
                    Author author = new Author(authorID, authorName);
                    Book book = new Book(bookID, ISBN, title, editorial, edition, year, editionYear, author, deterioration);
                    book.ISBN = (int)nudBookISBN.Value;
                    book.Title = txbBookName.Text;
                    book.Year = (int)nudBookYear.Value;
                    book.EditionYear = (int)nudBookEditionYear.Value;
                    book.Deterioration = txbBookDeterioration.Text;
                    book.Author = (Author)cmbBookAuthor.SelectedItem;
                    book.Editorial = (Editorial)cmbBookEditorial.SelectedItem;
                    book.Edition = (int)nudBookEdition.Value;

                    if (bookController.AddBook(book) != null) MessageBox.Show("Se agregó un libro con éxito.");
                } 
                else
                {
                    MessageBox.Show("Ya existe un libro con ese ISBN.");
                }                

                updateAll();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(error);
            }
        }
        private void btnLoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtmEstimated.Value > dtmLoan.Value)
                {
                    Editorial editorial = new Editorial(editorialID, editorialName);
                    Author author = new Author(authorID, authorName);
                    Book book = new Book(bookID, ISBN, title, editorial, edition, year, editionYear, author, deterioration);
                    Partner partner = new Partner(partnerID, lastName, firstName, DNI, address, phone);
                    Loan loan = new Loan(loanID, book, partner, loanDate, estimatedDate, devolutionDate);
                    loan.Book = (Book)cmbLoanBook.SelectedItem;
                    loan.Partner = (Partner)cmbLoanPartner.SelectedItem;
                    loan.LoanDate = dtmLoan.Value;
                    loan.EstimatedDate = dtmEstimated.Value;
                    loan.DevolutionDate = default(DateTime);

                    if (loanController.AddLoan(loan) != null) MessageBox.Show("Se agregó un préstamo con éxito.");
                }
                else
                {
                    MessageBox.Show("La fecha estimada de devolución es anterior a la fecha de inicio del préstamo.");
                }                

                updateAll();
            }
            catch(Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(error);
            }
        }
        private void btnEndLoan_Click(object sender, EventArgs e)
        {
            try
            {
                Editorial editorial = new Editorial(editorialID, editorialName);
                Author author = new Author(authorID, authorName);
                Book book = new Book(bookID, ISBN, title, editorial, edition, year, editionYear, author, deterioration);
                Partner partner = new Partner(partnerID, lastName, firstName, DNI, address, phone);
                Loan loan = new Loan(loanID, book, partner, loanDate, estimatedDate, devolutionDate);
                loan.LoanID = ((Loan)cmbLoan.SelectedItem).LoanID;
                loan.Book = ((Loan)cmbLoan.SelectedItem).Book;
                loan.Partner = ((Loan)cmbLoan.SelectedItem).Partner;
                loan.LoanDate = ((Loan)cmbLoan.SelectedItem).LoanDate;
                loan.EstimatedDate = ((Loan)cmbLoan.SelectedItem).EstimatedDate;
                loan.DevolutionDate = dtmDevolution.Value;

                if (loanController.EditLoan(loan) != null) MessageBox.Show("Finalizó un préstamo con éxito.");

                updateAll();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(error);
            }
        }
        private void btnAuthorAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Author author = new Author(authorID, authorName);
                author.Name = txbAutorNombre.Text;

                if (authorController.AddAuthor(author) != null) MessageBox.Show("Se agregó un autor con éxito.");

                updateAll();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(error);
            }
        }
        private void btnAddEditorial_Click(object sender, EventArgs e)
        {
            try
            {
                Editorial editorial = new Editorial(editorialID ,editorialName);
                editorial.Name = txbAddEditorial.Text;

                if (editorialController.AddEditorial(editorial) != null) MessageBox.Show("Se agregó una editorial con éxito.");

                updateAll();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(error);
            }
        }
    }
}
