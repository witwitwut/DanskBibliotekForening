using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Repository;

namespace IO
{
    public class ClassDbfDB : ClassDB
    {
        public ClassDbfDB()
        {
            SetCon(@"Server=10.205.44.39,49172;Database=DBF;User Id=AspIT;Password=Server2012;");
        }

        public ObservableCollection<ClassBog> GetAllBooksLike(string search)
        {
            ObservableCollection<ClassBog> obcBooks = new ObservableCollection<ClassBog>();
            DataTable dt = DbReturnDataTable("SELECT Books.id, Titel.titel, ISBNnr.isbnNr, Type.TypeNavn, Forfatter.forfatter, Forlag.forlagsNavn, Genre.genreType, Books.pris" +
                                             "FROM Books INNER JOIN Titel ON Books.titelID = Titel.id" +
                                             "INNER JOIN Type ON Books.typeID = Type.id " +
                                             "INNER JOIN Forfatter ON Books.forfatterID = Forfatter.id " +
                                             "INNER JOIN Forlag ON Books.forlagID = Forlag.id " +
                                             "INNER JOIN Genre ON Books.genreID = Genre.id " +
                                             "INNER JOIN ISBNnr ON Books.isbnID = ISBNnr.id" +
                                             "WHERE Titel.id LIKE '%" + search + "%'");
            foreach (DataRow row in dt.Rows)
            {
                obcBooks.Add(new ClassBog(Convert.ToInt32(row["id"]),
                                          row["titel"].ToString(),
                                          row["isbnNr"].ToString(),
                                          row["TypeNavn"].ToString(),
                                          row["forfatter"].ToString(),
                                          row["forlagsNavn"].ToString(),
                                          row["genreType"].ToString(),
                                          Convert.ToDecimal(row["pris"])));
            }

            return obcBooks;
        }

        public ObservableCollection<ClassBog> GetAllBooksLendToUser(string id)
        {
            ObservableCollection<ClassBog> obcLendBooks = new ObservableCollection<ClassBog>();
            DataTable dt = DbReturnDataTable("SELECT Udlaan.id, Books.id AS Expr1, Titel.titel, Udlaan.udlaansDato" +
                                             "FROM Books INNER JOIN Udlaan ON Books.id = Udlaan.bookID " +
                                             "INNER JOIN Person ON Udlaan.personID = Person.id " +
                                             "INNER JOIN Titel ON Books.titelID = Titel.id" +
                                             "WHERE Person.id LIKE '" + id + "%'");
            foreach (DataRow row in dt.Rows)
            {
                obcLendBooks.Add(new ClassBog(Convert.ToInt32(row["id"]),
                                              row["titel"].ToString(),
                                              Convert.ToDateTime(row["udlaansDato"])));
            }

            return obcLendBooks;
        }

        public void UpdateTheLendingStatus(string id, bool status)
        {
            try
            {
                string sqlString = "UPDATE UdlaansStatus SET status = " + status + "WHERE id = " + id;
                FunctionExecuteNonQuery(sqlString);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Fejl i DB kommunikationen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ClassPerson GetUser(string userID, string password)
        {

        }
    }
}
